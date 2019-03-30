using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;

using static System.Windows.Input.Key;

namespace KeySend_Server
{
    public class User
    {
        public string IP { get; set; }
        public string Name { get; set; }
        public Dictionary<Key, Key> KeyMap = new Dictionary<Key, Key>();
        public List<Key> KeyAllow = new List<Key>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static List<User> Users = new List<User>();
        public static void CreateTestData()
        {
            List<Key> keys = new List<Key>() {
                W,A,S,D,J,K,L
            };
            Users.Add(new User()
            {
                IP = "192.168.1.179",
                KeyMap = new Dictionary<Key, Key>{
                {W,Q},{A,E},{S,R},{D,T},{J,Y},{K,U},{L,I}
                },
                KeyAllow = keys,
                Name = "Surface-WIFI"
            });
            Users.Add(new User()
            {
                IP = "192.168.1.248",
                KeyMap = new Dictionary<Key, Key>{
                {W,O},{A,P},{S,F},{D,G},{J,H},{K,Z},{L,X}
                },
                KeyAllow = keys,
                Name = "JJY"
            });
            Users.Add(new User()
            {
                IP = "192.168.1.145",
                KeyMap = new Dictionary<Key, Key>{
                {W,C},{A,V},{S,B},{D,N},{J,M},{K,NumPad0},{L,NumPad1}
                },
                KeyAllow = keys,
                Name = "ZLQ"
            });
            Users.Add(new User()
            {
                IP = "192.168.1.116",
                KeyMap = new Dictionary<Key, Key>{
                {W,NumPad2},{A,NumPad3},{S,NumPad4},{D,NumPad5},{J,NumPad6},{K,NumPad7},{L,NumPad8}
                },
                KeyAllow = keys,
                Name = "ZBM"
            });
            foreach (var user in Users)
            {
                Console.WriteLine(user);
            }
        }
        public static Key? MapKey(string ip, Key k)
        {
            var users = (from user in Users where user.IP == ip select user).ToList();
            if (users.Count == 0)
            {
                return null;//Bad User
            }
            var u = users[0];
            if (u.KeyMap.ContainsKey(k))
            {
                return u.KeyMap[k];
            }
            else
            {
                return k;
            }
        }
        public static bool IsAllowKey(string ip, Key? k)
        {
            if (k == null)
            {
                return false;
            }
            var users = (from user in Users where user.IP == ip select user).ToList();
            if (users.Count == 0)
            {
                return false;//Bad User
            }
            return users[0].KeyAllow.Contains((Key)k);
        }
    }
}
