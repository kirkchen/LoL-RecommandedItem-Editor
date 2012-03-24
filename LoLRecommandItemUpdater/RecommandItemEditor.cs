using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoLRecommandItemUpdater.DataAccess;
using LoLRecommandItemUpdater.Model;
using System.IO;

namespace LoLRecommandItemUpdater
{
    /// <summary>
    /// RecommandItemEditor
    /// </summary>
    public partial class RecommandItemEditor : Form
    {
        /// <summary>
        /// DataRepository
        /// </summary>
        private DataRepository m_dataRepository = new DataRepository();

        /// <summary>
        /// Item Picker
        /// </summary>
        private ItemPicker m_itemPicker = new ItemPicker();

        /// <summary>
        /// Hero Picker
        /// </summary>
        private HeroPicker m_heroPicker = new HeroPicker();

        /// <summary>
        /// Gets or sets the selected hero.
        /// </summary>
        /// <value>
        /// The selected hero.
        /// </value>
        public Hero SelectedHero
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the recommand items.
        /// </summary>
        /// <value>
        /// The recommand items.
        /// </value>
        public Dictionary<int, Item> RecommandItems
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecommandItemEditor"/> class.
        /// </summary>
        public RecommandItemEditor()
        {
            InitializeComponent();

            //this.SelectedHero = new Hero() { Name = "Ahri", ChineseName = "阿璃" };
            this.RecommandItems = new Dictionary<int, Item>()
                                  {
                                      { 1 , null },
                                      { 2 , null },
                                      { 3 , null },
                                      { 4 , null },
                                      { 5 , null },
                                      { 6 , null },
                                  };
        }

        /// <summary>
        /// Handles the Load event of the RecommandItemEditor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RecommandItemEditor_Load(object sender, EventArgs e)
        {
            this.InitializeGameFolder();

            this.DisplaySelectedHero();

            this.ResetRecommandItem();

            this.DisplayRecommandItemsPrice();
        }

