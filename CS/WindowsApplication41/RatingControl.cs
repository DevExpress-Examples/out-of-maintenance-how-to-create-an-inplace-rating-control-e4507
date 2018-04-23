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

[ToolboxItem(true)]
public class RatingControl : BaseEdit {

    static RatingControl() {
        RepositoryItemRatingControl.RegisterMyRatingControl();
    }
    public RatingControl() {
        this.TabStop = false;
        this.fOldEditValue = this.fEditValue = 0;
    }
    [Browsable(false)]
    public override string EditorTypeName { get { return "RatingControl"; } }
    [Description("Gets an object containing properties, methods and events specific to rating controls."), Category(CategoryName.Properties), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public new RepositoryItemRatingControl Properties { get { return base.Properties as RepositoryItemRatingControl; } }
    [Browsable(false), DefaultValue(0)]
    public override object EditValue {
        get { return base.EditValue; }
        set { base.EditValue = ConvertCheckValue(value); }
    }
    [Category(CategoryName.Appearance), Description("Gets or sets position."), RefreshProperties(RefreshProperties.All), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(0),
    Bindable(ControlConstants.NonObjectBindable)]
    public virtual int Position {
        get { return Properties.ConvertValue(EditValue); }
        set { EditValue = Properties.CheckValue(value); }
    }
    public virtual string Title {
        get { return Properties.Title; }
        set { EditValue = value; }
    }
    protected virtual object ConvertCheckValue(object val) {
        if(val == null || val is DBNull) return val;
        int converted = Properties.ConvertValue(val);
        try {
            if(converted == Convert.ToInt32(val))
                return val;
        } catch { }
        return converted;
    }
    protected internal virtual void OnMinMaxChanged() {
        if(IsLoading) return;
        Position = Properties.CheckValue(Position);
    }
    protected internal virtual void UpdatePercent() {
        RatingControlViewInfo vi = ViewInfo as RatingControlViewInfo;
        if(vi == null) return;
        vi.UpdateProgressInfo(vi.ProgressInfo);
    }
    public event EventHandler PositionChanged {
        add { Properties.PositionChanged += value; }
        remove { Properties.PositionChanged -= value; }
    }
    protected override void OnMouseMove(MouseEventArgs e) {
        Properties.HotTrackIndex = GetValueByPoint(e.Location);
        UpdateValue();
        base.OnMouseMove(e);
    }
    private int GetValueByPoint(Point location) {
        double steps = (double)Properties.Maximum / (double)Width;
        double value = location.X * steps;
        return (int)Math.Ceiling(value);
    }
    protected override void OnMouseClick(MouseEventArgs e) {
        Position = GetValueByPoint(e.Location);
        UpdateValue();
        base.OnMouseClick(e);
    }
    protected override void OnMouseLeave(EventArgs e) {
        //TODO:
        Properties.HotTrackIndex = 0;
        base.OnMouseLeave(e);
    }
    protected internal virtual void UpdateValue() {
        RatingControlViewInfo vi = ViewInfo as RatingControlViewInfo;
        if(vi == null) return;
        vi.UpdateProgressInfo(vi.ProgressInfo);
    }
}
