using System;
using System.Windows.Forms;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Lab4

{

    internal class Window3D : GameWindow
    {
        Axes xyz = new Axes(); // declarare obiect axe
        ManualCube mc = new ManualCube();// declarare cbiect cub
        ManualTriangle tin = new ManualTriangle();// declerere obiect triunchi
        KeyboardState lastKeyPress;

      

        private Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            HelpMenu();
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
           

           
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            var mouse1 = OpenTK.Input.Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }
            if (keyboard[Key.H] && !keyboard.Equals(lastKeyPress))
            {
                HelpMenu();
            }


            if (keyboard[Key.P] && !keyboard.Equals(lastKeyPress))
            { // modificare vizibilitate si restarrare culori initiale cub
                mc.resetInitialColor();
                mc.ToggleVisibility();
            }
            if (keyboard[Key.R] && !keyboard.Equals(lastKeyPress))
            {// pozitie initiala a cubului
                mc.ToggleStatus();
            }

            if (keyboard[Key.A])
            {
                //miscare cub la stanga
                mc.ManualMoveMe(true,false, false, false, false, false);
            }
            if (keyboard[Key.D])
            {//miscare cub la dreapta
                mc.ManualMoveMe(false, true, false, false, false, false);
            }

            if (keyboard[Key.W])
            {//miscare cub in fata
                mc.ManualMoveMe(false, false, true, false, false, false);
            }
            if (keyboard[Key.S])
            {//miscare cub in spate
                mc.ManualMoveMe(false, false, false, true, false, false);
            }

            if (keyboard[Key.Up])
            {//miscare cub in sus
                mc.ManualMoveMe(false, false, false, false, true, false);
            }
            if (keyboard[Key.Down])
            {//miscare cub in jos
                mc.ManualMoveMe(false, false, false, false, false, true);
            }
            if (keyboard[Key.T] && !keyboard.Equals(lastKeyPress))
            {//modificare culoare fata1 cub
                mc.setColorFace1(Color.FromArgb(0,0,0));
                
            }
            if (keyboard[Key.Y] && !keyboard.Equals(lastKeyPress))
            {//modificare culoare fata2 cub
                mc.setColorFace2(Color.FromArgb(0, 100,124));
           
            }
            if (keyboard[Key.U] && !keyboard.Equals(lastKeyPress))
            {//modificare culoare fata3 cub
                mc.setColorFace3(Color.FromArgb(113, 113, 0));
                
            }
            if (keyboard[Key.Q] && !keyboard.Equals(lastKeyPress))
            {//schimbare culoare random fete cub
                mc.setRandomColorFace();
           

            }
            if (keyboard[Key.V] && !keyboard.Equals(lastKeyPress))
            {//odificare vizibilitate triunghi
                tin.ToggleVisibility();
            }
            if (keyboard[Key.B])
            {//modificare gradient vertex 1
                tin.ManualMoveMe(true,false,false);

            }
            if (keyboard[Key.N])
            {//modificare gradient vertex 2
                tin.ManualMoveMe(false, true, false);

            }
            if (keyboard[Key.M])
            {//modificare gradient vertex 3
                tin.ManualMoveMe(false, false, true);
            }

          
            lastKeyPress = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            //desenare obiecte
            xyz.DrawMe();
            mc.DrawMe();
            tin.DrawMe();
           

            SwapBuffers();
        }
        protected void HelpMenu() {
            Console.WriteLine("Meniu de utilizare Aplicatie");
            Console.WriteLine("__________________________________________________");
            
            Console.WriteLine("---> [P] Hide/Show Cub ");
            Console.WriteLine("---> [H] Show Help ");
            Console.WriteLine("---> [R] Multiplica cub in pozitia originala ");
            Console.WriteLine("---> [Q] Generare culori random cub ");
            Console.WriteLine("---> [T] Schimba culoare fata1 cub ");
            Console.WriteLine("---> [Y]  Schimba culoare fata2 cub ");
            Console.WriteLine("---> [U] Schimba culoare fata3 cub");
            Console.WriteLine("---> [V]  Hide/Show Triunghi  ");
            Console.WriteLine("---> [B] Modifica culoare Vertex1 Triunghi ");
            Console.WriteLine("---> [N] Modifica culoare Vertex2 Triunghi");
            Console.WriteLine("---> [M] Modifica culoare Vertex3 Triunghi");
            Console.WriteLine("---> [UP]  Modificare pozitie cub in sus");
            Console.WriteLine("---> [down] Modificare pozitie cub in jos");
            Console.WriteLine("---> [A] Modificare pozitie cub in stanga ");
            Console.WriteLine("---> [S] Modificare pozitie cub inapoi");
            Console.WriteLine("---> [D] Modificare pozitie cub in dreapta");
            Console.WriteLine("---> [W] Modificare pozitie cub inainte");
            Console.WriteLine("---> [Esc]  Iesire aplicatie");
        }

        [STAThread]
        static void Main(string[] args)
        {

            using (Window3D example = new Window3D())
            {
                example.Run(30.0, 0.0);
            }

        }
    }

}
