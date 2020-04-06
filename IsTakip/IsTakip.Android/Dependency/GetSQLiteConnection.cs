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
using IsTakip.Helper;
using SQLite;
using System.IO;
using IsTakip.Droid.Dependency;
using Xamarin.Forms;
using static System.Environment;

[assembly: Dependency(typeof(GetSQLiteConnection))]
namespace IsTakip.Droid.Dependency
{

    class GetSQLiteConnection : ISQLiteConnection
    {
        public SQLiteConnection SQLiteConnection()
        {

            try
            {
                var docpath = GetFolderPath(SpecialFolder.Personal);
                string libFolder = Path.Combine(docpath, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }
                var path = Path.Combine(libFolder, App.DB_NAME);

                var connection = new SQLiteConnection(path);

                return connection;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}