using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakip.Helper
{
   public  interface ISQLiteManager
    {
        void Insert<T>(T data);
        List<T> GetAll<T>() where T : new();

        int Count<T>() where T : new ();
        void Delete<T>(T data);
        void Update<T>(T data);
        void CreateTable<T>();

    }
}
