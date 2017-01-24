using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    class KeyHandler
    {
        public KeyHandler()
        {
        }

        public string HandleKey(ConsoleKeyInfo key)
        {
            return key.Key.ToString();

        }

    }
}
