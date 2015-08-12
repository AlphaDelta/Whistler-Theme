using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Whistler.Controls
{
    public class WhistlerCheckBox : CheckBox
    {
        public WhistlerCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular);

            back = new SolidBrush(this.BackColor);
        }

        Pen pBorder = new Pen(Color.FromArgb(0x82, 0x82, 0x76));
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(back, e.ClipRectangle);
            /*e.Graphics.FillRectangle(back, e.ClipRectangle);

            e.Graphics.DrawImage(Properties.Resources.CheckBoxShadow, 0, 0);

            e.Graphics.FillRectangle(Brushes.White, 1, 1, 11, 11);
            e.Graphics.DrawRectangle(pBorder, 0, 0, 12, 12);

            if (this.Checked) e.Graphics.DrawImage(Properties.Resources.CheckBoxCheck, 1, 1);*/

            if (this.Checked)
                e.Graphics.DrawImage(
                    (this.Enabled ?
                        (active ? Properties.Resources.CheckBoxCheckedActive :
                            (hover ? Properties.Resources.CheckBoxCheckedHover : Properties.Resources.CheckBoxChecked))
                    : Properties.Resources.CheckBoxCheckedDisabled),
                    0, 0);
            else
                e.Graphics.DrawImage(
                    (this.Enabled ?
                        (active ? Properties.Resources.CheckBoxEmptyActive :
                            (hover ? Properties.Resources.CheckBoxEmptyHover : Properties.Resources.CheckBoxEmpty))
                    : Properties.Resources.CheckBoxEmptyDisabled),
                    0, 0);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(17, 0, this.Width - 17, 12), Color.Black, TextFormatFlags.EndEllipsis);
        }

        Brush back = null;
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            back = new SolidBrush(this.BackColor);
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
    }
}
