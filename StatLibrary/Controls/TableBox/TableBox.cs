using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Controls.TableBox
{
    public partial class TableBox : System.Windows.Forms.Control
    {
        private static float[] d_width = new float[12];
        private static float d_height;
               
        private Cell cell; 
 
        public TableBox()
        {
            InitializeComponent();
            Initialize();
        }

        public TableBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }

        private void Initialize ()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 10; i++)
            {
                d_width[i] = g.MeasureString(i.ToString("0"), this.Font).Width-3;
            }
            d_width[10] = g.MeasureString(" ", this.Font).Width-3;
            d_width[11] = g.MeasureString(",", this.Font).Width-3;
            d_height = g.MeasureString("0", this.Font).Height;
            cell = new Cell((decimal)100.25, 0, 0, d_width[8] * 8, d_height);
        }


        private void TableBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            cell.Paint(g, this.Font);
            g.DrawLine(Pens.Black, 0, 0, 0, 0);
        }
        
        public class Cell 
        {
            private decimal _value;
            private string s_value;
            private Size _size;
            private Point _location;
            private Rectangle _rectagle;


            public Cell(decimal value, int x, int y, int width, int height)
            {
                this._value = value;
                this.s_value = value.ToString();
                this._size = new Size(width, height);
                this._location=new Point(x,y);
                this._rectagle = new Rectangle(this._location, this._size);
            }

            public Cell(decimal value, int x, int y, float width, float height) : this(value, x, y, (int)width, (int)height) { }
            
            public Cell(int x, int y, int width, int height) : this(0, x, y, width, height) { }
            
            public void Paint(Graphics g, Font font)
            {
                g.DrawRectangle(Pens.Black,  this._rectagle);
                int l=this._rectagle.Width-5;
                for (int i = this._value.ToString().Length-1; i >= 0; i--)
                {
                    int d = (int)Char.GetNumericValue(s_value[i]);
                    if (d == -1)
                    {
                        l = l - (int)TableBox.d_width[11];
                        g.DrawString(",", font, Brushes.Black, l, 0);
                    }
                    else
                    {
                        l = l - (int)TableBox.d_width[d];
                        g.DrawString(d.ToString(), font, Brushes.Black,l,0);               
                   }
                } 
            }
        }
    }
}
