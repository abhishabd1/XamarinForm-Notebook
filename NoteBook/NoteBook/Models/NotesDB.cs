using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Models
{
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
    
}
