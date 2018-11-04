using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace qcm
{
    // FEUILLE MERE : héberge des feuilles filles (Questionnaire, A propos, Saisie du nom....)
    public partial class Mère : Form
    {
        #region ATTRIBUTS
        private List<questionnaire> listeques;
        private questionnaire unquestionnaire;
        private about unabout;
        private saisie unesaisie;
        public string utilisateur;      // Nom de l'utilisateur saisi
        public bool valider;            // Indicateur pour ajout des réponses effectuées dans la BD 

        #endregion

        #region  CONSTRUCTEUR

        public Mère()
        {
            InitializeComponent();
            this.listeques = new List<questionnaire>();
            this.unquestionnaire = null;
            this.unabout = null;
            this.utilisateur = "";
            this.valider = false;
        }

        #endregion

        #region CHARGEMENT DE LA FEUILLE

        // Saisir le nom de l'utilisateur
        private void Mère_Load(object sender, EventArgs e)
        {
            this.unesaisie = new saisie(this);
            this.unesaisie.Show();
        }

        #endregion

        #region OPTIONS DU MENU FICHIER

        // *** A COMPLETER
        // Fichier XML - NOUVEAU
        // Ouverture d'un fichier XML, puis instanciation et affichage d'un objet de classe "questionnaire"
        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".xml")
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        this.unquestionnaire = new questionnaire(filePath, this);
                        this.unquestionnaire.ControlBox = false;             // supprimer controleurs barre du haut

                        this.listeques.Add(this.unquestionnaire);
                        this.unquestionnaire.Show();                         // on affiche le dernier questionnaire
                    }
                    else
                        MessageBox.Show("Veuillez saisir un fichier au format .XML","Erreur extension fichier", MessageBoxButtons.OK);
                   
                }
            }


            }

        // *** A COMPLETER
        // Fichier XML - FERMER
        // Ferme la feuille FILLE active sans provoquer d'ajout dans la BD des réponses effectuées
        // (cf. VALIDER)
        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (this.unquestionnaire != null)
            {
                this.unquestionnaire.Close();                       // ferme questionnaire en cours
                this.unquestionnaire.Afficher();
                this.listeques.RemoveAt(this.listeques.Count - 1);

                if(this.listeques.Count > 0)
                     this.unquestionnaire = this.listeques[listeques.Count - 1];    // reéssignation questionnaire
                


            }
      
        }

        // *** A COMPLETER
        // Fichier XML - VALIDER
        //  * Positionner l'attribut "valider" à VRAI (=la feuille fille correspondante
        //    y aura accès et, lors de sa fermeture, lancera l'ajout dans la BD des réponses effectuées)
        //  * Fermeture de la feuille FILLE active (=l'événement "Form Closing" se produira
        //    juste avant sa fermeture définitive)
        private void ValiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.unquestionnaire.Afficher();
            this.unquestionnaire.Insérer();
                   

        }

        // Fichier XML - QUITTER
        // Ferme la feuille mère
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.valider = false;
            this.Close();
        }

        // Fenêtre - CASCADE
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        // Fenêtre - MOSAIQUE HORIZONTALE
        private void mosaiquehorizontaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        // Fenêtre - MOSAIQUE VERTICALE
        private void mosaiqueverticaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        // Aide - A PROPOS
        private void aproposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unabout = new about(this);
            unabout.Show();
        }

        #endregion

      
    }
}
