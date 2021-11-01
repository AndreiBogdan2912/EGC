using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Lab4
{
    class ManualTriangle
    {
        private int[] vec = new int[] { 8, 0, 5, 20, 0, 5, 17, 0, 14 };
        private int ok0 = 200;
        private int ok1 = 200;
        private int ok2 = 200;
        public bool IsDrawable { get; set; }

        public void Hide()
        {
            IsDrawable = false;
        }

        public void Show()
        {
            IsDrawable = true;
        }

        public void ToggleVisibility()
        {
            if (IsDrawable == true)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
        public void ManualMoveMe(bool _vertex1, bool _vertex2, bool _vertex3)
        {

            if (IsDrawable == false)
            {
                return;
            }
            if (_vertex1)
            {
                if (ok0 == 255)
                    ok0 = 0;
                ok0++;
                Console.WriteLine("RGB=(" + ok0 + "," + ok1 + "," + ok2 + ")");

            }
            if (_vertex2)
            {
                if (ok1 == 255)
                    ok1 = 0;

                ok1++;
                Console.WriteLine("RGB=(" + ok0 + "," + ok1 + "," + ok2 + ")");

            }
            if (_vertex3)
            {
                if (ok2 == 255)
                    ok2 = 0;

                ok2++;
                Console.WriteLine("RGB=(" + ok0 + "," + ok1 + "," + ok2 + ")");
            }
        }

            public void DrawMe()
        {
            if (IsDrawable == false)
            {
                return;
            }

            GL.Begin(PrimitiveType.Triangles);



            GL.Color3(Color.FromArgb(ok0, 0, 0));
            GL.Vertex3(vec[0], vec[1], vec[2]);
            GL.Color3(Color.FromArgb(0, ok1, 0));
            GL.Vertex3(vec[3], vec[4], vec[5]);
            GL.Color3(Color.FromArgb(0, 0, ok2));

            GL.Vertex3(vec[6], vec[7], vec[8]);

            GL.End();
        }
    }
 
}
