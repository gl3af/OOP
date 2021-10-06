using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Rectangle
    {
        private int x, y, width, height;
        private bool SHOW;
        private Color color = Color.Red;

        public Rectangle()
        {
            var rand = new Random();
            x = rand.Next(51, 501);
            y = rand.Next(51, 501);
            width = rand.Next(1, 51);
            height = rand.Next(1, 51);
        }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
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
            gr.DrawRectangle(pen, this.x, this.y, width, height);
        }

        public void MoveTo(Graphics gr, int dx, int dy)
        {
            Show(gr, Color.White);
            x += dx;
            y += dy;
            Show(gr, color);
        }

        public void ChangeSides(Graphics gr, int width, int height)
        {
            Show(gr, Color.White);
            this.width = width;
            this.height = height;
            Show(gr, color);
        }
    }
}
