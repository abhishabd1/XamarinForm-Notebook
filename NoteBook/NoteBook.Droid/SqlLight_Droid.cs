using System;
using System.IO;
using Xamarin.Forms;
using NoteBook.Droid;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


[assembly: Dependency(typeof(SqlLight_Droid))]
namespace NoteBook.Droid
{
    public class SqlLight_Droid : Interfacebook
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "Notes.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, filename);


            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;

        }
    }
}