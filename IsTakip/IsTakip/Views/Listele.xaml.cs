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
	public partial class Listele : ContentPage
	{
        SQLiteManager con = new SQLiteManager();
        
        public Listele ()
		{

            InitializeComponent();
            var list = con.GetAll<Kayit>().OrderByDescending(x => x.Tarih);
            List<Kayit> listele = new List<Kayit>();
            foreach (var item in list)
            {
                if (DateTime.Now.AddMonths(-1)<=item.Tarih)
                {
                    listele.Add(item);
                }
            }
            isler.ItemsSource = listele;
           
        }

        private void yenile_Clicked(object sender, EventArgs e)
        {

            var list = con.GetAll<Kayit>().OrderByDescending(x => x.Tarih);
            List<Kayit> listele = new List<Kayit>();
            foreach (var item in list)
            {
                if (DateTime.Now.AddMonths(-1) <= item.Tarih)
                {
                    listele.Add(item);
                }
            }
            isler.ItemsSource = listele;

        }

        private void isler_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void hesapla_Clicked(object sender, EventArgs e)
        {
            List<Kayit> list = con.GetAll<Kayit>();
            List<Kayit> listele = new List<Kayit>();
            foreach (var item in list)
            {
                if (kesimTarihi.Date.AddMonths(-1) <= item.Tarih && kesimTarihi.Date.AddMonths(1) >=item.Tarih)
                {
                    listele.Add(item);
                }
            }
            double kazanilan = 0;
            double harcananMazot = 0;
            double harcananAvans = 0;
            try
            {
                foreach (Kayit item in listele)
                {
                    harcananMazot += item.Mazot;
                    harcananAvans += item.Avans;
                    List<TeslimYeri> fiyatHesap = con.select<TeslimYeri>("select Fiyat from TeslimYeri where TeslimAdi = ?", item.TeslimId);
                    foreach (TeslimYeri x in fiyatHesap)
                    {
                        kazanilan += x.Fiyat *( item.Tonaj/(double)1000);
                    }
                }
            }
            catch (Exception msj)
            {

                DisplayAlert("Hesaplama Sırasında Hata", msj.Message, "Tamam");
            }
            string display = "Toplamda Harcanan Mazot:"+harcananMazot.ToString()+
                             "TL\nToplamda Harcanan Avans:"+harcananAvans.ToString()+
                             "TL\nToplamda Kazanılan Para:"+kazanilan.ToString()+
                             "TL\nEdilen Kâr : "+(kazanilan-(harcananMazot+harcananAvans)).ToString()+"TL";
            DisplayAlert(kesimTarihi.Date.AddMonths(-1).ToShortDateString()+"-"+kesimTarihi.Date.ToShortDateString()+"Tarihli Rapor", display, "Kapat");
        }

        private void tumunuGor_Clicked(object sender, EventArgs e)
        {
            var list = con.GetAll<Kayit>().OrderByDescending(x => x.Tarih);
            isler.ItemsSource = list;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

           
            var stackLayout = sender as StackLayout;
           isler.SelectedItem = stackLayout.BindingContext;
            var gelenKayit = (Kayit)isler.SelectedItem;
            
            string display = "Tarih:" + gelenKayit.Tarih.ToShortDateString() +
                      "\nAraç Plakası:" + gelenKayit.Plaka +
                      "\nYükleme Yeri:" + gelenKayit.YuklemeId +
                      "\nTeslim Yeri:" + gelenKayit.TeslimId +
                      "\nTonaj:" + gelenKayit.Tonaj +
                      "\nMazot Ücreti:" + gelenKayit.Mazot +
                      "\nAlınan Avans:" + gelenKayit.Avans +
                      "\nFirma:" + gelenKayit.FirmalarId;

            DisplayAlert("Detaylı Görünüm", display, "Tamam");

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            isler.SelectedItem = stackLayout.BindingContext;
            var gelenKayit = (Kayit)isler.SelectedItem;
           string cevap = await DisplayActionSheet("Gerçekten Silmek İstiyor Musunuz?", "İptal", "Sil");
        
            if(cevap == "Sil")
            {
                try
                {
                    con.Delete(gelenKayit);
                    var list = con.GetAll<Kayit>().OrderByDescending(x => x.Tarih);
                    List<Kayit> listele = new List<Kayit>();
                    foreach (var item in list)
                    {
                        if (DateTime.Now.AddMonths(-1) <= item.Tarih)
                        {

                            listele.Add(item);
                        }
                    }
                    isler.ItemsSource = listele;
                }
                catch (Exception  )
                {
                    throw;
                }

            }

        }
    }
}