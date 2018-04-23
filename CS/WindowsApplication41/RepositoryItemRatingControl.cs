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


[UserRepositoryItem("RegisterMyRatingControl")]
public class RepositoryItemRatingControl : RepositoryItem {
    string[] titles = { "Vote Here!", "Very Bad", "Bad", "Normal", "Good", "Very Good", "Perfect", "Excellent", "Great", "8-th title", "Awesome" };
    Color _barColor;
    Color _starsRectangleBackgroundColor;
    Color _titlesRectangleBackgroundColor;
    Color _normalStarColor;
    Color _selectedStarColor;
    Color _hotTrackedStarColor;
    string title;

    int _hotTrackIndex;
    [Browsable(false)]
    public int HotTrackIndex {
        get { return _hotTrackIndex; }
        set {
            if(_hotTrackIndex == value) return;
            _hotTrackIndex = value;
            this.OnPropertiesChanged();
        }
    }
    public string Title {
        get { return title; }
        set {
            if(title != value) {
                title = value;
                OnPropertiesChanged();
            }
        }
    }
    #region Colors
    public Color TitlesRectangleBackgroundColor {
        get { return _titlesRectangleBackgroundColor; }
        set {
            if(_titlesRectangleBackgroundColor == value) return;
            _titlesRectangleBackgroundColor = value;
            this.OnPropertiesChanged();
        }
    }
    public Color StarsRectangleBackgroundColor {
        get { return _starsRectangleBackgroundColor; }
        set {
            if(_starsRectangleBackgroundColor == value) return;
            _starsRectangleBackgroundColor = value;
            this.OnPropertiesChanged();
        }
    }
    public Color BarColor {
        get { return _barColor; }
        set {
            if(_barColor == value) return;
            _barColor = value;
            this.OnPropertiesChanged();
        }
    }
    public Color NormalStarColor {
        get { return _normalStarColor; }
        set {
            if(_normalStarColor == value) return;
            _normalStarColor = value;
            this.OnPropertiesChanged();
        }
    }
    public Color SelectedStarColor {
        get { return _selectedStarColor; }
        set {
            if(_selectedStarColor == value) return;
            _selectedStarColor = value;
            this.OnPropertiesChanged();
        }
    }
    public Color HotTrackedStarColor {
        get { return _hotTrackedStarColor; }
        set {
            if(_hotTrackedStarColor == value) return;
            _hotTrackedStarColor = value;
            this.OnPropertiesChanged();
        }
    }

    #endregion

    static RepositoryItemRatingControl() { RegisterMyRatingControl(); }

    public static void RegisterMyRatingControl() {
        EditorRegistrationInfo.Default.Editors.Add(
            new EditorClassInfo(
                "RatingControl",
                typeof(RatingControl),
                typeof(RepositoryItemRatingControl),
                typeof(RatingControlViewInfo),
                new RatingControlPainter(),
                true,
                null,
                typeof(DevExpress.Accessibility.PopupEditAccessible)));
    }

    public new RepositoryItemRatingControl Properties { get { return this; } }
    private static object positionChanged = new object();
    [Browsable(false)]
    public override string EditorTypeName { get { return "RatingControl"; } }
    int _minimum, _maximum;
    public RepositoryItemRatingControl() {

        this.fAutoHeight = false;
        this._barColor = Color.YellowGreen;
        _starsRectangleBackgroundColor = Color.Black;
        _titlesRectangleBackgroundColor = Color.Green;
        _normalStarColor = Color.Yellow;
        _selectedStarColor = Color.Red;
        title = titles[0];
        _hotTrackedStarColor = Color.Purple;
        this.HotTrackIndex = 0;
        this._minimum = 0;
        this._maximum = 5;
    }
    public override void Assign(RepositoryItem item) {
        RepositoryItemRatingControl source = item as RepositoryItemRatingControl;
        BeginUpdate();
        try {
            base.Assign(item);
            if(source == null) return;
            this._maximum = source.Maximum;
            this._minimum = source.Minimum;
            this.BarColor = source.BarColor;

            StarsRectangleBackgroundColor = source.StarsRectangleBackgroundColor;
            TitlesRectangleBackgroundColor = source.TitlesRectangleBackgroundColor;
            NormalStarColor = source.NormalStarColor;
            SelectedStarColor = source.SelectedStarColor;
            HotTrackedStarColor = source.HotTrackedStarColor;
            this.HotTrackIndex = source.HotTrackIndex;
            Title = source.Title;
        } finally {
            EndUpdate();
        }
        Events.AddHandler(positionChanged, source.Events[positionChanged]);
    }
    protected new RatingControl OwnerEdit { get { return base.OwnerEdit as RatingControl; } }
    [Category(CategoryName.Behavior), Description("Gets or sets the control's minimum value."), RefreshProperties(RefreshProperties.All), DefaultValue(0)]
    public int Minimum {
        get { return _minimum; }
        set {
            if(!IsLoading) {
                if(value > Maximum) value = Maximum;
            }
            if(Minimum == value) return;
            _minimum = value;
            OnMinMaxChanged();
            OnPropertiesChanged();
        }
    }
    [Category(CategoryName.Behavior), Description("Gets or sets the control's maximum value."), RefreshProperties(RefreshProperties.All), DefaultValue(100)]
    public int Maximum {
        get { return _maximum; }
        set {
            if(!IsLoading) {
                if(value < Minimum) value = Minimum;
            }
            if(Maximum == value) return;
            _maximum = value;
            OnMinMaxChanged();
            OnPropertiesChanged();
        }
    }
    protected internal virtual int ConvertValue(object val) {
        try {
            return CheckValue(Convert.ToInt32(val));
        } catch { }
        return Minimum;
    }
    protected internal virtual int CheckValue(int val) {
        if(IsLoading) return val;
        val = Math.Max(val, Minimum);
        val = Math.Min(val, Maximum);
        return val;
    }
    public override IVisualBrick GetBrick(PrintCellHelperInfo info) {
        IProgressBarBrick brick = (IProgressBarBrick)base.GetBrick(info);
        brick.Position = ConvertValue(info.EditValue);
        return brick;
    }
    protected virtual void OnMinMaxChanged() {
        if(OwnerEdit != null) OwnerEdit.OnMinMaxChanged();
    }
    [Description("Occurs after the value of the ProgressBarControl.Position property has been changed."), Category(CategoryName.Events)]
    public event EventHandler PositionChanged {
        add { this.Events.AddHandler(positionChanged, value); }
        remove { this.Events.RemoveHandler(positionChanged, value); }
    }
    protected override void RaiseEditValueChangedCore(EventArgs e) {
        base.RaiseEditValueChangedCore(e);
        RaisePositionChanged(e);
    }
    protected internal virtual void RaisePositionChanged(EventArgs e) {
        EventHandler handler = (EventHandler)this.Events[positionChanged];
        if(handler != null) handler(GetEventSender(), e);
    }
}
