using NoteBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteBook.Views
{
    class EditPage: ContentPage
    {
        //Creating obj
        public QueryTable _QUERY;
        public NotesDB _NOTESDB;
        public DateTime _DATETIME;

       


        public EditPage()
        {
            //Here i am passin dbConnectivity
            _NOTESDB = new NotesDB();
            _QUERY = new QueryTable();


            //Here i am binding data
            var idEntry = new Entry { };
            idEntry.SetBinding(Entry.TextProperty, "id");
            idEntry.IsVisible = false;

            var noteEntry = new Entry { };
            noteEntry.SetBinding(Entry.TextProperty, "Note");


            //Design Button 
            var updateButton = new Button { Text = "UPDATE" };
            var DeleteButton = new Button { Text = "Delete" };
            var CancelButton = new Button { Text = "Cancel" };




            //creating event for updating data
            updateButton.Clicked += (object sender, EventArgs e) =>
              {
                  try
                  {
                      _DATETIME = DateTime.Now;
                      SetNotesDB(idEntry.Text.ToString(), noteEntry.Text.ToString(), _DATETIME.ToString());
                      _QUERY.UpdateDetails(_NOTESDB);
                      DisplayAlert("Yes..!!", "Update Successfully.", "Ok");
                      Navigation.PushAsync(new HomePage());

                  }
                  catch (Exception ex)
                  {
                      string error = ex.ToString();
                      DisplayAlert("Oops...!!", "Try After Sometime.", "Ok");
                  }
  
              };
            //Creating Event for Delete

            DeleteButton.Clicked += (object sender, EventArgs e) =>
              {
                  try
                  {
                      int Id = Convert.ToInt32(idEntry.Text.ToString());
                      //_QUERY.DeleteDetails(Id);
                      SetNotesDB(idEntry.Text.ToString(), noteEntry.Text.ToString(), _DATETIME.ToString());
                      int x=_QUERY.DeleteDetails(_NOTESDB);
                      DisplayAlert("Alert", "Deleted Succesfully.", "Ok");
                      Navigation.PushAsync(new HomePage());
                  }
                  catch (Exception ex)
                  {
                      string error = ex.ToString();
                      DisplayAlert("Opps...!!", "Something went Wrong", "Ok");
                  }
              };

            //Cancel Button Evenet
            CancelButton.Clicked += (sender, e) =>
              {
                  var NoteItem = (NotesDB)BindingContext;
                  this.Navigation.PopAsync();

              };


            //Layout
            var btnStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children ={
                    updateButton,DeleteButton,CancelButton

                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20),
                Children = {
                    idEntry,noteEntry,btnStack

                }

            };

            
        }

        public void SetNotesDB(string Id, string note, string date)
        {
            int id = Convert.ToInt32(Id);
            _NOTESDB.id = id;
            _NOTESDB.Note = note;
            _NOTESDB.Date = date;
        }

       
    }
}
