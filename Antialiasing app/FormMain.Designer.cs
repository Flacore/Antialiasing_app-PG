
namespace Antialiasing_app
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.uControlAntialiasParams = new Antialiasing_app.UserControls.uControlAntialiasParams();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.panelCenter = new Editor2D.DoubleBufferPanel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.uControlAntialiasParams);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(208, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // uControlAntialiasParams
            // 
            this.uControlAntialiasParams.Location = new System.Drawing.Point(0, 0);
            this.uControlAntialiasParams.Name = "uControlAntialiasParams";
            this.uControlAntialiasParams.Size = new System.Drawing.Size(213, 233);
            this.uControlAntialiasParams.TabIndex = 2;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.White;
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(208, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(592, 450);
            this.panelCenter.TabIndex = 1;
            this.panelCenter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCenter_Paint);
            this.panelCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCenter_MouseDown);
            this.panelCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCenter_MouseMove);
            this.panelCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCenter_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelLeft);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.Text = "Pixel antialiasing";
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private UserControls.uControlAntialiasParams uControlAntialiasParams;
        private System.Windows.Forms.Timer timerMain;
        private Editor2D.DoubleBufferPanel panelCenter;
    }
}

