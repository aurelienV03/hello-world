using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Linq;



namespace qcm
{
    //------------------------------------------------
    // FEUILLE AFFICHANT UN QCM ISSU D'UN DOCUMENT XML
    //------------------------------------------------
    public partial class questionnaire : Form
    {
        #region ATTRIBUTS

        // Constantes
        private const int LARGEUR_CONTROLES = 300;
        private const int CARACTERES_PAR_LIGNE = 30;
        private const int HAUTEUR_PAR_LIGNE = 19;

        // Va permettre de définir l'emplacement :
        // 		a) Des objets de classes "graphiques" crées dans la feuille
        // 		b) D'une nouvelle feuille en fonction du nombre et de la taille 
        //         des contrôles qui seront crées dynamiquement
        // REMARQUE : la structure "Point" représente une paire 
        // ordonnée de coordonnées x et y entières qui définit 
        // un point dans un plan à deux dimensions.
        private Point Emplacement;
        private XmlDocument docXML;             // Document XML associé
        private string Titre;               // Titre de la feuille
        private List<string> Réponse;             // Réponse au questionnaire
        private string utilisateur;         // Nom de l'utilisateur
        private string cle;                 // Clé du questionnaire
        private Mère feuille_mère;          // Feuille mère

    

        Control.ControlCollection LesControles;  // tous les controleurs du questionnaire 
 

        #endregion

        #region CONSTRUCTEUR


        public questionnaire(string DocXML, Mère m)
        {
            InitializeComponent();
            this.Height = 0;
            this.Width = questionnaire.LARGEUR_CONTROLES;
            // Associer cette feuille fille à la fenêtre mère
            this.MdiParent = m;

            // Initialiser les attributs : feuille mère et utilisateur
            // (à partir de la valeur del'attribut de l'objet feuille mère)
            this.feuille_mère = m;
            this.utilisateur = m.utilisateur;
           
            // Remplir le questionnaire à partir du document XML
            this.CreerAPartirXML(DocXML);
        }

        #endregion

        #region ACCESSEURS

        // Retourne ou modifie la propriété "Height" de la feuille
        private int LaHauteur
        {
            get { return this.Height; }
            set { this.Height = value; }
        }

        // Retourne ou modifie la propriété "Width" de la feuille
        private int Largeur
        {
            get { return this.Width; }
            set { this.Width = value; }
        }

        // Retourne une COLLECTION des objets des classes graphiques 
        // (=CONTROLES) figurant sur la feuille
        private Control.ControlCollection TousLesControles
        {
            get { return this.Controls; }
      
        }

        // Retourne ou modifie la propriété privée "Titre", et dans ce dernier cas, 
        // la propriété "Text" de la feuille est renseignée.
        private string LeTitre
        {
            get { return Titre; }

            set
            {
                Titre = value;
                this.Text = Titre;
            }
        }

        // Nom de l'utilisateur
        public string LeNom
        {
            get { return this.utilisateur; }
            set { this.utilisateur = value; }
        }

        #endregion

        #region METHODES

