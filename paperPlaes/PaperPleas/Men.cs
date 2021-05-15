using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaperPleas
{
    class Men : GameObject
    {
        Book Ticket { get; set; }
        bool IsMask { get; set; }

        public Men(Image img, Point position, Size size, Book book, bool isMask) : base(img, position, size)
        {
            Ticket = book;
            IsMask = isMask;
        }

        public Men(Color c, Point position, Size size, Book book, bool isMask) : base(c, position, size)
        {
            Ticket = book;
            IsMask = isMask;
        }


        public void walk()
        {
            label.Location = new Point(label.Location.X, Convert.ToInt32(label.Location.Y * Math.Sin(label.Location.X)));
        }
    }
}
