using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviouralPattern.MediatorPattern
{
    public class MediatorPatternDemo
    {
        public static void Run()
        {
            IChatMediator chatRoom = new ChatRoom();

            User tom = new User("Tom", chatRoom);
            User pam = new User("Pam", chatRoom);
            User fransy = new User("Fransy", chatRoom);

            chatRoom.AddUser(tom);
            chatRoom.AddUser(pam);
            chatRoom.AddUser(fransy);

            tom.Send("Hello Everyone");
            pam.Send("Hey from Pam");
        }
    }
}
