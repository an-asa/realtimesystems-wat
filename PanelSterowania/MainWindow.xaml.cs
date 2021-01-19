using Klienci;
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

namespace PanelSterowania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SterowanieKlient sterowanie;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                sterowanie = new SterowanieKlient();
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sterowanie.DisposeAsync();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            string programStr = comboBoxProgramPrania.SelectedValue.ToString();

            Task.Run(() => {
                ProgramPrania program;
                
                if (programStr.Equals("Bawełna"))
                {
                    program = ProgramPrania.Bawelna;
                } else if (programStr.Equals("Bawełna bez wirowania"))
                {
                    program = ProgramPrania.BawelnaBezWirowania;
                } else
                {
                    program = ProgramPrania.Syntetyki;
                }

                sterowanie.Start(program).Wait();
            });
        }
    }
}
