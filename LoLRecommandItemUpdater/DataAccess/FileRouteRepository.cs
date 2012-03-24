using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLRecommandItemUpdater.DataAccess
{
    /// <summary>
    /// FileRouteRepository
    /// </summary>
    public class FileRouteRepository
    {
        /// <summary>
        /// Gets the hero image root folder.
        /// </summary>
        /// <returns>path</returns>
        public static string GetHeroImageRootFolder()
        {
            return @"\Images\champions_files\";
        }

        /// <summary>
        /// Gets the item image root folder.
        /// </summary>
        /// <returns>path</returns>
        public static string GetItemImageRootFolder()
        {
            return @"\Images\items_files\";
        }
    }
}
