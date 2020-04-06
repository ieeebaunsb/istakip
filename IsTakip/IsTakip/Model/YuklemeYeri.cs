using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace IsTakip.Model
{
    class YuklemeYeri
    {
        [PrimaryKey,AutoIncrement]
        public int YuklemeId { get; set; }
        public string YuklemeAdi { get; set; }

    }
}
