using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    internal interface IPlayer
    {
        int Score { get; set; }
        List<Item> Inventory { get; set; }

    }
}