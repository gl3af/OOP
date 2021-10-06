using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Circle
    {
        private int x, y, r;
        private bool SHOW;
        private Color color = Color.Red;

        public Circle()
        {
            var rand = new Random();
            x = rand.Next(55, 501);
            y = rand.Next(50, 501);
            r = rand.Next(0, 51);
        }

        public Circle(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
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
            gr.DrawEllipse(pen, this.x - r, this.y - r, 2*r, 2*r);
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
