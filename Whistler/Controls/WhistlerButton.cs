using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        Pen pBorder = new Pen(Color.FromArgb(0x80, 0x80, 0x80)), pBorderFocus = new Pen(Color.FromArgb(0x6F, 0x89, 0xB0)), pBorderDisabled = new Pen(Color.FromArgb(0xC0, 0xC2, 0xBE)), pBorderActive = new Pen(Color.FromArgb(0x66, 0x7E, 0xA2));
        Pen pHighlightFocus = new Pen(Color.FromArgb(0xC7, 0xDC, 0xF6)), pHighlightDisabled = new Pen(Color.FromArgb(0xF4, 0xF5, 0xF2)), pHighlightActive = new Pen(Color.FromArgb(0xB7, 0xCB, 0xE3));
        Pen pShadow = new Pen(Color.FromArgb(0xBC, 0xBE, 0xB8)), pShadowFocus = new Pen(Color.FromArgb(0x87, 0xAC, 0xDD)), pShadowDisabled = new Pen(Color.FromArgb(0xE1, 0xE3, 0xDD)), pShadowActive = new Pen(Color.FromArgb(0x7C, 0x9F, 0xCC));
        Brush bFocus = new SolidBrush(Color.FromArgb(0xCC, 0x9C, 0xBF, 0xE7));
        Color cDisabled = Color.FromArgb(0xA1, 0xA1, 0x92);
        protected override void OnPaint(PaintEventArgs e)
        {
            if (active)
            {
                e.Graphics.DrawRectangle(pBorderActive, 0, 0, this.Width - 1, this.Height - 1);

                e.Graphics.DrawLine(pShadowActive, 1, 1, 1, this.Height - 3);
                e.Graphics.DrawLine(pShadowActive, 1, 1, this.Width - 3, 1);

                e.Graphics.DrawLine(pHighlightActive, this.Width - 2, 1, this.Width - 2, this.Height - 2);
                e.Graphics.DrawLine(pHighlightActive, 1, this.Height - 2, this.Width - 2, this.Height - 2);
            }
            else
            {
                e.Graphics.DrawRectangle((this.Enabled ? (this.Focused || hover ? pBorderFocus : pBorder) : pBorderDisabled), 0, 0, this.Width - 1, this.Height - 1);

                e.Graphics.DrawLine((this.Enabled ? (this.Focused || hover ? pHighlightFocus : Pens.White) : pHighlightDisabled), 1, 1, 1, this.Height - 2);
                e.Graphics.DrawLine((this.Enabled ? (this.Focused || hover ? pHighlightFocus : Pens.White) : pHighlightDisabled), 1, 1, this.Width - 2, 1);

                e.Graphics.DrawLine((this.Enabled ? (this.Focused || hover ? pShadowFocus : pShadow) : pShadowDisabled), this.Width - 2, 2, this.Width - 2, this.Height - 2);
                e.Graphics.DrawLine((this.Enabled ? (this.Focused || hover ? pShadowFocus : pShadow) : pShadowDisabled), 2, this.Height - 2, this.Width - 2, this.Height - 2);
            }

            //e.Graphics.FillRectangle((this.Enabled ? (hover ? tbButtonBackgroundHover : tbButtonBackground) : tbButtonBackgroundDisabled), 2, 2, this.Width - 4, this.Height - 4);

            using (ImageAttributes attribs = new ImageAttributes())
            {
                attribs.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                e.Graphics.DrawImage((this.Enabled ? (active ? Properties.Resources.ButtonBackgroundActive : (hover ? Properties.Resources.ButtonBackgroundHover : Properties.Resources.ButtonBackground)) : Properties.Resources.ButtonBackgroundDisabled),
                    new Rectangle(2, 2, this.Width - 4, this.Height - 4),
                        0, 0, 1, Properties.Resources.ButtonBackground.Height,
                        GraphicsUnit.Pixel, attribs);
            }

            //e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            /*e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            int matw = this.Width - 2, matx = this.Height - 4;
            for (int i = 2; i < matw; i++)
                e.Graphics.DrawImage((this.Enabled ? (hover ? Properties.Resources.ButtonBackgroundDisabled : Properties.Resources.ButtonBackground) : Properties.Resources.ButtonBackgroundDisabled), i, 2, 1, matx);
            */
            if (this.Focused && !hover)
            {
                e.Graphics.FillRectangle(bFocus, 2, 2, this.Width - 4, 2);
                e.Graphics.FillRectangle(bFocus, 2, this.Height - 4, this.Width - 4, 2);

                e.Graphics.FillRectangle(bFocus, 2, 4, 2, this.Height - 8);
                e.Graphics.FillRectangle(bFocus, this.Width - 4, 4, 2, this.Height - 8);
            }

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(0, 0, this.Width, this.Height), (this.Enabled ? Color.Black : cDisabled), (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis));
        }

        bool hover = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            hover = true;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            hover = false;
            this.Invalidate();
        }

        bool active = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            active = true;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            active = false;
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
    }
}
