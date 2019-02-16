using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileInformation1
{
    public partial class Form1 : Form
    {

        string stazaDirektorija;
        string[] popisDatotekaUDirektoriju; 

        public Form1()
        {
            InitializeComponent();
        }

        private void odaberiDirektorijTipka_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                stazaDirektorija = folderBrowserDialog1.SelectedPath;
                direktorijTextBox.Text = stazaDirektorija;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            popisDatoteka.Items.Add("Tekst 1");
            popisDatoteka.Items.Add("Tekst 2");
            popisDatoteka.Items.Add("Tekst 3"); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            popisDatoteka.Items.Clear();
        }

        private void dodajPopisDatotekaButton_Click(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(stazaDirektorija))
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    stazaDirektorija = folderBrowserDialog1.SelectedPath;
                    direktorijTextBox.Text = stazaDirektorija;
                }
                else
                {
                    return;
                }
                /* Ovaj dio se kasnije može preskočiti kako ne bi svaki puta
                 * kada je staza u redu smetao korinsika */
                /*
                string message = "Staza direktorija je valjana";
                string caption = "Provjera valjanosti staze direktorija.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);*/         
            }
            /*else
            {
                string message = "Staza direktorija NIJE valjana!";
                string caption = "Provjera valjanosti staze direktorija.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
               
                return;
            }*/
           
                popisDatotekaUDirektoriju = Directory.GetFiles(stazaDirektorija);
           
            foreach (string datoteka in popisDatotekaUDirektoriju)
            {
                popisDatoteka.Items.Add(datoteka);
            }

            if (stazaDirektorija != null) 
            {
                folderBrowserDialog1.SelectedPath = stazaDirektorija;
            }

        }

        private void popisDatoteka_SelectedIndexChanged(object sender, EventArgs e)
        {

            string odabranaDatotekaStaza = popisDatotekaUDirektoriju[popisDatoteka.SelectedIndex];
            odabranaDatotekaTextBox.Text = odabranaDatotekaStaza;
            odabranaDatotekaIndexTextBox.Text = popisDatoteka.SelectedIndex.ToString();

            FileInfo fileInfo = new FileInfo(odabranaDatotekaStaza);
            
            string[] sufix = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int s = 0;
            long size = fileInfo.Length;
            while (size >= 1024)
            {
                s++;
                size /= 1024;
            }
            velicinaDatotekeTextBox.Text = size.ToString() + sufix[s];
            vrijeme.Text = fileInfo.LastAccessTime.ToString();
            atributi.Text = fileInfo.Attributes.ToString();
            read.Text = fileInfo.IsReadOnly.ToString();


        }

    }
}
