using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RecordAndPlayMouse
{
    public partial class FormUI : Form
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public static Point MousePoint;

        private KeyHandler keyHandler;
        private System.Timers.Timer mouseClicksTimer;
        private List<Point> points;
        private int pointsIndex;
        private bool started;

        public FormUI()
        {
            InitializeComponent();

            keyHandler = new KeyHandler(Keys.F10, this);
            keyHandler.Register();

            MousePoint = new Point();
            started = false;

            MouseHook.MouseAction += new EventHandler(MouseClickEvent);

            mouseClicksTimer = new System.Timers.Timer(1000);
            mouseClicksTimer.Elapsed += new System.Timers.ElapsedEventHandler(PlaceCursorAndPerformClick);
        }

        private void HandleHotkey()
        {
            if (started)
            {
                StopPlayback();
            }
            else
            {
                StartPlayback();
            }
        }

        private void StartPlayback()
        {
            MouseHook.Stop();
            mouseClicksTimer.Start();
            this.WindowState = FormWindowState.Minimized;
            started = true;
        }

        private void StopPlayback()
        {
            mouseClicksTimer.Stop();
            this.WindowState = FormWindowState.Normal;
            started = false;
            pointsIndex = 0;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }
            base.WndProc(ref m);
        }

        private void PlaceCursorAndPerformClick(object sender, EventArgs e)
        {
            if (pointsIndex >= points.Count)
            {
                pointsIndex = 0;
            }

            uint x = (uint)points[pointsIndex].X;
            uint y = (uint)points[pointsIndex].Y;
            MouseHook.MoveCursorAndPerformMouseClick(x, y);

            pointsIndex++;
        }

        private void MouseClickEvent(object sender, EventArgs e)
        {
            points.Add(MousePoint);
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            points = new List<Point>();
            pointsIndex = 0;
            MouseHook.Start();
        }
    }
}