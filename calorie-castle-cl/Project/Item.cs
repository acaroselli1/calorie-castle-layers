using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    internal class Item : IItem
    {
     public string Name { get; set; }
     public string Description { get; set; }

     public Item (string name, string description)
        {
            Name = name;
            Description = description;
        }
    }


}