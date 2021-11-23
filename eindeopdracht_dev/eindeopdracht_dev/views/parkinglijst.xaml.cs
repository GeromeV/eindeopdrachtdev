using eindopdracht.Models;
using eindopdracht.REpo;
using eindeopdracht_dev.views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class parkinglijst : ContentPage
    {
        public parkinglijst()
        {
            InitializeComponent();
            opvullen();
        }

        private async void opvullen()
        {
            Debug.WriteLine("debug parking");
            ParkingGent.Rootobject x = await ParkingRepo.GetRecords();
            lvwProductions.ItemsSource = x.records;



        }

        private async void lvwProductions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //edit
            var parking = (ParkingGent.Rootobject)sender;
            await Navigation.PushAsync(new parkingdetails());
        }

    }
}