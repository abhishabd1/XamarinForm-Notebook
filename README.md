# XamarinForm-Notebook
With C# UI and Sqlite db


Create model class with the name ofNotesDB
  public class NotesDB
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength (500)]
        public string Note { get; set; }

        public string Date { get; set; }

        public NotesDB()
        {

        }


           
        }
 
