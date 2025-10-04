using System;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Supermarket.BS_layer;

namespace Supermarket
{
    public partial class LoginForm : Form
    {
        private readonly BLUser _blUser = new BLUser();
        public string UserRole { get; private set; }
        private readonly SpeechSynthesizer _tts;

        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogIn;
            this.CancelButton = btnCancel;
            this.Load -= LoginForm_Load;

            // Khởi tạo TTS
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
            {
                _tts.SelectVoice(enVoice.Name);
            }
            else
            {
                _tts.SelectVoiceByHints(
                    VoiceGender.Female,
                    VoiceAge.Adult,
                    0,
                    CultureInfo.GetCultureInfo("en-US"));
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show(
                  "Vui lòng nhập đầy đủ Username và Password.",
                  "Thông báo",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning
                );
                return;
            }

            var info = _blUser.Authenticate(user, pass);
            if (info == null)
            {
                MessageBox.Show(
                  "Tên đăng nhập hoặc mật khẩu sai.",
                  "Đăng nhập thất bại",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                );
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }
             _tts.SpeakAsync("Welcome back SIR");
            UserRole = info.RoleName;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
