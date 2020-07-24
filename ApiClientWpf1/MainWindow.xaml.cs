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
using Newtonsoft.Json;

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

        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var data = new Dictionary<string, string> { { "Name", "new person" }, { "EmployeeNo", "ABC-9999" }, { "PrefectureId", "12" }, { "Age", "99" } };
            var json = JsonConvert.SerializeObject(data);
            var cont = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await hc.PostAsync("http://localhost:5000/api/People", cont);
            var str = await res.Content.ReadAsStringAsync();
            textResult.Text = str;
        }
    }
}
