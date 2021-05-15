using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaperPleas
{
    class GameObject
    {
        public Label label { get; private set; }

        public GameObject(Image img, Point position, Size size)
        {
            label = new Label();
            label.Image = img;
            label.Location = position;
            label.Size = size;
        }

        public GameObject(Color c, Point position, Size size)
        {
            label = new Label();
            label.BackColor = c;
            label.Location = position;
            label.Size = size;
        }
    }
}
