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
using Tetris_dll;
using Tetris_dll.Elements;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tetris_Winforms
{
    public partial class Tetris_Game : Form
    {
        private TetrisGame game;
        private const int size = 25;
        private bool IsPaused = false;
        
        
        public Tetris_Game()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(KeyControl);
            game = new TetrisGame();
            Init();
        }
        public void Init()
        {
            timer1.Interval = 500;
            timer1.Tick -= new EventHandler(update);
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            Invalidate();
        }
        private void update(object sender, EventArgs e)
        {
            game.ResetArea();
            if (!game.Collide())
            {
                game.GetcurrentShape().MoveDown();
            }
            else
            {
                game.Merge();
                game.SliceMap();

                game.Nextshape();
                if (game.Collide())
                {
                    game.ClearMap();
                    timer1.Tick -= new EventHandler(update);
                    timer1.Stop();
                    Init();
                }
            }
            game.Merge();
            Invalidate();
        }
        private void KeyControl(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (!game.CollideHor(-1))
                    {
                        game.ResetArea();
                        game.GetcurrentShape().MoveLeft();
                        game.Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Up:
                    if (!game.IsIntersects())
                    {
                        game.ResetArea();
                        game.GetcurrentShape().Rotate();
                        game.Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Right:
                    if (!game.CollideHor(1))
                    {
                        game.ResetArea();
                        game.GetcurrentShape().MoveRight();
                        game.Merge();
                        Invalidate();
                    }
                    break;

                default:
                    break;
            }
        }
        public static void DrawMap(Graphics e, Field field)
        {
            Brush color = null;
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    switch (field.Grid[i, j])
                    {
                        case 0:
                            color = Brushes.White; break;
                        case 1:
                            color = Brushes.Red; break;
                        case 2:
                            color = Brushes.Yellow; break;
                            case 3:
                                color = Brushes.Green; break;
                        case 4: 
                            color= Brushes.Blue; break;
                        case 5:
                            color = Brushes.Purple; break;
                        default:
                            color = Brushes.Orange;
                            break;
                    }

                        e.FillRectangle(color, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var field = game.GetField();
            DrawMap(e.Graphics, field);
        }

        private void ConstrucrotWindow_Click(object sender, EventArgs e)
        {
            WindowConstructor shapeConstructor = new WindowConstructor(); 
            shapeConstructor.ShowDialog();
            if (shapeConstructor.ShowDialog() == DialogResult.OK)
            {
                game.AddCustomShape(shapeConstructor.customPattern);
                MessageBox.Show("Фигура добавлена");
            }
        }

        private void NotActive(object sender, EventArgs e)
        {
            IsPaused = true;
            timer1.Stop();
        }

        private void CancelPause(object sender, EventArgs e)
        {
            if (IsPaused)
            {
                timer1.Start();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var text = toolStripTextBox1.Text;
            if (text.Length > 0 && (text.Length > 2 || !text.All(x => char.IsDigit(x))))
            {
                toolStripTextBox1.Text = string.Empty;
            }
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            var text = toolStripTextBox2.Text;
            if (text.Length > 0 && (text.Length > 2 || !text.All(x => char.IsDigit(x))))
            {
                toolStripTextBox2.Text = string.Empty;
            }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var height = toolStripTextBox1.Text;
            var width = toolStripTextBox2.Text;
            if (!string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(width))
            {
                int customHeight = int.Parse(height);
                int customWidth = int.Parse(width);
                if (customHeight < 20)
                { 
                    toolStripTextBox1.Text = "20";
                }
                if (customHeight >= (int)(this.Height - 25) / 25 )
                {
                    customHeight = (this.Height - 100) / 25;
                }
                if (customWidth >= (int)this.Width / 25)
                {
                    customWidth = (this.Width - 100) / 25;
                }
                if (customWidth < 15)
                {
                    toolStripTextBox2.Text = "15";
                }
                game.ChangeGridParameters(customHeight, customWidth);
                Init();
                MessageBox.Show("Изменения внесены");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            game = new TetrisGame();
            Init();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

