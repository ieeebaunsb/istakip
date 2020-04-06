using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakip.Helper
{
   public interface ISQLiteConnection
    {
        SQLiteConnection SQLiteConnection();
    }
}
