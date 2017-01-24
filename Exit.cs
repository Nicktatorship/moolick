using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class Exit: GameObject
    {
        private Room destination;

        public Exit(string identifier, string description)
        {
            setIdentifier(identifier);
            setDescription(description);
        }

        public void setDestination(Room destination)
        {
            this.destination = destination;
        }
        public Room getDestination()
        {
            return this.destination;
        }
    }
}
