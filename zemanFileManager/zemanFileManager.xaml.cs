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
using MahApps.Metro.Controls;
using System.IO;
using Xceed.Wpf.Toolkit;
using System.Windows.Markup;




namespace zemanFileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ZemanFileManager : MetroWindow
    {

        public ZemanFileManager()
        {
            InitializeComponent();
            DisablajSveLijeveButtone();
            DisablajSveDesneButtone();

        }
        
        DriveInfo[] sviDiskovi = DriveInfo.GetDrives();

        public void PočistiStatusBar()
        {
            info.Text = "";
            statusBar.Background = Brushes.DeepSkyBlue;  
        }

        #region DISABLANJE I ENABLANJE BUTTONA
        public void DisablajSveLijeveButtone()
        {
            lijeviKopirajButton.IsEnabled = false;
            lijeviMoveButton.IsEnabled = false;
            lijeviDeleteButton.IsEnabled = false;
        }
        public void EnablajSveLijeveButtone()
        {
            lijeviKopirajButton.IsEnabled = true;
            lijeviMoveButton.IsEnabled = true;
            lijeviDeleteButton.IsEnabled = true;
        }
        public void DisablajSveDesneButtone()
        {
            desniDeleteButton.IsEnabled = false;
            desniKopirajButton.IsEnabled = false;
            desniMoveButton.IsEnabled = false;
        }
        public void EnablajSveDesneButtone()
        {
            desniDeleteButton.IsEnabled = true;
            desniKopirajButton.IsEnabled = true;
            desniMoveButton.IsEnabled = true;
        }
        #endregion

        #region REFRESHANJE LISTVIEWA
        public void RefreshajListView(ListView _listView, TextBox _textBox)
        {
            if (_textBox.Text != "")
            {

                try
                {
                    _listView.ItemsSource = null;

                    string stazaOdabranogDirektorija_Refresh = _textBox.Text.ToString();
                    //Console.Write("stazaOdabranogDirektorija_Refresh: " + stazaOdabranogDirektorija_Refresh + "\n");

                    string[] popisDatotekaUDirektoriju_Refresh = Directory.GetFiles(stazaOdabranogDirektorija_Refresh);

                    //Console.Write("Refresham " + _listView.Name + "; Staza odabranog direktorija Refresh: " + stazaOdabranogDirektorija_Refresh.ToString() + "\n");

                    DirectoryInfo d1 = new DirectoryInfo(stazaOdabranogDirektorija_Refresh);

                    if (d1.Exists)
                    {

                        FileInfo[] datoteke_Refresh = d1.GetFiles("*.*");
                        _listView.ItemsSource = datoteke_Refresh;
                    }


                }
                catch (Exception ex)
                {
                    info.Text = "Nemože se refreshati listview";
                }

            }
        }
        #endregion

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        string[] lijeviPopisDatotekaUDirektoriju;
        string[] desniPopisDatotekaUDirektoriju;

        string lijevaStazaOdabranogDirektorija;
        string desnaStazaOdabranogDirektorija;

        #region LIST VIEW SELECTION CHANGED
        private void ListView_SelectionChanged(ListView _listView, TextBox _textBox, TextBox _velicinaTextBox, TextBox _atributiDatotekeTextBox,  CheckBox _isReadOnlyCheckBox)
        {
            
            if (_listView.SelectedIndex >= 0 && _listView.Items.Count > _listView.SelectedIndex-1)
            {
                string[] popisDatotekaUDirektoriju_Refresh = Directory.GetFiles(_textBox.Text.ToString());

                string TEST = popisDatotekaUDirektoriju_Refresh[_listView.SelectedIndex];


                FileInfo fileInfo1 = new FileInfo(TEST);

                if (fileInfo1.Exists)
                {
                    _velicinaTextBox.Text = FormatBytes(fileInfo1.Length);
                    _atributiDatotekeTextBox.Text = fileInfo1.Attributes.ToString();

                    _isReadOnlyCheckBox.IsChecked = fileInfo1.IsReadOnly;

                    PočistiStatusBar();
                }
            }
        }
        private void lijeviListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListView_SelectionChanged(lijeviListView, lijeviPathTextBox ,lijevaVeličinaTextBox, lijeviAtributiDatotekeTextBox, lijeviIsReadOnlyCheckBox);

        }

   
        
        private void desniListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView_SelectionChanged(desniListView, desniPathTextBox ,desniVeličinaTextBox, desniAtributiDatotekeTextBox, desniIsReadOnlyCheckBox);
        }
        #endregion

        private void lijeviButton_Click(object sender, RoutedEventArgs e)
        {
           
            FolderBrowser fb1 = new FolderBrowser();

            fb1.Show();

            fb1.Closed += new EventHandler(fb1_Closed);
                

        }

        private void desniButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowser fb2 = new FolderBrowser();

            fb2.Show();

            fb2.Closed += new EventHandler(fb2_Closed);
            
        }

        #region FB1 & FB2 CLOSED EVENTI

        private void fb1_Closed(object sender, EventArgs e)
        {
            EnablajSveLijeveButtone() ;

            lijevaStazaOdabranogDirektorija = (sender as FolderBrowser).SelectedImagePath;
            lijeviPopisDatotekaUDirektoriju = Directory.GetFiles(lijevaStazaOdabranogDirektorija);
            lijeviPathTextBox.Text = lijevaStazaOdabranogDirektorija;

            DirectoryInfo d1 = new DirectoryInfo(lijevaStazaOdabranogDirektorija);
        
            if (d1.Exists)
            {
                FileInfo[] datoteke1 = d1.GetFiles("*.*");
                lijeviListView.ItemsSource = datoteke1;
                lijeviPathTextBox.Text = lijevaStazaOdabranogDirektorija;

                


                foreach (DriveInfo disk in sviDiskovi)
                {
                    if (lijevaStazaOdabranogDirektorija.Substring(0, 3) == disk.Name)
                    {
                        long slobodno = disk.TotalFreeSpace;
                        long sveukupno = disk.TotalSize;


                        lijevaVelicinaDiskaLabel.Content = FormatBytes(slobodno)  +" / " + FormatBytes(sveukupno);


                        decimal omjerSlobodnogISvekupunog = 100 - (Math.Round(Decimal.Divide(slobodno, sveukupno), 2) * 100); ;
                        Console.Write("OMJER SLOBODNOG I SVE UKUPNOG = " + omjerSlobodnogISvekupunog);
                        lijeviDiskProgressBar.Value = (double)omjerSlobodnogISvekupunog;


                    }
                }


            }

            



        }

        private void fb2_Closed(object sender, EventArgs e)
        {
            EnablajSveDesneButtone();

            desnaStazaOdabranogDirektorija = (sender as FolderBrowser).SelectedImagePath;
            desniPopisDatotekaUDirektoriju = Directory.GetFiles(desnaStazaOdabranogDirektorija);
            desniPathTextBox.Text = desnaStazaOdabranogDirektorija;
            

            DirectoryInfo d2 = new DirectoryInfo(desnaStazaOdabranogDirektorija);
            if (d2.Exists)
            {
                FileInfo[] datoteke2 = d2.GetFiles("*.*");
                desniListView.ItemsSource = datoteke2;
                desniPathTextBox.Text = desnaStazaOdabranogDirektorija;

                desniPopisDatotekaUDirektoriju = Directory.GetFiles(desnaStazaOdabranogDirektorija);



                foreach (DriveInfo disk in sviDiskovi)
                {
                    if (desnaStazaOdabranogDirektorija.Substring(0, 3) == disk.Name)
                    {

                        long slobodno = disk.TotalFreeSpace;
                        long sveukupno = disk.TotalSize;


                        desnaVelicinaDiskaLabel.Content = FormatBytes(slobodno) + " / " + FormatBytes(sveukupno);


                        decimal omjerSlobodnogISvekupunog = 100 - (Math.Round(Decimal.Divide(slobodno, sveukupno), 2) * 100); ;
                        Console.Write("OMJER SLOBODNOG I SVE UKUPNOG = " +omjerSlobodnogISvekupunog);
                        desniDiskProgressBar.Value = (double)omjerSlobodnogISvekupunog;
                        


                    }
                }


            }


        }
        #endregion

        #region FILE COPY

        public void KopirajFile(ListView _listView, TextBox _pathTextBox, string _stazaOdabranogDirektorija)
        {


            try
            {
                string[] popisDatotekaUDirektoriju = Directory.GetFiles(_pathTextBox.Text.ToString());
                string pathOdabraneDatoteke = popisDatotekaUDirektoriju[_listView.SelectedIndex];
                string pathKamoIdeDatoteka = _stazaOdabranogDirektorija + @"\" + _listView.SelectedItem;

                File.Copy(pathOdabraneDatoteke, pathKamoIdeDatoteka);
                statusBar.Background = Brushes.Green;
                info.Text = pathOdabraneDatoteke + " kopirano u " + pathKamoIdeDatoteka;
            }
            catch (Exception ex)
            {
                statusBar.Background = Brushes.Red;
                info.Text = ex.Message;
            }
   
        }

        private void lijeviKopirajButton_Click(object sender, RoutedEventArgs e)
        {
            DisablajSveLijeveButtone();

            KopirajFile(lijeviListView, lijeviPathTextBox,  desnaStazaOdabranogDirektorija);
          
            RefreshajListView(desniListView, desniPathTextBox);

            EnablajSveLijeveButtone();
            
        }

        private void desniKopirajButton_Click(object sender, RoutedEventArgs e)
        {
            
            DisablajSveDesneButtone();

            KopirajFile(desniListView, desniPathTextBox, lijevaStazaOdabranogDirektorija);
         
            RefreshajListView(lijeviListView, lijeviPathTextBox);
        
            EnablajSveDesneButtone();
        }

        #endregion

        #region FILE MOVE
        private void PomakniFile(ListView _listView, TextBox _pathTextBox, string _stazaOdabranogDirektorija)
        {

        
            try {
                    string[] popisDatotekaUDirektoriju = Directory.GetFiles(_pathTextBox.Text.ToString());
                    string pathOdabraneDatoteke = popisDatotekaUDirektoriju[_listView.SelectedIndex];
                    string pathKamoIdeDatoteka = _stazaOdabranogDirektorija + @"\" + _listView.SelectedItem;

                    File.Move(pathOdabraneDatoteke, pathKamoIdeDatoteka);
                    statusBar.Background = Brushes.Green;
                    info.Text = pathOdabraneDatoteke + " premješteno u " + pathKamoIdeDatoteka;

             }
                catch (Exception ex)
                {
                    statusBar.Background = Brushes.Red;
                     info.Text = ex.Message;
                }
           
        }
            
        private void lijeviMoveButton_Click(object sender, RoutedEventArgs e)
        {
            DisablajSveLijeveButtone();
            
            PomakniFile(lijeviListView, lijeviPathTextBox, desnaStazaOdabranogDirektorija);
            
            RefreshajListView(lijeviListView,lijeviPathTextBox);
            RefreshajListView(desniListView, desniPathTextBox);
            
            EnablajSveLijeveButtone();
            
        }
        
        private void desniMoveButton_Click(object sender, RoutedEventArgs e)
        {
            DisablajSveDesneButtone();
            PomakniFile(desniListView, desniPathTextBox, lijevaStazaOdabranogDirektorija);
            
            RefreshajListView(desniListView, desniPathTextBox);
            RefreshajListView(lijeviListView, lijeviPathTextBox);
            
            
            EnablajSveDesneButtone();
        }
        #endregion

        
        #region FILE DELETE 

        public void DeleteFile(ListView _listView, TextBox _pathTextBox)
        {
            

            if (_listView.SelectedIndex >= 0)
            {
                try
                {
                    string stazaOdabranogDirektorija_Refresh = _pathTextBox.Text;
                    string[] popisDatotekaUDirektoriju_Refresh = Directory.GetFiles(stazaOdabranogDirektorija_Refresh);

                    string pathOdabraneDatoteke = popisDatotekaUDirektoriju_Refresh[_listView.SelectedIndex];
                    //Console.Write("\nBRIŠEM: " + pathOdabraneDatoteke + " na indexu: " + _listView.SelectedIndex + "\n");

                    File.Delete(pathOdabraneDatoteke);

                    info.Text = pathOdabraneDatoteke + " izbrisano!";
                    statusBar.Background = Brushes.Green;
                }
                catch (Exception ex)
                {
                    statusBar.Background = Brushes.Red;
                    info.Text = ex.Message;
                }
            }
            else
            {
                statusBar.Background = Brushes.Red;
                info.Text = "Označite datoteku!";
            }
        }

        private void lijeviDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DisablajSveLijeveButtone();
            
            DeleteFile(lijeviListView,lijeviPathTextBox);
            RefreshajListView(lijeviListView, lijeviPathTextBox);
            RefreshajListView(desniListView, desniPathTextBox);

            EnablajSveLijeveButtone();
            
        }

        private void desniDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            DisablajSveDesneButtone();

            DeleteFile(desniListView, desniPathTextBox);
            RefreshajListView(desniListView, desniPathTextBox);
            RefreshajListView(lijeviListView, lijeviPathTextBox);
            
            EnablajSveDesneButtone();
        }

        #endregion


        #region RENAME
        private void PreimenujFile(TextBox _pathTextBox, string _stazaOdabranogDirektorija, ListView _listView, TextBox preimenovanje)
        {
            
            if (_listView.SelectedIndex >= 0)
            {
                
                try
                {
                    string[] popisDatotekaUDirektoriju_Refresh = Directory.GetFiles(_stazaOdabranogDirektorija);
                    string pathOdabraneDatoteke = popisDatotekaUDirektoriju_Refresh[_listView.SelectedIndex];
                    FileInfo fi = new FileInfo(pathOdabraneDatoteke);
                   
                    string pathKamoIdeDatoteka = _stazaOdabranogDirektorija + @"\\" + preimenovanje.Text + fi.Extension;

                     File.Move(pathOdabraneDatoteke, pathKamoIdeDatoteka);
                                                     
                     info.Text = pathOdabraneDatoteke + " preimenovano u " + pathKamoIdeDatoteka;
                     statusBar.Background = Brushes.Green;
                    

                }
                catch (Exception ex)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void lijeviRenameButton_Click(object sender, RoutedEventArgs e)
        {
            PreimenujFile(lijeviPathTextBox, lijevaStazaOdabranogDirektorija, lijeviListView, lijeviRenameTextBox);
            RefreshajListView(lijeviListView, lijeviPathTextBox);
            RefreshajListView(desniListView, desniPathTextBox);
        }

        private void desniRenameButton_Click(object sender, RoutedEventArgs e)
        {
            PreimenujFile(desniPathTextBox, desnaStazaOdabranogDirektorija, desniListView, desniRenameTextBox);
            RefreshajListView(lijeviListView, lijeviPathTextBox);
            RefreshajListView(desniListView, desniPathTextBox);
        }
        #endregion








    }
 }
