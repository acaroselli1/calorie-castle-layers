using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    internal interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }

        void UseItem(Item item);

    }
}