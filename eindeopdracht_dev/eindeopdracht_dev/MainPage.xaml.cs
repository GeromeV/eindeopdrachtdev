using eindopdracht.Models;
using eindopdracht.REpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eindeopdracht_dev
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void opvullen()
        {
            Debug.WriteLine("debug parking");
            ParkingGent.Rootobject x = await ParkingRepo.GetRecords();
            lvwProductions.ItemsSource = x.records;
            


        }

        private void lvwProductions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}
