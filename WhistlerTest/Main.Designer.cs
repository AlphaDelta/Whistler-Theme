namespace WhistlerTest
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new Whistler.Controls.WhistlerButton();
            this.btnCancel = new Whistler.Controls.WhistlerButton();
            this.whistlerCheckBox1 = new Whistler.Controls.WhistlerCheckBox();
            this.whistlerButton1 = new Whistler.Controls.WhistlerButton();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(122, 282);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(203, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // whistlerCheckBox1
            // 
            this.whistlerCheckBox1.AutoSize = true;
            this.whistlerCheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.whistlerCheckBox1.Location = new System.Drawing.Point(12, 35);
            this.whistlerCheckBox1.Name = "whistlerCheckBox1";
            this.whistlerCheckBox1.Size = new System.Drawing.Size(116, 17);
            this.whistlerCheckBox1.TabIndex = 2;
            this.whistlerCheckBox1.Text = "whistlerCheckBox1";
            this.whistlerCheckBox1.UseVisualStyleBackColor = true;
            // 
            // whistlerButton1
            // 
            this.whistlerButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whistlerButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.whistlerButton1.Location = new System.Drawing.Point(95, 117);
            this.whistlerButton1.Name = "whistlerButton1";
            this.whistlerButton1.Size = new System.Drawing.Size(116, 83);
            this.whistlerButton1.TabIndex = 3;
            this.whistlerButton1.Text = "Stretchy";
            this.whistlerButton1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 317);
            this.Controls.Add(this.whistlerButton1);
            this.Controls.Add(this.whistlerCheckBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "Main";
            this.Text = "Test form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Whistler.Controls.WhistlerButton btnOk;
        private Whistler.Controls.WhistlerButton btnCancel;
        private Whistler.Controls.WhistlerCheckBox whistlerCheckBox1;
        private Whistler.Controls.WhistlerButton whistlerButton1;


    }
}

