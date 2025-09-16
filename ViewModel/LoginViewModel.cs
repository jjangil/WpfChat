using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WpfChat.Model;
using WpfChat.View;

namespace WpfChat.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private List<User> _user;

        private string _inputId;
        public string InputId
        {
            get => _inputId;
            set
            {
                _inputId = value;
                OnPropertyChanged(nameof(InputId));
            }
        }

        private string _inputPassword;
        public string InputPassword
        {
            get => _inputPassword;
            set
            {
                _inputPassword = value;
                OnPropertyChanged(nameof(InputPassword));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            // JSON 파일 읽어서 사용자 목록 불러오기
            if (File.Exists("User.json"))
            {
                var json = File.ReadAllText("User.json");


                _user = JsonSerializer.Deserialize<List<User>>(json);
            }
            else
            {
                _user = new List<User>();
            }

            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            var user = _user.FirstOrDefault(u => u.Id == InputId && u.Password == InputPassword);
            if (user != null)
            {
                // 로그인 성공 → MainWindow 열기
                var main = new MainWindow();
                main.Show();

                // 현재 로그인 창 닫기
                foreach (Window w in Application.Current.Windows)
                {
                    if (w is View.LoginWindow) { w.Close(); break; }
                }
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.");
            }
        }
    }
}
