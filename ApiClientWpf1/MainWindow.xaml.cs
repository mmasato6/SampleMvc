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
using System.Net.Http;

namespace ApiClientWpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var res = await hc.GetAsync("http://localhost:5000/api/People");
            var str = await res.Content.ReadAsStringAsync();
            textResult.Text = str;
        }
    }
}
