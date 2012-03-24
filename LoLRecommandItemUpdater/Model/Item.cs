using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLRecommandItemUpdater.Model
{
    /// <summary>
    /// Item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the maptype.
        /// </summary>
        /// <value>
        /// The maptype.
        /// </value>
        public MapType Maptype { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
