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

            this.FilterItemType = ItemType.None;

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

        #region Checkbox ItemGroup Clicked

        /// <summary>
        /// Handles the Click event of the CheckboxHealth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxHealth_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxHealth, ItemType.Health);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxArmor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxArmor_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxArmor, ItemType.Armor);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxHealthRegen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxHealthRegen_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxHealthRegen, ItemType.HealthRegen);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxMagicResist control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxMagicResist_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxMagicResist, ItemType.MagicResist);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxDamage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxDamage_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxDamage, ItemType.Damage);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxCriticalStrike control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxCriticalStrike_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxCriticalStrike, ItemType.CriticalStrike);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxAttackSpeed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxAttackSpeed_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxAttackSpeed, ItemType.AttackSpeed);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxLifeSteal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxLifeSteal_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxLifeSteal, ItemType.LifeSteal);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxSpellDamage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxSpellDamage_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxSpellDamage, ItemType.SpellDamage);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxCooldownReduction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxCooldownReduction_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxCooldownReduction, ItemType.CooldownReduction);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxMana control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxMana_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxMana, ItemType.Mana);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxManaRegen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxManaRegen_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxManaRegen, ItemType.ManaRegen);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxMovement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxMovement_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxMovement, ItemType.Movement);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckboxConsumable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckboxConsumable_Click(object sender, EventArgs e)
        {
            this.SwitchDisplayItemType(this.CheckboxConsumable, ItemType.Consumable);
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the itemPicture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ItemPicture_Click(object sender, EventArgs e)
        {
            // Highlight選取的圖片
            foreach (var control in this.FlowLayoutPanelItems.Controls)
            {
                if (control is PictureBox)
                {
                    (control as PictureBox).BackColor = Color.Transparent;
                }
            }

            var itemPicture = sender as PictureBox;
            itemPicture.BackColor = Color.Red;

            // 顯示詳細說明
            this.SeletectedItem = this.m_dataRepository.GetItemByCode(Convert.ToInt32(itemPicture.Name));
            this.LabelDescription.Text = this.SeletectedItem.Description;
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
        /// Switches the type of the item.
        /// </summary>
        /// <param name="checkbox">The checkbox.</param>
        /// <param name="itemType">Type of the item.</param>
        private void SwitchDisplayItemType(CheckBox checkbox, ItemType itemType)
        {
            if (checkbox.Checked)
            {
                this.FilterItemType = this.FilterItemType | itemType;
            }
            else
            {
                this.FilterItemType = this.FilterItemType ^ itemType;
            }

            this.DisplayItems();
        }
    }
}
