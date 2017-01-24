using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class GameObject
    {
        private int id = -1;
        private string identifier = "Unnamed";
        private string description = "Not set.";
        private int location = -1;
        private bool _takeable = false;
        public bool IsTakeable
        {
            get { return _takeable; }
            set { _takeable = value; }
        }

        // Constructors for GameObject class

        public GameObject()
        {
            setId(DBHandler.Instance.NextObject++);
            DBHandler.Instance.GameDB.Add(this);
            
        }

        public GameObject(string identifier, string description)
        {
            setId(DBHandler.Instance.NextObject++);
            setIdentifier(identifier);
            setDescription(description);
            DBHandler.Instance.GameDB.Add(this);
        }

        // Setters for GameObject class

        public void setId(int id)
        {
            this.id = id;
        }
        public void setIdentifier(string identifier)
        {
            this.identifier = identifier;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        public void setLocation(int location)
        {
            this.location = location;
        }

        // Getters for GameObject class

        public int getId()
        {
            return this.id;
        }
        public string getIdentifier()
        {
            return this.identifier;
        }
        public string getDescription()
        {
            return this.description;
        }
        public int getLocation()
        {
            return this.location;
        }
    }


}