        /// <summary>
        /// Handles the Click event of the ButtonSelectRoot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonSelectRoot_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.TextBoxRoot.Text = dialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonSaveRoot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonSaveRoot_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextBoxRoot.Text))
            {
                this.m_dataRepository.SaveGameFolder(this.TextBoxRoot.Text);

                MessageBox.Show("遊戲路徑儲存成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Picture RecommandItem
        /// <summary>
        /// Handles the Click event of the PictureBoxRecItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxRecItem1_Click(object sender, EventArgs e)
        {
            this.m_itemPicker.ShowDialog();

            var item = this.m_itemPicker.SeletectedItem;
            if (item != null)
            {
                this.PictureBoxRecItem1.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                this.RecommandItems[1] = item;

                this.DisplayRecommandItemsPrice();
            }
        }

        /// <summary>
        /// Handles the Click event of the PictureBoxRecItem2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxRecItem2_Click(object sender, EventArgs e)
        {
            this.m_itemPicker.ShowDialog();

            var item = this.m_itemPicker.SeletectedItem;
            if (item != null)
            {
                this.PictureBoxRecItem2.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                this.RecommandItems[2] = item;

                this.DisplayRecommandItemsPrice();
            }
        }

        /// <summary>
        /// Handles the Click event of the PictureBoxRecItem3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxRecItem3_Click(object sender, EventArgs e)
        {
            this.m_itemPicker.ShowDialog();

            var item = this.m_itemPicker.SeletectedItem;
            if (item != null)
            {
                this.PictureBoxRecItem3.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                this.RecommandItems[3] = item;

                this.DisplayRecommandItemsPrice();
            }
        }

        /// <summary>
        /// Handles the Click event of the PictureBoxRecItem4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxRecItem4_Click(object sender, EventArgs e)
        {
            this.m_itemPicker.ShowDialog();

            var item = this.m_itemPicker.SeletectedItem;
            if (item != null)
            {
                this.PictureBoxRecItem4.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                this.RecommandItems[4] = item;

                this.DisplayRecommandItemsPrice();
            }
        }

        /// <summary>
        /// Handles the Click event of the PictureBoxRecItem5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxRecItem5_Click(object sender, EventArgs e)
        {
            this.m_itemPicker.ShowDialog();

            var item = this.m_itemPicker.SeletectedItem;
            if (item != null)
            {
                this.PictureBoxRecItem5.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                this.RecommandItems[5] = item;

                this.DisplayRecommandItemsPrice();
            }
        }

        /// <summary>
        /// Handles the Click event of the PictureBoxRecItem6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxRecItem6_Click(object sender, EventArgs e)
        {
            this.m_itemPicker.ShowDialog();

            var item = this.m_itemPicker.SeletectedItem;
            if (item != null)
            {
                this.PictureBoxRecItem6.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                this.RecommandItems[6] = item;

                this.DisplayRecommandItemsPrice();
            }
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the PictureBoxHero control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PictureBoxHero_Click(object sender, EventArgs e)
        {
            this.m_heroPicker.ShowDialog();
            this.SelectedHero = this.m_heroPicker.SelectedHero;

            this.DisplaySelectedHero();
            this.ResetRecommandItem();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the RadioButtonClassic control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RadioButtonClassic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonClassic.Checked)
            {
                this.m_itemPicker.FilterMapType = MapType.Classic;
            }

            this.ResetRecommandItem();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the RadioButtonDominion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RadioButtonDominion_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonDominion.Checked)
            {
                this.m_itemPicker.FilterMapType = MapType.Dominion;
            }

            this.ResetRecommandItem();
        }

        /// <summary>
        /// Handles the Click event of the ButtonSaveToGameFolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonSaveToGameFolder_Click(object sender, EventArgs e)
        {
            if (this.RecommandItems.Where(i => i.Value == null).Count() > 0)
            {
                MessageBox.Show("您至少有一個道具是空的。請確定在存檔前已選滿六個道具。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var content = this.ConvertRecitemToContent(this.RecommandItems);

            var outputPath = this.GetGameFolderOutputPath();

            this.WriteRecommandItemToFile(outputPath, content);

            MessageBox.Show("儲存成功。\n您可以在遊戲中確認。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the Click event of the ButtonReadData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonReadData_Click(object sender, EventArgs e)
        {
            this.ReadRecommandItemFromFile();
        }

        /// <summary>
        /// Handles the Click event of the ButtonSaveToFileFolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonSaveToFileFolder_Click(object sender, EventArgs e)
        {
            if (this.RecommandItems.Where(i => i.Value == null).Count() > 0)
            {
                MessageBox.Show("您至少有一個道具是空的。請確定在存檔前已選滿六個道具。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var content = this.ConvertRecitemToContent(this.RecommandItems);

            var outputPath = this.GetFileFolderOutputPath();

            this.WriteRecommandItemToFile(outputPath, content);

            MessageBox.Show("已成功儲存為檔案。(位置在這執行檔的\\save\\" + this.SelectedHero.Name + "的資料夾裡)\n您可以自行移動至\n 安裝目錄\\GameData\\Apps\\LoLTW\\Game\\DATA\\Characters\\" + this.SelectedHero.Name + "的資料夾下以儲存至遊戲。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the Click event of the ButtonResetHeroSetting control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonResetHeroSetting_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("您確定要刪除該英雄全部模式的儲存檔案嗎？\n這動作無法復原。", "全部刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            var outputPath = string.Empty;
            if (this.RadioButtonFileFolder.Checked)
            {
                outputPath = this.GetFileFolderOutputPath();
            }
            else
            {
                outputPath = this.GetGameFolderOutputPath();
            }

            var outputFolder = Path.GetDirectoryName(outputPath);
            if (Directory.Exists(outputFolder))
            {
                Directory.Delete(outputFolder, true);
                MessageBox.Show("已刪除該英雄的設定檔", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ResetRecommandItem();
            }
            else
            {
                MessageBox.Show("沒有找到設定檔。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ResetRecommandItem();
            }

        }

        /// <summary>
        /// Initializes the game folder.
        /// </summary>
        private void InitializeGameFolder()
        {
            var gameFolderPath = this.m_dataRepository.GetGameFolder();

            if (string.IsNullOrEmpty(gameFolderPath))
            {
                MessageBox.Show("程式無法找到您安裝英雄聯盟的資料夾(台版)。請瀏覽到您安裝遊戲的資料夾(GarenaLoLTW)", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.TextBoxRoot.Text = gameFolderPath;
            }
        }

        /// <summary>
        /// Initializes the hero.
        /// </summary>
        private void DisplaySelectedHero()
        {
            if (this.SelectedHero != null)
            {
                this.PictureBoxHero.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetHeroImagePath(this.SelectedHero.Name));

                this.LabelHeroName.Text = this.SelectedHero.ChineseName;
            }
            else
            {
                this.PictureBoxHero.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultHeroImagePath());

                this.LabelHeroName.Text = "尚未選擇";
            }
        }

        /// <summary>
        /// Displays the recommand items price.
        /// </summary>
        private void DisplayRecommandItemsPrice()
        {
            var totalPrice = this.RecommandItems.Where(i => i.Value != null)
                                                .Sum(i => i.Value.Price);

            this.LabelItemPrice.Text = string.Format("物品售價: {0}", totalPrice);
        }

        /// <summary>
        /// Resets the recommand item.
        /// </summary>
        private void ResetRecommandItem()
        {
            this.RecommandItems = new Dictionary<int, Item>()
                                  {
                                      { 1 , null },
                                      { 2 , null },
                                      { 3 , null },
                                      { 4 , null },
                                      { 5 , null },
                                      { 6 , null },
                                  };

            this.PictureBoxRecItem1.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultItemImagePath());
            this.PictureBoxRecItem2.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultItemImagePath());
            this.PictureBoxRecItem3.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultItemImagePath());
            this.PictureBoxRecItem4.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultItemImagePath());
            this.PictureBoxRecItem5.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultItemImagePath());
            this.PictureBoxRecItem6.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetDefaultItemImagePath());
        }

        /// <summary>
        /// Converts the content of the recitem to.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        private string ConvertRecitemToContent(Dictionary<int, Item> dictionary)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("[ItemSet1]");
            builder.AppendLine("SetName=Set1");

            for (int i = 1; i < 7; i++)
            {
                builder.AppendLine(string.Format("RecItem{0}={1}", i, this.RecommandItems[i].Code));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Writes the recommand item to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void WriteRecommandItemToFile(string filePath, string content)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(filePath, content);
        }

        /// <summary>
        /// Reads the recommand item from file.
        /// </summary>
        private void ReadRecommandItemFromFile()
        {
            if (this.SelectedHero == null)
            {
                return;
            }

            var outputPath = string.Empty;
            if (this.RadioButtonFileFolder.Checked)
            {
                outputPath = this.GetFileFolderOutputPath();
            }
            else
            {
                outputPath = this.GetGameFolderOutputPath();
            }

            if (File.Exists(outputPath))
            {
                var content = File.ReadAllText(outputPath);

                try
                {
                    this.RecommandItems = this.ConvertContentToRecommandItems(content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取失敗! 無法解析來源資料!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("讀取失敗! 找不到來源資料檔案!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.RecommandItems.Where(i => i.Value == null).Count() == 0)
            {
                this.PictureBoxRecItem1.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(this.RecommandItems[1].Code));
                this.PictureBoxRecItem2.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(this.RecommandItems[2].Code));
                this.PictureBoxRecItem3.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(this.RecommandItems[3].Code));
                this.PictureBoxRecItem4.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(this.RecommandItems[4].Code));
                this.PictureBoxRecItem5.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(this.RecommandItems[5].Code));
                this.PictureBoxRecItem6.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(this.RecommandItems[6].Code));

                this.DisplayRecommandItemsPrice();
            }
            else
            {
                MessageBox.Show("讀取失敗! 來源資料格式錯誤!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Converts the content to recommand items.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        private Dictionary<int, Item> ConvertContentToRecommandItems(string content)
        {
            Dictionary<int, Item> recommandItems = new Dictionary<int, Item>();
            var data = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var counter = 1;
            for (int i = 2; i < 8; i++)
            {
                var code = data[i].Split('=')[1];
                var item = this.m_dataRepository.GetItemByCode(Convert.ToInt32(code));

                recommandItems.Add(counter++, item);
            }

            return recommandItems;
        }

        /// <summary>
        /// Gets the game folder output path.
        /// </summary>
        /// <returns></returns>
        private string GetGameFolderOutputPath()
        {
            var rootFolder = this.TextBoxRoot.Text;
            var fileName = this.RadioButtonClassic.Checked ? "RecItemsCLASSIC.ini" : "RecItemsODIN.ini";
            var outputPath = string.Format("{0}\\GameData\\Apps\\LoLTW\\Game\\DATA\\Characters\\{1}\\{2}", rootFolder, this.SelectedHero.Name, fileName);
            return outputPath;
        }

        /// <summary>
        /// Gets the file folder output path.
        /// </summary>
        /// <returns></returns>
        private string GetFileFolderOutputPath()
        {
            var rootFolder = Application.StartupPath + "\\save";
            var fileName = this.RadioButtonClassic.Checked ? "RecItemsCLASSIC.ini" : "RecItemsODIN.ini";
            var outputPath = string.Format("{0}\\{1}\\{2}", rootFolder, this.SelectedHero.Name, fileName);
            return outputPath;
        }
    }
}
