using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class Room: GameObject
    {
        List<Exit> exits = new List<Exit>();
        List<Item> contents = new List<Item>();
        List<Character> crowd = new List<Character>();

        public Room(string identifier, string description) : base(identifier, description) { }

        public bool hasExits() {
            return (exits.Count() != 0);
        }

        public bool hasContents()
        {
            return (contents.Count() != 0);
        }

        public bool hasCrowd()
        {
            return (crowd.Count() != 0);
        }

        public void addExit(Exit e)
        {
            exits.Add(e);
        }

        public List<Exit> getExits()
        {
            return exits;
        }


        public void addContent(Item i)
        {
            contents.Add(i);
        }
        public void removeContent(Item i)
        {
            contents.Remove(i);
        }
        public List<Item> getContents()
        {
            return contents;
        }

        public void addCrowd(Character c)
        {
            crowd.Add(c);
        }
        public void removeCrowd(Character c)
        {
            crowd.Remove(c);
        }

        public List<Character> getCrowd()
        {
            return crowd;
        }

    }
}
