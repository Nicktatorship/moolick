using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public sealed class DBHandler
    {
        private int _nextObject = 0;
        public int NextObject
        {
            get { return _nextObject; }
            set { _nextObject = value; }
        }
        
        private List<GameObject> _db = new List<GameObject>();
        public List<GameObject> GameDB
        {
            get { return _db; }
            set { _db = value; }
        }


        static readonly DBHandler _instance = new DBHandler();

        public static DBHandler Instance
        {
            get { return _instance; }
        }

        private DBHandler() {
        }

    }
}
