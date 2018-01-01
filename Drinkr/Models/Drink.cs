using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Drinkr.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public byte[] Image { get; set; }
    }
}