using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfChat.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand ShowChatViewCommand { get; }
        public ICommand ShowFriendViewCommand { get; }

        public MainViewModel()
        {
            // 기본 화면: 친구 목록
            CurrentView = new FriendViewModel();

            // Action 기반 RelayCommand라서 매개변수 필요 없음
            ShowChatViewCommand = new RelayCommand(() => CurrentView = new ChatViewModel());
            ShowFriendViewCommand = new RelayCommand(() => CurrentView = new FriendViewModel());
        }
    }
}
