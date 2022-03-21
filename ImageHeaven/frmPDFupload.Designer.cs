namespace ImageHeaven
{
    partial class frmPDFupload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDFupload));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deButton1 = new nControls.deButton();
            this.deTextBox1 = new nControls.deTextBox();
            this.deLabel1 = new nControls.deLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deButton3 = new nControls.deButton();
            this.deButton2 = new nControls.deButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deButton1);
            this.groupBox1.Controls.Add(this.deTextBox1);
            this.groupBox1.Controls.Add(this.deLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PDF Selection";
            // 
            // deButton1
            // 
            this.deButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deButton1.Location = new System.Drawing.Point(516, 38);
            this.deButton1.Name = "deButton1";
            this.deButton1.Size = new System.Drawing.Size(36, 23);
            this.deButton1.TabIndex = 2;
            this.deButton1.Text = "...";
            this.deButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deButton1.UseCompatibleTextRendering = true;
            this.deButton1.UseVisualStyleBackColor = true;
            this.deButton1.Click += new System.EventHandler(this.deButton1_Click);
            // 
            // deTextBox1
            // 
            this.deTextBox1.BackColor = System.Drawing.Color.White;
            this.deTextBox1.Enabled = false;
            this.deTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deTextBox1.ForeColor = System.Drawing.Color.Black;
            this.deTextBox1.Location = new System.Drawing.Point(113, 39);
            this.deTextBox1.Mandatory = true;
            this.deTextBox1.Name = "deTextBox1";
            this.deTextBox1.Size = new System.Drawing.Size(375, 23);
            this.deTextBox1.TabIndex = 1;
            // 
            // deLabel1
            // 
            this.deLabel1.AutoSize = true;
            this.deLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deLabel1.Location = new System.Drawing.Point(24, 43);
            this.deLabel1.Name = "deLabel1";
            this.deLabel1.Size = new System.Drawing.Size(83, 15);
            this.deLabel1.TabIndex = 0;
            this.deLabel1.Text = "PDF Locarion :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deButton3);
            this.groupBox2.Controls.Add(this.deButton2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 69);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // deButton3
            // 
            this.deButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deButton3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deButton3.Image = global::ImageHeaven.Properties.Resources.abort;
            this.deButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deButton3.Location = new System.Drawing.Point(458, 19);
            this.deButton3.Name = "deButton3";
            this.deButton3.Size = new System.Drawing.Size(94, 38);
            this.deButton3.TabIndex = 1;
            this.deButton3.Text = "&Abort";
            this.deButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deButton3.UseCompatibleTextRendering = true;
            this.deButton3.UseVisualStyleBackColor = true;
            this.deButton3.Click += new System.EventHandler(this.deButton3_Click);
            // 
            // deButton2
            // 
            this.deButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deButton2.Image = global::ImageHeaven.Properties.Resources.usb_stick;
            this.deButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deButton2.Location = new System.Drawing.Point(338, 19);
            this.deButton2.Name = "deButton2";
            this.deButton2.Size = new System.Drawing.Size(95, 38);
            this.deButton2.TabIndex = 0;
            this.deButton2.Text = "&Upload";
            this.deButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deButton2.UseCompatibleTextRendering = true;
            this.deButton2.UseVisualStyleBackColor = true;
            this.deButton2.Click += new System.EventHandler(this.deButton2_Click);
            // 
            // frmPDFupload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 148);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPDFupload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Upload";
            this.Load += new System.EventHandler(this.frmPDFupload_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private nControls.deLabel deLabel1;
        private nControls.deButton deButton1;
        private nControls.deTextBox deTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private nControls.deButton deButton3;
        private nControls.deButton deButton2;

    }
}