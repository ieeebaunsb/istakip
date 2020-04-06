using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakip.Model
{
    class TeslimYeri
    {
        [PrimaryKey,AutoIncrement]
        public int TeslimId { get; set; }
        public string TeslimAdi { get; set; }
        public double Fiyat { get; set; }
    }
}
