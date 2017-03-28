using NoteBook.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteBook
{
    public class QueryTable
    {
        static object locker = new object();

        SQLiteConnection con;


        // For Get connected and create table

        public QueryTable()
        {
            con = DependencyService.Get<Interfacebook>().GetConnection();
            con.CreateTable<NotesDB>();
        }


        //For Insert data
        public int InsertDetails(NotesDB notesdb)
        {
            lock(locker)
            {
                return con.Insert(notesdb);
            }

        }

        //For Update data

        public int UpdateDetails(NotesDB Unotesdb)
        {
            lock(locker)
            {
                return con.Update(Unotesdb);
            }

        }


        //For Delete Data

        public int DeleteDetails(NotesDB Dnotedb)
        {
            lock(locker)
            {
                return con.Delete(Dnotedb);
            }
                
           
        }


        //Get All notes

        public IEnumerable<NotesDB>GetAllNotes()
        {
            lock(locker)
            {
                return (from i in con.Table<NotesDB>() select i).ToList();

            }
        }
        //Dospose connection
        public void Dispose()
        {
            con.Dispose();
        }

        internal void DeleteDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
