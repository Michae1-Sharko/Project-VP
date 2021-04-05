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
        private TableLayoutPanelCellPosition locationCat;
        private TableLayoutPanelCellPosition locationToGo;

        private TableLayoutPanelCellPosition locationMeatBawl;
        private TableLayoutPanelCellPosition locationWaterBawl;

        public Form1()
        {
            InitializeComponent();

            progressBarSatietyLack.SetState((int)ProgressBarColors.Red);
            progressBarSatiety.SetState((int)ProgressBarColors.Green);
            progressBarSatietyExcess.SetState((int)ProgressBarColors.Yellow);

            progressBarHydrationLack.SetState((int)ProgressBarColors.Red);
            progressBarHydration.SetState((int)ProgressBarColors.Green);
            progressBarHydrationExcess.SetState((int)ProgressBarColors.Yellow);

            locationCat = new TableLayoutPanelCellPosition(table.ColumnCount / 2, 0);
            locationToGo = getRandomCell();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var width = panelBorderCatUp.Width;
            var height = panelBorderCatUp.Height;

            if (locationCat.Column != locationToGo.Column)
            {
                if (locationToGo.Column - locationCat.Column > 0)
                {
                    locationCat.Column++; // to left

                    panelBackgroundUp.Location = new Point(panelBackgroundUp.Location.X - width, panelBackgroundUp.Location.Y);
                    panelBorderCatUp.Location = new Point(panelBorderCatUp.Location.X + width, panelBorderCatUp.Location.Y);

                    panelBackgroundDown.Location = new Point(panelBackgroundDown.Location.X + width, panelBackgroundDown.Location.Y);
                    panelBorderCatDown.Location = new Point(panelBorderCatDown.Location.X - width, panelBorderCatDown.Location.Y);

                    panelBackgroundLeft.Location = new Point(panelBackgroundLeft.Location.X, panelBackgroundLeft.Location.Y - height);
                    panelBorderCatLeft.Location = new Point(panelBorderCatLeft.Location.X, panelBorderCatLeft.Location.Y + height);

                    panelBackgroundRight.Location = new Point(panelBackgroundRight.Location.X, panelBackgroundRight.Location.Y + height);
                    panelBorderCatRight.Location = new Point(panelBorderCatRight.Location.X, panelBorderCatRight.Location.Y - height);
                }
                else
                {
                    locationCat.Column--; // to right

                    panelBackgroundUp.Location = new Point(panelBackgroundUp.Location.X + width, panelBackgroundUp.Location.Y);
                    panelBorderCatUp.Location = new Point(panelBorderCatUp.Location.X - width, panelBorderCatUp.Location.Y);

                    panelBackgroundDown.Location = new Point(panelBackgroundDown.Location.X - width, panelBackgroundDown.Location.Y);
                    panelBorderCatDown.Location = new Point(panelBorderCatDown.Location.X + width, panelBorderCatDown.Location.Y);

                    panelBackgroundLeft.Location = new Point(panelBackgroundLeft.Location.X, panelBackgroundLeft.Location.Y + height);
                    panelBorderCatLeft.Location = new Point(panelBorderCatLeft.Location.X, panelBorderCatLeft.Location.Y - height);

                    panelBackgroundRight.Location = new Point(panelBackgroundRight.Location.X, panelBackgroundRight.Location.Y - height);
                    panelBorderCatRight.Location = new Point(panelBorderCatRight.Location.X, panelBorderCatRight.Location.Y + height);
                }
            }

            if (locationCat.Row != locationToGo.Row)
            {
                if (locationToGo.Row - locationCat.Row > 0)
                {
                    locationCat.Row++; // to Up

                    panelBackgroundUp.Location = new Point(panelBackgroundUp.Location.X, panelBackgroundUp.Location.Y - height);
                    panelBorderCatUp.Location = new Point(panelBorderCatUp.Location.X, panelBorderCatUp.Location.Y + height);

                    panelBackgroundDown.Location = new Point(panelBackgroundDown.Location.X, panelBackgroundDown.Location.Y + height);
                    panelBorderCatDown.Location = new Point(panelBorderCatDown.Location.X, panelBorderCatDown.Location.Y - height);

                    panelBackgroundLeft.Location = new Point(panelBackgroundLeft.Location.X + width, panelBackgroundLeft.Location.Y);
                    panelBorderCatLeft.Location = new Point(panelBorderCatLeft.Location.X - width, panelBorderCatLeft.Location.Y);

                    panelBackgroundRight.Location = new Point(panelBackgroundRight.Location.X - width, panelBackgroundRight.Location.Y);
                    panelBorderCatRight.Location = new Point(panelBorderCatRight.Location.X + width, panelBorderCatRight.Location.Y);
                }
                else
                {
                    locationCat.Row--; // to Down

                    panelBackgroundUp.Location = new Point(panelBackgroundUp.Location.X, panelBackgroundUp.Location.Y + height);
                    panelBorderCatUp.Location = new Point(panelBorderCatUp.Location.X, panelBorderCatUp.Location.Y - height);

                    panelBackgroundDown.Location = new Point(panelBackgroundDown.Location.X, panelBackgroundDown.Location.Y - height);
                    panelBorderCatDown.Location = new Point(panelBorderCatDown.Location.X, panelBorderCatDown.Location.Y + height);

                    panelBackgroundLeft.Location = new Point(panelBackgroundLeft.Location.X - width, panelBackgroundLeft.Location.Y);
                    panelBorderCatLeft.Location = new Point(panelBorderCatLeft.Location.X + width, panelBorderCatLeft.Location.Y);

                    panelBackgroundRight.Location = new Point(panelBackgroundRight.Location.X + width, panelBackgroundRight.Location.Y);
                    panelBorderCatRight.Location = new Point(panelBorderCatRight.Location.X - width, panelBorderCatRight.Location.Y);
                }
            }

            table.SetCellPosition(pictureTableCat, locationCat);

            if (pictureTableMeat.Visible && locationCat == locationMeatBawl)
            {
                pictureTableMeat.Visible = false;

                buttonMeat.Enabled = true;
                buttonWater.Enabled = true;

                progressBarSatiety.Value = ((progressBarSatiety.Value + 7) < progressBarSatiety.Maximum) ? (progressBarSatiety.Value + 7) : (progressBarSatiety.Maximum);
                progressBarSatietyLack.Value = 0;

                progressBarSatietyLack.SetState((int)ProgressBarColors.Green);
                progressBarSatietyLack.SetState((int)ProgressBarColors.Red);

                if (progressBarSatiety.Value > progressBarSatiety.Maximum - progressBarSatietyExcess.Maximum)
                {
                    //int sub = progressBarSatiety.Maximum - progressBarSatiety.Value;
                    //progressBarSatietyExcess.Value = (sub > progressBarSatietyExcess.Value) ? (progressBarSatietyExcess.Maximum) : (sub);
                    progressBarSatietyExcess.Value = progressBarSatiety.Value - (progressBarSatiety.Maximum - progressBarSatietyExcess.Maximum);

                    progressBarSatietyExcess.SetState((int)ProgressBarColors.Green);
                    progressBarSatietyExcess.SetState((int)ProgressBarColors.Yellow);
                }
            }

            if (pictureTableWater.Visible && locationCat == locationWaterBawl)
            {
                pictureTableWater.Visible = false;

                buttonMeat.Enabled = true;
                buttonWater.Enabled = true;

                progressBarHydration.Value = ((progressBarHydration.Value + 7) < progressBarHydration.Maximum) ? (progressBarHydration.Value + 7) : (progressBarHydration.Maximum);
                progressBarHydrationLack.Value = 0;
                progressBarHydrationLack.SetState((int)ProgressBarColors.Green);
                progressBarHydrationLack.SetState((int)ProgressBarColors.Red);

                if (progressBarHydration.Value > progressBarHydration.Maximum - progressBarHydrationExcess.Maximum)
                {
                    //int sub = progressBarHydration.Maximum - progressBarHydration.Value;
                    //progressBarHydrationExcess.Value = (sub > progressBarHydrationExcess.Value) ? (progressBarHydrationExcess.Maximum) : (sub);
                    progressBarHydrationExcess.Value = progressBarHydration.Value - (progressBarHydration.Maximum - progressBarHydrationExcess.Maximum);

                    progressBarHydrationExcess.SetState((int)ProgressBarColors.Green);
                    progressBarHydrationExcess.SetState((int)ProgressBarColors.Yellow);
                }

            }

            if (locationCat == locationToGo)
            {
                locationToGo = getRandomCell();
            }

            if (progressBarSatietyExcess.Value > 0)
                progressBarSatietyExcess.Value--;
            else
            {
                progressBarSatietyExcess.SetState((int)ProgressBarColors.Green);
                progressBarSatietyExcess.SetState((int)ProgressBarColors.Yellow);
            }

            if (progressBarHydrationExcess.Value > 0)
                progressBarHydrationExcess.Value--;
            else
            {
                progressBarHydrationExcess.SetState((int)ProgressBarColors.Green);
                progressBarHydrationExcess.SetState((int)ProgressBarColors.Yellow);
            }

            if (progressBarSatiety.Value > 0)
            {
                progressBarSatiety.Value--;

                if (progressBarSatiety.Value <= progressBarSatietyLack.Maximum && progressBarSatietyLack.Value < progressBarSatietyLack.Maximum)
                    progressBarSatietyLack.Value++;
            }

            if (progressBarHydration.Value > 0)
            {
                progressBarHydration.Value--;

                if (progressBarHydration.Value <= progressBarHydrationLack.Maximum && progressBarHydrationLack.Value < progressBarHydrationLack.Maximum)
                    progressBarHydrationLack.Value++;
            }

            if (progressBarSatiety.Value == 0 || progressBarHydration.Value == 0)
            {
                buttonGameState.Enabled = false;
                timer.Enabled = false;

                progressBarSatietyLack.SetState((int)ProgressBarColors.Green);
                progressBarHydrationLack.SetState((int)ProgressBarColors.Green);

                progressBarSatietyLack.SetState((int)ProgressBarColors.Red);
                progressBarHydrationLack.SetState((int)ProgressBarColors.Red);

                buttonGameState.Text = "Game Over";
            }
        }

        private void buttonGameState_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;

            buttonMeat.Enabled = !buttonMeat.Enabled;
            buttonWater.Enabled = !buttonWater.Enabled;

            buttonGameState.Text = (timer.Enabled) ? ("Pause") : ("Play");
        }

        TableLayoutPanelCellPosition getRandomCell()
        {
            var random = new Random();

            var column = random.Next() % (table.ColumnCount - 1);
            var row = random.Next() % (table.RowCount - 1);

            if (column >= locationCat.Column) column++;
            if (row >= locationCat.Row) row++;

            return new TableLayoutPanelCellPosition(column, row);
        }

        private void buttonMeat_Click(object sender, EventArgs e)
        {
            locationMeatBawl = getRandomCell();
            table.SetCellPosition(pictureTableMeat, locationMeatBawl);

            pictureTableMeat.Visible = true;

            buttonMeat.Enabled = false;
            buttonWater.Enabled = false;

            locationToGo = locationMeatBawl;
        }

        private void buttonWater_Click(object sender, EventArgs e)
        {
            locationWaterBawl = getRandomCell();
            table.SetCellPosition(pictureTableWater, locationWaterBawl);

            pictureTableWater.Visible = true;

            buttonMeat.Enabled = false;
            buttonWater.Enabled = false;

            locationToGo = locationWaterBawl;
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
