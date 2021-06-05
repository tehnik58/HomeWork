using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PaperPleas
{
    static class Game
    {
        static public void InitgameObject(ref ObjectBufer render, ref Init init)
        {
            init.SetStaticObjBuffer();
            init.SetActivObjBuffer();
            init.SetMenBuffer();
            render.set(init.SetRender());

            foreach (var e in render.ActivObjBuffer)
                e.label.Click += new EventHandler(e.SwitchClick);
        }

        static private void MenLogic(ref ObjectBufer render, bool is60fps)
        {
            if (render.MenBuffer.Count > 0)
                foreach (var men in render.MenBuffer)
                {
                    if (is60fps)
                        men.Move(20, 0);
                    else
                        men.Move64(20, 0);

                    if (men.label.Location.X >= 1280 / 2 - 100 && !men.IsCanGo && men.WithDoc)
                    {
                        men.withDocSwitch();
                        render.ActivObjBuffer.Add(men.GetBook());
                    }

                    if (men.label.Location.X >= 1280 - 100)
                    {
                        Men m = Men.GeneratRandomMen();
                        render.MenBuffer.Add(m);
                        render.ActivObjBuffer.Add(m.GetBook());
                        render.MenBuffer.Remove(men);
                        break;
                    }
                }
        }

        static void ActivObjectLogic(ref ObjectBufer render, Point mouse, Paper form)
        {
            foreach (var obj in render.ActivObjBuffer)
            {
                if (!obj.IsClick && Restriction.InRest(obj))
                {
                    foreach (var men in render.MenBuffer)
                        if (obj.id == men.id)
                        {
                            men.IsCanGo = true;
                            render.AddObject(men.GetBook());
                        }
                    render.ActivObjBuffer.Remove(obj);
                    break;
                }
                if (obj.IsClick)
                {
                    obj.label.Location = form.PointToClient(new Point(mouse.X - 50, mouse.Y - 25));
                }
            }
        }


        static public void GameLogic(ref ObjectBufer render, Point mouse, bool is60fps, Paper form)
        {
            MenLogic(ref render, is60fps);
            ActivObjectLogic(ref render, mouse, form);
        }
    }
}
