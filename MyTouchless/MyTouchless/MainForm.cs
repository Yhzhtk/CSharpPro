using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TouchlessLib;
using YH;
using System.Threading;

namespace MyTouchless
{
    public partial class MainForm : Form
    {
        TouchlessMgr touchlessMgr;
        private static Image _latestFrame;
        private static DrawPicture drawDemo;

        private static Point _markerCenter;
        private static float _markerRadius;
        private static bool _fAddingMarker;
        private static int _addedMarkerCount;
        private static bool _drawSelectionAdornment;
        private static bool _fUpdatingMarkerUI;

        private static Marker _markerSelected;

        public MainForm()
        {
            InitializeComponent();

            DateTime s = DateTime.Now;
            Thread.Sleep(1000);
            DateTime e = DateTime.Now;
            s = e;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //注册快捷键
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F1);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.F2);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.None, Keys.F3);

            // Make a new TouchlessMgr for library interaction
            touchlessMgr = new TouchlessMgr();

            if (touchlessMgr.Cameras.Count > 0)
            {
                Camera c = touchlessMgr.Cameras[0];
                c.OnImageCaptured += new EventHandler<CameraEventArgs>(OnImageCaptured);
                touchlessMgr.CurrentCamera = c;

                pictureBoxDisplay.Paint += new PaintEventHandler(drawLatestImage);
            }
            else
            {
                MessageBox.Show("没有可用的摄像头！");
                Environment.Exit(0);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注册快捷键
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
        }

        /// <summary>
        /// 重载WbdProc,实现热键响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            //按快捷键
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 100://按下的是F1，则相应
                        {
                            hideBtn_Click(null, null);
                        }
                        break;
                    case 101://按下的是F2，则相应
                        {
                            showBtn_Click(null, null);
                        }
                        break;
                    case 102://按下的是F3，则相应
                        {
                            palyBtn_Click(null, null);
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Event handler from the active camera
        /// </summary>
        public void OnImageCaptured(object sender, CameraEventArgs args)
        {
            if (!_fAddingMarker)
            {
                _latestFrame = args.Image;

                pictureBoxDisplay.Invalidate();
            }
        }

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (_latestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(_latestFrame, 0, 0, pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                if (_drawSelectionAdornment)
                {
                    Pen pen = new Pen(Brushes.Red, 1);
                    e.Graphics.DrawEllipse(pen, _markerCenter.X - _markerRadius, _markerCenter.Y - _markerRadius, 2 * _markerRadius, 2 * _markerRadius);
                }

                if (drawDemo != null)
                {
                    drawDemo.drawCanvas(e.Graphics);
                }
            }
        }

        #region picture method

        private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker center on mouse down
            if (_fAddingMarker)
            {
                _markerCenter = e.Location;
                _markerRadius = 0;

                // Begin drawing the selection adornment
                _drawSelectionAdornment = true;
            }
        }

        private void pictureBoxDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker radius on mouse up, add the marker
            if (_fAddingMarker)
            {
                int dx = e.X - _markerCenter.X;
                int dy = e.Y - _markerCenter.Y;
                _markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);
                // Adjust for the image/display scaling (assumes proportional scaling)
                _markerCenter.X = (_markerCenter.X * _latestFrame.Width) / pictureBoxDisplay.Width;
                _markerCenter.Y = (_markerCenter.Y * _latestFrame.Height) / pictureBoxDisplay.Height;
                _markerRadius = (_markerRadius * _latestFrame.Height) / pictureBoxDisplay.Height;
                // Add the marker
                Marker newMarker = touchlessMgr.AddMarker("Marker #" + ++_addedMarkerCount, (Bitmap)_latestFrame, _markerCenter, _markerRadius);
                comboBoxMarkers.Items.Add(newMarker);

                // Restore the app to its normal state and clear the selection area adorment
                _fAddingMarker = false;
                buttonMarkerAdd.Text = "Add A New Marker";
                _markerCenter = new Point();
                _drawSelectionAdornment = false;
                pictureBoxDisplay.Image = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                comboBoxMarkers.Enabled = true;
            }
        }

        private void pictureBoxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // If the user is selecting a marker, draw a circle of their selection as a selection adornment
            if (_fAddingMarker && !_markerCenter.IsEmpty)
            {
                // Get the current radius
                int dx = e.X - _markerCenter.X;
                int dy = e.Y - _markerCenter.Y;
                _markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);

                // Cause display update
                pictureBoxDisplay.Invalidate();
            }
        }

        #endregion picture method

        #region marker method

        private void buttonMarkerAdd_Click(object sender, EventArgs e)
        {
            _fAddingMarker = !_fAddingMarker;
            buttonMarkerAdd.Text = _fAddingMarker ? "Cancel Adding Marker" : "Add A New Marker";
        }

        private void buttonMarkerRemove_Click(object sender, EventArgs e)
        {
            touchlessMgr.RemoveMarker(comboBoxMarkers.SelectedIndex);
            comboBoxMarkers.Items.RemoveAt(comboBoxMarkers.SelectedIndex);
            comboBoxMarkers.SelectedIndex = -1;
            comboBoxMarkers.Text = "Edit An Existing Marker";
            groupBoxMarkerControl.Enabled = false;
            groupBoxMarkerControl.Text = "No Marker Selected";
            if (comboBoxMarkers.Items.Count == 0)
            {
                comboBoxMarkers.Enabled = false;
            }
        }

        private void comboBoxMarkers_DropDown(object sender, EventArgs e)
        {
            comboBoxMarkers.Items.Clear();
            foreach (Marker marker in touchlessMgr.Markers)
                comboBoxMarkers.Items.Add(marker);
        }

        private void comboBoxMarkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_markerSelected != null)
                _markerSelected.OnChange -= new EventHandler<MarkerEventArgs>(OnSelectedMarkerUpdate);

            if (comboBoxMarkers.SelectedIndex < 0)
            {
                comboBoxMarkers.Text = "Edit An Existing Marker";
                groupBoxMarkerControl.Enabled = false;
                groupBoxMarkerControl.Text = "No Marker Selected";
                return;
            }

            _markerSelected = (Marker)comboBoxMarkers.SelectedItem;
            _markerSelected.OnChange += new EventHandler<MarkerEventArgs>(OnSelectedMarkerUpdate);

            groupBoxMarkerControl.Text = _markerSelected.Name;
            groupBoxMarkerControl.Enabled = true;
            _fUpdatingMarkerUI = true;
            checkBoxMarkerHighlight.Checked = _markerSelected.Highlight;
            checkBoxMarkerSmoothing.Checked = _markerSelected.SmoothingEnabled;
            numericUpDownMarkerThresh.Value = _markerSelected.Threshold;
            _fUpdatingMarkerUI = false;
        }

        public void OnSelectedMarkerUpdate(object sender, MarkerEventArgs args)
        {
            this.BeginInvoke(new Action<MarkerEventData>(UpdateMarkerDataInUI), new object[] { args.EventData });
        }

        private void UpdateMarkerDataInUI(MarkerEventData data)
        {
            if (data.Present)
            {
                labelMarkerData.Text =
                      "Center X:  " + data.X + "\n"
                    + "Center Y:  " + data.Y + "\n"
                    + "DX:        " + data.DX + "\n"
                    + "DY:        " + data.DY + "\n"
                    + "Area:      " + data.Area + "\n"
                    + "Left:      " + data.Bounds.Left + "\n"
                    + "Right:     " + data.Bounds.Right + "\n"
                    + "Top:       " + data.Bounds.Top + "\n"
                    + "Bottom:    " + data.Bounds.Bottom + "\n";
            }
            else
                labelMarkerData.Text = "Marker not present";
        }

        private void checkBoxMarkerHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (_fUpdatingMarkerUI)
                return;

            ((Marker)comboBoxMarkers.SelectedItem).Highlight = checkBoxMarkerHighlight.Checked;
        }

        private void checkBoxMarkerSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            if (_fUpdatingMarkerUI)
                return;

            ((Marker)comboBoxMarkers.SelectedItem).SmoothingEnabled = checkBoxMarkerSmoothing.Checked;
        }

        #endregion marker method

        private void palyBtn_Click(object sender, EventArgs e)
        {
            if (touchlessMgr.Markers.Count == 0)
            {
                MessageBox.Show("请先设置一个Marker。");
                return;
            }

            if (drawDemo == null)
            {
                drawDemo = new DrawPicture(touchlessMgr, pictureBoxDisplay.Bounds, imgBox.Text);
                palyBtn.Text = "停止";
            }
            else
            {
                drawDemo.Dispose();
                drawDemo = null;
                palyBtn.Text = "开始";
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //比例恒定在320：240
            float ratio = touchlessMgr.Cameras[0].CaptureHeight / (float) touchlessMgr.Cameras[0].CaptureWidth;

            Size s = picPanel.Size;
            Rectangle b = pictureBoxDisplay.Bounds;

            if ((s.Height / (float)s.Width) > ratio)
            {
                b.Height = (int)(s.Width * ratio);
                b.Width = s.Width;
                b.X = 0;
                b.Y = (s.Height - b.Height) / 2;
            }
            else
            {
                b.Width = (int)(s.Height / ratio);
                b.Height = s.Height;
                b.X = (s.Width - b.Width) / 2;
                b.Y = 0;
            }
            pictureBoxDisplay.SetBounds(b.X, b.Y, b.Width, b.Height);
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            this.ctrlPanel.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            this.ctrlPanel.Visible = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "图片文件(*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif)|(*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif)|所有文件(*.*)|*.*";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgBox.Text = open.FileName;
            }
        }
    }
}
