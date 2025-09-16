using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfChat.Model;

namespace WpfChat.ViewModel
{
    public class ChatViewModel : BaseViewModel
    {
        private string _newMessage;
        public string NewMessage
        {
            get => _newMessage;
            set
            {
                _newMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        public ObservableCollection<ChatMessage> Messages { get; set; }
        public ICommand SendMessageCommand { get; }

        public ChatViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                Messages.Add(new ChatMessage { Text = NewMessage });
                NewMessage = string.Empty;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

    }
}
