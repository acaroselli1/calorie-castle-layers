using CastleGrimtol.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace castle_grimtolCL
{
    internal class Game
    {
        public string Name;

        internal Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public string HelpGuide()

        {
            var helpGuide = " " + Environment.NewLine + "Game Commands" 
            + Environment.NewLine + "-------------------------------------- "
            + Environment.NewLine + "Go East or West - type 'e' or 'w' --> This command moves your player between rooms."
            + Environment.NewLine + "Look - type 'L' --> This command will allow you to see what's in the room."
            + Environment.NewLine + "Use item - type 'U <item> -->   This command uses an item from your inventory or an item bound to the room."
            + Environment.NewLine + "Take item - type 'T <item>' -->  If an item can be picked up, this command will put the item in the player inventory."
            + Environment.NewLine + "Inventory - type 'I' -->  This command lists the current items in the player inventory."
            + Environment.NewLine + "Quit game - type 'Q' -->  This command exits the game."
            + Environment.NewLine + "Help - type 'H' -->  This command lists the Game Commands as seen here.";

            return helpGuide;
        }


        public void Setup()
        {

            Room Cake = new Room("Cake Room", "You find yourself in a room full of cakes; all of your favorites but sure to " +
            "ruin your diet! You look around the room. Boxes of cakes line the walls from floor to ceiling.  You are very hungry and " +
            "the sights around you are making you want to start your diet next week.");

            Room Cookies = new Room("Cookie Room", "You find yourself in a room full of cookies of every variety!  You are trying to watch your " +
            "eating habits but you have never passed up a cookie before.  Boxes of cookies line the walls from floor to ceiling.  You are very hungry and " +
            "the sights are making you think about starting your diet in a day or two.");

            Room Candy = new Room("Candy Bar Room", "Cavities and calories all in one.  You find yourself in a room full of candy bars. " +
            "Boxes of candy bars line the walls from floor to ceiling.  You are trying to stay trim but you wondering if maybe your scale " +
            "is off by 25-30 pounds.");

            Room Icecream = new Room("Icecream Room", "You find yourself in a freezer full of icecream treats. A little bit of calcium and a whole lot of empty calories.  You're not one to let treats like this go to waste; though you understand that, if you don't, it will go to your waist.  While looking over the boxes for anything redeeming in the nutrition facts, you happen to notice a switch on the wall.");

            Room Win = new Room("Winner's Room!!!!", "You successfully made it through all the room challenges without consuming any of the foods on the unhealthy list!! Way to go!! You are sure to make weight for the Johnny's Fitclub Challenge and win the grand prize!!!");

            Room Outside = new Room("Outside", "Well, you're back outside.  Go 'e' to play.");

            Outside.Exits.Add("e", Cake);
            Cake.Exits.Add("w", Outside);
            Cake.Exits.Add("e", Cookies);
            Cookies.Exits.Add("w", Cake);
            Cookies.Exits.Add("e", Candy);
            Candy.Exits.Add("w", Cookies);
            Candy.Exits.Add("e", Icecream);
            Icecream.Exits.Add("w", Candy);
            Icecream.Exits.Add("e", Win);

            Item Twinkie = new Item("twinkie box", "Golden, delicious, but you must resist eating them!");
            Item Oreo = new Item("oreo box", "Plenty to go around with a fridge full of milk!");
            Item Butterfinger = new Item("butterfinger box", "Sweet and salty but this is not on the healthy list!");
            Item RockyRoad = new Item("rocky road", "Don't make a rocky start on the road to wellness!");
            Item IcecreamSandwich = new Item("icecream sandwich box", "Watch out for sandwiches of this variety!");
            Item Switch = new Item("switch", "Here's a switch with an unknown function");
            Item CrunchBar = new Item("cruch bar box", "Snap, crackle, carbs!");
            Item Cupcake = new Item("cupcake box", "They look as good as they are bad for you!");
            Item Rolos = new Item("rolos box", "You're on a roll with your diet, resist the rolos!");
            Item Cheesecake = new Item("cheesecake", "Hold the cheesecake and make your diet goals!");
            Item ChocolateChipCookie = new Item("chocolatechip cookie box", "Full of chips and full of calories!");

            Cake.Items.Add(Twinkie);
            Cake.Items.Add(Cheesecake);
            Cake.Items.Add(Cupcake);

            Cookies.Items.Add(Oreo);
            Cookies.Items.Add(ChocolateChipCookie);

            Candy.Items.Add(Butterfinger);
            Candy.Items.Add(CrunchBar);
            Candy.Items.Add(Rolos);

            Icecream.Items.Add(IcecreamSandwich);
            Icecream.Items.Add(RockyRoad);
            Icecream.Items.Add(Switch);

            Player Alex = new Player("Alex", 100);

            CurrentPlayer = Alex;
            CurrentRoom = Cake;
        }

        public string Look()
        {

            var message = "";

            message += Environment.NewLine + $"You have entered the {CurrentRoom.Name} - {CurrentRoom.Description}";


            int count = 1;
            foreach (var item in CurrentRoom.Items)
            {
                message += Environment.NewLine + Environment.NewLine + $"Item {count}: {item.Name} - {item.Description}" + Environment.NewLine + Environment.NewLine;
                count++;
            }

            int count2 = 1;
            foreach (var item in CurrentRoom.Exits)
            {
                message += Environment.NewLine + Environment.NewLine + $"Exit {count2}: {item.Key}" + Environment.NewLine + Environment.NewLine;
                count2++;
            }

            return message;
        }

        public string Go(string direction)
        {
           
            CurrentRoom = CurrentRoom.Exits[direction];
            if (CurrentRoom.Name == "Winner's Room!!!!")
            {
                CurrentPlayer.Score = CurrentPlayer.Score + 100;
              
                return Environment.NewLine + "You successfully made it through all the room challenges without consuming any of the foods on the unhealthy list!! Way to go!! You are sure to make weight for the Johnny's Fitclub Challenge and win the grand prize!!! " + Environment.NewLine + Environment.NewLine + "+100pts:  You have doubled your initial score and now have the winning total of " + CurrentPlayer.Score + " points!";

            }
            return " ";
        }
       
        //No need to Pass a room since Items can only be used in the CurrentRoom
        public string UseItem(string item)
        {
            var result = "";
            if (item == "switch" && CurrentRoom.Name == "Icecream Room")
            {

                
                CurrentRoom.Items.Remove(CurrentRoom.Items[1]);
                CurrentRoom.Items.Remove(CurrentRoom.Items[0]);
                return Environment.NewLine + "You flip the switch not knowing its purpose.  Tired from your journey, you lay down to take a short nap with freezer temperature becoming surprisingingly comfortable.  Twelve hours later, you wake up dripping with sweat; feeling the effects of the summer heat wave!  You notice that the freezer, once full of ice cream, is now nothing more than an ice cream pond.  The switch you flipped turned off the freezer and you're actually bathing in liquid ice cream!  Ice cream is now gone from the room inventory so this is no longer an item you can take or use.";
                
            }
            else
            {
                for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
                    if (CurrentPlayer.Inventory[i].Name == item)
                    {
                        CurrentPlayer.Score = CurrentPlayer.Score - 100;

                        return Environment.NewLine + "-100pts:  You start by eating one and then eat 12.  Sorry, you're probably not going to make weight for the Johnny's Fitclub Challenge weigh-in tomorrow!  Game Over!";

                    }
              
            }
            return result;
        }

        public string TakeItem(string item)
        {
            for (var i = 0; i < CurrentRoom.Items.Count; i++)
            {
                if (CurrentRoom.Items[i].Name == item)
                {
                    CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                    CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                    return "";
                }

            }
                return "";
        }

        public string ListPlayerInventory()
        {
            var inventory = "";

            if (CurrentPlayer.Inventory.Count == 0)
            {
                inventory = Environment.NewLine + "Nothing in inventory";
            }
            else
            {
                foreach (var item in CurrentPlayer.Inventory)
                {
                    inventory += Environment.NewLine + $"Item in Inventory: {item.Name}";
                }  
            }

                return inventory;
        }

        public string InvalidInput()
        {
            return Environment.NewLine + "Invalid Input";
        }

    }
}

