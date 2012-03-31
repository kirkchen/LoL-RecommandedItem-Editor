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

namespace LoLRecommandItemUpdater
{
    /// <summary>
    /// Item's Picker
    /// </summary>
    public partial class ItemPicker : Form
    {
        /// <summary>
        /// DataRepository
        /// </summary>
        private DataRepository m_dataRepository = new DataRepository();

        /// <summary>
        /// Gets or sets the seletected item.
        /// </summary>
        /// <value>
        /// The seletected item.
        /// </value>
        public Item SeletectedItem
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the filter map.
        /// </summary>
        /// <value>
        /// The type of the filter map.
        /// </value>
        public MapType FilterMapType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the filter item.
        /// </summary>
        /// <value>
        /// The type of the filter item.
        /// </value>
        public ItemType FilterItemType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the filter keyword.
        /// </summary>
        /// <value>
        /// The filter keyword.
        /// </value>
        public string FilterKeyword
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemPicker"/> class.
        /// </summary>
        public ItemPicker()
        {
            InitializeComponent();

            this.FilterMapType = MapType.All;
            this.FilterItemType = ItemType.All;

            this.DisplayItems();
        }

        /// <summary>
        /// Handles the Load event of the ItemPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ItemPicker_Load(object sender, EventArgs e)
        {
            this.DisplayItems();

            this.ResetSelectedPicture();

            this.SeletectedItem = null;
        }

        /// <summary>
        /// Handles the Click event of the ButtonConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (this.SeletectedItem != null)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("您尚未選擇任何物品!", "請選擇物品", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.SeletectedItem = null;
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the ButtonSeletectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonSeletectAll_Click(object sender, EventArgs e)
        {
            this.CheckboxHealth.Checked = true;
            this.CheckboxArmor.Checked = true;
            this.CheckboxHealthRegen.Checked = true;
            this.CheckboxMagicResist.Checked = true;
            this.CheckboxDamage.Checked = true;
            this.CheckboxCriticalStrike.Checked = true;
            this.CheckboxAttackSpeed.Checked = true;
            this.CheckboxLifeSteal.Checked = true;
            this.CheckboxSpellDamage.Checked = true;
            this.CheckboxCooldownReduction.Checked = true;
            this.CheckboxMana.Checked = true;
            this.CheckboxManaRegen.Checked = true;
            this.CheckboxMovement.Checked = true;
            this.CheckboxConsumable.Checked = true;

            this.FilterItemType = ItemType.All;

            this.DisplayItems();
        }

        /// <summary>
        /// Handles the Click event of the ButtonUnSelectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonUnSelectAll_Click(object sender, EventArgs e)
        {
            this.CheckboxHealth.Checked = false;
            this.CheckboxArmor.Checked = false;
            this.CheckboxHealthRegen.Checked = false;
            this.CheckboxMagicResist.Checked = false;
            this.CheckboxDamage.Checked = false;
            this.CheckboxCriticalStrike.Checked = false;
            this.CheckboxAttackSpeed.Checked = false;
            this.CheckboxLifeSteal.Checked = false;
            this.CheckboxSpellDamage.Checked = false;
            this.CheckboxCooldownReduction.Checked = false;
            this.CheckboxMana.Checked = false;
            this.CheckboxManaRegen.Checked = false;
            this.CheckboxMovement.Checked = false;
            this.CheckboxConsumable.Checked = false;

            this.FilterItemType = ItemType.All;

            this.DisplayItems();
        }

        /// <summary>
        /// Handles the TextChanged event of the TextBoxItemName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TextBoxItemName_TextChanged(object sender, EventArgs e)
        {
            this.FilterKeyword = this.TextBoxItemName.Text.Trim();

            this.DisplayItems();
        }

        /// <summary>
        /// Handles the Click event of the CheckboxItemType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxItemType_Click(object sender, EventArgs e)
        {
            this.SwitchFilterItemType();

            this.DisplayItems();
        }

        /// <summary>
        /// Handles the Click event of the itemPicture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ItemPicture_Click(object sender, EventArgs e)
        {
            // 恢復所有圖片為未選取
            this.ResetSelectedPicture();

            // Highlight選取的圖片
            var itemPicture = sender as PictureBox;
            itemPicture.BackColor = Color.Red;

            // 顯示詳細說明
            this.SeletectedItem = this.m_dataRepository.GetItemByCode(Convert.ToInt32(itemPicture.Name));
            this.LabelDescription.Text = this.SeletectedItem.Description;
        }

