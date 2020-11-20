using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ApiClientWpf1.Models;
using Newtonsoft.Json;

namespace ApiClientWpf1
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //都道府県データを読み込む
            var hc = new HttpClient();
            var res = await hc.GetAsync("http://localhost:5000/api/Prefectures");
            var st = await res.Content.ReadAsStreamAsync();
            var jr = new JsonTextReader(new StreamReader(st));
            var js = new JsonSerializer();
            var items = js.Deserialize<IEnumerable<Models.Prefecture>>(jr);
            comboPrefecture.ItemsSource = items;
        }

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var res = await hc.GetAsync("http://localhost:5000/api/People");
            var st = await res.Content.ReadAsStreamAsync();
            var js = new JsonSerializer();
            var jr = new JsonTextReader(new StreamReader(st));
            var items = js.Deserialize<IEnumerable<Models.Person>>(jr);
            dataGrid.ItemsSource = items;
        }

        private async void btnGetId_Click(object sender, RoutedEventArgs e)
        {
            if (textId.Text == "") return;
            int id = int.Parse(textId.Text);
            var hc = new HttpClient();
            var res = await hc.GetAsync($"http://localhost:5000/api/People/{id}");
            var st = await res.Content.ReadAsStreamAsync();
            var js = new JsonSerializer();
            var jr = new JsonTextReader(new StreamReader(st));
            var item = js.Deserialize<Person>(jr);
            if (item == null) return;
            textName.Text = item.Name;
            textAge.Text = item.Age.ToString();
            comboPrefecture.SelectedValue = item.PrefectureId;

        }

        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var data = new Person { 
                Name = textName.Text, 
                Age = int.Parse(textAge.Text), 
                PrefectureId = (int)comboPrefecture.SelectedValue 
            };
            var json = JsonConvert.SerializeObject(data);
            var cont = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await hc.PostAsync("http://localhost:5000/api/People",cont);
            var str = await res.Content.ReadAsStringAsync();
            MessageBox.Show(str);   
        }

        private async void btnPutId_Click(object sender, RoutedEventArgs e)
        {
            if (textId.Text == "") return;
            int id = int.Parse(textId.Text);
            var data = new Person { Id = id, Name = textName.Text, Age = int.Parse(textAge.Text), PrefectureId = (int)comboPrefecture.SelectedValue };
            var json = JsonConvert.SerializeObject(data);
            var cont = new StringContent(json, Encoding.UTF8, "application/json");
            var hc = new HttpClient();
            var res = await hc.PutAsync($"http://localhost:5000/api/People/{id}", cont);
            var str = await res.Content.ReadAsStringAsync();
            MessageBox.Show(str);
        }

        private async void btnDeleteId_Click(object sender, RoutedEventArgs e)
        {
            if (textId.Text == null) return;
            int id = int.Parse(textId.Text);
            var hc = new HttpClient();
            _ = await hc.DeleteAsync($"http://localhost:5000/api/People/{id}");
        }
    }
}
