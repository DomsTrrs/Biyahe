using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biyahe.UI
{
    public static class AcrylicRenderer
    {
        public static bool IsWebViewHost(Control parent)
        {
            if (parent == null) return false;

            foreach (Control c in parent.Controls)
            {
                string name = c.GetType().Name;
                if (name.Contains("WebView") ||
                    name.Contains("WebBrowser"))
                    return true;
            }

            return false;
        }

        public static void DrawAcrylic(
            Graphics g,
            Rectangle rect,
            Color tint,
            Color highlight)
        {
            // Base frost layer
            using (SolidBrush baseBrush =
                   new SolidBrush(tint))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Top highlight gradient (Fluent look)
            Rectangle top = new Rectangle(
                rect.X,
                rect.Y,
                rect.Width,
                rect.Height / 2);

            using (LinearGradientBrush shine =
                   new LinearGradientBrush(
                       top,
                       highlight,
                       Color.Transparent,
                       LinearGradientMode.Vertical))
            {
                g.FillRectangle(shine, top);
            }

            // Subtle depth shadow
            using (SolidBrush shadow =
                   new SolidBrush(Color.FromArgb(12, 0, 0, 0)))
            {
                g.FillRectangle(shadow, rect);
            }
        }
    }
}