
namespace Antialiasing_app.UserControls
{
    partial class uControlAntialiasParams
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPickColor = new System.Windows.Forms.Button();
            this.checkBoxAntialias = new System.Windows.Forms.CheckBox();
            this.numericUpDownDegPerSec = new System.Windows.Forms.NumericUpDown();
            this.panelPixelColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.send_plane = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDegPerSec)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "deg/s";
            // 
            // buttonPickColor
            // 
            this.buttonPickColor.Location = new System.Drawing.Point(99, 66);
            this.buttonPickColor.Name = "buttonPickColor";
            this.buttonPickColor.Size = new System.Drawing.Size(106, 23);
            this.buttonPickColor.TabIndex = 6;
            this.buttonPickColor.Text = "Pick color";
            this.buttonPickColor.UseVisualStyleBackColor = true;
            this.buttonPickColor.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // checkBoxAntialias
            // 
            this.checkBoxAntialias.AutoSize = true;
            this.checkBoxAntialias.Location = new System.Drawing.Point(63, 38);
            this.checkBoxAntialias.Name = "checkBoxAntialias";
            this.checkBoxAntialias.Size = new System.Drawing.Size(107, 19);
            this.checkBoxAntialias.TabIndex = 9;
            this.checkBoxAntialias.Text = "use antialiasing";
            this.checkBoxAntialias.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDegPerSec
            // 
            this.numericUpDownDegPerSec.Location = new System.Drawing.Point(63, 9);
            this.numericUpDownDegPerSec.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownDegPerSec.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.numericUpDownDegPerSec.Name = "numericUpDownDegPerSec";
            this.numericUpDownDegPerSec.Size = new System.Drawing.Size(100, 23);
            this.numericUpDownDegPerSec.TabIndex = 10;
            this.numericUpDownDegPerSec.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownDegPerSec.ValueChanged += new System.EventHandler(this.numericUpDownDegPerSec_ValueChanged);
            // 
            // panelPixelColor
            // 
            this.panelPixelColor.BackColor = System.Drawing.Color.Black;
            this.panelPixelColor.Location = new System.Drawing.Point(73, 67);
            this.panelPixelColor.Name = "panelPixelColor";
            this.panelPixelColor.Size = new System.Drawing.Size(20, 20);
            this.panelPixelColor.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pixel color";
            // 
            // send_plane
            // 
            this.send_plane.Location = new System.Drawing.Point(5, 93);
            this.send_plane.Name = "send_plane";
            this.send_plane.Size = new System.Drawing.Size(200, 36);
            this.send_plane.TabIndex = 14;
            this.send_plane.Text = "Send Plane";
            this.send_plane.UseVisualStyleBackColor = true;
            this.send_plane.Click += new System.EventHandler(this.send_plane_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(56, 132);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 19);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "only one point";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // uControlAntialiasParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.send_plane);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelPixelColor);
            this.Controls.Add(this.numericUpDownDegPerSec);
            this.Controls.Add(this.checkBoxAntialias);
            this.Controls.Add(this.buttonPickColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "uControlAntialiasParams";
            this.Size = new System.Drawing.Size(213, 154);
            this.Load += new System.EventHandler(this.uControlAntialiasParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDegPerSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPickColor;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.NumericUpDown numericUpDownDegPerSec;
		public System.Windows.Forms.Panel panelPixelColor;
        public System.Windows.Forms.CheckBox checkBoxAntialias;
        private System.Windows.Forms.Button send_plane;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}
