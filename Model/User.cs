using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat.Model
{
    public class User   //Class는 식판이라고 가정
    {
        //식판 안에는 밥, 국, 반찬을 담는 파트가 있을 것
        public string Id { get; set; }  //밥
        public string Password { get; set; }    //국

        //현재 User라는 식판에는 밥, 국을 담는 속성이 있음 
    }
}
