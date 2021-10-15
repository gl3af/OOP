using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Square
    {
        private int x, y, side;
        private bool SHOW;
        private Color color = Color.Red;

        public Square()
        {
            var rand = new Random();
            x = rand.Next(55, 501);
            y = rand.Next(50, 501);
            side = rand.Next(0, 51);
        }

        public Square(int x, int y, int side)
        {
            this.x = x;
            this.y = y;
            this.side = side;
        }

        public bool IsVisible()
        {
            return SHOW;
        }

        public void SetVisibility(bool v)
        {
            SHOW = v;
        }

        public void Show(Graphics gr, Color color)
        {
            Pen pen = new Pen(color, 2);
            gr.DrawRectangle(pen, this.x, this.y, side, side);
        }

        public void MoveTo(Graphics gr, int dx, int dy)
        {
            Show(gr, Color.White);
            x += dx;
            y += dy;
            Show(gr, color);
        }
    }
}
