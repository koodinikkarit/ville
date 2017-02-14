using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ville
{
    static public class Commands
    {
        public const byte REPORT_ALL_CONFIG = 1;
        public const byte REPORT_PEKKA_IP = 2;
        public const byte REPORT_PEKKA_PORT = 3;
        public const byte REPORT_MAC = 4;
        public const byte PEKKA_IP = 5;
        public const byte PEKKA_PORT = 6;
        public const byte MAC = 7;
        public const byte SET_PEKKA_IP = 8;
        public const byte SET_PEKKA_PORT = 9;
        public const byte SET_MAC = 10;
    }
}
