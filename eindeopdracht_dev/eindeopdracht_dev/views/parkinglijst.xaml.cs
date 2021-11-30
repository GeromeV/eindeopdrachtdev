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
using eindeopdracht_dev.Models;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class parkinglijst : ContentPage
    {
        ParkingGent.Record record;
        public parkinglijst()
        {
            InitializeComponent();
            opvullen();
            imgMapnav.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.map.png");

        }

        private async void opvullen()
        {
            Debug.WriteLine("debug parking");
            ParkingGent.Rootobject x = await ParkingRepo.GetRecords();
            record = new ParkingGent.Record();
            lvwParking.ItemsSource = x.records;
            List<favoriet> favo = await ParkingRepo.Getfavoriet();
            foreach (var item in favo)
            {
                Debug.WriteLine(item.parkingid);
            }

            //imgpark.Source = ImageSource.FromResource("eindeopdracht_dev/Assets/reep.jpg");
            
            


        }

        private async void lvwProductions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            
            ParkingGent.Record sele = lvwParking.SelectedItem as ParkingGent.Record;
            await Navigation.PushAsync(new parkingdetails(sele));

            
           
        }

        private void imgMapnav_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new mapalleparkings());
        }
    }
}