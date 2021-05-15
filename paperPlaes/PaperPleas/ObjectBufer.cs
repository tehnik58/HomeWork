using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PaperPleas
{
    class ObjectBufer
    {
        public List<List<GameObject>> StaticObjBuffer{ get; }
        public List<Book> ActivObjBuffer { get; }
        public List<Men> MenBuffer { private set; get; }

        public ObjectBufer()
        {
            StaticObjBuffer = new List<List<GameObject>>();
            ActivObjBuffer = new List<Book>();
            MenBuffer = new List<Men>();
        }

        public void AddMen(Men men)
        {
            MenBuffer.Add(men);
        }

        public void RemoveMen(Men men)
        {
            MenBuffer.Remove(men);
        }

        public void AddObject(Book gameObject)
        {
            ActivObjBuffer.Add(gameObject);
        }

        public void AddLvl(int lvl, GameObject obj)
        {
            StaticObjBuffer.Add(new List<GameObject>());
            AddLStaticObject(lvl, obj);
        }

        public void AddLStaticObject(int lvl, GameObject obj)
        {
            if (lvl >= StaticObjBuffer.Count)
                AddLvl(lvl, obj);
            else
                StaticObjBuffer[lvl].Add(obj);
        }
    }
}
