using System;
using System.Collections.Generic;
using System.Text;

namespace castle_grimtolCL
{
    public class GameApi
    {
        Game game = new Game();

        public void startGame()
        {
            game.Setup();
        }

        public string processCommand (string playerchoice)
        {

            switch (playerchoice)
            {
                case "L":
                    return game.Look();
                    break;
                case "I":
                    return game.ListPlayerInventory();
                    break;
                case "H":
                    return game.HelpGuide();
                    break;
                case "Q":
                    System.Environment.Exit(0);
                    return "";
                    break;
                case "T twinkie box":
                    return game.TakeItem("twinkie box");
                    break;
                case "T oreo box":
                    return game.TakeItem("oreo box");
                    break;
                case "T butterfinger box":
                    return game.TakeItem("butterfinger box");
                    break;
                case "T icecream sandwich box":
                    return game.TakeItem("icecream sandwich box");
                    break;
                case "T cheesecake":
                    return game.TakeItem("cheesecake");
                    break;
                case "T cupcake box":
                    return game.TakeItem("cupcake box");
                    break;
                case "T chocolatechip cookie box":
                    return game.TakeItem("chocolatechip cookie box");
                    break;
                case "T rolos box":
                    return game.TakeItem("rolos box");
                    break;
                case "T crunch bar box":
                    return game.TakeItem("cruch bar box");
                    break;
                case "T rocky road":
                    return game.TakeItem("rocky road");
                    break;
                case "U cheesecake":
                    return game.UseItem("cheesecake");
                    break;
                case "U cupcake box":
                    return game.UseItem("cupcake box");
                    break;
                case "U chocolatechip cookie box":
                    return game.UseItem("chocolatechip cookie box");
                    break;
                case "U rolos box":
                    return game.UseItem("rolos box");
                    break;
                case "U crunch bar box":
                    return game.UseItem("cruch bar box");
                    break;
                case "U rocky road":
                    return game.UseItem("rocky road");
                    break;
                case "U twinkie box":
                    return game.UseItem("twinkie box");
                    break;
                case "U oreo box":
                    return game.UseItem("oreo box");
                    break;
                case "U butterfinger box":
                    return game.UseItem("butterfinger box");
                    break;
                case "U icecream sandwich box":
                    return game.UseItem("icecream sandwich box");
                    break;
                case "U switch":
                    return game.UseItem("switch");
                    break;
                case "e":
                    return game.Go("e");
                    break;
                case "w":
                    return game.Go("w");
                    break;
                default:
                    return game.InvalidInput();
                    break;

            }
        }

    }

}

