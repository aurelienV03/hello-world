using System;
using System.Windows.Forms;

namespace qcm
{
    //-------------------------------
    // Saisie du nom de l'utilisateur
    //-------------------------------
    public partial class saisie : Form
    {
        // Attribut: feuille mère
        Mère feuille_mère;

        // Constructeur : on lui passe une référence sur l'objet "feuille mère"
        public saisie(Mère m)
        {
            InitializeComponent();

            // Initialiser l'attribut feuille mère
            this.feuille_mère = m;
        }

        // Clic sur OK : renseigner le nom de l'utilisateur et fermer la feuille
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("Valeur du nom incorrecte !","QCM", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            { 
                this.feuille_mère.utilisateur = textBox1.Text;
                this.Close();
            }
        }
    }
}
