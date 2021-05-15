using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaperPleas
{
    static class Restriction
    {
        public static Point Location = new Point();
        public static Size RestSize = new Size();
        public static bool InRest(Book book)
        {
            return book.label.Location.Y + book.label.Size.Height < Location.Y;
        }
    }

    public partial class paper : Form
    {
        ObjectBufer render = new ObjectBufer();
        List<Book> AllTypeBook = new List<Book>();

        void InitGameObject()
        {
            Restriction.Location = new Point(100, ClientSize.Height / 2 + 100);
            Restriction.RestSize = new Size(ClientSize.Width - 200, ClientSize.Height / 2 - 100);

            // окно позвди
            render.AddLStaticObject
                (3,
                new GameObject(Color.Azure,
                new Point(ClientSize.Width / 6, ClientSize.Height / 6),
                new Size(ClientSize.Width * 4 / 6, ClientSize.Height / 3)));
            //стол
            render.AddLStaticObject
                (1,
                new GameObject(Color.Gray,
                new Point(100, ClientSize.Height / 2 + 100),
                new Size(ClientSize.Width - 200, ClientSize.Height / 2 - 100)));
            //методичка что делать
            var BaseBook = new Book(Color.Red, new Point(100, ClientSize.Height / 2 + 101), new Size(150, 250));
            BaseBook.label.Text =
                @"методичка:
1) Не пускайте студентов без студика УрФу

2) Не пускайте без масок";
            render.AddObject(BaseBook);
            BaseBook.label.Click += new EventHandler(BaseBook.SwitchClick);
        }

        void Drow()
        {
            foreach (var obj in render.RenderObj)
            {
                if (obj.IsClick)
                    obj.label.Location = this.PointToClient(Cursor.Position);
                else if (Restriction.InRest(obj))
                {
                    render.RenderObj.Remove(obj);
                    Controls.Remove(obj.label);
                    break;
                }

                Controls.Add(obj.label); 
            }

            for (var i = 1; i < render.RenderLvl.Count; i++)
                foreach (var obj in render.RenderLvl[i])
                    Controls.Add(obj.label);
        }

        void Tick(object Sender, EventArgs e)
        {
            Drow();
        }

        public paper()
        {
            InitializeComponent();

            InitGameObject();

            Timer timer = new Timer();
            timer.Interval = 33;
            timer.Tick += new EventHandler(Tick);
            timer.Enabled = true;
        }
    }
}
