﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RecordAndPlayMouse
{
    public partial class FormUI : Form
    {
        public static Point MousePoint;
        public static Boolean LeftClick;
        public static System.Timers.Timer PlaybackRepeater;

        private const int WM_HOTKEY_MSG_ID = 0x0312;

        private KeyHandler keyHandler;
        private Stopwatch stopwatch;
        private List<Point> points;
        private List<Boolean> leftClicks;
        private List<long> milisToNext;
        private bool started;

        public FormUI()
        {
            InitializeComponent();

            keyHandler = new KeyHandler(Keys.F10, this);
            keyHandler.Register();

            MousePoint = new Point();
            started = false;

            MouseHook.MouseAction += new EventHandler(MouseClickEvent);

            PlaybackRepeater = new System.Timers.Timer();
            Console.WriteLine(TimeSpan.FromSeconds((double)nudSecondsRepeat.Value).TotalMilliseconds);
            PlaybackRepeater.Elapsed += new System.Timers.ElapsedEventHandler(RepeatPlayback);
            stopwatch = new Stopwatch();
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

        private void RepeatPlayback(object sender, EventArgs e)
        {
            PlaybackRepeater.Stop();
            MouseHook.StartPlayback(points, leftClicks, milisToNext);
        }

        private void StartPlayback()
        {
            MouseHook.Stop();
            MouseHook.Stopped = false;
            this.WindowState = FormWindowState.Minimized;
            started = true;
            PlaybackRepeater.Interval = TimeSpan.FromSeconds((double)nudSecondsRepeat.Value).TotalMilliseconds;
            MouseHook.StartPlayback(points, leftClicks, milisToNext);
        }

        private void StopPlayback()
        {
            MouseHook.Stopped = true;
            this.WindowState = FormWindowState.Normal;
            PlaybackRepeater.Stop();
            started = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }
            base.WndProc(ref m);
        }

        private void MouseClickEvent(object sender, EventArgs e)
        {
            milisToNext.Add(stopwatch.ElapsedMilliseconds);
            points.Add(MousePoint);
            leftClicks.Add(LeftClick);
            stopwatch.Restart();
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            points = new List<Point>();
            leftClicks = new List<Boolean>();
            milisToNext = new List<long>();
            MouseHook.Start();
            stopwatch.Restart();
        }
    }
}