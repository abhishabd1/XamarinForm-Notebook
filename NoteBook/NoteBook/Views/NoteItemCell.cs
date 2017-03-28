using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteBook
{
    public class NoteItemCell : ViewCell
    {
        //I Created list item page here with cell with binding
        public NoteItemCell()
        {
            //creating Label for ID
            var IdLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            IdLabel.SetBinding(Label.TextProperty, "Id");


            //Creatin Label for date
            var DateLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand

            };
            DateLabel.SetBinding(Label.TextProperty, "Date");

            // For notes
            var NoteLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            NoteLabel.SetBinding(Label.TextProperty, "Note");

            var line = new Label
            {
                Text = "",
                BackgroundColor = Color.White,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.FillAndExpand



            };

            //CREATING Layout HERE
            var Layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    DateLabel,NoteLabel,line
                }
            };
            View = Layout;


        }
    }
}
