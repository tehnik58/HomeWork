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
        public bool WithDoc { get; set; }
        public bool IsCanGo { set; get; }
        public int id { get; set; }
        public Men(Image img, Point position, Size size, Book book, bool isMask) : base(img, position, size)
        {
            Ticket = book;
            //IsMask = isMask;
            IsCanGo = false;
            WithDoc = true;
        }

        public void withDocSwitch() => WithDoc = !WithDoc;

        public Men(Color c, Point position, Size size, Book book, bool isMask) : base(c, position, size)
        {
            Ticket = book;
            //IsMask = isMask;
            IsCanGo = false;
            WithDoc = true;
        }

        public Book GetBook()
        {
            return Ticket;
        }

        public void Move(int x, int y)
        {
            if (label.Location.X <= 1280/2 || IsCanGo)
                label.Location = new Point(label.Location.X + x, label.Location.Y + y);
        }
        public void Move64(int x, int y)
        {
            if (label.Location.X <= 1280 / 2 || IsCanGo)
                label.Location = new Point(label.Location.X + x/2, label.Location.Y + y/2);     
        }

        static private Book RandomBook(int id, bool fl)
        {
            string txt = fl ? "стройка": "ртф";
            var book = new Book(Color.Green, new Point(500, 720 / 2 + 101), new Size(100, 50), txt);
            return book;
        }

        static public Men GeneratRandomMen()
        {
            Color c = Color.Red;
            Point pos = new Point(0, 720 / 4);
            Size size = new Size(300, 500);

            var r = new Random();

            int id = r.Next();
            bool f = id % 2 == 0;

            Book book = RandomBook(id, f);

            var men = new Men(c, pos, size, book, false);
            men.id = f ? book.id : 0;

            return men;
        }

        public void walk()
        {
            label.Location = new Point(label.Location.X, Convert.ToInt32(label.Location.Y * Math.Sin(label.Location.X)));
        }
    }
}
