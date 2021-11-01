using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Lab4
{
    class ManualCube
    {
       
        ReadFile File;
        Random ran = new Random();
        // culori pentru fiecare fata a cubului 
        private Color ColorFace1;
        private Color ColorFace2;
        private Color ColorFace3;
        private Color ColorFace4;
        private Color ColorFace5;
        private Color ColorFace6;

        // voriabile pentru retinerea indexului generat de random
        private int a, b, c;

        private int transStep = 0;
        private int radStep = 0;
        private int attStep = 0;

       

        private bool newStatus = false;





        private int[] objVertex;

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
        public bool IsToggleStatus() {
            return newStatus;
        }
        public void ToggleStatus() {
            if (newStatus == true)
            { newStatus = false; }
            else{
                newStatus = true;

            }
        }
        public void ManualMoveMe(bool _transStep1, bool _transStep2, bool _radStep1, bool _radStep2, bool _attStep1, bool _attStep2)
        {

            if (IsDrawable == false)
            {
                return;
            }
            if (_transStep1)
            {
                transStep--;
            }
            if (_transStep2)
            {
                transStep++;
            }

            if (_radStep1)
            {
                radStep--;
            }
            if (_radStep2)
            {
                radStep++;
            }

            if (_attStep1)
            {
                attStep++;
            }
            if (_attStep2)
            {
                attStep--;
            }
        }
            public ManualCube() {
            File = new ReadFile("vertexcub.txt");
           
            objVertex = File.ReturnArray();
            IsDrawable = true;
            ColorFace1 = Color.FromArgb(255, 0, 0);
            ColorFace2 = Color.FromArgb(0, 0, 255);
            ColorFace3 = Color.FromArgb(0, 255, 0);
            ColorFace4 = Color.FromArgb(255, 0, 255);
            ColorFace5 = Color.FromArgb(0, 255, 255);
            ColorFace6 = Color.FromArgb(255, 255, 0);
           

        }
        public void resetInitialColor() {
            ColorFace1 = Color.FromArgb(255, 0, 0);
            ColorFace2 = Color.FromArgb(0, 0, 255);
            ColorFace3 = Color.FromArgb(0, 255, 0);
            ColorFace4 = Color.FromArgb(255, 0, 255);
            ColorFace5 = Color.FromArgb(0, 255, 255);
            ColorFace6 = Color.FromArgb(255, 255, 0);
        }
        public void  setColorFace1(Color c){
            ColorFace1 = c;}
        public void setColorFace2(Color c)
        {
            ColorFace2 = c;
        }
        public void setColorFace3(Color c)
        {
            ColorFace6 = c;
        }
        public void setColorFace4(Color c)
        {
            ColorFace4 = c;
        }
        public void setColorFace5(Color c)
        {
            ColorFace5 = c;
        }
        public void setColorFace6(Color c)
        {
            ColorFace6 = c;
        }
        public void setShowFace(Color c1,Color c2,Color c3) {
            ColorFace1 = c1;
            ColorFace2 = c2;
            ColorFace6 = c3;
        }
        public void setRandomColorFace()
        {
            a = ran.Next(0, 255);
            b = ran.Next(0, 255);
            c = ran.Next(0, 255);
            ColorFace1 = Color.FromArgb(a, b, c); ;
            ColorFace2 = Color.FromArgb(b, c, a); ;
            ColorFace6 = Color.FromArgb(a, c, b); ;
        }
        
        public void DrawMe()
        {
            if (IsDrawable == false)
            {
                return;
            }
            GL.PushMatrix();
            GL.Translate(transStep, attStep, radStep);
            DrawCube();
            GL.PopMatrix();
           
            if (IsToggleStatus())
            DrawCube();
            
        }

        public void DrawCube()
        {

            if (File.getIsRead())
            {
                GL.Begin(PrimitiveType.Quads);
                for (int i = 0; i < 72; i = i + 12)
                {

                    if (i >= 0 && i <= 11)
                        GL.Color3(ColorFace1);//vedere
                    if (i >= 12 && i <= 23)
                        GL.Color3(ColorFace2);//vedere
                    if (i >= 24 && i <= 35)
                        GL.Color3(ColorFace3);
                    if (i >= 36 && i <= 47)
                        GL.Color3(ColorFace4);
                    if (i >= 48 && i <= 59)
                        GL.Color3(ColorFace5);
                    if (i >= 60 && i <= 71)
                        GL.Color3(ColorFace6);//vedere
                    GL.Vertex3(objVertex[i], objVertex[i + 1], objVertex[i + 2]);
                    GL.Vertex3(objVertex[i + 3], objVertex[i + 4], objVertex[i + 5]);
                    GL.Vertex3(objVertex[i + 6], objVertex[i + 7], objVertex[i + 8]);
                    GL.Vertex3(objVertex[i + 9], objVertex[i + 10], objVertex[i + 11]);
                }
                GL.End();
            }
        }

    }
}
