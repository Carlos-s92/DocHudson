using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace TestGit.Class
{
    internal static class HoverZoomEffect
    {
        public static void Apply(Control ctrl, int zoomAmount = 10, bool centered = true, int animationSteps = 5, int intervalMs = 15)
        {
            Size originalSize = ctrl.Size;
            Point originalLocation = ctrl.Location;

            int originalIconSize = (ctrl is IconButton iconBtn) ? iconBtn.IconSize : 0;

            Timer enterTimer = new Timer { Interval = intervalMs };
            Timer leaveTimer = new Timer { Interval = intervalMs };

            int step = 0;

            enterTimer.Tick += (s, e) =>
            {
                if (step >= animationSteps)
                {
                    enterTimer.Stop();
                    return;
                }

                step++;

                int delta = (zoomAmount * step) / animationSteps;

                ctrl.Size = new Size(originalSize.Width + delta, originalSize.Height + delta);

                if (centered)
                {
                    ctrl.Location = new Point(
                        originalLocation.X - delta / 2,
                        originalLocation.Y - delta / 2
                    );
                }

                if (ctrl is IconButton ib)
                {
                    ib.IconSize = originalIconSize + delta;
                }
            };

            leaveTimer.Tick += (s, e) =>
            {
                if (step <= 0)
                {
                    leaveTimer.Stop();
                    return;
                }

                step--;

                int delta = (zoomAmount * step) / animationSteps;

                ctrl.Size = new Size(originalSize.Width + delta, originalSize.Height + delta);

                if (centered)
                {
                    ctrl.Location = new Point(
                        originalLocation.X - delta / 2,
                        originalLocation.Y - delta / 2
                    );
                }

                if (ctrl is IconButton ib)
                {
                    ib.IconSize = originalIconSize + delta;
                }
            };

            ctrl.MouseEnter += (s, e) =>
            {
                leaveTimer.Stop();
                enterTimer.Start();
            };

            ctrl.MouseLeave += (s, e) =>
            {
                enterTimer.Stop();
                leaveTimer.Start();
            };
        }
    }
}
