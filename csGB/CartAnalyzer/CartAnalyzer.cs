using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartAnalyzer
{
    public partial class CartAnalyzer : Form
    {
        public CartAnalyzer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadCart(fileDialog.FileName);
            }
        }

        private void LoadCart(string filePath)
        {
            var cart = Cart.GetFromFile(filePath);

            this.CartName.Text = cart.CartName;
            this.CartType.Text = cart.CartTypeName;

            this.RomBanks.Text = cart.RomBanks.ToString();
            this.RomSize.Text = cart.RomSize.ToString();

            this.RamBanks.Text = cart.RamBanks.ToString();
            this.RamSize.Text = cart.RamSize.ToString();

            this.SGBCheckBox.Checked = cart.SGB;
            this.GBColorCheckBox.Checked = cart.ColorGB;
        }
    }
}
