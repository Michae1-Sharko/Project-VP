﻿using System;
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

                    pictureCatUp.Location = new Point(0, -2 * panelBorderCatUp.Height);
                    pictureCatDown.Location = new Point(0, -1 * panelBorderCatDown.Height);
                    pictureCatLeft.Location = new Point(0, 0 * panelBorderCatLeft.Height);
                    pictureCatRight.Location = new Point(0, -3 * panelBorderCatRight.Height);
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

                    pictureCatUp.Location = new Point(0, -1 * panelBorderCatUp.Height);
                    pictureCatDown.Location = new Point(0, -2 * panelBorderCatDown.Height);
                    pictureCatLeft.Location = new Point(0, -3 * panelBorderCatLeft.Height);
                    pictureCatRight.Location = new Point(0, 0 * panelBorderCatRight.Height);
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

                    pictureCatUp.Location = new Point(0, 0 * panelBorderCatUp.Height);
                    pictureCatDown.Location = new Point(0, -3 * panelBorderCatDown.Height);
                    pictureCatLeft.Location = new Point(0, -1 * panelBorderCatLeft.Height);
                    pictureCatRight.Location = new Point(0, -2 * panelBorderCatRight.Height);
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

                    pictureCatUp.Location = new Point(0, -3 * panelBorderCatUp.Height);
                    pictureCatDown.Location = new Point(0, 0 * panelBorderCatDown.Height);
                    pictureCatLeft.Location = new Point(0, -2 * panelBorderCatLeft.Height);
                    pictureCatRight.Location = new Point(0, -1 * panelBorderCatRight.Height);
                }
            }

            table.SetCellPosition(pictureTableCat, locationCat);

            if (pictureTableMeat.Visible && locationCat == locationMeatBawl)
            {
                pictureTableMeat.Visible = false;

                panelBawlsUp.Visible = false;
                panelBawlsDown.Visible = false;
                panelBawlsLeft.Visible = false;
                panelBawlsRight.Visible = false;

                buttonMeat.Enabled = true;
                buttonWater.Enabled = true;

                progressBarSatiety.Value = ((progressBarSatiety.Value + 7) < progressBarSatiety.Maximum) ? (progressBarSatiety.Value + 7) : (progressBarSatiety.Maximum);
                progressBarSatietyLack.Value = 0;

                progressBarSatietyLack.SetState((int)ProgressBarColors.Green);
                progressBarSatietyLack.SetState((int)ProgressBarColors.Red);

                if (progressBarSatiety.Value > progressBarSatiety.Maximum - progressBarSatietyExcess.Maximum)
                {
                    progressBarSatietyExcess.Value = progressBarSatiety.Value - (progressBarSatiety.Maximum - progressBarSatietyExcess.Maximum);

                    progressBarSatietyExcess.SetState((int)ProgressBarColors.Green);
                    progressBarSatietyExcess.SetState((int)ProgressBarColors.Yellow);
                }
            }

            if (pictureTableWater.Visible && locationCat == locationWaterBawl)
            {
                pictureTableWater.Visible = false;

                panelBawlsUp.Visible = false;
                panelBawlsDown.Visible = false;
                panelBawlsLeft.Visible = false;
                panelBawlsRight.Visible = false;

                buttonMeat.Enabled = true;
                buttonWater.Enabled = true;

                progressBarHydration.Value = ((progressBarHydration.Value + 7) < progressBarHydration.Maximum) ? (progressBarHydration.Value + 7) : (progressBarHydration.Maximum);
                progressBarHydrationLack.Value = 0;
                progressBarHydrationLack.SetState((int)ProgressBarColors.Green);
                progressBarHydrationLack.SetState((int)ProgressBarColors.Red);

                if (progressBarHydration.Value > progressBarHydration.Maximum - progressBarHydrationExcess.Maximum)
                {
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

            if (pictureTableMeat.Visible == false|| pictureTableMeat.Visible == false)
            {
                buttonMeat.Enabled = !buttonMeat.Enabled;
                buttonWater.Enabled = !buttonWater.Enabled;
            }
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

            panelBawlsUp.Location = new Point(panelBawlsUp.Width * (locationToGo.Column + 2), panelBawlsUp.Height * (locationToGo.Row + 2));
            pictureBawlsUp.Location = new Point(panelBawlsUp.Width * (-1), 0);

            panelBawlsDown.Location = new Point(panelBawlsDown.Width * (table.ColumnCount - locationToGo.Column - 1 + 2), panelBawlsDown.Height * (table.RowCount - locationToGo.Row - 1 + 2));
            pictureBawlsDown.Location = new Point(panelBawlsDown.Width * (-1), 0);

            panelBawlsLeft.Location = new Point(panelBawlsLeft.Width * (table.RowCount - locationToGo.Row - 1 + 2), panelBawlsLeft.Height * (locationToGo.Column + 2));
            pictureBawlsLeft.Location = new Point(panelBawlsLeft.Width * (-1), 0);

            panelBawlsRight.Location = new Point(panelBawlsRight.Width * (locationToGo.Row + 2), panelBawlsRight.Height * (table.ColumnCount - locationToGo.Column - 1 + 2));
            pictureBawlsRight.Location = new Point(panelBawlsRight.Width * (-1), 0);

            panelBawlsUp.Visible = true;
            panelBawlsDown.Visible = true;
            panelBawlsLeft.Visible = true;
            panelBawlsRight.Visible = true;
        }

        private void buttonWater_Click(object sender, EventArgs e)
        {
            locationWaterBawl = getRandomCell();
            table.SetCellPosition(pictureTableWater, locationWaterBawl);

            pictureTableWater.Visible = true;

            buttonMeat.Enabled = false;
            buttonWater.Enabled = false;

            locationToGo = locationWaterBawl;

            panelBawlsUp.Location = new Point(panelBawlsUp.Width * (locationToGo.Column + 2), panelBawlsUp.Height * (locationToGo.Row + 2));
            pictureBawlsUp.Location = new Point(panelBawlsUp.Width * (-2), 0);

            panelBawlsDown.Location = new Point(panelBawlsDown.Width * (table.ColumnCount - locationToGo.Column - 1 + 2), panelBawlsDown.Height * (table.RowCount - locationToGo.Row - 1 + 2));
            pictureBawlsDown.Location = new Point(panelBawlsDown.Width * (-2), 0);

            panelBawlsLeft.Location = new Point(panelBawlsLeft.Width * (table.RowCount - locationToGo.Row - 1 + 2), panelBawlsLeft.Height * (locationToGo.Column + 2));
            pictureBawlsLeft.Location = new Point(panelBawlsLeft.Width * (-2), 0);

            panelBawlsRight.Location = new Point(panelBawlsRight.Width * (locationToGo.Row + 2), panelBawlsRight.Height * (table.ColumnCount - locationToGo.Column - 1 + 2));
            pictureBawlsRight.Location = new Point(panelBawlsRight.Width * (-2), 0);

            panelBawlsUp.Visible = true;
            panelBawlsDown.Visible = true;
            panelBawlsLeft.Visible = true;
            panelBawlsRight.Visible = true;
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
