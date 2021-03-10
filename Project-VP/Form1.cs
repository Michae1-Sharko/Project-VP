using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Project_VP
{
    enum ProgressBarColors
    {
        Green = 1,
        Red,
        Yellow
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            progressBarSatietyLack.SetState((int)ProgressBarColors.Red);
            progressBarSatiety.SetState((int)ProgressBarColors.Green);
            progressBarSatietyExcess.SetState((int)ProgressBarColors.Yellow);
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }
    public static class ModifyProgressBarColor
    {
        // https://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
