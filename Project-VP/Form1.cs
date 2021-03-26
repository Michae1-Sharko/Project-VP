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
        private struct TableLocation
        {
            public TableLocation(int pos_x, int pos_y, int steps)
            {
                x = pos_x;
                y = pos_y;
                stepsToDisappear = steps;
            }

            int x;
            int y;

            int stepsToDisappear;
        }

        private TableLocation locationCat;
        private List<TableLocation> locationToGo;

        private List<TableLocation> locationsEmptyBawls;
        private List<TableLocation> locationsMeatBawls;
        private List<TableLocation> locationsWaterBawls;

        public Form1()
        {
            InitializeComponent();

            progressBarSatietyLack.SetState((int)ProgressBarColors.Red);
            progressBarSatiety.SetState((int)ProgressBarColors.Green);
            progressBarSatietyExcess.SetState((int)ProgressBarColors.Yellow);

            progressBarHydrationLack.SetState((int)ProgressBarColors.Red);
            progressBarHydration.SetState((int)ProgressBarColors.Green);
            progressBarHydrationExcess.SetState((int)ProgressBarColors.Yellow);

            progressBarEnduranceLack.SetState((int)ProgressBarColors.Red);
            progressBarEndurance.SetState((int)ProgressBarColors.Green);  

            locationCat = new TableLocation(4, 0, 0);
            locationToGo.Add(new TableLocation(4, 2, 0));
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }

        private void buttonGameState_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;

            buttonMeat.Enabled = !buttonMeat.Enabled;
            buttonWater.Enabled = !buttonWater.Enabled;
            buttonSleep.Enabled = !buttonSleep.Enabled;

            buttonGameState.Text = (timer.Enabled) ? ("Pause") : ("Play");
        }

        private void buttonMeat_Click(object sender, EventArgs e)
        {

        }

        private void buttonWater_Click(object sender, EventArgs e)
        {

        }

        private void buttonSleep_Click(object sender, EventArgs e)
        {

        }
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
