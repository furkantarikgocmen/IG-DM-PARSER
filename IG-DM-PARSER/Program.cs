using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace IG_DM_PARSER
{
    public class Like
    {
        public string username { get; set; }
        public DateTime date { get; set; }
    }

    public class Conversation
    {
        public string sender { get; set; }
        public DateTime created_at { get; set; }
        public string story_share { get; set; }
        public string text { get; set; }
        public string media_owner { get; set; }
        public string media_share_caption { get; set; }
        public string media_share_url { get; set; }
        public List<Like> likes { get; set; }
        public string heart { get; set; }
        public string profile_share_username { get; set; }
        public string profile_share_name { get; set; }
        public string action { get; set; }
        public string link { get; set; }
        public string media { get; set; }
        public string mentioned_username { get; set; }
    }

    public class RootObject
    {
        public List<string> participants { get; set; }
        public List<Conversation> conversation { get; set; }


    }
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Instagram Verileri Mesaj Dosyası Ayıklama Scripti");
                Console.WriteLine("Copyright FTG Furkan Tarık Göçmen ©");
                Console.WriteLine("Instagram @furkantarikgocmen");
                Console.WriteLine("GitHub /Furkantarikgocmen");
                Console.WriteLine("Put The File (messages.json) With The Application İn The Same Directory");
                Console.WriteLine("Turkish Subtitle: Dosyayı (messages.json) Uygulama İle Aynı Dizine Koyunuz");
                Console.WriteLine("==!==Eğer sadece bir kullanıcının mesajlarını istiyor iseniz o kullanıcının ismini giriniz. Hepsini istiyorsanız kullanıcı adı kısmını boş bırakınız.==!==");
                Console.WriteLine("==!==If you want only one user's message, please enter that user's name.If you want them all, leave the user name blank.=!==");
                using (System.IO.StreamReader _StreamReader = new System.IO.StreamReader("messages.json"))
                {

                    string jsonData = _StreamReader.ReadToEnd();
                    List<RootObject> Katilimcilar = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RootObject>>(jsonData);

                    Console.WriteLine("Kullanıcı Adı Giriniz / Enter The Username");
                    string kullanici = Console.ReadLine();

                    int sayac = 0;

                    using (StreamWriter writer = new StreamWriter("output.txt"))
                    {
                        writer.WriteLine("=====Transaction Is Starting=====");
                        foreach (var _Mesaj in Katilimcilar)
                        {

                            foreach (var kullanicilar in _Mesaj.participants)
                            {


                                if (kullanici == kullanicilar)
                                {

                                    writer.WriteLine("======MESAJLAR/MESSAGES=====");

                                    foreach (var mesajlar in _Mesaj.conversation)
                                    {
                                        writer.WriteLine("{0}: {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} ", mesajlar.sender, mesajlar.story_share, mesajlar.media_owner, mesajlar.media_share_caption, mesajlar.media_share_url, mesajlar.profile_share_username, mesajlar.profile_share_name, mesajlar.link, mesajlar.media, mesajlar.mentioned_username, mesajlar.text, mesajlar.heart, mesajlar.created_at);
                                        Console.WriteLine("{0}: {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} ", mesajlar.sender, mesajlar.story_share, mesajlar.media_owner, mesajlar.media_share_caption, mesajlar.media_share_url, mesajlar.profile_share_username, mesajlar.profile_share_name, mesajlar.link, mesajlar.media, mesajlar.mentioned_username, mesajlar.text, mesajlar.heart, mesajlar.created_at);
                                        sayac++;
                                    }
                                }

                                if (kullanici == string.Empty)
                                {

                                    writer.WriteLine("======MESAJLAR/MESSAGES=====");

                                    foreach (var mesajlar in _Mesaj.conversation)
                                    {
                                        writer.WriteLine("{0}: {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} ", mesajlar.sender, mesajlar.story_share, mesajlar.media_owner, mesajlar.media_share_caption, mesajlar.media_share_url, mesajlar.profile_share_username, mesajlar.profile_share_name, mesajlar.link, mesajlar.media, mesajlar.mentioned_username, mesajlar.text, mesajlar.heart, mesajlar.created_at);
                                        Console.WriteLine("{0}: {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} ", mesajlar.sender, mesajlar.story_share, mesajlar.media_owner, mesajlar.media_share_caption, mesajlar.media_share_url, mesajlar.profile_share_username, mesajlar.profile_share_name, mesajlar.link, mesajlar.media, mesajlar.mentioned_username, mesajlar.text, mesajlar.heart, mesajlar.created_at);

                                        sayac++;
                                    }
                                }
                            }

                        }
                        Console.WriteLine("=====Toplam Mesaj Sayısı : {0}=====", sayac);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction Successful!");
                Console.WriteLine("If Messages Without Username, User Blocked The You!");
                Console.WriteLine("Eğer Mesajlarda Kullanıcı Adı Yoksa, Kullanıcı Sizi Engellemiş Olabilir.");
                Console.WriteLine("Press Any Key To Exit!");
                Console.ReadKey();
            }
        }
    }
}
