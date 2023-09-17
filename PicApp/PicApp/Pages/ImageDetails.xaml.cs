using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    public partial class ImageDetails : ContentPage
    {
        Image ItemToDisplay { get; set; }

        public ImageDetails()
        {
            InitializeComponent();
        }

        public ImageDetails(Image selected)
        {
            InitializeComponent();
            img.Source = selected.Src.ToString().Substring(6);
            path.Text = selected.Src.ToString().Substring(6);
            dt.Text = String.Concat("Image created: ", selected.CreationDate.ToString());
        }
    }
}