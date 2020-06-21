using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHouseingCompanyV_2
{
    public partial class Notification : Form
    {
        private static readonly List<Notification> OpenNotifications = new List<Notification>();
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;
        private string iconPath;

        public Notification(string body, string iconPath)
        {
            InitializeComponent();

            labelBody.Text = body;

            var animationMethod = FormAnimator.AnimationMethod.Slide;

            var animationDirection = FormAnimator.AnimationDirection.Up;

            _animator = new FormAnimator(this, animationMethod, animationDirection, 500);

            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 5, Height - 5, 20, 20));

            this.iconPath = iconPath;
        }

        
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                                      Screen.PrimaryScreen.WorkingArea.Height - Height);

            // Move each open form upwards to make room for this one
            foreach (Notification openForm in OpenNotifications)
            {
                openForm.Top -= Height;
            }

            //pbTempIcon.Image = Image.FromFile(@"..\Images\" + iconPath + ".png");
            string path  = pbTempIcon.ImageLocation;
            MessageBox.Show(path);

            OpenNotifications.Add(this);
       
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += Height;
            }

            OpenNotifications.Remove(this);
        }

        private void Notification_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
