using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Lab4

{
    class Axes
    {

        private bool visibility;
        private int xyzSize;
        private Color colorX, colorY, colorZ;

        public Axes()
        {
            visibility = true;
            xyzSize = 75;
            colorX = Color.Red;
            colorY = Color.Green;
            colorZ =Color.Blue;
        }

        public Axes(int _ax)
        {
            visibility = true;
            xyzSize = _ax;
        }
        public Axes(int _ax,Color c1,Color c2,Color c3)
        {
            visibility = true;
            xyzSize = _ax;
            colorX = c1;
            colorY = c2;
            colorZ = c3;
        }
        public Axes( Color c1, Color c2, Color c3)
        {
            visibility = true;
            xyzSize = 75;
            colorX = c1;
            colorY = c2;
            colorZ = c3;
        }

        public bool GetVisibility()
        {
            return visibility;
        }

        public void ShowMe()
        {
            visibility = true;
        }

        public void HideMe()
        {
            visibility = false;
        }

        public void ToggleVisibility()
        {
            if (visibility)
            {
                visibility = false;
            }
            else
            {
                visibility = true;
            }
        }

        public void DrawMe()
        {

            if (!visibility)
            {
                return;
            }

            // Set color/coords for Ox.
            GL.Color3(colorX);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(xyzSize, 0, 0);
            GL.End();

            // Set color/coords for Oy.
            GL.Color3(colorY);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, xyzSize, 0);
            GL.End();

            // Set color/coords for Oz.
            GL.Color3(colorZ);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, xyzSize);
            GL.End();
        }

    }

}
