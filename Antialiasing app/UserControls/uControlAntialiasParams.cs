using System;
using System.Windows.Forms;

namespace Antialiasing_app.UserControls
{

	public partial class uControlAntialiasParams : UserControl
    {
        public int plane_sended;
        public bool only_one;

        public uControlAntialiasParams()
        {
            plane_sended = 0;
            only_one = false;
            InitializeComponent();
        }

		private void numericUpDownDegPerSec_ValueChanged(object sender, EventArgs e)
		{
			(ParentForm as FormMain).Speed = (int)numericUpDownDegPerSec.Value; 
		}

		private void buttonRun_Click(object sender, EventArgs e)
		{
            ColorDialog colorPickingDialog = new ColorDialog();
            colorPickingDialog.AllowFullOpen = true;
            colorPickingDialog.ShowHelp = true;
            colorPickingDialog.Color = panelPixelColor.BackColor;

            // Update the text box color if the user clicks OK 
            if (colorPickingDialog.ShowDialog() == DialogResult.OK)
                panelPixelColor.BackColor = colorPickingDialog.Color;
        }

        private void uControlAntialiasParams_Load(object sender, EventArgs e)
        {

        }

        private void send_plane_Click(object sender, EventArgs e)
        {
            plane_sended++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                only_one = true;
            else
                only_one = false;
                
        }
    }
}
