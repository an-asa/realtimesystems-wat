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
        SilnikKlient silnik;

        private static readonly Dictionary<string, ProgramPrania> ProgramPraniaStringToEnum = new Dictionary<string, ProgramPrania> {
            { "Bawełna", ProgramPrania.Bawelna },
            { "Bawełna bez wirowania", ProgramPrania.BawelnaBezWirowania },
            { "Syntetyki", ProgramPrania.Syntetyki }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                sterowanie = new SterowanieKlient();
                sterowanie.ZmianaEtapuPrania += Sterowanie_ZmianaEtapuPrania;
                silnik = new SilnikKlient();
                silnik.ZmianaPredkosciKatowej += Silnik_ZmianaPredkosciKatowej;
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sterowanie.DisposeAsync();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            ProgramPrania program = ProgramPraniaStringToEnum[comboBoxProgramPrania.SelectedValue.ToString()];

            Task.Run(() => {
                sterowanie.Start(program).Wait();
            });
        }
        private void Sterowanie_ZmianaEtapuPrania(object sender, EtapPrania etapPrania)
        {
            Dispatcher.Invoke(() => {
                labelEtapPrania.Content = etapPrania.ToString();
            });
        }
        private void Silnik_ZmianaPredkosciKatowej(object sender, float predkoscKatowa)
        {
            Dispatcher.Invoke(() => {
                labelPredkoscKatowa.Content = predkoscKatowa.ToString();
            });
        }
    }
}
