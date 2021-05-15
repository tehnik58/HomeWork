using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PaperPleas
{
    class Book : GameObject
    {
        public bool IsClick { get; private set; }
        public Book(Image img, Point position, Size size) : base(img, position, size) 
        { IsClick = false; }
        public Book(Color c, Point position, Size size) : base(c, position, size) 
        { IsClick = false; }
        public void SwitchClick(object Sender, EventArgs e) 
        {
            IsClick = !IsClick;
            if (IsClick)
                label.BackColor = Color.Blue;
            else
                label.BackColor = Color.Red;
        }
    }
}
