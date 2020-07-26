using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Server
    {
        public static List<Server> list { get; protected set; }

        public string strIdent { get; protected set; }
        public IPAddress ipAddress { get; protected set; }
        public string strLocation { get; protected set; }
        public string strName { get; protected set; }
        public bool isConnectable { get; protected set; }
        public bool isPinging = false;
        public long[] longarrPing;

        public Server(string[] _data)
        {
            strIdent = _data[0];
            ipAddress = IPAddress.Parse(_data[1].Trim());
            strLocation = _data[2];
            strName = _data[3];

            if (_data[4] == "1")
            {
                isConnectable = true;
            }
            else
            {
                isConnectable = false;
            }
        }

        public static void Add(Server _server)
        {
            list.Add(_server);
        }

        public static void Reset()
        {
            list = new List<Server>();
        }
    }
}
