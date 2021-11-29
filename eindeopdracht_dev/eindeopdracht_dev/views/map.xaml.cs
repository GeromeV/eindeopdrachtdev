using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eindopdracht.Models;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class map : ContentPage
    {
       private readonly Geocoder geocoder = new Geocoder();
        public map(ParkingGent.Record record)
        {
            maps(record);

        }

        public async void maps(ParkingGent.Record record)
        {

            Map kaart = new Map();
            kaart.MapType = MapType.Street;
            Position position = new Position(record.geometry.coordinates[1], record.geometry.coordinates[0]);
            var addresses = await geocoder.GetAddressesForPositionAsync(position);

            Pin pin = new Pin
            {
                Label = record.fields.name,
                Address = addresses.FirstOrDefault()?.ToString(),
                Type = PinType.Place,
                Position = position
            };
            kaart.Pins.Add(pin);
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

            kaart.MoveToRegion(new MapSpan(position, 0.01, 0.01));
        }

        
    }
}
