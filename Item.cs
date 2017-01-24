using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class Item : GameObject
    {
        public Item(string identifier, string description, int location)
        {
            setIdentifier(identifier);
            setDescription(description);
            setLocation(location);
            IsTakeable = true;
        }
        
        public Item(string identifier, string description, int location, bool isTakeable)
        {
            setIdentifier(identifier);
            setDescription(description);
            setLocation(location);
            IsTakeable = isTakeable;
        }
    }
}
