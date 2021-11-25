using eindopdracht.Models;
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
    public partial class parkingdetails : ContentPage
    {

       
        public ParkingGent.Record records = new ParkingGent.Record();
        public parkingdetails(ParkingGent.Record record)
        {
            InitializeComponent();
            BindingContext = record;
            records = record;
            

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //ParkingGent.Record sele = lblcordinaten as ParkingGent.Geometry;
            
            await Navigation.PushAsync(new map(records));
        }
    }
}