        // *** A COMPLETER
        //-----------------------------------------------------------------
        // Création dynamique de contrôles et positionnement sur la feuille 
        // à partir du contenu d'un document XML représentant un QCM
        //-----------------------------------------------------------------
        private void CreerAPartirXML(string doc)
        {
            try
            {
                                
                XmlDocument docXML = new XmlDocument();
                docXML.Load(doc);
              
            
                XmlNode node = docXML.SelectSingleNode("questionnaire");       // recupere nom questionnaire                               
                string name = node.Attributes[1].InnerText;
                string cle = node.Attributes[0].InnerText;        
                this.LeTitre = name;
                this.cle = cle;

                XmlNodeList listeQuestion = docXML.SelectNodes("/questionnaire/question");           
                this.LesControles = this.TousLesControles;
                
                Emplacement = new Point(10, 10);
          

                foreach (XmlNode question in listeQuestion)
                {
                   
                    if (question.Attributes[0].InnerText == "combo")
                    {
                        Emplacement = this.AddComboBox(question, LesControles, this.Emplacement, "");
                       
                    }
                    else if(question.Attributes[0].InnerText == "text")
                    {               
                        Emplacement =  this.AddTextBox(question, LesControles, this.Emplacement, "");
                       
                    }
                    else if (question.Attributes[0].InnerText == "liste")
                    {
                        Emplacement = this.AddListBox(question, LesControles, this.Emplacement, "", true);
                       
                    }
                    else if (question.Attributes[0].InnerText == "radio")
                    {
                        Emplacement =  this.AddRadioButtons(question, LesControles, this.Emplacement, "");
                        
                    }
                    this.Height = 1000;
                }

           
                // ON SPÉCIFIE LA NOUVELLE LARGEUR ET LA NOUVELLE HAUTEUR DE LA FEUILLE

                this.Largeur = Emplacement.X + LARGEUR_CONTROLES + 40;
                this.LaHauteur = Emplacement.Y + 40;
               
                // AFFICHAGE DU QUESTIONNAIRE
                this.Show();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "QCM2", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private Point AddComboBox(XmlNode question, Control.ControlCollection desControles, Point unEmplacement, string premier)
        {
            // CREATION COMBOBOX + ATTRIBUTS

            Point EmplacementCombo = unEmplacement;
            EmplacementCombo.Y += 15;
            ComboBox combobox = new ComboBox();
            combobox.Location = EmplacementCombo;
            combobox.Name =  question.Attributes["name"].Value;
            combobox.Width = 250;
          

            if (question.SelectSingleNode("reponses/defaultreponse") != null)  // 1 reponse 
            {
                combobox.Text = question.SelectSingleNode("reponses/defaultreponse").InnerText;
                combobox.SelectAll();
            }
            else                                                            // plusieurs reponses
            {

                XmlNodeList reponses = question.SelectNodes("reponses/reponse");
                foreach (XmlNode rep in reponses)
                {
                    combobox.Items.Add(rep.InnerText);
                }
            }
               desControles.Add(combobox);
     
            XmlNode nomQuestionnaire = question.SelectSingleNode("text");
            string name = nomQuestionnaire.InnerText;
                   
            Label monlabel2 = new Label();
            monlabel2.Name = "label";
            monlabel2.Text = name;
            monlabel2.Width = 200;
           
            // Ajout à la collection
            monlabel2.Location = unEmplacement;
            desControles.Add(monlabel2);

            unEmplacement.Y += 50;
            this.Height += Emplacement.Y;       // Hauteur questionnaire 
            return unEmplacement;
        }

        private Point AddListBox(XmlNode question, Control.ControlCollection desControles, Point unEmplacement, string premier, bool MultiSelect)
        {
            Point copieEmplacement = unEmplacement;
            copieEmplacement.Y += 15;
          
            ListBox listebox = new ListBox();
            listebox.Name = question.Attributes["name"].Value;
            listebox.Width = 200;
            listebox.Height = 25;
            listebox.Location = copieEmplacement;

            // On positionne la propriété "SelectionMode" de la ListBox en fonction du paramètre de type booléen "MultiSelect"

            if (MultiSelect)
                listebox.SelectionMode = SelectionMode.MultiExtended;
            else
                listebox.SelectionMode = SelectionMode.One;

            if (question.SelectSingleNode("reponses/defaultreponse") != null)  // 1 reponse 
            {
                listebox.Items.Add(question.SelectSingleNode("reponses/defaultreponse").InnerText);
                listebox.Height += 50;
            }
            else
            {
                XmlNodeList reponses = question.SelectNodes("reponses/reponse");
                foreach (XmlNode rep in reponses)
                {
                    listebox.Items.Add(rep.InnerText);
                    listebox.Height += questionnaire.HAUTEUR_PAR_LIGNE;
                }
            }
            desControles.Add(listebox);

            // Création d'un Label

            XmlNode nomQuestionnaire = question.SelectSingleNode("text");
            string name = nomQuestionnaire.InnerText;
            Label monlabel2 = new Label();
            monlabel2.Name = "label";
            monlabel2.Text = name;
            monlabel2.Width = 200;
            monlabel2.Location = unEmplacement;
            desControles.Add(monlabel2);
       
            unEmplacement.Y += listebox.Height + 50;
            this.Height += Emplacement.Y;       // Hauteur questionnaire 
            return unEmplacement;
        }

        private Point AddRadioButtons(XmlNode question, Control.ControlCollection desControles, Point unEmplacement, string premier)
        {

         
            // Création d'une GroupBox contenant les boutons radio
            XmlNode text = question.SelectSingleNode("text");
            string NomQuestion = text.InnerText;

            // Création d'un Label
            Label monlabel = new Label();
            monlabel.Text = NomQuestion;
            monlabel.Name = "label";
            monlabel.Width = this.Width;

              
            // Ajout à la collection
            monlabel.Location = unEmplacement;
            desControles.Add(monlabel);

            GroupBox gb = new GroupBox();         
            gb.Enabled = true;
            gb.Width = 300;                                                 //ANCIENNE VERSION
            gb.Height = 50;
            gb.Name = question.Attributes["name"].Value;
            
            RadioButton rb;

            // N"cessaire pour positioner les RadioButtons et redimensionner le GroupBox les contenant

            if (question.SelectSingleNode("reponses/defaultreponse") != null)
            {
                rb = new RadioButton();
                unEmplacement.Y += 20;           
                rb.Text = question.SelectSingleNode("reponses/defaultreponse").InnerText;
                rb.Location = unEmplacement;
                rb.Name = question.Attributes["name"].Value;
                /*
                gb.Controls.Add(rb);            
                gb.Height += 20;
                */

            }
            else
            {
                XmlNodeList reponses = question.SelectNodes("reponses/reponse");
               
                foreach (XmlNode reponse in reponses)
                {
                   
                    rb = new RadioButton();
                    rb.Name = question.Attributes["name"].Value;
                    rb.Text = reponse.InnerText;
                    rb.Location = unEmplacement;
                    desControles.Add(rb);
                    unEmplacement.Y += 20;
                    // gb.Height += 20;                    
                }
            }
               
     
          

            // gb.Location = unEmplacement;
            //desControles.Add(gb);       
             unEmplacement.Y += gb.Height + 50;
            this.Height += Emplacement.Y;       // Hauteur questionnaire 
            return unEmplacement;
        }

        private Point AddTextBox(XmlNode unNoeud, Control.ControlCollection desControles, Point unEmplacement, string premier)
        {
            
            // Création d'un contrôle TextBox.
            TextBox maTextBox = new TextBox();
    
            // Il y a-t-il une réponse par défaut ? (cf. noeud <defaultreponse>
            if (unNoeud.SelectSingleNode("reponses/defaultreponse") != null)
                maTextBox.Text = unNoeud.SelectSingleNode("reponses/defaultreponse").InnerText;

            // Valeur de l'attribut "name" de la balise <question> en cours
            if (unNoeud.Attributes["name"] != null)
                maTextBox.Name = unNoeud.Attributes["name"].Value;
   
            maTextBox.Width = LARGEUR_CONTROLES;
            
            // Il y a-t-il un nombre maximal de caractères ? (cf. noeud <maxCharacters>)
            if (unNoeud.SelectSingleNode("reponses/maxCharacters") != null)
                    maTextBox.MaxLength = int.Parse(unNoeud.SelectSingleNode("reponses/maxCharacters").InnerText);

            // Calculer le nombre de lignes qui devront être affichées

            if (maTextBox.MaxLength > 0)
            {
                int numLines = (maTextBox.MaxLength / CARACTERES_PAR_LIGNE) + 1;

                // Calculer la largeur de la TextBox, et par conséquent s'il y a lieu
                // d'avoir des barres de défilement
                if (numLines == 1)
                    maTextBox.Multiline = false;
                else
                {
                    if (numLines >= 4)
                    {
                        maTextBox.Multiline = true;
                        maTextBox.Height = 4 * HAUTEUR_PAR_LIGNE;
                        maTextBox.ScrollBars = ScrollBars.Vertical;
                    }
                    else
                    {
                        maTextBox.Multiline = true;
                        maTextBox.Height = numLines * HAUTEUR_PAR_LIGNE;
                        maTextBox.ScrollBars = ScrollBars.None;
                    }
                }
            }
            
            // Création d'un Label

            Label monLabel = new Label();
            monLabel.Name =   "Label";
            if (unNoeud.SelectSingleNode("text") != null)
                monLabel.Text = unNoeud.SelectSingleNode("text").InnerText;
       
            monLabel.Width = LARGEUR_CONTROLES;

            // Ajout à la collection
            monLabel.Location = unEmplacement;
            desControles.Add(monLabel);
            unEmplacement.Y += monLabel.Height;

            maTextBox.Location = unEmplacement;
            desControles.Add(maTextBox);
           
            unEmplacement.Y += maTextBox.Height + 10;
       
            this.Height += Emplacement.Y;       // Hauteur questionnaire 
            return unEmplacement;
            
            

        }



        // *** A COMPLETER
        //-----------------------------------------------------------
        // AFFICHE le résultat du questionnaire sans ajout dans la BD
        //-----------------------------------------------------------



        public void Afficher()
        {
         
            this.Réponse = new List<string>();          // reponses pour BDD       
            string afficher = "";

            // Parcours de chaque contrôle  
            foreach (Control monControle in this.LesControles)
            {
           
                switch (monControle.GetType().ToString().ToLower())
                {
                    case "system.windows.forms.combobox":           // COMBOBOX
                        ComboBox cb = (ComboBox)monControle;                    
                        if (cb.SelectedItem != null)
                        {
                            afficher += cb.Name + "  " + (string)cb.SelectedItem + "\n";
                            this.Réponse.Add(cb.Name + " - " + (string)cb.SelectedItem);
                        }
                        break;
                    case "system.windows.forms.listbox":            // LISTEBOX
                        ListBox lb = (ListBox)monControle;                 
                        var reponses = lb.SelectedItems;
              
                        if (reponses != null)
                        {
                            afficher += lb.Name + " - ";
                            foreach (string reponse in reponses)
                            {
                                if (reponse != "")
                                    afficher += "\t" + reponse + "\t" + "\n";
                                this.Réponse.Add(lb.Name + " - " + reponse);
                            }
                        }
                        break;
                    case "system.windows.forms.radiobutton":       //  radio buttons)      
                        
                        RadioButton rb = (RadioButton)monControle;
                        if (rb.Checked)
                        {
                            afficher += rb.Name + " - " + rb.Text+ "\n";
                            this.Réponse.Add(rb.Name + " - " + rb.Text);                  
                        }
                        break;

                    case "system.windows.forms.textbox":       // TEXTBOX        
                        
                    
                        break;
                    




                }




                // REMARQUE : pour une liste, on parcours l'ensemble des lignes sélectionnées

            }
            MessageBox.Show(afficher);
           
            //  MessageBox.Show(Réponse + " NOM : " + this.LeNom, this.Réponse, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


      
        //-----------------------------------------------
        // AJOUTE le résultat du questionnaire dans la BD
        //-----------------------------------------------
        public void Insérer()
        {

            foreach (Control monControle in this.LesControles)
            {

                switch (monControle.GetType().ToString().ToLower())
                {
                    case "system.windows.forms.combobox":           // COMBOBOX
                        ComboBox cb = (ComboBox)monControle;
                        if (cb.SelectedItem != null)
                        {
                           
                            this.Réponse.Add(cb.Name + " - " + (string)cb.SelectedItem);
                        }
                        break;
                    case "system.windows.forms.listbox":            // LISTEBOX
                        ListBox lb = (ListBox)monControle;
                        var reponses = lb.SelectedItems;

                        if (reponses != null)
                        {
                           
                            foreach (string reponse in reponses)
                            {
                                if (reponse != "")
                                   
                                this.Réponse.Add(lb.Name + " - " + reponse);
                            }
                        }
                        break;
                    case "system.windows.forms.radiobutton":       //  radio buttons)      

                        RadioButton rb = (RadioButton)monControle;
                        if (rb.Checked)
                        {
                           
                            this.Réponse.Add(rb.Name + " - " + rb.Text);
                        }
                        break;

                    case "system.windows.forms.textbox":       // TEXTBOX        


                        break;





                }




                // REMARQUE : pour une liste, on parcours l'ensemble des lignes sélectionnées

            } // on recupere les infos des controleurs

            string chaineDeConnexion = "DSN=MySQLDSN";
            string requete = "";
            OdbcCommand commande;
            OdbcConnection MaConnexion = new OdbcConnection(chaineDeConnexion);
            MaConnexion.Open();

            if(this.utilisateur == "" )     // Parametre utilisateur manquant 
            {
                this.utilisateur = "inconnu";
            }
                                  
            try
            {
                int nb = 1;                 // numero de la reponse          
                foreach (string reponse in this.Réponse)
                {
                    requete = "INSERT INTO reponses(cle_questionnaire, utilisateur, rang, date_creation, reponse) VALUES('"+this.cle+"', '"+this.utilisateur+"', "+nb+", NOW(), '"+reponse+"')";
                    MessageBox.Show("rep : " + reponse);
                    commande = new OdbcCommand(requete, MaConnexion);
                    commande.ExecuteNonQuery();
                    nb++;
                }
                
                 MessageBox.Show("Ajouts terminés (" + (nb-1) + " lignes )"  , "QCM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                MaConnexion.Close();
            }
        }


        // *** A COMPLETER
        //----------------------------------------
        // A LA FERMETURE : on affiche le résultat
        //----------------------------------------
        private void questionnaire_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (feuille_mère.valider)
                this.Insérer();
            else
                this.Afficher();
        
        }


        #endregion

        private void questionnaire_Load(object sender, EventArgs e)
        {

        }

    
    }
}
