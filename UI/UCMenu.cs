using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class UCMenu : UserControl
    {
        private readonly string[] _messages = {
            "🌟 Ưu đãi 50% mỗi ngày tại SIÊU THỊ PHÚC VŨ! 🌟",
            "🚚 Miễn phí giao hàng cho đơn trên 500K₫!",
            "🎁 Quà tặng cho 100 khách đầu tiên!",
            "💳 Thanh toán thẻ, ví điện tử, COD!",
            "🔥 Sản phẩm mới: Điện thoại, Laptop!",
            "💐 Giảm 10% cuối tuần cho đơn trên 1 triệu!"
        };

        private readonly List<Label> _labels = new List<Label>();
        private readonly List<int> _idxs = new List<int>();
        private readonly List<int> _speeds = new List<int>();
        private readonly Random _rand = new Random();

        private Bitmap _bg;

        public UCMenu()
        {
            InitializeComponent();
            typeof(Panel).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)?
                .SetValue(pnlMarquee, true, null);

            this.Load += UCMenu_Load;
            tmrMarquee.Tick += TmrMarquee_Tick;
        }

        private void UCMenu_Load(object sender, EventArgs e)
        {
            int count = 6;
            int panelW = pnlMarquee.Width;
            int panelH = pnlMarquee.Height;
            int spacingY = panelH / (count + 1);

            _bg = new Bitmap(panelW, panelH);
            using (var g = Graphics.FromImage(_bg))
            using (var brush = new LinearGradientBrush(
                       new Rectangle(0, 0, panelW, panelH),
                       Color.FromArgb(30, 144, 255),
                       Color.FromArgb(135, 206, 250),
                       LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, 0, 0, panelW, panelH);
            }
            pnlMarquee.BackgroundImage = _bg;
            pnlMarquee.BackgroundImageLayout = ImageLayout.Stretch;

            for (int i = 0; i < count; i++)
            {
                var lbl = new Label
                {
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    Text = _messages[_rand.Next(_messages.Length)]
                };
                int y = spacingY * (i + 1) - lbl.Height / 2;
                int x = panelW + _rand.Next(0, 500);
                lbl.Location = new Point(x, y);
                _labels.Add(lbl);
                _idxs.Add(Array.IndexOf(_messages, lbl.Text));
                _speeds.Add(_rand.Next(2, 9));
                pnlMarquee.Controls.Add(lbl);
            }
            tmrMarquee.Start();
        }

        private void TmrMarquee_Tick(object sender, EventArgs e)
        {
            int panelW = pnlMarquee.Width;

            for (int i = 0; i < _labels.Count; i++)
            {
                var lbl = _labels[i];
                var speed = _speeds[i];
                lbl.Left -= speed;
                if (lbl.Right < 0)
                {
                    _idxs[i] = (_idxs[i] + 1) % _messages.Length;
                    lbl.Text = _messages[_idxs[i]];
                    lbl.Left = panelW + _rand.Next(0, 500);
                }
            }
        }
    }
}
