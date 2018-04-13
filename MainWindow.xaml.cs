/*
 U3Weather
 Aiden Jolley Ruhn
 April 13, 2018
 Outputs current temperature
 
 */


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

namespace U3Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.BaseAddress = "https://weather.gc.ca/city/pages/on-88_metric_e.html";
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("Weather.txt");
            System.IO.StreamReader streamReader = new System.IO.StreamReader(webClient.OpenRead("https://weather.gc.ca/city/pages/on-88_metric_e.html"));
            bool temp = false; 
            try
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    //        MessageBox.Show(line);
                    //        streamWriter.WriteLine(line);
                    if (temp == true)
                    {
                        //   string temp2 = line.IndexOf("u\0076",50).ToString();
                        //location of >

                        int locOfGreater = line.IndexOf("\x3E");
                        MessageBox.Show("\x26");
                        //find &
                        int locOfAmpersand = line.IndexOf("\x26");
                        string tempTemp = line.Substring(locOfGreater + 1, locOfAmpersand - locOfGreater - 1);
                        MessageBox.Show(tempTemp);
                        MessageBox.Show("> " + locOfGreater.ToString() + "\n" + "& " + locOfAmpersand.ToString());
                        MessageBox.Show(line);
                        MessageBox.Show(line.IndexOf("\u0076",line.IndexOf("\u0046")).ToString());
                        streamWriter.WriteLine(line);
                    }
                    temp = line.Contains("Temperature");
                    
                }
                streamWriter.Write(streamReader.ReadToEnd());
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Close();
                MessageBox.Show("I Have read everything!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "Error");
            }
        }
    }
}
