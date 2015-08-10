using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Whistler
{
    public partial class WhistlerForm : Form
    {
        public WhistlerForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.EnableNotifyMessage, true);

            SetBounds();

            intback = new SolidBrush(this.BackColor);

            //oldw = this.Width;
            //oldh = this.Height;
        }

        Icon _Icon = null;
        Image _IconImg = null;
        public new Icon Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;

                if (_IconImg != null) _IconImg.Dispose();

                Icon temp = new Icon(value, 16, 16);
                _IconImg = temp.ToBitmap();
                temp.Dispose();

                this.Invalidate();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(this.DesignMode == false)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            oldw = this.Width;
            oldh = this.Height;
        }

        Rectangle CaptionBounds, CaptionDragBounds, WindowBounds, InsideBounds, btnClose, btnMaximize, btnMinimize;
        const int buttonsize = 8, buttonwidth = 17, buttonxmid = (buttonwidth / 2 + buttonsize / 2);
        void SetBounds()
        {
            CaptionBounds = new Rectangle(0, 0, this.Width, 22);
            CaptionDragBounds = new Rectangle(0, 0, CaptionBounds.Width - (buttonwidth * capcontrols.Length), CaptionBounds.Height);
            WindowBounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            btnClose = new Rectangle(CaptionBounds.Width - buttonwidth, 0, buttonwidth, CaptionBounds.Height);
            btnMaximize = new Rectangle(CaptionBounds.Width - buttonwidth * 2, 0, buttonwidth, CaptionBounds.Height);
            btnMinimize = new Rectangle(CaptionBounds.Width - buttonwidth * 3, 0, buttonwidth, CaptionBounds.Height);
        }
        protected override void OnResize(EventArgs e)
        {
            SetBounds();

            base.OnResize(e);

            this.Invalidate();
        }

        //Font fCaption = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);
        Font fCaption = new Font("Tahoma", 8.25f, FontStyle.Bold);
        Pen pBorder = new Pen(Color.FromArgb(0x68, 0x96, 0xE0)), pBorderShadow1 = new Pen(Color.FromArgb(0x2F, 0x67, 0xBF)), pBorderShadow2 = new Pen(Color.FromArgb(0x33, 0x6F, 0xCE)),
            pBorderInactive = new Pen(Color.FromArgb(0x5A, 0x81, 0xBF)), pBorderShadow1Inactive = new Pen(Color.FromArgb(0x27, 0x56, 0x9F)), pBorderShadow2Inactive = new Pen(Color.FromArgb(0x2A, 0x5C, 0xAB));
        Brush bBorder = new SolidBrush(Color.FromArgb(0x35, 0x73, 0xD6)), bBorderInactive = new SolidBrush(Color.FromArgb(0x2C, 0x60, 0xB2));
        Color cCaptionTitleInactive = Color.FromArgb(0x7A, 0xA1, 0xFF);
        protected override void OnPaint(PaintEventArgs e)
        {
            Brush border = (realfocus ? bBorder : bBorderInactive);
            e.Graphics.FillRectangle(border, CaptionBounds);
            e.Graphics.FillRectangle(border, 0, 0, 4, this.Height);
            e.Graphics.FillRectangle(border, this.Width - 4, 0, 4, this.Height);
            e.Graphics.FillRectangle(border, 0, this.Height - 4, this.Width, 4);

            e.Graphics.DrawRectangle((realfocus ? pBorder : pBorderInactive), WindowBounds);
            e.Graphics.DrawRectangle((realfocus ? pBorderShadow1 : pBorderShadow1Inactive), 3, CaptionBounds.Bottom - 1, this.Width - 7, this.Height - CaptionBounds.Bottom - 3);
            e.Graphics.DrawRectangle((realfocus ? pBorderShadow2 : pBorderShadow2Inactive), 2, CaptionBounds.Bottom - 2, this.Width - 5, this.Height - CaptionBounds.Bottom - 1);

            if (realfocus)
            {
                e.Graphics.DrawImage(Properties.Resources.BorderLeft, 0, CaptionBounds.Bottom, 4, (Properties.Resources.BorderLeft.Height + CaptionBounds.Bottom > this.Height - 4 ? this.Height - CaptionBounds.Bottom - 4 : Properties.Resources.BorderLeft.Height));
                e.Graphics.DrawImage(Properties.Resources.CaptionLeft, 0, 0);

                int dong = this.Width - 139;
                using (TextureBrush b = new TextureBrush(Properties.Resources.CaptionRepeat))
                    e.Graphics.FillRectangle(b, 6, 0, (dong < 24 ? 24 : dong), CaptionBounds.Height);

                e.Graphics.DrawImage(Properties.Resources.CaptionDivider, (dong < 24 ? 24 : dong), 0);
            }

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            TextRenderer.DrawText(e.Graphics, this.Text, fCaption, new Point((this.ShowIcon && _IconImg != null ? 27 : 9), 4), (realfocus ? Color.White : cCaptionTitleInactive));

            if (this.ShowIcon && _IconImg != null)
            {
                e.Graphics.DrawImage(_IconImg, 4, 2);
            }
        }

        int[] capcontrols = new int[3];
        void UpdateCaptionControl(int index, int state)
        {
            if (state <= capcontrols[index] && state != 0) return;
            
            this.Invalidate();
            capcontrols[index] = state;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            e = new MouseEventArgs(e.Button, e.Clicks, e.X - 9, e.Y - 30, e.Delta);

            base.OnMouseMove(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(intback, e.Graphics.ClipBounds);
            //base.OnPaintBackground(e);
        }

        Brush intback = null;
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            intback = new SolidBrush(this.BackColor);
        }

        const int bordersize = 8;
        bool realfocus = true, ignore = true;
        int oldw = 0, oldh = 0;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WinAPI.WM_NCHITTEST)
            {
                Point mouse = this.PointToClient(Cursor.Position);

                //System.Diagnostics.Debug.WriteLine(mouse.X + ":" + mouse.Y);

                UpdateCaptionControl(0, (btnClose.Contains(mouse) ? 1 : 0));
                UpdateCaptionControl(1, (btnMaximize.Contains(mouse) ? 1 : 0));
                UpdateCaptionControl(2, (btnMinimize.Contains(mouse) ? 1 : 0));

                foreach (int b in capcontrols)
                    if (b != 0)
                    {
                        m.Result = (IntPtr)WinAPI.HTBORDER;
                        return;
                    }

                bool
                left = false,
                right = false,
                top = false,
                bottom = false;

                if (mouse.X <= bordersize) left = true;
                else if (mouse.X >= this.Width - bordersize) right = true;
                if (mouse.Y <= bordersize) top = true;
                else if (mouse.Y >= this.Height - bordersize) bottom = true;

                if (top && left) m.Result = (IntPtr)WinAPI.HTTOPLEFT;
                else if (top && right) m.Result = (IntPtr)WinAPI.HTTOPRIGHT;
                else if (bottom && left) m.Result = (IntPtr)WinAPI.HTBOTTOMLEFT;
                else if (bottom && right) m.Result = (IntPtr)WinAPI.HTBOTTOMRIGHT;
                else if (top) m.Result = (IntPtr)WinAPI.HTTOP;
                else if (bottom) m.Result = (IntPtr)WinAPI.HTBOTTOM;
                else if (left) m.Result = (IntPtr)WinAPI.HTLEFT;
                else if (right) m.Result = (IntPtr)WinAPI.HTRIGHT;
                else if (CaptionDragBounds.Contains(mouse)) m.Result = (IntPtr)WinAPI.HTCAPTION;
                else if (CaptionBounds.Contains(mouse)) m.Result = (IntPtr)WinAPI.HTBORDER;
                else m.Result = (IntPtr)WinAPI.HTCLIENT;
                return;
            }
            else if (m.Msg == WinAPI.WM_NCMOUSELEAVE)
            {
                for (int i = 0; i < capcontrols.Length; i++) capcontrols[i] = 0;
                this.Invalidate();
            }
            else if (m.Msg == WinAPI.WM_NCLBUTTONUP)
            {
                Point mouse = this.PointToClient(Cursor.Position);
                if (btnClose.Contains(mouse) && capcontrols[0] == 2) { this.Close(); return; }
                else if (btnMaximize.Contains(mouse) && capcontrols[1] == 2)
                {
                    this.WindowState = (this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized);

                    return;
                }
                else if (btnMinimize.Contains(mouse) && capcontrols[2] == 2) { this.WindowState = FormWindowState.Minimized; return; }

                for (int i = 0; i < capcontrols.Length; i++)
                    if (capcontrols[i] == 2) capcontrols[i] = 1;
                this.Invalidate();
            }
            else if (m.Msg == WinAPI.WM_NCLBUTTONDOWN)
            {
                Point mouse = this.PointToClient(Cursor.Position);
                UpdateCaptionControl(0, (btnClose.Contains(mouse) ? 2 : 0));
                UpdateCaptionControl(1, (btnMaximize.Contains(mouse) ? 2 : 0));
                UpdateCaptionControl(2, (btnMinimize.Contains(mouse) ? 2 : 0));
            }
            else if (m.Msg == WinAPI.WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                m.Result = new IntPtr(0x00);
                return;
            }
            /*else if (m.Msg == WinAPI.WM_SYSCOMMAND)
            {
                int command = m.WParam.ToInt32() & 0xFFF0;
                if (command == WinAPI.SC_MINIMIZE) glow.WindowState = FormWindowState.Minimized;
                else if (command == WinAPI.SC_RESTORE) glow.WindowState = FormWindowState.Normal;
            }*/
            else if (m.Msg == WinAPI.WM_ACTIVATE)
            {
                if (ignore) ignore = false;
                else
                {
                    realfocus = (m.WParam.ToInt32() != 0);

                    if (m.WParam.ToInt32() == 0)
                    {
                        oldw = this.Width;
                        oldh = this.Height;
                    }
                    else
                    {
                        this.Width = oldw;
                        this.Height = oldh;
                    }

                    this.Invalidate();
                }
            }

            base.WndProc(ref m);
        }
    }
}
