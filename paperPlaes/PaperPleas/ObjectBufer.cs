using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PaperPleas
{
    class ObjectBufer
    {
        public List<List<GameObject>> StaticObjBuffer { get; set; }
        public List<Book> ActivObjBuffer { get; set; }
        public List<Men> MenBuffer { set; get; }

        public ObjectBufer(ObjectBufer obj)
        {
            this.StaticObjBuffer = obj.StaticObjBuffer;
            this.ActivObjBuffer = obj.ActivObjBuffer;
            this.MenBuffer = obj.MenBuffer;
        }

        public ObjectBufer()
        {
            StaticObjBuffer = new List<List<GameObject>>();
            ActivObjBuffer = new List<Book>();
            MenBuffer = new List<Men>();
        }

        public void set(ObjectBufer obj)
        {
            this.StaticObjBuffer = obj.StaticObjBuffer;
            this.ActivObjBuffer = obj.ActivObjBuffer;
            this.MenBuffer = obj.MenBuffer;
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
            SetLStaticObject(lvl, obj);
        }

        public void SetLStaticObject(int lvl, GameObject obj)
        {
            if (lvl >= StaticObjBuffer.Count)
                AddLvl(lvl, obj);
            else
                StaticObjBuffer[lvl].Add(obj);
        }
    }
}
