using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class Actor : GameObject
    {
        private int _cunning = 1;
        public int Cunning
        {
            get { return _cunning; }
            set { _cunning = value; }
        }

        private int _brawn = 1;
        public int Brawn
        {
            get { return _brawn; }
            set { _brawn = value; }
        }

        private int _wit = 1;
        public int Wit
        {
            get { return _wit; }
            set { _wit = value; }
        }

        private int _curHealth = 1;
        public int CurrentHealth
        {
            get { return _curHealth; }
            set { _curHealth = value; }
        }

        private int _curMana = 0;
        public int CurrentMana
        {
            get { return _curMana; }
            set { _curMana = value; }
        }
        private int _curEnergy = 1;
        public int CurrentEnergy
        {
            get { return _curEnergy; }
            set { _curEnergy = value; }
        }

        private int _maxHealth = 1;
        public int MaximumHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        private int _maxMana = 0;
        public int MaximumMana
        {
            get { return _maxMana; }
            set { _maxMana = value; }
        }

        private int _maxEnergy = 1;
        public int MaximumEnergy
        {
            get { return _maxEnergy; }
            set { _maxEnergy = value; }
        }
        public Actor() {}

        public Actor(string identifier, string description, int location) : base(identifier, description) 
        {
            setLocation(location);
        }
    }

}
