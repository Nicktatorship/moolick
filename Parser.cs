using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World1
{
    public class Parser
    {
        List<string> commands = new List<string>();
        GameObject targetObject = null;

        public Parser() {
            commands.Add("look");
            commands.Add("get");
            commands.Add("attack");
            commands.Add("inventory");
            commands.Add("block");
            commands.Add("drop");
            commands.Add("stats");
            commands.Add("showdb");
            commands.Add("sheet");
            commands.Add("quit");
            commands.Add("q");
            commands.Add("go");
            commands.Add("teleport");
        }

        public string execute(Player player, Room room, String playerInput)
        {
            bool hasFoundCommand = false;
            bool hasFoundObject = false;
            targetObject = null;

            string strippedInput;
            string playerAction = "";

            strippedInput = playerInput;

            foreach (String c in commands)
            {
                if (playerInput.StartsWith(c, StringComparison.CurrentCultureIgnoreCase))
                {
                    hasFoundCommand = true;
                    if (c.Equals("q")) {
                        playerAction = "quit";
                    } else {
                        playerAction = c;
                    }
                    if (playerInput.Length > c.Length)
                    {
                        strippedInput = playerInput.Substring(c.Length + 1);
                    }
                    break;
                }
            }

            if (!hasFoundCommand || playerAction.Equals("go"))
            {
                Exit door = room.getExits().Find(
                    delegate(Exit e)
                    {
                        return e.getIdentifier().Equals(strippedInput, StringComparison.CurrentCultureIgnoreCase);
                    }
                );
                if (door != null)
                {
                    targetObject = door;
                    hasFoundCommand = true;
                    hasFoundObject = true;
                    playerAction = "go";
                }
            }

            if (!hasFoundObject)
            {
                GameObject localObject = DBHandler.Instance.GameDB.Find(
                    delegate(GameObject g)
                    {
                        return ((g.getLocation() == player.getLocation()) &&
                            (g.getIdentifier().Equals(strippedInput, StringComparison.CurrentCultureIgnoreCase)));
                    }
                );
                if (localObject != null) {
                    targetObject = localObject;
                    hasFoundObject = true;
                }
            }

            if (!hasFoundObject) {
                if (strippedInput.Equals("here", StringComparison.CurrentCultureIgnoreCase) || strippedInput.Equals("room", StringComparison.CurrentCultureIgnoreCase))
                {
                    targetObject = room;
                    hasFoundObject = true;
                }
                else if (strippedInput.Equals("self", StringComparison.CurrentCultureIgnoreCase) || strippedInput.Equals("me", StringComparison.CurrentCultureIgnoreCase))
                {
                    targetObject = player;
                    hasFoundObject = true;
                }
            }

            return playerAction;
        }

        public GameObject getTarget()
        {
            return targetObject;
        }

    }
}
