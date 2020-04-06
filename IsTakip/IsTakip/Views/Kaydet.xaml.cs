using IsTakip.Database;
using IsTakip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsTakip.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Kaydet : ContentPage
	{
        SQLiteManager con = new SQLiteManager();

        public Kaydet ()
		{
			InitializeComponent ();
            foreach (var item in con.GetAll<YuklemeYeri>())
            {
                yukleme.Items.Add(item.YuklemeAdi);

            }
            foreach (var item in con.GetAll<TeslimYeri>())
            {
                teslim.Items.Add(item.TeslimAdi);
            }
            foreach (var item in con.GetAll<Firmalar>())
            {
                firma.Items.Add(item.FirmaAdi);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //string fatura = "Yükleme Yeri : " + yukleme.SelectedItem.ToString() + "\nTeslim Yeri : " + teslim.SelectedItem.ToString() + "\nTonaj :" + tonaj.Text.ToString()
            //    + "kg\nFirma :" + firma.SelectedItem.ToString() + "\nMazot :" + mazot.Text.ToString() + "TL\nAvans :" + avans.Text.ToString() + "TL\nAraç :" + arac.SelectedItem.ToString();

            //DisplayAlert("Fatura", fatura, "tamam");

            try
            {

                con.CreateTable<Kayit>();
                Kayit isKayit = new Kayit();
                isKayit.Tarih = tarih.Date;


                isKayit.YuklemeId = yukleme.SelectedItem.ToString();


                isKayit.TeslimId = teslim.SelectedItem.ToString();
                
                isKayit.Tonaj = Convert.ToDouble(tonaj.Text);

                isKayit.FirmalarId = firma.SelectedItem.ToString();
                
                isKayit.Mazot = Convert.ToDouble(mazot.Text);
                isKayit.Avans = Convert.ToDouble(avans.Text);
                isKayit.Plaka="41 R 2285";
                con.Insert<Kayit>(isKayit);
                DisplayAlert("Kayıt", "Kayıt Başarıyla Tamamlandı\n"+con.Count<Kayit>().ToString(), "Tamam");
            }
            catch (Exception msj)
            {

                DisplayAlert("Kayıt Hatası", msj.Message, "Tamam");
            }
            
        }
    }
}