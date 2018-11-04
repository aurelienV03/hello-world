using System;
using System.Windows.Forms;

namespace qcm
{
    public partial class about : Form
    {
        // Constructeur
        public about(Form Mère)
        {
            InitializeComponent();

            // Associer cette feuille fille à la fenêtre mère
            this.MdiParent = Mère;
        }

        // Fermer
        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
