using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakip.Model
{
    class Firmalar
    {
        [PrimaryKey,AutoIncrement]
        public int FirmalarId { get; set; }
        public string FirmaAdi { get; set; }
    }
}
