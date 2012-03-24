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

        /// <summary>
        /// Gets the item image path.
        /// </summary>
        /// <param name="itemCode">The item code.</param>
        /// <returns>path</returns>
        public static string GetItemImagePath(int itemCode)
        {
            return FileRouteRepository.GetItemImageRootFolder() + itemCode + ".gif";
        }

        /// <summary>
        /// Gets the default item image path.
        /// </summary>
        /// <returns>path</returns>
        public static string GetDefaultItemImagePath()
        {
            return FileRouteRepository.GetItemImageRootFolder() + "----.gif";
        }

        /// <summary>
        /// Gets the item image path.
        /// </summary>
        /// <param name="itemCode">The item code.</param>
        /// <returns>path</returns>
        public static string GetHeroImagePath(string heroName)
        {
            return FileRouteRepository.GetHeroImageRootFolder() + heroName + ".jpg";
        }

        /// <summary>
        /// Gets the default item image path.
        /// </summary>
        /// <returns>path</returns>
        public static string GetDefaultHeroImagePath()
        {
            return FileRouteRepository.GetHeroImageRootFolder() + "Empty.jpg";
        }
    }
}
