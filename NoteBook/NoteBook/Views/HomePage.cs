using NoteBook.Models;
using NoteBook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteBook
{
    public class HomePage: ContentPage
    {
        ListView _lstview;
        public QueryTable _querytable;
        public NotesDB _notesdb;


        public HomePage()
        {
            //Here i am passin dbConnectivity
            _notesdb = new NotesDB();
            _querytable = new QueryTable();



            //create button for Add Note
            var createButton = new Button { Text = "Add Note" };
            _lstview = new ListView { };
            //calling item cells
            _lstview.ItemTemplate = new DataTemplate(typeof(NoteItemCell));
            
            
            //CREATIN EVENT
            _lstview.ItemSelected += async (sender, e) =>
             {

                 if (e.SelectedItem == null)
                 {
                     return;
                 }
                 var detail_item = (NotesDB)e.SelectedItem;
                 var detail_page = new EditPage();
                 detail_page.BindingContext = detail_item;
                 await Navigation.PushAsync(detail_page);
                 ((ListView)sender).SelectedItem = null;//using for clear selected bg

             };
            //Add button event
            createButton.Clicked += (object sender, EventArgs e)=>
              {
                  Navigation.PushAsync(new CreatePage());

              };
            //LAYOUT
            var mainLayout = new StackLayout { };
            mainLayout.Children.Add(createButton);
            mainLayout.Children.Add(_lstview);

            Content = mainLayout;



        }

        protected override void OnAppearing()
        {
            //lOADING ITEM TO LIST
            _lstview.ItemsSource = _querytable.GetAllNotes();
        
            base.OnAppearing();
        }

    }
}
