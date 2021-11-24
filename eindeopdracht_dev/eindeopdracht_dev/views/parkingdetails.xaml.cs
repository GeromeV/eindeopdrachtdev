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
        
        public parkingdetails(ParkingGent.Rootobject park)
        {
            InitializeComponent();
            Debug.WriteLine(park);
        }
    }
}