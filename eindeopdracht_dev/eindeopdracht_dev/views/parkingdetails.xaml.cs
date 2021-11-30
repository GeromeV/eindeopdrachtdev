using eindeopdracht_dev.Models;
using eindopdracht.Models;
using eindopdracht.REpo;
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
            favorieten();
            

        }

        private async void favorieten()
        {
            List<favoriet> favo = await ParkingRepo.Getfavoriet();
            foreach (var item in favo)
            {
                Debug.WriteLine(item.parkingid);
                if (item.parkingid != records.fields.name)
                {
                    imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");
                }

                else
                {
                    imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.stergeel.png");

                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //ParkingGent.Record sele = lblcordinaten as ParkingGent.Geometry;
            
            await Navigation.PushAsync(new map(records));
        }

        private async void imgfavoriet_Clicked(object sender, EventArgs e)
        {
            
            List<favoriet> favo = await ParkingRepo.Getfavoriet();
            foreach (var item in favo)
            {
                Debug.WriteLine(item.parkingid);
                if (item.parkingid == records.fields.name)
                {
                    imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");
                }

                else
                {
                    imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.stergeel.png");


                }
            }



        }
    }
}