using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace IsTakip.Model
{
   public class Kayit
    {
        [PrimaryKey,AutoIncrement]
        public int KayitID { get; set; }
        public DateTime Tarih { get; set; }
        
        public string YuklemeId { get; set; }
        public string TeslimId { get; set; }
        public double Tonaj { get; set; }
        public string FirmalarId { get; set; }
        public double Mazot { get; set; }
        public double Avans { get; set; }
        public string Plaka { get; set; }
    }
}
