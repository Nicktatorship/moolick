using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    class Cartographer
    {
        List<Room> rooms = new List<Room>();

        public Cartographer()
        {
            generateMap();
        }

        public List<Room> getRooms() {
            return rooms;
        }

        public void generateMap() 
        {
            rooms.Add(new Room("Dungeon", "You are in a dungeon. There is some light coming from the wall."));
            rooms.Add(new Room("Outside", "You are outside the dungeon, amongst many trees."));

            addExit("Dungeon", "Outside", "Tunnel", "The tunnel seems to lead outside.");
            addExit("Outside", "Dungeon", "Tunnel", "The tunnel leads into the dungeon.");

            rooms.Add(new Room("Cellar", "You are in the musty cellar."));
            addExit("Dungeon", "Cellar", "Hatch", "There is a hatch leading up out of the cell.");
            addExit("Cellar", "Dungeon", "Trapdoor", "There is a trapdoor leading down into darkness.");

            rooms.Add(new Room("Street", "You are standing on the street."));
            addExit("Outside", "Street", "South", "The trees started to clear away toward the south.");
            addExit("Street", "Outside", "North", "There is a walkway leading north, away from the road.");

            rooms.Add(new Room("Old Well", "There is an old well at the top of the hill."));
            addExit("Outside", "Old Well", "North", "There is a hill to the north.");
            addExit("Old Well", "Outside", "South", "There is a bunch of trees further down the hill.");

            rooms.Add(new Room("Shop", "You are inside the general store."));
            addExit("Street", "Shop", "West", "There is a general store on the western edge of the road.");
            addExit("Shop", "Street", "Out", "There is a path leading out of the shop.");

            addContent("Old Well", "Bucket", "An empty bucket.", true);
            addContent("Cellar", "Large Barrel", "A large oak barrel, filled with wine.", false);
            addContent("Dungeon", "Wooden Sword", "A worn wooden sword.", true);

            addCrowd("Shop", "Merchant", "A short, round man with glasses.");
        }

        private void addCrowd(string location, string identifier, string description)
        {
            Room targetRoom = rooms.Find(delegate(Room r) { return r.getIdentifier().Equals(location); });
            Character c = new Character(identifier, description, targetRoom.getId());
            targetRoom.addCrowd(c);
        }

        private void addContent(string location, string identifier, string description, bool isTakeable)
        {
            Room targetRoom = rooms.Find(delegate(Room r) { return r.getIdentifier().Equals(location); });
            Item i = new Item(identifier, description, targetRoom.getId(), isTakeable);
            targetRoom.addContent(i);
        }

        private void addExit(string location, string destination, string identifier, string description)
        {
            Exit e = new Exit(identifier, description);
            Room sourceRoom = rooms.Find(delegate(Room r) { return r.getIdentifier().Equals(location); });
            Room destinationRoom = rooms.Find(delegate(Room r) { return r.getIdentifier().Equals(destination); });
            e.setDestination(destinationRoom);
            e.setLocation(sourceRoom.getId());
            sourceRoom.addExit(e);
        }

    }
}
