using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using top_medkit_models.Models;

namespace top_medkit_manager_wpfclient
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
        }
        public ObservableCollection<DrugInfo> DrugInfos { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using HttpClient client = new();
            var result = await client.GetAsync("https://localhost:5000/api/drug");
            var json = await result.Content.ReadAsStringAsync();
            var jObj = JObject.Parse(json);
            if ((string?)jObj["status"] != "ok")
                throw new Exception();
        }
    }
}
