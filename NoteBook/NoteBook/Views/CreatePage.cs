using NoteBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteBook
{
   public class CreatePage : ContentPage
    {
        public QueryTable _querytable;
        public NotesDB _notesdb;


        private DateTime _datetime;
        public string primary;

        public CreatePage()
        {
            //Here pass DB connectivity

            _notesdb = new NotesDB();
            _querytable = new QueryTable();


            //here i am creating Editor

            var noteEditor = new Editor
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand

            };

            //Here i am creating Button

            var saveButton = new Button { Text = "Save", HorizontalOptions = LayoutOptions.FillAndExpand };
            var cancelButton = new Button { Text = "Cancel", HorizontalOptions = LayoutOptions.FillAndExpand };


            //Here i am creatin Event

            saveButton.Clicked += (object sender, EventArgs e) =>
              {
                  _datetime = DateTime.Now;
                  try
                  {
                      InsertData(noteEditor.Text.ToString(), _datetime.ToString());

                      //I Creata Display alert
                      DisplayAlert("Alert", "Save Succesfully...!", "ok");
                      //Navigate
                      Navigation.PushAsync(new HomePage());

  
                  }
                  catch(Exception ex)
                  {
                      string error = ex.ToString();
                      DisplayAlert("Opps...!", "Something went wrong.", "Ok");
                  }
  
              };

            //Layout fOR BUTTON
            var btnStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    saveButton,cancelButton
                }
            };


            //Button Event for Cancel Button
            cancelButton.Clicked += (sender, e) =>
              {
                  var NoteItem = (NotesDB)BindingContext;
                  this.Navigation.PopAsync();

              };
            //Stack Layout fOR Editor
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    noteEditor,btnStack
                }


            };
        }

        //Insertion data
        public void InsertData(string note, string date)
        {
            _notesdb.Note = note;
            _notesdb.Date = date;
            _querytable.InsertDetails(_notesdb);
        }
    }
}
