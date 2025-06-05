using ClassLib.DataAccess;
using ClassLib.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWerknemer
{
    public partial class MainWindow : Window
    {
        private List<Werknemer> _werknemers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }

        private void DisableButtons()
        {
            werknemerButton.IsEnabled = true;
            bediendeButton.IsEnabled = false;
            kaderButton.IsEnabled = false;
            commissieButton.IsEnabled = false;
        }

        private void werknemerButton_Click(object sender, RoutedEventArgs e)
        {
            _werknemers = FileReader.ReadFile("Werknemers.txt");
            EnableButtons();
            FillListBox();
        }

        private void EnableButtons()
        {
            werknemerButton.IsEnabled = false;
            bediendeButton.IsEnabled = true;
            kaderButton.IsEnabled = true;
            commissieButton.IsEnabled = true;
        }

        private void FillListBox()
        {
            _werknemers.ForEach(werknemer => resultListBox.Items.Add(werknemer.Info()));
        }

        private void bediendeButton_Click(object sender, RoutedEventArgs e)
        {
            resultListBox.Items.Clear();
            _werknemers.ForEach(werknemer =>
            {
                if (werknemer is Bediende)
                {
                    resultListBox.Items.Add(werknemer.Info());
                }
            });
        }

        private void kaderButton_Click(object sender, RoutedEventArgs e)
        {
            resultListBox.Items.Clear();
            _werknemers.ForEach(werknemer =>
            {
                if (werknemer is Kader)
                {
                    resultListBox.Items.Add(werknemer.Info());
                }
            });
        }

        private void commissieButton_Click(object sender, RoutedEventArgs e)
        {
            resultListBox.Items.Clear();
            _werknemers.ForEach(werknemer =>
            {
                if (werknemer is Commissie)
                {
                    resultListBox.Items.Add(werknemer.Info());
                }
            });
        }
    }
}