using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Wpf.Ui.Controls;

using System.Xml;


namespace PracticText3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RootTextBox.Focus();
            


        }
        public string FilePath;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;


                FilePath = filename;
                this.Title = filename;

                Paragraph paragraph = new Paragraph();

                paragraph.Inlines.Add(System.IO.File.ReadAllText(filename));

                FlowDocument document = new FlowDocument(paragraph);

                RootTextBox.Document = document;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            RootTextBox.Document = new();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

                    FilePath = saveFileDialog.FileName;
                this.Title = FilePath;
            }
        }

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            RootTextBox.FontSize = FontSizeBox.Value;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RootTextBox.Document.ContentStart, RootTextBox.Document.ContentEnd).Text.ToUpper();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(richText);

            FlowDocument document = new FlowDocument(paragraph);

            RootTextBox.Document = document;

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RootTextBox.Document.ContentStart, RootTextBox.Document.ContentEnd).Text.ToLower();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(richText);

            FlowDocument document = new FlowDocument(paragraph);

            RootTextBox.Document = document;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            var messageBox = new Wpf.Ui.Controls.MessageBox
            {

                Content = "Developed by Denis"


            };
            messageBox.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            if (FilePath != null)
            {
                string richText = new TextRange(RootTextBox.Document.ContentStart, RootTextBox.Document.ContentEnd).Text;
                using (StreamWriter writetext = new StreamWriter(FilePath))
                {
                    writetext.Write(richText);
                }

            }
            else
            {
                string richText = new TextRange(RootTextBox.Document.ContentStart, RootTextBox.Document.ContentEnd).Text;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (StreamWriter writetext = new StreamWriter(saveFileDialog.FileName))
                    {
                        writetext.Write(richText);
                        FilePath = saveFileDialog.FileName;
                    }
                }
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RootTextBox.Document.ContentStart, RootTextBox.Document.ContentEnd).Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writetext = new StreamWriter(saveFileDialog.FileName))
                {
                    writetext.Write(richText);
                    FilePath = saveFileDialog.FileName;
                }
            }
        }
    }
}
