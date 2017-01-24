using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class Player : Actor
    {
        public Player()
        {
            MaximumHealth = 20;
            CurrentHealth = 20;
            setLocation(1);
        }

    }
}
