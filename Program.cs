namespace proje1_2
{
    
        internal class Program
        {


            #region Adminsiz
            //    
            //    string[] urunler = { "Su", "Soda", "Kola" };
            //    decimal[] fiyatlar = { 10.0m, 20.0m, 30.0m };

            //   
            //    Console.WriteLine("Ürünler ve Fiyatları:");
            //    for (int i = 0; i < urunler.Length; i++)
            //    {
            //        Console.WriteLine($"{i + 1}. {urunler[i]} - {fiyatlar[i]} TL");
            //    }

            //    
            //    Console.Write("\nAlmak istediğiniz ürünü seçin (1-3): ");
            //    int urunSecimi = int.Parse(Console.ReadLine()) - 1;

            //    
            //    Console.WriteLine($"\nSeçilen Ürün: {urunler[urunSecimi]} - {fiyatlar[urunSecimi]} TL");

            //    
            //    Console.Write("Lütfen ödeme yapacağınız miktarı girin: ");
            //    decimal odenenTutar = decimal.Parse(Console.ReadLine());

            //    
            //    if (odenenTutar >= fiyatlar[urunSecimi])
            //    {
            //        decimal paraUstu = odenenTutar - fiyatlar[urunSecimi];
            //        Console.WriteLine($"\nÖdeme başarılı! Para üstü: {paraUstu} TL");
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nYetersiz ödeme yaptınız. İşlem başarısız.");
            //    }
            #endregion
            #region 
            // Array.Resize ı kullandığımda admin panelinde ya hata aldım yada istediğim gibi çalışmadı 

            // UrunEkle kısmında aynı ürünü hala ekliyor.


            static List<string> urunler = new List<string> { "Su", "Soda", "Kola" };
            static List<decimal> fiyatlar = new List<decimal> { 10.0m, 20.0m, 30.0m };

            static void Main()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Ürünler ve Fiyatları:");
                    for (int i = 0; i < urunler.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {urunler[i]} - {fiyatlar[i]} TL");
                    }

                    Console.WriteLine("\nÜrün almak için ürün numarasını seçin, Admin paneli için -1 yazın:");
                    int urunSecimi = int.Parse(Console.ReadLine());

                    if (urunSecimi == -1)
                    {
                        AdminPaneli();
                    }
                    else if (urunSecimi > 0 && urunSecimi <= urunler.Count)
                    {
                        UrunAl(urunSecimi - 1);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim.");
                        Console.ReadLine();
                    }
                }
            }

            static void UrunAl(int urunIndex)
            {
                Console.Clear();
                Console.WriteLine($"Seçilen Ürün: {urunler[urunIndex]} - {fiyatlar[urunIndex]} TL");
                Console.Write("Lütfen para girişi yapın: ");
                decimal odenenTutar = decimal.Parse(Console.ReadLine());

                if (odenenTutar >= fiyatlar[urunIndex])
                {
                    decimal paraUstu = odenenTutar - fiyatlar[urunIndex];
                    Console.WriteLine($"\nÖdeme başarılı! Para üstü: {paraUstu} TL");
                }
                else
                {
                    Console.WriteLine("\nYetersiz ödeme yaptınız. İşlem başarısız.");
                    Thread.Sleep(2000);
                }

                Console.WriteLine("Devam etmek için bir tuşa basın.");
                Console.ReadLine();
            }

            static void AdminPaneli()
            {
                string adminSifre = "1234";
                int hataliGirisHakki = 3;

                while (hataliGirisHakki > 0)
                {
                    Console.Clear();
                    Console.Write("Admin şifresini girin: ");
                    string sifre = Console.ReadLine();

                    if (sifre == adminSifre)
                    {
                        AdminIslemleri();
                        return;
                    }
                    else
                    {
                        hataliGirisHakki--;
                        Console.WriteLine($"Hatalı giriş. Kalan deneme hakkı: {hataliGirisHakki}");
                        Thread.Sleep(2000);
                        if (hataliGirisHakki == 0)
                        {
                            Console.WriteLine("Giriş hakkınız bitti.");
                            Thread.Sleep(5000);
                            Console.ReadLine();
                            return;
                        }
                    }
                }
            }

            static void AdminIslemleri()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Admin Paneli:");
                    Console.WriteLine("1. Ürün ekle");
                    Console.WriteLine("2. Ürün sil");
                    Console.WriteLine("3. Çık");
                    Console.Write("Seçiminizi yapın: ");
                    int secim = int.Parse(Console.ReadLine());

                    switch (secim)
                    {
                        case 1:
                            UrunEkle();
                            break;
                        case 2:
                            UrunCikar();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Geçersiz seçim.");
                            break;
                    }
                }
            }

            static void UrunEkle()
            {
                Console.Clear();
                Console.Write("Yeni ürün adını girin: ");
                string yeniUrun = Console.ReadLine();
                yeniUrun = yeniUrun.ToLower();     //HATA: aynı ürünü ayıklamıyor. 
                bool exists = false;
                for (int i = 0; i < urunler.Count; i++)    // Length Count? List yerine Array kullanıp array.exist?
                {
                    if (urunler[i].ToLower() == yeniUrun)
                    {
                        exists = true;
                        break;
                    }


                    if (exists)
                    {
                        Console.WriteLine("Bu ürün zaten mevcut.");
                        Thread.Sleep(2000);
                        continue;                  // return; yazınca menüye dönmüyor, patlıyor.
                    }
                }

                Console.Write("Yeni ürün fiyatını girin: ");
                decimal yeniFiyat = decimal.Parse(Console.ReadLine());

                urunler.Add(yeniUrun);
                fiyatlar.Add(yeniFiyat);

                Console.WriteLine("Yeni ürün eklendi.");
                Console.ReadLine();
            }

            static void UrunCikar()
            {
                Console.Clear();
                Console.WriteLine("Mevcut Ürünler:");
                for (int i = 0; i < urunler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {urunler[i]} - {fiyatlar[i]} TL");
                }

                Console.Write("Silmek istediğiniz ürünün numarasını girin: ");
                int silinecekUrun = int.Parse(Console.ReadLine()) - 1;

                if (silinecekUrun >= 0 && silinecekUrun < urunler.Count)
                {
                    Console.WriteLine($"{urunler[silinecekUrun]} ürünü silindi.");
                    urunler.RemoveAt(silinecekUrun);
                    fiyatlar.RemoveAt(silinecekUrun);
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün seçimi.");
                }

                Console.ReadLine();
            }
        }


        #endregion
    }

