using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors.Registrator;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using System.Diagnostics;
using WindowsApplication41;
using System.Collections.Generic;

[ToolboxBitmap(typeof(RatingControl), "")]
public class RatingControlViewInfo : BaseEditViewInfo {
    int position;
    float percents;
    int hotTrackValue;
    List<Image> _images;

    RatingControlObjectInfoArgs progressInfo;

    public RatingControlViewInfo(RepositoryItem item)
        : base(item) {
            _images = new List<Image>();
            _images.Add(new Bitmap("..\\..\\Normal.png"));
            _images.Add(new Bitmap("..\\..\\Highlighted.png"));
            _images.Add(new Bitmap("..\\..\\Selected.png"));
    }

    protected override void Assign(BaseControlViewInfo info) {
        base.Assign(info);
        RatingControlViewInfo be = info as RatingControlViewInfo;
        if(be == null) return;
        this.percents = be.percents;
        this._images = be._images;
        this.position = be.position;
        this.hotTrackValue = be.hotTrackValue;
    }

    protected override void OnEditValueChanged() {
        this.position = Item.ConvertValue(EditValue);
        this.percents = 1;
        if(Item.Maximum != Item.Minimum) {
            this.percents = Math.Abs((float)(Position - Item.Minimum) / (float)(Item.Maximum - Item.Minimum));
        }
    }
    public virtual List<Image> Images { get { return _images; } }
    public virtual int Position { get { return position; } }
    public virtual float Percents { get { return percents; } }
    protected override void ReCalcViewInfoCore(Graphics g, MouseButtons buttons, Point mousePosition, Rectangle bounds) {
        base.ReCalcViewInfoCore(g, buttons, mousePosition, bounds);
        UpdateProgressInfo(ProgressInfo);
    }
    public override void Reset() {
        base.Reset();
        this.progressInfo = CreateInfoArgs();
        this.position = 0;
        this.percents = 0;
        this.hotTrackValue = 0;
    }
    public virtual RatingControlObjectInfoArgs ProgressInfo { get { return progressInfo; } }
    public new RepositoryItemRatingControl Item { get { return base.Item as RepositoryItemRatingControl; } }
    protected internal virtual void UpdateProgressInfo(RatingControlObjectInfoArgs info) {
        info.Bounds = ContentRect;
        info.BarColor = Item.BarColor;
        info.NormalStarColor = Item.NormalStarColor;
        info.StarsRectangleBackgroundColor = Item.StarsRectangleBackgroundColor;
        info.TitlesRectangleBackgroundColor = Item.TitlesRectangleBackgroundColor;
        info.NormalStarColor = Item.NormalStarColor;
        info.SelectedStarColor = Item.SelectedStarColor;
        info.HotTrackedStarColor = Item.HotTrackedStarColor;
        info.BackgroundColor = Item.Appearance.BackColor;
        info.Percent = this.Percents;
        info.Value = this.Position;
        info.HotTrackValue = hotTrackValue;
    }
    protected override ObjectInfoArgs GetBorderArgs(Rectangle bounds) {
        RatingControlObjectInfoArgs pi = new RatingControlObjectInfoArgs();
        pi.Bounds = bounds;
        return pi;
    }
    protected override BorderPainter GetBorderPainterCore() {
        BorderPainter bp = base.GetBorderPainterCore();
        if(bp is WindowsXPTextBorderPainter) bp = new WindowsXPProgressBarBorderPainter();
        return bp;
    }
    #region Updating Object State
    protected override bool UpdateObjectState() {
        return true;
    }
    public override bool IsRequiredUpdateOnMouseMove {
        get {
            return true;
        }
    }
    public override bool UpdateObjectState(MouseButtons mouseButtons, Point mousePosition) {
        if(ProgressInfo.Bounds.Contains(mousePosition)) {
            hotTrackValue = GetValueByPoint(mousePosition);
        } else hotTrackValue = 0;
        UpdateProgressInfo(progressInfo);
        return base.UpdateObjectState(mouseButtons, mousePosition);
    }
    #endregion

    private int GetValueByPoint(Point location) {
        double steps = (double)Item.Maximum / (double)ProgressInfo.Bounds.Width;
        double value = location.X * steps;
        return (int)Math.Ceiling(value);
    }

    public override void Offset(int x, int y) {
        base.Offset(x, y);
        ProgressInfo.OffsetContent(x, y);
    }
    protected override void CalcContentRect(Rectangle bounds) {
        base.CalcContentRect(bounds);
        UpdateProgressInfo(ProgressInfo);
    }
    protected override Size CalcClientSize(Graphics g) {
        Size s = base.CalcClientSize(g);
        s.Height = Images[0].Size.Height;
        return s;
    }
    protected virtual RatingControlObjectInfoArgs CreateInfoArgs() {
        return new RatingControlObjectInfoArgs();
    }
    public override object EditValue {
        get { return base.EditValue; }
        set {
            this.fEditValue = value;
            OnEditValueChanged();
        }
    }
    protected override int CalcMinHeightCore(Graphics g) {
        int height = base.CalcMinHeightCore(g);
        height += _images[0].Size.Height;
        return height;
    }
}
