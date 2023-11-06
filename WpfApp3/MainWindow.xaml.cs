using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var proc = Process.GetProcessesByName("TaskManagerApp");

            if (proc.Length > 0)
            {
                proc[0].Kill();

            }
            var processes = Process.GetProcesses().ToList();

        
           
            foreach (var process in processes)
            {
               
                nametxt.Items.Add($"Id: {process.Id} )                                           Name: [{process.ProcessName}]");
            }


        }

     

        private void OpenApplication_Click(object sender, RoutedEventArgs e)
        {
            string applicationName = Microsoft.VisualBasic.Interaction.InputBox("Applicationa daxil olun", "Application axtaris yeri", "");

            if (!string.IsNullOrEmpty(applicationName))
            {
                Process.Start(applicationName);

                Thread.Sleep(10); 

                Application.Current.Shutdown();
            }
        }
    }
}
