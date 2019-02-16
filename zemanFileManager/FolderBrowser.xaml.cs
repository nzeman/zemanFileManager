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
using System.IO;
using Xceed.Wpf.Toolkit;
using System.Windows.Markup;

namespace zemanFileManager
{
    /// <summary>
    /// Interaction logic for FolderBrowser.xaml
    /// </summary>
    public partial class FolderBrowser : MetroWindow
    {
        private object dummyNode = null;

        public FolderBrowser()
        {
            InitializeComponent();
            
        }
        

        public string SelectedImagePath { get; set; }

        private void LoadajDiskove() 
        {
            foldersItem.Items.Clear();
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                item.Tag = s;
                item.FontWeight = FontWeights.Normal;
                item.Items.Add(dummyNode);
                item.Expanded += new RoutedEventHandler(folder_Expanded);
                foldersItem.Items.Add(item);
            }
        }

        private void FolderBrowser_Loaded(object sender, RoutedEventArgs e)
        {

            LoadajDiskove();
        }

        void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        item.Items.Add(subitem);
                    }
                    /*
                    foreach (string s in Directory.GetFiles(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        item.Items.Add(subitem);
                    }
                    */
                }
                catch (Exception) { }
            }
        }



        private void foldersItem_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            pathDirektorija.Clear();
            TreeView tree = (TreeView)sender;
            TreeViewItem temp = ((TreeViewItem)tree.SelectedItem);

            if (temp == null)
                return;
            SelectedImagePath = "";
            string temp1 = "";
            string temp2 = "";
            while (true)
            {
                temp1 = temp.Header.ToString();
                if (temp1.Contains(@"\"))
                {
                    temp2 = "";
                }
                SelectedImagePath = temp1 + temp2 + SelectedImagePath;
                if (temp.Parent.GetType().Equals(typeof(TreeView)))
                {
                    break;
                }
                temp = ((TreeViewItem)temp.Parent);
                temp2 = @"\";
                
                
            }
            
            pathDirektorija.Text = SelectedImagePath;
            
            

        }


        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (pathDirektorija.Text == "")
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Molim Vas selektirajte neku mapu!", "Greška :(", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                this.Close();
            }

        }

        private void obrišiDirektorijButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedImagePath != null) { 
            try
            {
                var dir = new DirectoryInfo(pathDirektorija.Text);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete();

                LoadajDiskove();

               

            }
            catch (Exception ex)
            {

                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());

            }
            }
        }

        private void preimenovanjeDirektorija_Click(object sender, RoutedEventArgs e)
        {

                try
                {
                
                    string fullPath = System.IO.Path.GetFullPath(SelectedImagePath).TrimEnd(System.IO.Path.DirectorySeparatorChar);
                    string projectName = System.IO.Path.GetFileName(fullPath);
                    Console.Write("\n" + fullPath + " \t " + projectName + "\n");

                    string kamoIde = fullPath.Substring(0, (fullPath.Length - projectName.Length)) + @"\" + preimenovanjeTextBox.Text;

                    Console.Write("\n" + kamoIde);

                    Directory.Move(fullPath, kamoIde);


                }
                catch (Exception ex)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                         

                LoadajDiskove();

            }
          
        





    }
}




