using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLRecommandItemUpdater.Model
{
    [Flags]
    public enum MapType
    {
        None = 0,

        Classic = 1,

        Dominion = 2,

        All = Classic | Dominion,
    }
}
