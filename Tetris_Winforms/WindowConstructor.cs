using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Tetris_Winforms
{
    public partial class WindowConstructor : Form
    {
        public int[,] customPattern = new int[4,4];
        private int totalBlocks = 8;
        private int activeBlocks = 0;

        public WindowConstructor()
        {
            InitializeComponent();
        }

        private void block00_Click(object sender, EventArgs e)
        {

            if (customPattern[0, 0] == 0 && totalBlocks > 0 && HasAdjacent(0, 0))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[0, 0] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[0, 0] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[0, 0] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block01_Click(object sender, EventArgs e)
        {

            if (customPattern[0, 1] == 0 && totalBlocks > 0 && HasAdjacent(0, 1))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[0, 1] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[0, 1] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[0, 1] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block02_Click(object sender, EventArgs e)
        {

            if (customPattern[0, 2] == 0 && totalBlocks >= 0 && HasAdjacent(0, 2))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[0, 2] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[0, 2] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[0, 2] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block03_Click(object sender, EventArgs e)
        {

            if (customPattern[0, 3] == 0 && totalBlocks > 0 && HasAdjacent(0, 3))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[0, 3] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[0, 3] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[0, 3] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block10_Click(object sender, EventArgs e)
        {

            if (customPattern[1, 0] == 0 && totalBlocks > 0 && HasAdjacent(1, 0))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[1, 0] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[1, 0] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[1,0] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block11_Click(object sender, EventArgs e)
        {

            if (customPattern[1, 1] == 0 && totalBlocks > 0 && HasAdjacent(1, 1))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[1, 1] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[1, 1] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[1, 1] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block12_Click(object sender, EventArgs e)
        {

            if (customPattern[1, 2] == 0 && totalBlocks > 0 && HasAdjacent(1, 2))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[1, 2] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[1, 2] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[1, 2] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block13_Click(object sender, EventArgs e)
        {

            if (customPattern[1,3] == 0 && totalBlocks > 0 && HasAdjacent(1, 3))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[1, 3] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[1, 3] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[1, 3] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block20_Click(object sender, EventArgs e)
        {

            if (customPattern[2, 0] == 0 && totalBlocks > 0 && HasAdjacent(2, 0))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[2, 0] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[2, 0] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[2, 0] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block21_Click(object sender, EventArgs e)
        {

            if (customPattern[2, 1] == 0 && totalBlocks > 0 && HasAdjacent(2, 1))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[2, 1] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[2, 1] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[2, 1] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block22_Click(object sender, EventArgs e)
        {

            if (customPattern[2, 2] == 0 && totalBlocks > 0 && HasAdjacent(2, 2))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[2, 2] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[2, 2] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[2, 2] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block23_Click(object sender, EventArgs e)
        {

            if (customPattern[2, 3] == 0 && totalBlocks > 0 && HasAdjacent(2, 3))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[2, 3] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[2, 3] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[2, 3] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block30_Click(object sender, EventArgs e)
        {

            if (customPattern[3, 0] == 0 && totalBlocks > 0 && HasAdjacent(3, 0))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[3, 0] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[3, 0] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[3, 0] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block31_Click(object sender, EventArgs e)
        {

            if (customPattern[3, 1] == 0 && totalBlocks > 0 && HasAdjacent(3, 1) )
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[3, 1] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[3, 1] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[3, 1] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block32_Click(object sender, EventArgs e)
        {

            if (customPattern[3, 2] == 0 && totalBlocks > 0 && HasAdjacent(3, 2))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[3, 2] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[3, 2] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[3, 2] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private void block33_Click(object sender, EventArgs e)
        {

            if (customPattern[3, 3] == 0 && totalBlocks >= 0 && HasAdjacent(3,3))
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Green;
                customPattern[3, 3] = 1;
                activeBlocks++;
                totalBlocks--;
                this.label3.Text = totalBlocks.ToString();
            }
            else if (customPattern[3, 3] == 1)
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGray;
                customPattern[3, 3] = 0;
                activeBlocks--;
                totalBlocks++;
                this.label3.Text = totalBlocks.ToString();
            }
        }
        private bool HasAdjacent(int y, int x)
        {
            if (activeBlocks == 0)
            {
                return true;
            }
            if (y > 0 && y <= 3 )
            {
                if (customPattern[y - 1, x] == 1)
                {
                    return true;
                }
            }
            if (y >= 0 && y < 3)
            {
                if (customPattern[y + 1, x] == 1)
                {
                    return true;
                }
            }
            if (x > 0 && x <= 3)
            {
                if (customPattern[y, x - 1] == 1)
                {
                    return true;
                }
            }
            if (x >= 0 && x < 3)
            {
                if (customPattern[y, x + 1] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddCustomShape_Click(object sender, EventArgs e)
        {
            
            
            if (activeBlocks > 1)
            {
                AddCustomShape.DialogResult= DialogResult.OK;
            }
            else
            {
                AddCustomShape.DialogResult = DialogResult.None;
            }
            
            this.Hide();

        }
    }
}
