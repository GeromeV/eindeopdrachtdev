using eindopdracht.Models;
using eindopdracht.REpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;


namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mapalleparkings : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();
       

        public mapalleparkings()
        {
            maps();

            
        }
        public async void maps()
        {
            ParkingGent.Rootobject x = await ParkingRepo.GetRecords();

            Map kaart = new Map();
            kaart.MapType = MapType.Street;
            Position gent = new Position(51.0543422, 3.7174243);
            foreach (var item in x.records)
            {
                Position position = new Position(item.geometry.coordinates[1], item.geometry.coordinates[0]);
                var addresses = await geocoder.GetAddressesForPositionAsync(position);
                

                Pin pin = new Pin
                {
                    
                    Label = item.fields.name,
                    Address = addresses.FirstOrDefault()?.ToString(),
                    Type = PinType.Place,
                    Position = position
                   
                    
                };
                    kaart.Pins.Add(pin);
            }
            kaart.IsShowingUser = true;
            //Circle circle = new Circle
            //{
            //    Center = position,
            //    Radius = new Distance(250),
            //    StrokeColor = Color.FromHex("#88FF0000"),
            //    StrokeWidth = 8,
            //    FillColor = Color.FromHex("#88FFC0CB")
            //};
            //map.MapElements.Add(circle);

            //Title = "Circle demo";
            Content = kaart;

            kaart.MoveToRegion(new MapSpan(gent,0.1, 0.1));
        }
    }
}