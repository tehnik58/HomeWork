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

    public partial class Paper : Form
    {
        private ObjectBufer render     = new ObjectBufer();
        private readonly Timer       timer      = new Timer();
        private          bool        fps60      = false;            // флаг на 60 фпс
        private readonly List<Book>  noRealBook = new List<Book>();

        private void InitGame()
        {
            Restriction.Location = new Point(100, ClientSize.Height / 2 + 100);
            Restriction.RestSize = new Size(ClientSize.Width - 200, ClientSize.Height / 2 - 100);

            Init init = new Init(this);
            Game.InitgameObject(ref render, ref init);
        }

        private void DrowActivObject()
        {
            foreach (var obj in render.ActivObjBuffer)
                Controls.Add(obj.label);
        }

        private void DrowStaticObjectAndMen()
        {
            for (var i = 1; i < render.StaticObjBuffer.Count; i++)
            {
                if (i == 2) DrowMen();

                foreach (var obj in render.StaticObjBuffer[i])
                {
                    Controls.Add(obj.label);
                }
            }
        }

        private void DrowMen()
        {
            if (render.MenBuffer.Count >= 1)
                foreach (var man in render.MenBuffer)
                    Controls.Add(man.label);
        }

        private void clear()
        {
            foreach (var e in render.StaticObjBuffer)
                foreach (var a in e)
                    Controls.Remove(a.label);

            foreach (var e in render.ActivObjBuffer)
                Controls.Remove(e.label);

            foreach (var e in render.MenBuffer)
                Controls.Remove(e.label);
        }

        private void Drow()
        {
            clear();
            DrowActivObject();
            DrowStaticObjectAndMen();

            foreach (var e in render.ActivObjBuffer)
            {
                e.label.Click += new EventHandler(e.SwitchClick);
            }
        }

        private void ChangeFps(object Sender, EventArgs e)
        {
            fps60 = !fps60;

            if (fps60)
                timer.Interval = 33/2;
            else
                timer.Interval = 33;
        }

        CheckBox box = new CheckBox();
        private void Tick(object Sender, EventArgs e)
        {
            Game.GameLogic(ref render, Cursor.Position, fps60, this);
            Drow();

            box.Text = @"60 fps";
            box.Location = new Point(0, 0);
            Controls.Add(box);

            box.MouseClick += (ChangeFps);
        }

        public Paper()
        {
            InitializeComponent();

            InitGame();

            timer.Interval = 33;
            timer.Tick += new EventHandler(Tick);
            timer.Enabled = true;
        }
    }
}