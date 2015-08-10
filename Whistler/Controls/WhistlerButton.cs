using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Whistler.Controls
{
    public class WhistlerButton : Button
    {
        public WhistlerButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular);
        }

        Pen pBorder = new Pen(Color.FromArgb(0x80, 0x80, 0x80)), pBorderFocus = new Pen(Color.FromArgb(0x6F, 0x89, 0xB0)), pBorderDisabled = new Pen(Color.FromArgb(0xC0, 0xC2, 0xBE));
        Pen pHighlightFocus = new Pen(Color.FromArgb(0xC7, 0xDC, 0xF6)), pHighlightDisabled = new Pen(Color.FromArgb(0xF4, 0xF5, 0xF2));
        Pen pShadow = new Pen(Color.FromArgb(0xBC, 0xBE, 0xB8)), pShadowFocus = new Pen(Color.FromArgb(0x87, 0xAC, 0xDD)), pShadowDisabled = new Pen(Color.FromArgb(0xE1, 0xE3, 0xDD));
        Brush bFocus = new SolidBrush(Color.FromArgb(0xCC, 0x9C, 0xBF, 0xE7));
        Color cDisabled = Color.FromArgb(0xA1, 0xA1, 0x92);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle((this.Enabled ? (this.Focused ? pBorderFocus : pBorder) : pBorderDisabled), 0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawLine((this.Enabled ? (this.Focused ? pHighlightFocus : Pens.White) : pHighlightDisabled), 1, 1, 1, this.Height - 2); e.Graphics.DrawLine((this.Enabled ? (this.Focused ? pHighlightFocus : Pens.White) : pHighlightDisabled), 1, 1, this.Width - 2, 1);
            e.Graphics.DrawLine((this.Enabled ? (this.Focused ? pShadowFocus : pShadow) : pShadowDisabled), this.Width - 2, 2, this.Width - 2, this.Height - 2); e.Graphics.DrawLine((this.Enabled ? (this.Focused ? pShadowFocus : pShadow) : pShadowDisabled), 2, this.Height - 2, this.Width - 2, this.Height - 2);


            using (TextureBrush b = new TextureBrush((this.Enabled ? Properties.Resources.ButtonBackground : Properties.Resources.ButtonBackgroundDisabled)))
            {
                b.TranslateTransform(2, 2);
                e.Graphics.FillRectangle(b, 2, 2, this.Width - 4, this.Height - 4);
            }

            if (this.Focused)
            {
                e.Graphics.FillRectangle(bFocus, 2, 2, this.Width - 4, 2);
                e.Graphics.FillRectangle(bFocus, 2, this.Height - 4, this.Width - 4, 2);

                e.Graphics.FillRectangle(bFocus, 2, 4, 2, this.Height - 8);
                e.Graphics.FillRectangle(bFocus, this.Width - 4, 4, 2, this.Height - 8);
            }

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(0, 0, this.Width, this.Height), (this.Enabled ? Color.Black : cDisabled), (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis));
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
    }
}
