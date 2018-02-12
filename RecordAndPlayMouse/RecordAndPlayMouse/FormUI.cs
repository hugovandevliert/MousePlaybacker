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
        public static Boolean LeftClick;

        private KeyHandler keyHandler;
        private System.Timers.Timer mouseClicksTimer;
        private List<Point> points;
        private List<Boolean> leftClicks;
        private int index;
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
            index = 0;
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
            if (index >= points.Count)
            {
                index = 0;
            }

            uint x = (uint)points[index].X;
            uint y = (uint)points[index].Y;
            Boolean leftClick = leftClicks[index];
            MouseHook.MoveCursorAndPerformMouseClick(x, y, leftClick);

            index++;
        }

        private void MouseClickEvent(object sender, EventArgs e)
        {
            points.Add(MousePoint);
            leftClicks.Add(LeftClick);
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            points = new List<Point>();
            leftClicks = new List<Boolean>();
            index = 0;
            MouseHook.Start();
        }
    }
}