using IsTakip.Database;
using IsTakip.Helper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteManager))]

namespace IsTakip.Database
{
  public  class SQLiteManager : ISQLiteManager
    {
        SQLiteConnection connection;
        public SQLiteManager()
        {
            connection = DependencyService.Get<ISQLiteConnection>().SQLiteConnection();
        }
        public List<T> select<T>(string sqlSorgu,params string[] a) where T:new()
        {
            return connection.Query<T>(sqlSorgu,a);
        }
        public int Count<T>() where T:new()
        {
            return connection.Table<T>().Count();
        }

        public void CreateTable<T>()
        {
            connection.CreateTable<T>();
        }

        public void Delete<T>(T data)
        {
            connection.Delete(data);
        }

        public List<T> GetAll<T>() where T : new()
        {
            var allData = connection.Table<T>().ToList();

            return allData;
        }

        public void Insert<T>(T data)
        {
            connection.Insert(data);
        }

        public void Update<T>(T data)
        {
            connection.Update(data);
        }
    }
}
