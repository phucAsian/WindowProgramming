using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.UI;

namespace Supermarket
{
    public partial class frmHome : Form
    {
        private readonly bool _isManager;
        private readonly SpeechSynthesizer _tts;
        private void OpenUC(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        public frmHome(string roleName)
        {
            InitializeComponent();
            _isManager = roleName.Equals("Manager",
                          StringComparison.OrdinalIgnoreCase);

            // Khởi tạo TTS và chọn giọng English
            _tts = new SpeechSynthesizer
            {
                Rate = 0,
                Volume = 100
            };
            var enVoice = _tts.GetInstalledVoices()
                              .Select(v => v.VoiceInfo)
                              .FirstOrDefault(info =>
                                  info.Culture.Name.StartsWith("en", StringComparison.OrdinalIgnoreCase));
            if (enVoice != null)
                _tts.SelectVoice(enVoice.Name);

            this.Load += frmHome_Load;
        }

        private void ApplyPermissions()
        {
            // Các nút chỉ dành cho Manager
            btnKho.Enabled = _isManager;  
            btnNCC.Enabled = _isManager;  
            btnNV.Enabled = _isManager;  
            btnThongke.Enabled = _isManager;  

            // 2 form Nhập hàng và Hóa đơn luôn mở được
            btnNhap.Enabled = true;
            btnBan.Enabled = true;
            btnKho.Enabled = _isManager;
        }


        private void btnKho_Click(object sender, EventArgs e)
        {
            OpenUC(new UCKho());
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            OpenUC(new UCMenu());
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenUC(new UCNhapHang());
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            OpenUC(new UCInvoice());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenUC(new UCSupplier());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            OpenUC(new UCEmployee());
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            OpenUC(new UCStatistics());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            _tts.SpeakAsync("See you again");
            this.Hide();
            // 2) Show lại LoginForm
            using (var login = new LoginForm())
            {
                var dr = login.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var home = new frmHome(login.UserRole);
                    home.ShowDialog();
                }
                else
                {
                    Application.Exit();
                }
            }
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            OpenUC(new UCMenu());
        }
    }
}
