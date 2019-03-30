using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
namespace KeySend_Server
{
    public class User
    {
        public string IP { get; set; }
        public Dictionary<Key, Key> KeyMap = new Dictionary<Key, Key>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static List<User> Users = new List<User>();
    }
}
