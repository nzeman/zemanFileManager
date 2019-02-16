using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;

namespace Notepad___
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    // ovaj kod napisan na ovom mjestu (code-behind) u pravoj aplikaciji treba
    // pisati u zesebnim razredima, bilo da se radi o BL (business logic) razredima
    // model (podaci) ili o VM (view-model) razredima koji kontroliraju ponašanje sučelja
    // Koga zanima više WPF programiranje - proučiti MVVM pattern.
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void otvoriButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Multiselect = false;
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                lokacijaTextBox.Text = ofd.FileName;
                ispisTextBox.Text = File.ReadAllText(lokacijaTextBox.Text);
            }
            else
            {
                lokacijaTextBox.Text = "Datoteka nije odabrana...";
            }
        }

        private void pohraniUButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderTexBox.Text = folderBrowser.SelectedPath;
            }
            else
            {
                folderTexBox.Text = "Nije odabran folder za pohranu...";
            }
        }

        private async Task UpisiDatoteku(string _putanja)
        {
            using (StreamWriter sw = File.CreateText(_putanja))
                {
                    
                    //klasičan pristup
                    //sw.WriteLine(upisTextBox.Text);                    
                    
                    // ako želimo asinkrono pisati (ne blokira se sučelje)
                    // u .Net frameworku 4.5 postoje ključne riječi
                    // async i await i pripadajuće metode sa nastavkom Async
                    await sw.WriteLineAsync(upisTextBox.Text);
                }
            MessageBoxResult result = 
                System.Windows.MessageBox.Show("Datoteka " + _putanja + " uspješno spremljena!");

        }

        private async void spremiButton_Click(object sender, RoutedEventArgs e)
        {
            string putanja = folderTexBox.Text + @"\" + datotekaTexBox.Text;

            if (!File.Exists(putanja))
            {
                await UpisiDatoteku(putanja);
            }
            else
            {
                MessageBoxResult result = 
                    System.Windows.MessageBox.Show("Datoteka već postoji, prepisati?", "Upozorenje",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    await UpisiDatoteku(putanja);
                }
            }
        }


    }
}