        /// <summary>
        /// Resets the selected picture.
        /// </summary>
        private void ResetSelectedPicture()
        {
            foreach (var control in this.FlowLayoutPanelItems.Controls)
            {
                if (control is PictureBox)
                {
                    (control as PictureBox).BackColor = Color.Transparent;
                }
            }
        }

        /// <summary>
        /// Displays the items.
        /// </summary>
        /// <param name="result">The result.</param>
        private void DisplayItems()
        {            
            // 取得物品資料
            var result = this.m_dataRepository.GetItemsByType(this.FilterMapType, this.FilterItemType, this.FilterKeyword);

            // 顯示物品清單
            if (this.FlowLayoutPanelItems.Controls.Count == 0)
            {
                foreach (var item in result)
                {
                    PictureBox itemPicture = new PictureBox();
                    itemPicture.Name = item.Code.ToString();
                    itemPicture.Image = Image.FromFile(Application.StartupPath + FileRouteRepository.GetItemImagePath(item.Code));
                    itemPicture.Size = new Size(80, 80);
                    itemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    itemPicture.Click += new EventHandler(ItemPicture_Click);
                    itemPicture.Padding = new Padding(5);
                    itemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    itemPicture.BorderStyle = BorderStyle.None;

                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(itemPicture, item.Description);

                    this.FlowLayoutPanelItems.Controls.Add(itemPicture);

                    this.TextBoxItemName.AutoCompleteCustomSource.Add(item.Description.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).First());
                }

                TextBoxItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TextBoxItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            else
            {
                foreach (Control control in this.FlowLayoutPanelItems.Controls.Cast<Control>().Reverse())
                {
                    control.Visible = result.Where(i => i.Code.ToString() == control.Name).Count() > 0;
                }
            }
        }       

        /// <summary>
        /// Switches the type of the filter item.
        /// </summary>
        private void SwitchFilterItemType()
        {
            this.FilterItemType = ItemType.None;

            this.FilterItemType = this.CheckboxHealth.Checked ? this.FilterItemType | ItemType.Health : this.FilterItemType;
            this.FilterItemType = this.CheckboxArmor.Checked ? this.FilterItemType | ItemType.Armor : this.FilterItemType;
            this.FilterItemType = this.CheckboxHealthRegen.Checked ? this.FilterItemType | ItemType.HealthRegen : this.FilterItemType;
            this.FilterItemType = this.CheckboxMagicResist.Checked ? this.FilterItemType | ItemType.MagicResist : this.FilterItemType;
            this.FilterItemType = this.CheckboxDamage.Checked ? this.FilterItemType | ItemType.Damage : this.FilterItemType;
            this.FilterItemType = this.CheckboxCriticalStrike.Checked ? this.FilterItemType | ItemType.CriticalStrike : this.FilterItemType;
            this.FilterItemType = this.CheckboxAttackSpeed.Checked ? this.FilterItemType | ItemType.AttackSpeed : this.FilterItemType;
            this.FilterItemType = this.CheckboxLifeSteal.Checked ? this.FilterItemType | ItemType.LifeSteal : this.FilterItemType;
            this.FilterItemType = this.CheckboxSpellDamage.Checked ? this.FilterItemType | ItemType.SpellDamage : this.FilterItemType;
            this.FilterItemType = this.CheckboxCooldownReduction.Checked ? this.FilterItemType | ItemType.CooldownReduction : this.FilterItemType;
            this.FilterItemType = this.CheckboxMana.Checked ? this.FilterItemType | ItemType.Mana : this.FilterItemType;
            this.FilterItemType = this.CheckboxManaRegen.Checked ? this.FilterItemType | ItemType.ManaRegen : this.FilterItemType;
            this.FilterItemType = this.CheckboxMovement.Checked ? this.FilterItemType | ItemType.Movement : this.FilterItemType;
            this.FilterItemType = this.CheckboxConsumable.Checked ? this.FilterItemType | ItemType.Consumable : this.FilterItemType;

            // 若全部未選取, 視為全部選取
            if (this.FilterItemType == ItemType.None)
            {
                this.FilterItemType = ItemType.All;
            }
        }
    }
}
