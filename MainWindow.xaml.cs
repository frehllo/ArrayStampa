using System;
using System.Collections.Generic;
using System.IO;
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

namespace ArrayStampa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string file = @"stato.txt";
        public MainWindow()
        {        
            InitializeComponent();
            if (File.Exists(file))
                using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
            {
                string line = reader.ReadLine();
                txt_numeroN.Text = $"{line}";
                int[] array = new int[int.Parse(line)];
                while ((line = reader.ReadLine()) != null)
                {
                    lbl_ris.Content += $"{line},";
                }
            }                            
        }
        Random rnd = new Random();
        private void btn_genera_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txt_numeroN.Text);
            try
            {
                if(n < 0)
                {
                    lbl_ris.Content = "Il numero deve essere positivo ";
                }                
                int[] array = new int[n];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next();
                }
                lbl_ris.Content = "[";
                for (int i = 0; i < array.Length; i++)
                {
                    lbl_ris.Content = lbl_ris.Content + $"{array[i]}";
                    if (i < array.Length - 1)
                        lbl_ris.Content += ",";
                }
                lbl_ris.Content += "]";
                try
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file))
                    {
                        writer.WriteLine(txt_numeroN.Text);
                        for (int i = 0; i < array.Length; i++)
                        {
                            writer.WriteLine(array[i]);
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                lbl_ris.Content = "";
            }
            
        }
    }
}
