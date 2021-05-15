using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PaperPleas
{
    class ObjectBufer
    {
        public List<List<GameObject>> RenderLvl{ get; }
        public List<Book> RenderObj { get; }

        public ObjectBufer()
        {
            RenderLvl = new List<List<GameObject>>();
            RenderObj = new List<Book>();
        }

        public void AddObject(Book gameObject)
        {
            RenderObj.Add(gameObject);
        }

        public void AddLvl(int lvl, GameObject obj)
        {
            RenderLvl.Add(new List<GameObject>());
            AddLStaticObject(lvl, obj);
        }

        public void AddLStaticObject(int lvl, GameObject obj)
        {
            if (lvl >= RenderLvl.Count)
                AddLvl(lvl, obj);
            else
                RenderLvl[lvl].Add(obj);
        }
    }
}
