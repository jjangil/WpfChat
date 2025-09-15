using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat.ViewModel
{
    public class Friend
    {
        public string Name { get; set; }
        public string StatusMessage { get; set; }
    }

    public class FriendViewModel : BaseViewModel
    {
        //ObservableCollection<Friend>는 Friend 객체들을 여러 개 담아서 변경 시 UI에 자동 반영되게 하는 컬렉션
        public ObservableCollection<Friend> Friends { get; set; }

        public FriendViewModel()
        {
            // 샘플 데이터 (나중에 DB나 서버 연동 가능)
            Friends = new ObservableCollection<Friend>
            {
                new Friend { Name = "홍길동", StatusMessage = "밥 먹는 중 🍚" },
                new Friend { Name = "이순신", StatusMessage = "열공 모드 📚" },
                new Friend { Name = "유재석", StatusMessage = "오늘도 파이팅 ✨" }
            };
        }
    }
}
