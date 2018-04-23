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
using System.Collections.Generic;
using System.Diagnostics;

public class RatingControlPainter : BaseEditPainter {
    int maximum = 0;
    string[] titles = { "Vote Here!", "Very Bad", "Bad", "Normal", "Good", "Very Good", "Perfect", "Excellent", "Great", "Awesome" };
    List<Image> images = new List<Image>();
    protected override void DrawContent(ControlGraphicsInfoArgs info) {
        RatingControlViewInfo vi = info.ViewInfo as RatingControlViewInfo;
        info.Graphics.FillRectangle(new SolidBrush(info.ViewInfo.PaintAppearance.BackColor), info.Bounds);
        maximum = vi.Item.Maximum;
        images = vi.Images;
        DrawObject(info.Cache, vi.ProgressInfo);
    }

    public void DrawObject(GraphicsCache cache, ObjectInfoArgs e) {
        if(e == null) return;
        RatingControlObjectInfoArgs ee = e as RatingControlObjectInfoArgs;
        GraphicsCache prev = e.Cache;
        e.Cache = cache;
        try {
            e.Cache.Paint.FillRectangle(e.Graphics, new SolidBrush(ee.BackgroundColor), e.Bounds);
            DrawStarsRect(ee);
            DrawTitlesRect(ee);
            DrawStarsRects(ee);
            DrawBorder(ee);
        } finally {
            e.Cache = prev;
        }
    }

    protected virtual void DrawStarsRect(RatingControlObjectInfoArgs e) {
        Brush brush = e.Cache.GetSolidBrush(e.StarsRectangleBackgroundColor);
        e.Cache.Paint.FillGradientRectangle(e.Graphics, brush, CalcStarsRect(e));
    }

    protected virtual void DrawBorder(RatingControlObjectInfoArgs e) {
        Brush brush = e.Cache.GetSolidBrush(Color.Plum);
        e.Cache.Paint.DrawRectangle(e.Graphics, brush, CalcStarsRect(e));
    }

    protected virtual void DrawTitlesRect(RatingControlObjectInfoArgs e) {
        Brush brush = e.Cache.GetSolidBrush(e.TitlesRectangleBackgroundColor);
        e.Cache.Paint.FillGradientRectangle(e.Graphics, brush, CalcTitlesRect(e));
        Rectangle rect = CalcTitlesRect(e);
        rect.Offset(rect.Width / 2, 0);
        string title = e.HotTrackValue != 0 ? titles[e.HotTrackValue] : titles[e.Value];
        e.Cache.Paint.DrawString(e.Cache, title, new Font("Arial", 10), Brushes.Black, rect, new StringFormat());
    }

    protected virtual void DrawStarsRects(RatingControlObjectInfoArgs e) {
        Brush normal = e.Cache.GetSolidBrush(e.NormalStarColor);
        Brush selected = e.Cache.GetSolidBrush(e.SelectedStarColor);
        Brush hotTrack = e.Cache.GetSolidBrush(e.HotTrackedStarColor);
        foreach(var item in CalcStarsRects(e)) {
            //e.Cache.Paint.FillGradientRectangle(e.Graphics, normal, item);
            e.Cache.Paint.DrawImage(e.Graphics, images[0], item);
        }
        List<Rectangle> rect = CalcStarsRects(e);
        for(int i = 0; i < e.Value; i++) {
            //  e.Cache.Paint.FillGradientRectangle(e.Graphics, selected, rect[i]);
            e.Cache.Paint.DrawImage(e.Graphics, images[2], rect[i]);
        }
        for(int i = 0; i < e.HotTrackValue; i++) {
            e.Cache.Paint.DrawImage(e.Graphics, images[1], rect[i]);
            //  e.Cache.Paint.FillGradientRectangle(e.Graphics, hotTrack, rect[i]);
        }
    }

    protected virtual List<Rectangle> CalcStarsRects(RatingControlObjectInfoArgs e) {
        List<Rectangle> result = new List<Rectangle>();
        for(int i = 0; i < maximum; i++) {
            Rectangle r = e.Bounds;
            r.Width = r.Width / maximum;
            r.Offset(i * r.Width + 2, 2);
            r.Size = new Size(r.Width, ((r.Height * 70) / 100) - 4);
            r.Inflate(-1, -1);
            result.Add(r);
        }
        return result;
    }

    protected virtual Rectangle CalcStarsRect(RatingControlObjectInfoArgs e) {
        Rectangle r = e.Bounds;
        Size size = r.Size;
        r.Height = (r.Height * 70) / 100;
        r.Inflate(-1, -1);
        return r;
    }

    protected virtual Rectangle CalcTitlesRect(RatingControlObjectInfoArgs e) {
        Rectangle r = e.Bounds;
        Size size = r.Size;
        r.Location = new Point(r.Location.X, r.Location.Y + (r.Height * 70) / 100);
        r.Height = (r.Height * 30) / 100;
        r.Inflate(-1, -1);
        return r;
    }
}

