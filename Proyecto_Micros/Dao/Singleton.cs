using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dao
{
    public abstract class Singleton<s> where s : Singleton<s>, new()
    {
        private static s _instance;

        public static s Instance()
        {
            if (_instance == null)
            {
                _instance = new s();
            }
            return _instance;
        }
    }
}
