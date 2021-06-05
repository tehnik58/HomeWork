using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaperPleas
{
    class Init
    {
        Form form;
        ObjectBufer render;

        public Init(Paper _form)
        {
            form = _form;
            render = new ObjectBufer();
        }

        public void SetStaticObjBuffer()
        {
            render.SetLStaticObject
                (3,
                new GameObject(Color.Azure,
                new Point(form.ClientSize.Width / 6, form.ClientSize.Height / 6),
                new Size(form.ClientSize.Width * 4 / 6, form.ClientSize.Height / 3)));

            //стол
            render.SetLStaticObject
                (1,
                new GameObject(Color.Gray,
                new Point(100, form.ClientSize.Height / 2 + 100),
                new Size(form.ClientSize.Width - 200, form.ClientSize.Height / 2 - 100)));
        }

        public void SetActivObjBuffer()
        {
            var BaseBook = new Book(Color.Blue, new Point(100, form.ClientSize.Height / 2 + 101), new Size(150, 250), " ");
            BaseBook.label.Text =
                @"методичка:
1) Не пускайте студентов без студика УрФу

2) Не пускайте без масок";
            BaseBook.id = 1;
            render.AddObject(BaseBook);
        }

        public void SetMenBuffer()
        {
            var BaseBook = new Book(Color.Green, new Point(500, form.ClientSize.Height / 2 + 101), new Size(100, 50), " ");
            BaseBook.label.Text =
                @"студак УрФУ РТФ";
            BaseBook.id = 0;

            Men men = new Men(Color.Green, 
                new Point(0, 720 / 4), 
                new Size(300, 500), 
                BaseBook, 
                false);
            men.id = 0;

            render.AddMen(men);
        }

        public ObjectBufer SetRender()
        {
            return render;
        }
    }
}
