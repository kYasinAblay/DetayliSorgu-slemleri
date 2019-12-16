using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K.YasinABLAY_Odev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int elemanSayisi = 0, baslangicDegeri = 0, bitisDegeri = 0, deger = 0,
            sayac = 0, SansliSayi = 0;
        int[] sayilar;
        private void btnRastgeleSayilariListeyeEkle_Click(object sender, EventArgs e)
        {
            int TekSayilarAdeti = 0, TekSayilarToplami = 0, TekSayilarOrtalamasi = 0, CiftSayilarAdeti = 0, CiftSayilarToplami = 0, CiftSayilarOrtalamasi = 0, d = 0;
            if (int.TryParse(txtElemanSayisi.Text, out elemanSayisi) == false)
            {
                MessageBox.Show("Eleman Sayısını Boş Geçemezsiniz.");
                txtElemanSayisi.Focus();
                return;
            }
            if (int.TryParse(txtBaslangicSayisi.Text, out baslangicDegeri) == false)
            {
                MessageBox.Show("Başlangıç Sayısını Boş Geçemezsiniz.");
                txtBaslangicSayisi.Focus();
                return;
            }
            if (int.TryParse(txtBitisSayisi.Text, out bitisDegeri) == false)
            {
                MessageBox.Show("Bitiş Sayısı Boş Geçemezsiniz.");
                txtBitisSayisi.Focus();
                return;
            }
            listDizidekiSayilar.Items.Clear();
            listCiftSayilar.Items.Clear();
            listTekSayilar.Items.Clear();
            listSansliSayininDizidekiIndisleri.Items.Clear();



            elemanSayisi = Convert.ToInt32(txtElemanSayisi.Text);
            if (elemanSayisi == 0)
            {
                MessageBox.Show("Eleman sayısını 0'dan farklı giriniz.");
                return;
            }
            baslangicDegeri = Convert.ToInt32(txtBaslangicSayisi.Text);
            bitisDegeri = Convert.ToInt32(txtBitisSayisi.Text);
            SansliSayi = Convert.ToInt32(txtSansliSayi.Text);
            //^---------------Başlangıç kontrolleri------------------^//




            //---------------------İşlemler----------------------//

            Random rnd = new Random();
            sayilar = new int[elemanSayisi];


            if (sayac != elemanSayisi)
            {
                for (int i = 0; i < elemanSayisi; i++)
                {
                    deger = rnd.Next(baslangicDegeri, bitisDegeri + 1);
                    sayilar[i] = deger;
                    listDizidekiSayilar.Items.Add(deger);
                    sayac++;
                    //-------Şanslı sayı--------//
                    if (deger == SansliSayi)
                    {

                        for (int j = 0; j < i + 1; j++)
                        {

                            if (sayilar[j] == SansliSayi)
                            {
                                if (listSansliSayininDizidekiIndisleri.Items.Contains(j) == false)
                                {
                                    listSansliSayininDizidekiIndisleri.Items.Add(j);
                                }
                                else
                                {
                                    continue;
                                }




                            }

                        }
                    }

                    //-------------Tek ve Çift Sayılar Kontrolü-------//
                    if (deger % 2 == 0)
                    {
                        listCiftSayilar.Items.Add(deger);


                        CiftSayilarToplami += deger;

                        CiftSayilarAdeti++;

                    }
                    else
                    {
                        listTekSayilar.Items.Add(deger);


                        TekSayilarToplami += deger;

                        TekSayilarAdeti++;

                    }
                }
            }



            else
            {
                MessageBox.Show("Dizi eleman sayısı doldu.");
            }
            //---Çift veya Tek sayı gelmemesi durumuna karşı önlem
            if (CiftSayilarAdeti != 0)
            {
                CiftSayilarOrtalamasi = CiftSayilarToplami / CiftSayilarAdeti;

            }
            if (TekSayilarAdeti != 0)
            {
                TekSayilarOrtalamasi = TekSayilarToplami / TekSayilarAdeti;
            }

            //---Sonuçlar---//
            lblTekSayilarToplami.Text = TekSayilarToplami.ToString();
            lblTekSayilarAdedi.Text = TekSayilarAdeti.ToString();
            lblTekSayilarOrtalamasi.Text = TekSayilarOrtalamasi.ToString();

            lblCiftSayilarToplami.Text = CiftSayilarToplami.ToString();
            lblCiftSayilarAdeti.Text = CiftSayilarAdeti.ToString();
            lblCiftSayilarOrtalamasi.Text = CiftSayilarOrtalamasi.ToString();




            sayac = 0;

        }
    }
}

