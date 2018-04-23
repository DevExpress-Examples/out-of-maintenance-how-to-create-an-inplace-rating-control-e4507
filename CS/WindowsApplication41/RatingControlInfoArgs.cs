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

public class RatingControlObjectInfoArgs : ObjectInfoArgs {
    public RatingControlObjectInfoArgs() { }
    public Color StarsRectangleBackgroundColor;
    public Color TitlesRectangleBackgroundColor;
    public Color NormalStarColor;
    public Color SelectedStarColor;
    public Color HotTrackedStarColor;
    public string Title;
    public Color BackgroundColor;
    public Color BarColor;
    public float Percent = 0;
    public int Value;
    public int HotTrackValue = 0;
    
}