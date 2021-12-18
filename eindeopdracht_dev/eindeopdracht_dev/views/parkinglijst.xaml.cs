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
       
        ParkingGentFavo.Rootobject parkfavo;
        ParkingGentFavo.Rootobject rootobject;

        public parkinglijst()
        {

            InitializeComponent();
            opvullen();
            imgfavo.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");
            imgMapnav.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.map.png");

        }

        private async void opvullen()
        {
            Debug.WriteLine("debug parking");
            ParkingGent.Rootobject x = await ParkingRepo.GetRecords();
            record = new ParkingGent.Record();
            lvwParking.ItemsSource = x.records;
           

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

        private async void imgfavo_Clicked(object sender, EventArgs e)
        {
            
            if (lvwParkingfavo.IsVisible == true)
            {
                imgfavo.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");
                lvwParkingfavo.IsVisible = false;
                lvwParking.IsVisible = true;


            }

            else if (lvwParkingfavo.IsVisible == false)
            {
                imgfavo.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.stergeel.png");
                lvwParkingfavo.IsVisible = true;
                lvwParking.IsVisible = false;
            }
            


            List<ParkingGentFavo.Record> piemel = await ParkingRepo.Getfavoriet();
            lvwParkingfavo.ItemsSource = piemel;



        }

        private async void lvwParkingfavo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ParkingGentFavo.Record sele = lvwParkingfavo.SelectedItem as ParkingGentFavo.Record;
            await Navigation.PushAsync(new detailpagefavo(sele));
        }
    }
}