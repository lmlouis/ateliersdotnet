using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenFileDialogue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }



        //au chargement du bouton Save 
        private void button1_Click(object sender, EventArgs e)
        {
            //Déclaration du fichier
            saveFileDialog1.InitialDirectory = Application.ExecutablePath;
            saveFileDialog1.Filter = "Fichiers texte (*.txt)|*.txt |Tous les fichiers (*.*)|*.* ";
            //saveFileDialog1.FilterIndex = 0;
            //afficher la boite de dialogue et recuperer le resultat
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //recuperer nom fichier 
                string nomFichier = saveFileDialog1.FileName;
                StreamWriter fichier = null;
                try
                {
                    //on ouvre le fichier en écriture
                    fichier = new StreamWriter(nomFichier);
                    //on écrit le texte dedans 
                    fichier.Write(richTextBox1.Text);
                }
                catch (Exception ex)
                {
                    //probleme
                    MessageBox.Show("Probleme à l'écriture du fichier(" +
                        ex.Message + ")", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                finally
                {
                    //on ferme le fichier 
                    if(fichier != null)
                    {
                        fichier.Dispose();
                    }

                }

            }
        }

        //au chargement du bouton Load

        private void button2_Click(object sender, EventArgs e)
        {
            //déclarer le fichier à ouvrir
            openFileDialog1.InitialDirectory = Application.ExecutablePath;
            openFileDialog1.Filter = "Fichiers texte (*.txt)|*.txt |Tous les fichiers (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;
            //afficher la boite de dialogue
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //recuperer nom fichier 
                string nomFichier = openFileDialog1.FileName;
                StreamReader fichier = null;
                try
                {
                    //on ouvre le fichier en lecture 
                    fichier = new StreamReader(nomFichier);
                    //on écrit le texte dedans 
                    richTextBox1.Text =  fichier.ReadToEnd();
                }
                catch (Exception ex)
                {
                    //probleme
                    MessageBox.Show("Probleme à l'écriture du fichier(" +
                        ex.Message + ")", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                finally
                {
                    //on ferme le fichier 
                    if (fichier != null)
                    {
                        fichier.Dispose();
                    }

                }

            }
        }

        //au chargement du bouton Clear

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Le Fichier est déja vide ");
            }
            else
            {
                richTextBox1.Text = "";
            }

        }

        //au chargement du bouton Color
        private void button4_Click(object sender, EventArgs e)
        {
            //colorer  le text 
            if(colorDialog1.ShowDialog()==DialogResult.OK)
                richTextBox1.ForeColor = colorDialog1.Color;

        }
        //au chargement du bouton Font
        private void button5_Click(object sender, EventArgs e)
        {
            //changer la police d'écriture du text 
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog1.Font;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
