using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
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
using top_medkit_models.Models;

namespace top_medkit_manager_wpfclient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public ObservableCollection<Drug> Drugs { get; set; }
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid ?? throw new NotImplementedException();
            var drug = (Drug?)dataGrid.SelectedCells[0].Item;
            if (drug is null)
                return;
            var drugId = drug.Id;
        }
    }
}
