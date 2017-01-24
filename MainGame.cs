using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    
    class MainGame
    {
        KeyHandler keyHandler = new KeyHandler();
        Player player = new Player();
        Cartographer atlas = new Cartographer();
        Parser parser = new Parser();
        
        public MainGame() 
        {
            GameLoop();
        }

        void GameLoop()
        {
            string userInput;
            string playerAction;

            do
            {
                Room currentRoom = atlas.getRooms().Find(delegate(Room r) { return r.getId() == player.getLocation(); });
                DisplayRoom(currentRoom);
                DisplayStatus();
                DisplayCursor();
                
                userInput = Console.ReadLine();
                playerAction = parser.execute(player, currentRoom, userInput);
                GameObject targetObject = parser.getTarget();

                Console.WriteLine("Action: {0}", playerAction);
                if (targetObject != null)
                {
                    Console.WriteLine("Target: {0}", parser.getTarget().getIdentifier());
                }

                switch (playerAction) {
                    case "stats" : ShowStats(); break;
                    case "showdb" : ShowDB(); break; 
                    case "go" : 
                        Exit e = (Exit) targetObject;
                        if (e != null)
                        {
                            player.setLocation(e.getDestination().getId());
                        } break;
                    case "look": 
                        if (targetObject != null) 
                        { 
                            Console.WriteLine("Desc: {0}", targetObject.getDescription()); 
                        } break;
                    case "get":
                        if (targetObject != null)
                        {
                            if (targetObject.IsTakeable)
                            {
                                Console.WriteLine("You take the {0}.", targetObject.getIdentifier());
                                targetObject.setLocation(player.getId());
                                currentRoom.removeContent((Item) targetObject);
                            }
                            else
                            {
                                Console.WriteLine("You can't take the {0}.", targetObject.getIdentifier());
                            }
                        } break;
                }
                
            } while (!playerAction.Equals("quit"));

        }

        void ShowStats()
        {
            foreach (Room r in atlas.getRooms())
            {
                Console.WriteLine("Room : {0} : {1}", r.getId(), r.getIdentifier());
                foreach (Character c in r.getCrowd())
                {
                    Console.WriteLine("Char : {0}", c.getIdentifier());
                }
                foreach (Item i in r.getContents())
                {
                    Console.WriteLine("Item : {0}", i.getIdentifier());
                }
                foreach (Exit e in r.getExits())
                {
                    Console.WriteLine("Exit : {0} : {1}--> {2}", e.getId(), e.getIdentifier(), e.getDestination().getId());
                }
            }
        }

        void ShowDB()
        {
            foreach (GameObject g in DBHandler.Instance.GameDB)
            {
                Console.WriteLine("DB# : {0}", g.getId());
                Console.WriteLine("Type: {0}", g.GetType().ToString());
                Console.WriteLine("Ident: {0}", g.getIdentifier());
                Console.WriteLine("Desc: {0}", g.getDescription());
                Console.WriteLine("Location: {0}", g.getLocation());
            }
        }

        void DisplayCursor()
        {
            Console.WriteLine();
            Console.Write(" > ");
        }

        void DisplayRoom(Room room)
        {
            Console.WriteLine(@"---------------------------------
You are in the {0}. You see:
{1}
", room.getIdentifier(), room.getDescription());

            if (room.hasCrowd())
            {
                Console.WriteLine("Characters:");
                foreach (Character c in room.getCrowd())
                {
                    Console.WriteLine("{0}", c.getIdentifier());
                }
                Console.WriteLine("");
            } 
            if (room.hasContents())
            {
                Console.WriteLine("Contents:");
                foreach (Item i in room.getContents())
                {
                    Console.WriteLine("{0}", i.getIdentifier());
                }
                Console.WriteLine("");
            }
            if (room.hasExits())
            {
                Console.WriteLine("Exits:");
                foreach (Exit e in room.getExits())
                {
                    Console.WriteLine("<{0}>", e.getIdentifier());
                }
                Console.WriteLine("");
            }

            Console.WriteLine(@"---------------------------------
");
                    
        }
        void DisplayStatus()
        {
            Console.WriteLine(@"
---( H:{0}/{1} | E:{2}/{3} | M:{4}/{5} )--
",
                player.CurrentHealth, player.MaximumHealth,
                player.CurrentEnergy, player.MaximumEnergy,
                player.CurrentMana, player.MaximumMana);

        }

    }
}
