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
            this.whistlerCheckBox2 = new Whistler.Controls.WhistlerCheckBox();
            this.whistlerCheckBox3 = new Whistler.Controls.WhistlerCheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(97, 272);
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
            this.btnCancel.Location = new System.Drawing.Point(178, 272);
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
            this.whistlerCheckBox1.Size = new System.Drawing.Size(73, 17);
            this.whistlerCheckBox1.TabIndex = 2;
            this.whistlerCheckBox1.Text = "Checkbox";
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
            this.whistlerButton1.Size = new System.Drawing.Size(91, 73);
            this.whistlerButton1.TabIndex = 3;
            this.whistlerButton1.Text = "Stretchy";
            this.whistlerButton1.UseVisualStyleBackColor = true;
            // 
            // whistlerCheckBox2
            // 
            this.whistlerCheckBox2.AutoSize = true;
            this.whistlerCheckBox2.Enabled = false;
            this.whistlerCheckBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.whistlerCheckBox2.Location = new System.Drawing.Point(12, 58);
            this.whistlerCheckBox2.Name = "whistlerCheckBox2";
            this.whistlerCheckBox2.Size = new System.Drawing.Size(66, 17);
            this.whistlerCheckBox2.TabIndex = 4;
            this.whistlerCheckBox2.Text = "Disabled";
            this.whistlerCheckBox2.UseVisualStyleBackColor = true;
            // 
            // whistlerCheckBox3
            // 
            this.whistlerCheckBox3.AutoSize = true;
            this.whistlerCheckBox3.Checked = true;
            this.whistlerCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whistlerCheckBox3.Enabled = false;
            this.whistlerCheckBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.whistlerCheckBox3.Location = new System.Drawing.Point(84, 58);
            this.whistlerCheckBox3.Name = "whistlerCheckBox3";
            this.whistlerCheckBox3.Size = new System.Drawing.Size(66, 17);
            this.whistlerCheckBox3.TabIndex = 5;
            this.whistlerCheckBox3.Text = "Disabled";
            this.whistlerCheckBox3.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 307);
            this.Controls.Add(this.whistlerCheckBox3);
            this.Controls.Add(this.whistlerCheckBox2);
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
        private Whistler.Controls.WhistlerCheckBox whistlerCheckBox2;
        private Whistler.Controls.WhistlerCheckBox whistlerCheckBox3;


    }
}

