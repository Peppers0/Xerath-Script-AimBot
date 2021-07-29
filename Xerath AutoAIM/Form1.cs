using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LowLevelInput.Hooks;
using AutoAIM.Scr;
using AutoAIM.Inputs;

namespace AutoAIM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static readonly InputManager Input = new InputManager();
        private static void InputManager_OnKeyboardEvent(VirtualKeyCode key, KeyState state)
        {
            if (key == VirtualKeyCode.Q)
            {
                switch (state)
                {
                    case KeyState.Down:
                        InputKeys.Keyboard.KeyDown((ushort)DirectInputKeys.DIK_1);
                        break;


                    case KeyState.Up:
                        try
                        {
                            Point p = Cursor.Position;
                            FindEnemy();
                            InputKeys.Keyboard.KeyUp((ushort)DirectInputKeys.DIK_1);
                            Thread.Sleep(20);
                            Cursor.Position = p;
                            Thread.Sleep(5000);
                        }
                        catch
                        {
                        }
                        break;

                }
            }

            else if (key == VirtualKeyCode.W)
            {
                switch (state)
                {
                    case KeyState.Down:
                        try
                        {
                            Point p = Cursor.Position;
                            FindEnemy();
                            InputKeys.Keyboard.KeyPress((ushort)DirectInputKeys.DIK_2);
                            Thread.Sleep(20);
                            Cursor.Position = p;
                            Thread.Sleep(5000);
                        }
                        catch
                        {
                        }
                        break;


                    case KeyState.Up:
                        break;

                }
            }
            else if (key == VirtualKeyCode.E)
            {
                switch (state)
                {
                    case KeyState.Down:
                        try
                        {
                            Point p = Cursor.Position;
                            FindEnemy();
                            InputKeys.Keyboard.KeyPress((ushort)DirectInputKeys.DIK_3);
                            Thread.Sleep(20);
                            Cursor.Position = p;
                            Thread.Sleep(5000);
                        }
                        catch
                        {
                        }
                        break;


                    case KeyState.Up:
                        break;

                }
            }
            else if (key == VirtualKeyCode.R)
            {
                switch (state)
                {
                    case KeyState.Down:
                        try
                        {
                            Point p = Cursor.Position;
                            FindEnemy();
                            InputKeys.Keyboard.KeyPress((ushort)DirectInputKeys.DIK_4);
                            Thread.Sleep(20);
                            Cursor.Position = p;
                            Thread.Sleep(500);
                        }
                        catch
                        {
                        }
                        break;


                    case KeyState.Up:
                        break;

                }
            }

        }
        public static void FindEnemy()
        {
            Color color = Color.FromArgb(66, 7, 1);
            var target = ScreenCapture.GetColorPosition(color);
            if (target == null)
            {
            }
            else
            {
                Cursor.Position = new Point(target.Value.X + 67, target.Value.Y + 101);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Input.Initialize();
            Input.OnKeyboardEvent += InputManager_OnKeyboardEvent;
        }
    }
}
