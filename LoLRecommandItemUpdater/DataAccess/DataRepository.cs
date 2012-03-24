using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoLRecommandItemUpdater.Model;
using System.IO;

namespace LoLRecommandItemUpdater.DataAccess
{
    /// <summary>
    /// DataRepository
    /// </summary>
    public class DataRepository
    {
        /// <summary>
        /// Items' cache
        /// </summary>
        private IEnumerable<Item> m_items;

        /// <summary>
        /// Heros' cache
        /// </summary>
        private IEnumerable<Hero> m_heros;

        #region Item
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>items</returns>
        public IEnumerable<Item> GetItems()
        {
            if (this.m_items == null)
            {
                var sourceDatas = File.ReadAllLines("item_cost.txt");

                this.m_items = sourceDatas.Select(
                                               i =>
                                               {
                                                   var data = i.Split(',');

                                                   return new Item()
                                                   {
                                                       Code = Convert.ToInt32(data[0]),
                                                       Price = Convert.ToInt32(data[1]),
                                                       Maptype = (MapType)Convert.ToInt32(data[2]),
                                                       ItemType = (ItemType)Convert.ToInt32(data[3]),
                                                       Description = data[4].Replace("\\n", Environment.NewLine)
                                                   };
                                               });
            }

            return m_items;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>items</returns>
        public IEnumerable<Item> GetItemsByType(MapType mapType, ItemType itemType, string keyword)
        {
            var items = this.GetItems();

            return items.Where(i => (i.Maptype & mapType) != MapType.None &&
                                    (i.ItemType & itemType) != ItemType.None &&
                                    (string.IsNullOrEmpty(keyword) || i.Description.Contains(keyword)));            
        }

        /// <summary>
        /// Gets the item by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Item GetItemByCode(int code)
        {
            var items = this.GetItems();

            return items.Where(i => i.Code == code)
                        .FirstOrDefault();
        }
        #endregion

        #region Game Folder
        /// <summary>
        /// Gets the game folder.
        /// </summary>
        public string GetGameFolder()
        {
            string gameFolderPath = string.Empty;

            if (File.Exists("config.ini"))
            {
                gameFolderPath = File.ReadAllText("config.ini");
            }

            return gameFolderPath;
        }

        /// <summary>
        /// Saves the game folder.
        /// </summary>
        /// <param name="gameFolderPath">The game folder path.</param>
        public void SaveGameFolder(string gameFolderPath)
        {
            File.WriteAllText("config.ini", gameFolderPath);
        }
        #endregion

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>items</returns>
        public IEnumerable<Hero> GetHeroes()
        {
            if (this.m_heros == null)
            {
                var sourceDatas = File.ReadAllLines("champs.ini");

                this.m_heros = sourceDatas.Select(
                                               i =>
                                               {
                                                   var data = i.Split('/');

                                                   return new Hero()
                                                   {
                                                       Name = data[0].Replace(" ", string.Empty)
                                                                     .Replace(".", string.Empty)
                                                                     .Replace("'", string.Empty),
                                                       ChineseName = data[1]
                                                   };
                                               });
            }

            return m_heros;
        }

        /// <summary>
        /// Gets the name of the hero by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Hero GetHeroByName(string name)
        {
            var heroes = this.GetHeroes();

            return heroes.Where(i => i.Name == name)
                         .FirstOrDefault();
        }
    }
}
