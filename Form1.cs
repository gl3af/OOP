using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class main_form : Form
    {

        #region Variables
        // Graphics
        Bitmap bmp;
        Graphics gr;

        //Circle
        Circle circle;
        Circle[] circle_data;
        int circle_count;

        //Rect
        Rectangle rect;
        Rectangle[] rect_data;
        int rect_count;

        //Square
        Square square;
        Square[] square_data;
        int square_count;
        #endregion
        public main_form()
        {
            InitializeComponent();
            circle_count = 0;
            rect_count = 0;
            square_count = 0;
            circle_data = new Circle[100];
            rect_data = new Rectangle[100];
            square_data = new Square[100];
            bmp = new Bitmap(main_picture.Width, main_picture.Height);
            gr = Graphics.FromImage(bmp);
        }

        public bool IsNumber(string str)
        {
            try
            {
                var t = Convert.ToInt32(str);
            }
            catch
            {
                return false;
            }

            return true;
        }

        #region Circle_Create
        private void circle_create_random_Click(object sender, EventArgs e)
        {
            circle = new Circle();
            MessageBox.Show($"Круг создан! ID: {circle_count}");
            circle_data[circle_count] = circle;
            circle_data[circle_count].SetVisibility(true);
            circle_data[circle_count++].Show(gr, Color.Red);
            main_picture.Image = bmp;
        }

        private void circle_create_Click(object sender, EventArgs e)
        {
            var x = circle_create_x.Text;
            var y = circle_create_y.Text;
            var r = circle_create_r.Text;

            if (String.IsNullOrWhiteSpace(x) || String.IsNullOrWhiteSpace(y) || String.IsNullOrWhiteSpace(r))
            {
                MessageBox.Show("Поле(-я) пустое(-ые)!");
            }
            else
            {
                if (IsNumber(x) && IsNumber(y) && IsNumber(r))
                {
                    circle = new Circle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(r));
                    MessageBox.Show($"Круг создан! ID: {circle_count}");
                    circle_data[circle_count] = circle;
                    circle_data[circle_count].SetVisibility(true);
                    circle_data[circle_count++].Show(gr, Color.Red);
                    main_picture.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }
        #endregion

        #region Circle_Move
        private void circle_move_all_Click(object sender, EventArgs e)
        {
            var dx = circle_move_x.Text;
            var dy = circle_move_y.Text;

            if (String.IsNullOrWhiteSpace(dx) || String.IsNullOrWhiteSpace(dy))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(dx) && IsNumber(dy))
                {
                    for (int i = 0; i < circle_count; i++)
                    {
                        if (circle_data[i].IsVisible())
                            circle_data[i].MoveTo(gr, Convert.ToInt32(dx), Convert.ToInt32(dy));
                    }
                    main_picture.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        private void circle_move_by_id_Click(object sender, EventArgs e)
        {
            var dx = circle_move_x.Text;
            var dy = circle_move_y.Text;
            var id = circle_move_id.Text;

            if (String.IsNullOrWhiteSpace(dx) || String.IsNullOrWhiteSpace(dy) || String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < circle_count; i++)
                    {
                        if (circle_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        if (IsNumber(dx) && IsNumber(dy))
                        {
                            circle_data[Convert.ToInt32(id)].MoveTo(gr, Convert.ToInt32(dx), Convert.ToInt32(dy));
                            main_picture.Image = bmp;
                        }
                        else
                        {
                            MessageBox.Show("Введены не натуральные числа!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        #endregion

        #region Circle_Delete
        private void circle_delete_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < circle_count; i++)
            {
                circle_data[i].SetVisibility(false);
                circle_data[i].Show(gr, main_picture.BackColor);
            }
            main_picture.Image = bmp;
        }

        private void circle_delete_by_id_Click(object sender, EventArgs e)
        {
            var id = circle_delete_id.Text;

            if (String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле пустое!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < circle_count; i++)
                    {
                        if (circle_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        circle_data[Convert.ToInt32(id)].Show(gr, main_picture.BackColor);
                        circle_data[Convert.ToInt32(id)].SetVisibility(false);
                        main_picture.Image = bmp;
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        #endregion

        #region Rect_Create
        private void rect_create_random_Click(object sender, EventArgs e)
        {
            rect = new Rectangle();
            MessageBox.Show($"Прямоугольник создан! ID: {rect_count}");
            rect_data[rect_count] = rect;
            rect_data[rect_count].SetVisibility(true);
            rect_data[rect_count++].Show(gr, Color.Red);
            main_picture.Image = bmp;
        }

        private void rect_create_Click(object sender, EventArgs e)
        {
            var x = rect_create_x.Text;
            var y = rect_create_y.Text;
            var w = rect_create_width.Text;
            var h = rect_create_height.Text;

            if (String.IsNullOrWhiteSpace(x) || String.IsNullOrWhiteSpace(y) || String.IsNullOrWhiteSpace(w) || String.IsNullOrWhiteSpace(h))
            {
                MessageBox.Show("Поле(-я) пустое(-ые)!");
            }
            else
            {
                if (IsNumber(x) && IsNumber(y) && IsNumber(w) && IsNumber(h))
                {
                    rect = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(w), Convert.ToInt32(h));
                    MessageBox.Show($"Прямоугольник создан! ID: {circle_count}");
                    rect_data[rect_count] = rect;
                    rect_data[rect_count].SetVisibility(true);
                    rect_data[rect_count++].Show(gr, Color.Red);
                    main_picture.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }
        #endregion

        #region Rect_Move
        private void rect_move_all_Click(object sender, EventArgs e)
        {
            var dw = rect_move_x.Text;
            var dh = rect_move_y.Text;

            if (String.IsNullOrWhiteSpace(dw) || String.IsNullOrWhiteSpace(dh))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(dw) && IsNumber(dh))
                {
                    for (int i = 0; i < rect_count; i++)
                    {
                        if (rect_data[i].IsVisible())
                            rect_data[i].MoveTo(gr, Convert.ToInt32(dw), Convert.ToInt32(dh));
                    }
                    main_picture.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        private void rect_move_by_id_Click(object sender, EventArgs e)
        {
            var dw = rect_move_x.Text;
            var dh = rect_move_y.Text;
            var id = rect_move_id.Text;

            if (String.IsNullOrWhiteSpace(dw) || String.IsNullOrWhiteSpace(dh) || String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < rect_count; i++)
                    {
                        if (rect_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        if (IsNumber(dw) && IsNumber(dh))
                        {
                            rect_data[Convert.ToInt32(id)].MoveTo(gr, Convert.ToInt32(dw), Convert.ToInt32(dh));
                            main_picture.Image = bmp;
                        }
                        else
                        {
                            MessageBox.Show("Введены не натуральные числа!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }
        #endregion

        #region Rect_Delete
        private void rect_delete_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rect_count; i++)
            {
                rect_data[i].SetVisibility(false);
                rect_data[i].Show(gr, main_picture.BackColor);
            }
            main_picture.Image = bmp;
        }

        private void rect_delete_by_id_Click(object sender, EventArgs e)
        {
            var id = rect_delete_id.Text;

            if (String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле пустое!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < rect_count; i++)
                    {
                        if (rect_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        rect_data[Convert.ToInt32(id)].Show(gr, main_picture.BackColor);
                        rect_data[Convert.ToInt32(id)].SetVisibility(false);
                        main_picture.Image = bmp;
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }
        #endregion

        #region Rect_Change
        private void rect_change_Click(object sender, EventArgs e)
        {
            var nw = rect_change_width.Text;
            var nh = rect_change_height.Text;
            var id = rect_change_id.Text;

            if (String.IsNullOrWhiteSpace(nw) || String.IsNullOrWhiteSpace(nh) || String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < rect_count; i++)
                    {
                        if (rect_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        if (IsNumber(nw) && IsNumber(nh))
                        {
                            rect_data[Convert.ToInt32(id)].ChangeSides(gr, Convert.ToInt32(nw), Convert.ToInt32(nh));
                            main_picture.Image = bmp;
                        }
                        else
                        {
                            MessageBox.Show("Введены не натуральные числа!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        #endregion

        #region Square_Create

        private void square_create_random_Click(object sender, EventArgs e)
        {
            square = new Square();
            MessageBox.Show($"Круг создан! ID: {square_count}");
            square_data[square_count] = square;
            square_data[square_count].SetVisibility(true);
            square_data[square_count++].Show(gr, Color.Red);
            main_picture.Image = bmp;
        }

        private void square_create_Click(object sender, EventArgs e)
        {
            var x = square_create_x.Text;
            var y = square_create_y.Text;
            var side = square_create_side.Text;

            if (String.IsNullOrWhiteSpace(x) || String.IsNullOrWhiteSpace(y) || String.IsNullOrWhiteSpace(side))
            {
                MessageBox.Show("Поле(-я) пустое(-ые)!");
            }
            else
            {
                if (IsNumber(x) && IsNumber(y) && IsNumber(side))
                {
                    circle = new Circle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(side));
                    MessageBox.Show($"Круг создан! ID: {square_count}");
                    square_data[square_count] = square;
                    square_data[square_count].SetVisibility(true);
                    square_data[square_count++].Show(gr, Color.Red);
                    main_picture.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        #endregion

        #region Square_Move

        private void square_move_all_Click(object sender, EventArgs e)
        {
            var dx = square_move_x.Text;
            var dy = square_move_y.Text;

            if (String.IsNullOrWhiteSpace(dx) || String.IsNullOrWhiteSpace(dy))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(dx) && IsNumber(dy))
                {
                    for (int i = 0; i < square_count; i++)
                    {
                        if (square_data[i].IsVisible())
                            square_data[i].MoveTo(gr, Convert.ToInt32(dx), Convert.ToInt32(dy));
                    }
                    main_picture.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        private void square_move_by_id_Click(object sender, EventArgs e)
        {
            var dx = circle_move_x.Text;
            var dy = circle_move_y.Text;
            var id = circle_move_id.Text;

            if (String.IsNullOrWhiteSpace(dx) || String.IsNullOrWhiteSpace(dy) || String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле(-я) пустые!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < circle_count; i++)
                    {
                        if (square_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        if (IsNumber(dx) && IsNumber(dy))
                        {
                            square_data[Convert.ToInt32(id)].MoveTo(gr, Convert.ToInt32(dx), Convert.ToInt32(dy));
                            main_picture.Image = bmp;
                        }
                        else
                        {
                            MessageBox.Show("Введены не натуральные числа!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }

        #endregion

        #region Square_Delete
        private void square_delete_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < square_count; i++)
            {
                square_data[i].SetVisibility(false);
                square_data[i].Show(gr, main_picture.BackColor);
            }
            main_picture.Image = bmp;
        }

        private void square_delete_by_id_Click(object sender, EventArgs e)
        {
            var id = square_delete_id.Text;

            if (String.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Поле пустое!");
            }
            else
            {
                if (IsNumber(id))
                {
                    int[] id_list = new int[100];
                    for (int i = 0; i < 100; i++)
                    {
                        id_list[i] = -1;
                    }
                    int k = 0;
                    for (int i = 0; i < square_count; i++)
                    {
                        if (square_data[i].IsVisible())
                            id_list[k++] = i;
                    }

                    if (!id_list.Contains<int>(Convert.ToInt32(id)))
                    {
                        String ids = "";
                        for (int i = 0; i < k; i++)
                        {
                            ids = ids + id_list[i].ToString() + " ";
                        }
                        MessageBox.Show("Неверный ID! Доступные ID: " + ids);
                    }
                    else
                    {
                        square_data[Convert.ToInt32(id)].Show(gr, main_picture.BackColor);
                        square_data[Convert.ToInt32(id)].SetVisibility(false);
                        main_picture.Image = bmp;
                    }
                }
                else
                {
                    MessageBox.Show("Введены не натуральные числа!");
                }
            }
        }
        #endregion
    }
}