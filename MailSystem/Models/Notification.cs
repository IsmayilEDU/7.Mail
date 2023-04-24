using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notification
{
    internal class Notification
    {

        //  ID
        public Guid ID { get; init; }

        //  Text
        public string Text { get; init; }

        //  Creation date
        public DateTime CreationTime { get; init; }

        //  Name ( Notification from user)
        public string UserName { get; init; }

        //  Costructor with parametres
        public Notification(Guid iD, string text, DateTime creationTime, string userName)
        {
            ID = iD;
            Text = text;
            CreationTime = creationTime;
            UserName = userName;
        }

        //  For show on console
        public override string ToString()
        {
            return $"ID: {ID}\nText: {Text}\nCreation time: {CreationTime}\nFrom {UserName}";
        }

    }
}
