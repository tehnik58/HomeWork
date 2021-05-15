using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PaperPleas
{
    class Book : GameObject
    {
        public bool IsClick { get; private set; }
        public Book(Image img, Point position, Size size, string text) : base(img, position, size) 
        {
            IsClick = false;
            label.Text = text;
            Text = text;
        }

        public Book(Color c, Point position, Size size, string text) : base(c, position, size)
        {
            IsClick = false;
            label.Text = text;
            Text = text;
        }

        public string Text {private set; get; }
        public void SwitchClick(object Sender, EventArgs e) 
        {
            IsClick = !IsClick;
            if (IsClick)
                label.BackColor = Color.Red;
            else
                label.BackColor = Color.Blue;
        }
    }
}
