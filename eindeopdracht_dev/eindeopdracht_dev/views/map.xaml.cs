using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class map : ContentPage
    {
        public map()
        {
            Map map = new Map();

            Position position = new Position(50.980669154585755, 3.5286615162748496);
            Pin pin = new Pin
            {
                Label = "Thuis",
                Address = "Louis Dhontstraat",
                Type = PinType.Place,
                Position = position
            };
            map.Pins.Add(pin);
            map.IsShowingUser = true;
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
            Content = map;

            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

        }
         
    }
}
