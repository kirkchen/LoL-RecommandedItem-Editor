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
    /// HeroPicker
    /// </summary>
    public partial class HeroPicker : Form
    {
        /// <summary>
        /// DataRepository
        /// </summary>
        private DataRepository m_dataRepository = new DataRepository();

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
        /// Initializes a new instance of the <see cref="HeroPicker"/> class.
        /// </summary>
        public HeroPicker()
        {
            InitializeComponent();

            this.DisplayHeroes();
        }

        /// <summary>
        /// Handles the Load event of the HeroPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HeroPicker_Load(object sender, EventArgs e)
        {
            //this.DisplayHeroes();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ComboBoxHeroName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ComboBoxHeroName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Highlight選取的圖片
            foreach (Control control in this.FlowLayoutPanelHero.Controls)
            {
                if (control is PictureBox)
                {
                    (control as PictureBox).BackColor = Color.Transparent;
                }

                if (control.Name == this.ComboBoxHeroName.SelectedValue.ToString())
                {
                    var itemPicture = control as PictureBox;
                    itemPicture.BackColor = Color.Red;

                    // 顯示詳細說明
                    this.SelectedHero = this.m_dataRepository.GetHeroByName(itemPicture.Name);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (this.SelectedHero != null)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("您尚未選擇任何英雄!", "請選擇英雄", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.SelectedHero = null;
            this.Hide();
        }

        /// <summary>
        /// Displays the heroes.
        /// </summary>
        private void DisplayHeroes()
        {
            var result = this.m_dataRepository.GetHeroes();

            if (this.FlowLayoutPanelHero.Controls.Count == 0)
            {
                foreach (var item in result)
                {
                    PictureBox itemPicture = new PictureBox();
                    itemPicture.Name = item.Name.ToString();
                    itemPicture.Image = Image.FromFile(Application.StartupPath + @"\images\champions_files\" + item.Name + ".jpg");
                    itemPicture.Size = new Size(80, 80);
                    itemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    itemPicture.Click += new EventHandler(ItemPicture_Click);
                    itemPicture.Padding = new Padding(5);
                    itemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    itemPicture.BorderStyle = BorderStyle.None;

                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(itemPicture, item.ChineseName);

                    this.FlowLayoutPanelHero.Controls.Add(itemPicture);

                    this.ComboBoxHeroName.AutoCompleteCustomSource.Add(item.ChineseName);                    
                }

                this.ComboBoxHeroName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.ComboBoxHeroName.AutoCompleteMode = AutoCompleteMode.Suggest;

                this.ComboBoxHeroName.DataSource = new BindingSource(result, null);
                this.ComboBoxHeroName.DisplayMember = "ChineseName";
                this.ComboBoxHeroName.ValueMember = "Name";
            }
        }

        /// <summary>
        /// Handles the Click event of the itemPicture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ItemPicture_Click(object sender, EventArgs e)
        {
            this.ComboBoxHeroName.SelectedValue = (sender as Control).Name;
        }        
    }
}
