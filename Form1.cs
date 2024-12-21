using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BricOgreniyorum
{
    public partial class Form1 : Form
    {
        private readonly string[,] _cards;
        private readonly int[] _dengeli, _yariDengeli;

        public Form1()
        {
            InitializeComponent();
            _cards = new[,]
            {
                {"♣1", "♦1", "♥1", "♠1"},
                {"♣2", "♦2", "♥2", "♠2"},
                {"♣3", "♦3", "♥3", "♠3"},
                {"♣4", "♦4", "♥4", "♠4"},
                {"♣5", "♦5", "♥5", "♠5"},
                {"♣6", "♦6", "♥6", "♠6"},
                {"♣7", "♦7", "♥7", "♠7"},
                {"♣8", "♦8", "♥8", "♠8"},
                {"♣9", "♦9", "♥9", "♠9"},
                {"♣10", "♦10", "♥10", "♠10"},
                {"♣J", "♦J", "♥J", "♠J"},
                {"♣Q", "♦Q", "♥Q", "♠Q"},
                {"♣K", "♦K", "♥K", "♠K"}
            };
            _dengeli = new[]
            {
                4333, 3433, 3334, 3343,
                4432, 4423, 4342, 4324,
                4234, 4243, 2434, 2344,
                2443, 3442, 3244, 3424,
                5332, 5323, 5233, 2335,
                2353, 2533, 3325, 3352,
                3253, 3235, 3532, 3523
            };
            _yariDengeli = new[]
            {
                5422, 5242, 2542, 5224,
                4522, 4252, 4225, 2245,
                2542, 2524, 2452, 2425,
                6322, 6232, 6223, 3226,
                3262, 3622, 2632, 2362,
                2326, 2236, 2263, 2623,
                7222, 2722, 2272, 2227
            };
        }

        private string ConvertImageName(string card)
        {
            var karakter = card[0].ToString();
            var num=0;
            switch (card.Substring(1))
            {
                case "J": num = 10; break;
                case "Q": num = 11; break;
                case "K": num = 12; break;
                case "A": num = 13; break;
                default: num = int.Parse(card.Substring(1)) - 1; break;
            }
            switch (karakter)
            {
                //{ "♣K", "♦K", "♥K", "♠K"}
                case "♣": karakter = "_clubs"; break;
                case "♦": karakter = "_diamonds";num += 13; break;
                case "♥": karakter = "_hearts";num += 26;break;
                case "♠": karakter = "_spades";num += 39; break;
            }
            return num.ToString("00") + karakter + ".jpg";
        }
        private int CheckNum(ListBox listbox, int card)
        {
            var counter = 0;
            foreach (var t in listbox.Items)
            {
                foreach (var num in Enumerable.Range(0,_cards.GetUpperBound(1)+1).Select(i=>_cards[card-1,i]).ToArray())
                {
                    if (num==t.ToString())
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        private  int Check(ListBox listbox, int card)
        {
            var counter = 0;
            foreach (var t in listbox.Items)
            {
                for (var i = 0; i <= _cards.GetUpperBound(1); i++)
                {
                    if (_cards[card - 1, i].Equals(t.ToString()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        public int PuanJG()
        {
            return Check(ListBoxGuney,10);
        }
        public int PuanJB()
        {
            return Check(ListBoxBati, 10);
        }
        public int PuanJK()
        {
            return Check(ListBoxKuzey, 10);
        }
        public int PuanJD()
        {
            return Check(ListBoxDogu, 10);
        }
        public int PuanQG()
        {
            return Check(ListBoxGuney,11);
        }
        public int PuanQB()
        {
            return Check(ListBoxBati,11);
        }
        public int PuanQK()
        {
            return Check(ListBoxKuzey,11);
        }
        public int PuanQD()
        {
            return Check(ListBoxDogu,11);
        }
        public int PuanKG()
        {
            return Check(ListBoxGuney,12);
        }
        public int PuanKB()
        {
            return Check(ListBoxBati,12);
        }
        public int PuanKK()
        {
            return Check(ListBoxKuzey,12);
        }
        public int PuanKD()
        {
            return Check(ListBoxDogu,12);
        }
         public int PuanAG()
        {
            return Check(ListBoxGuney,13);
        }
        public int PuanAB()
        {
            return Check(ListBoxBati, 13);
        }
        public int PuanAK()
        {

            return Check(ListBoxKuzey, 13);
        }
        public int PuanAD()
        {

            return Check(ListBoxDogu, 13);
        }

        public int ClubSayiG()
        {
            return CheckNum(ListBoxGuney,1);
        }

        public int KaroSayiG()
        {
            return CheckNum(ListBoxGuney,2);
        }

        public int KorSayiG()
        {

            return CheckNum(ListBoxGuney,3);
        }

        public int PikSayiG()
        {

            return CheckNum(ListBoxGuney,4);
        }

        public int ClubSayiB()
        {
            return CheckNum(ListBoxBati,1);
        }

        public int KaroSayiB()
        {
            return CheckNum(ListBoxBati,2);
        }

        public int KorSayiB()
        {
            return CheckNum(ListBoxBati,3);
        }

        public int PikSayiB()
        {
            return CheckNum(ListBoxBati,4);
        }

        public int ClubSayiK()
        {
            return CheckNum(ListBoxKuzey,1);
        }

        public int KaroSayiK()
        {
            return CheckNum(ListBoxKuzey,2);
        }

        public int KorSayiK()
        {
            return CheckNum(ListBoxKuzey,3);
        }

        public int PikSayiK()
        {
            return CheckNum(ListBoxKuzey,4);
        }

        public int ClubSayiD()
        {
            return CheckNum(ListBoxDogu,1);
        }

        public int KaroSayiD()
        {
            return CheckNum(ListBoxDogu, 2);
        }

        public int KorSayiD()
        {
            return CheckNum(ListBoxDogu, 3);
        }

        public int PikSayiD()
        {
            return CheckNum(ListBoxDogu, 4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BidGridView.Visible = false;
            LblGuney.ForeColor = Color.Green;
            BtnTrefl.Visible = false;
            BtnKaro.Visible = false;
            BtnKor.Visible = false;
            BtnPik.Visible = false;
            BtnNT.Visible = false;
            label62.Text = "♠";
            label63.ForeColor = Color.Red;
            label63.Text = "♥";
            label64.ForeColor = Color.Crimson;
            label64.Text = "♦";
            label65.ForeColor = Color.Green;
            label65.Text = "♣";
            label66.Text = "♠";
            label67.ForeColor = Color.Red;
            label67.Text = "♥";
            label68.ForeColor = Color.Crimson;
            label68.Text = "♦";
            label69.ForeColor = Color.Green;
            label69.Text = "♣";
            label70.Text = "♠";
            label71.ForeColor = Color.Red;
            label71.Text = "♥";
            label72.ForeColor = Color.Crimson;
            label72.Text = "♦";
            label73.ForeColor = Color.Green;
            label73.Text = "♣";
            label74.Text = "♠";
            label75.ForeColor = Color.Red;
            label75.Text = "♥";
            label76.ForeColor = Color.Crimson;
            label76.Text = "♦";
            label77.ForeColor = Color.Green;
            label77.Text = "♣";
            dataGridView1.Columns[0].Width = 40;
            for (int i = 1; i < 13; i++)
            {
                dataGridView1.Columns[i].Width = 35; //KOLON GENİŞLİK
            }
            this.dataGridView1.Rows.Insert(0, "♠");
            this.dataGridView1.Rows.Insert(1, "♥");
            this.dataGridView1.Rows.Insert(2, "♦");
            this.dataGridView1.Rows.Insert(3, "♣");
        }


        private void Button7_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = true;
            BtnBid1.Enabled = false;
            BtnBid2.Enabled = false;
            BtnBid3.Enabled = false;
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void BtnBid2_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = true;
            BtnBid1.Enabled = false;
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = true;
            BtnBid1.Enabled = false;
            BtnBid2.Enabled = false;
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = true;
            BtnBid1.Enabled = false;
            BtnBid2.Enabled = false;
            BtnBid3.Enabled = false;
            BtnBid4.Enabled = false;
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = true;
            BtnBid1.Enabled = false;
            BtnBid2.Enabled = false;
            BtnBid3.Enabled = false;
            BtnBid4.Enabled = false;
            BtnBid5.Enabled = false;
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            BtnTrefl.Enabled = true;
            BtnBid1.Enabled = false;
            BtnBid2.Enabled = false;
            BtnBid3.Enabled = false;
            BtnBid4.Enabled = false;
            BtnBid5.Enabled = false;
            BtnBid6.Enabled = false;
            BtnTrefl.Visible = true;
            BtnKaro.Visible = true;
            BtnKor.Visible = true;
            BtnPik.Visible = true;
            BtnNT.Visible = true;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void BtnPas_Click(object sender, EventArgs e)
        {
            if (LblBati.ForeColor == Color.Green)
            {
                BidGridView.Rows.Add(1);
                BidGridView.Rows[1].Cells[0].Value = "PAS";
                BidGridView.Rows[1].Cells[1].Value = "";
                BidGridView.Rows[1].Cells[2].Value = "";
                BidGridView.Rows[1].Cells[3].Value = "";
            }
            BidGridView.Rows[0].Cells[0].Value = "-";
            BidGridView.Rows[0].Cells[1].Value = "-";
            BidGridView.Rows[0].Cells[2].Value = "-";
            BidGridView.Rows[0].Cells[3].Value = "PAS";
            LblGuney.ForeColor = Color.Black;
            LblBati.ForeColor = Color.Green;
        }

        private Image CombineImages(string[] filenames, int vertical)
        {
            Image rtn = null;
            //if (File.Exists(Application.StartupPath + "\\Resources\\final.jpg"))
            //{
            //    File.Delete(Application.StartupPath + "\\Resources\\final.jpg");
            //}
            try
            {
                if (vertical==0)
                {
                    FileInfo[] files = new FileInfo[filenames.Length];
                    for (int i = 0; i < filenames.Length; i++)
                    {
                        //Application.StartupPath+ "\\Resources\\" + ConvertImageName(AKT)
                        files[i] = new FileInfo(Application.StartupPath + "\\Resources\\" + ConvertImageName(filenames[i]));
                    }
                    //change the location to store the final image.
                    string finalImage = Application.StartupPath + "\\Resources\\final.jpg";
                    List<int> imageHeights = new List<int>();
                    int nIndex = 0;
                    int width = 0;
                    foreach (FileInfo file in files)
                    {
                        Image img = Image.FromFile(file.FullName);
                        imageHeights.Add(img.Height);
                        width += img.Width;
                        img.Dispose();
                    }
                    imageHeights.Sort();
                    int height = imageHeights[imageHeights.Count - 1];
                    Bitmap img3 = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(img3);
                    g.Clear(SystemColors.AppWorkspace);
                    var widthindex = 0;
                    foreach (FileInfo file in files)
                    {
                        Image img = Image.FromFile(file.FullName);

                        if (nIndex == 0)
                        {
                            g.DrawImage(img, new Point(0, 0));
                            nIndex++;
                            widthindex++;
                            width = img.Width;
                        }
                        else
                        {
                            g.DrawImage(img, new Point(widthindex * 30, 0));
                            widthindex++;
                            width += img.Width;
                        }

                        img.Dispose();
                    }
                    g.Dispose();
                    img3.Save(finalImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                    rtn = new Bitmap(img3);
                    img3.Dispose();
                }
                else
                {
                    FileInfo[] files = new FileInfo[filenames.Length];
                    for (int i = 0; i < filenames.Length; i++)
                    {
                        //Application.StartupPath+ "\\Resources\\" + ConvertImageName(AKT)
                        files[i] = new FileInfo(Application.StartupPath + "\\Resources\\" + ConvertImageName(filenames[i]));
                    }
                    //change the location to store the final image.
                    string finalImage = Application.StartupPath + "\\Resources\\final.jpg";
                    List<int> imageWidths = new List<int>();
                    int nIndex = 0;
                    int height = 0;
                    foreach (FileInfo file in files)
                    {
                        Image img = Image.FromFile(file.FullName);
                        imageWidths.Add(img.Width);
                        height += img.Height;
                        img.Dispose();
                    }
                    imageWidths.Sort();
                    int width = imageWidths[imageWidths.Count - 1];
                    Bitmap img3 = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(img3);
                    g.Clear(SystemColors.AppWorkspace);
                    var heightindex = 0;
                    foreach (FileInfo file in files)
                    {
                        Image img = Image.FromFile(file.FullName);

                        if (nIndex == 0)
                        {
                            g.DrawImage(img, new Point(0, 0));
                            nIndex++;
                            heightindex++;
                            width = img.Width;
                        }
                        else
                        {
                            g.DrawImage(img, new Point( 0, heightindex * 50));
                            heightindex++;
                            width += img.Width;
                        }

                        img.Dispose();
                    }
                    g.Dispose();
                    img3.Save(finalImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                    rtn = new Bitmap(img3);
                    img3.Dispose();
                }
            }
            catch
            {

            }
            return rtn;
        }
        private void BtnKartDagit_Click(object sender, EventArgs e)
        {
            BidGridView.Visible = true;
            BidGridView.Rows.Clear();
            BidGridView.ReadOnly = true;
            ListBoxGuney.Items.Clear();
            ListBoxBati.Items.Clear();
            ListBoxKuzey.Items.Clear();
            ListBoxDogu.Items.Clear();
            label58.Text = "";
            label59.Text = "";
            label60.Text = "";
            label61.Text = "";
            GHCPuan.Text = "";
            label58.ForeColor = Color.Black;
            label59.ForeColor = Color.Black;
            label60.ForeColor = Color.Black;
            label61.ForeColor = Color.Black;

            {
                int sayac = 0;
                Random rastgele = new Random();
                string[] suits = {"♦", "♠", "♣", "♥"};
                string[] marka = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
                string[] TOPLAM = new string[52];
                string[] trefl =
                    {"C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "CJ", "CQ", "CK", "CA"}; // C = Sinek(Club)
                string[] karo =
                {
                    "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "DJ", "DQ", "DK", "DA"
                }; // D = Karo(Diamond)
                string[] kor =
                    {"H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK", "HA"}; //H = Kupa(Heart)
                string[] pik =
                    {"S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK", "SA"}; //S = Maça(Spade)
                //BIRBIRINDEN FARKLI RASTGELE KART TUTMA
                while (sayac < 52)
                {
                    int suitsrastgele = rastgele.Next(0, 4);
                    int markarastgele = rastgele.Next(0, 13);

                    if (Array.IndexOf(TOPLAM, suits[suitsrastgele] + marka[markarastgele]) == -1)
                    {
                        TOPLAM[sayac] = suits[suitsrastgele] + marka[markarastgele];
                        sayac += 1;
                    }
                }

                //YAZDIRMA İŞLEMI
                int sayi = 0;


                foreach (string AKT in TOPLAM)
                {
                    if (sayi < 13) // Güney kartların dağıtımı
                    {
                        AKT.Reverse();
                        ListBoxGuney.Items.Add(AKT);
                        ListBoxGuney.Sorted = true; //Kartların gruplandırılarak dizilmesi

                        string[] guney = new string[ListBoxGuney.Items.Count];
                        for (int i = 0; i < ListBoxGuney.Items.Count; i++)
                        {
                            guney[i] = ListBoxGuney.Items[i].ToString();
                            dataGridView1.Rows[0].Cells[i].Value = guney[i];
                        }

                        //Puanları Hesaplama
                        ClubSayiG();
                        label38.Text = ClubSayiG().ToString();
                        KaroSayiG();
                        label39.Text = KaroSayiG().ToString();
                        KorSayiG();
                        label40.Text = KorSayiG().ToString();
                        PikSayiG();
                        label41.Text = PikSayiG().ToString();
                        PuanJG();
                        label12.Text = PuanJG().ToString();
                        PuanQG();
                        label11.Text = PuanQG().ToString();
                        PuanKG();
                        label10.Text = PuanKG().ToString();
                        PuanAG();
                        label9.Text = PuanAG().ToString();
                        int JG;
                        JG = Convert.ToInt32(label12.Text);
                        int QG;
                        QG = Convert.ToInt32(label11.Text);
                        int KG;
                        KG = Convert.ToInt32(label10.Text);
                        int AG;
                        AG = Convert.ToInt32(label9.Text);
                        int GHCP;
                        GHCP = JG + (QG * 2) + (KG * 3) + (AG * 4); // Rastgele dağıtılan eldeki puanın hesaplanması
                        GHCPuan.Text = GHCP.ToString();
                        label54.Text = label38.Text + label39.Text + label40.Text + label41.Text;
                        // Güneyin el dağılım Kontrolleri Dengeli/Dengesiz
                    
                        int dagilim;
                        dagilim = Convert.ToInt32(label54.Text);
                        if (_dengeli.Equals(dagilim))
                        {
                            label58.ForeColor = Color.Blue;
                            label58.Text = "Dengeli";
                        }
                        else if (_yariDengeli.Equals(dagilim))
                        {
                            label58.ForeColor = Color.Green;
                            label58.Text = "Yarı Dengeli";
                        }
                        else

                            label58.Text = "Dengesiz";
                    }


                    else if (sayi < 26) //Batı kartların dağılımı
                    {
                        AKT.Reverse();
                        ListBoxBati.Items.Add(AKT);
                        ListBoxBati.Sorted = true; //Kartların gruplandırılarak dizilmesi
                        string[] Bati = new string[ListBoxBati.Items.Count];

                        for (int i = 0; i < ListBoxBati.Items.Count; i++)
                        {
                            Bati[i] = ListBoxBati.Items[i].ToString();
                            dataGridView1.Rows[1].Cells[i].Value = Bati[i];
                        }

                        //Puanları Hesaplama
                        ClubSayiB();
                        label42.Text = ClubSayiB().ToString();
                        KaroSayiB();
                        label43.Text = KaroSayiB().ToString();
                        KorSayiB();
                        label44.Text = KorSayiB().ToString();
                        PikSayiB();
                        label45.Text = PikSayiB().ToString();
                        PuanJB();
                        label16.Text = PuanJB().ToString();
                        PuanQB();
                        label15.Text = PuanQB().ToString();
                        PuanKB();
                        label14.Text = PuanKB().ToString();
                        PuanAB();
                        label13.Text = PuanAB().ToString();
                        int JB;
                        JB = Convert.ToInt32(label16.Text);
                        int QB;
                        QB = Convert.ToInt32(label15.Text);
                        int KB;
                        KB = Convert.ToInt32(label14.Text);
                        int AB;
                        AB = Convert.ToInt32(label13.Text);
                        int BHCP;
                        BHCP = JB + (QB * 2) + (KB * 3) + (AB * 4); // Rastgele dağıtılan eldeki puanın hesaplanması
                        BHCPuan.Text = "";
                        BHCPuan.Text = BHCP.ToString();
                        label55.Text = label42.Text + label43.Text + label44.Text + label45.Text;
                        // Batının el dağılım Kontrolleri Dengeli/Dengesiz
                        int dagilim;
                        dagilim = Convert.ToInt32(label55.Text);
                        if (_yariDengeli.Equals(dagilim))
                        {
                            label59.ForeColor = Color.Blue;
                            label59.Text = "Dengeli";
                        }
                        else if (_yariDengeli.Equals(dagilim))
                        {
                            label59.Text = "Yarı Dengeli";
                        }
                        else label59.Text = "Dengesiz";
                    }
                    else if (sayi < 39) //Kuzey kartların dağılımı
                    {
                        AKT.Reverse();
                        ListBoxKuzey.Items.Add(AKT);
                        ListBoxKuzey.Sorted = true; //Kartların gruplandırılarak dizilmesi
                        string[] Kuzey = new string[ListBoxKuzey.Items.Count];

                        for (int i = 0; i < ListBoxKuzey.Items.Count; i++)
                        {
                            Kuzey[i] = ListBoxKuzey.Items[i].ToString();
                            dataGridView1.Rows[2].Cells[i].Value = Kuzey[i];
                        }
                        //Puanları Hesaplama
                        PikSayiK();
                        label49.Text = PikSayiK().ToString();
                        KorSayiK();
                        label48.Text = KorSayiK().ToString();
                        KaroSayiK();
                        label47.Text = KaroSayiK().ToString();
                        ClubSayiK();
                        label46.Text = ClubSayiK().ToString();
                        PuanAK();
                        label24.Text = PuanAK().ToString();
                        PuanKK();
                        label23.Text = PuanKK().ToString();
                        PuanQK();
                        label22.Text = PuanQK().ToString();
                        PuanJK();
                        label21.Text = PuanJK().ToString();
                        int AK;
                        AK = Convert.ToInt32(label24.Text);
                        int KK;
                        KK = Convert.ToInt32(label23.Text);
                        int QK;
                        QK = Convert.ToInt32(label22.Text);
                        int JK;
                        JK = Convert.ToInt32(label21.Text);
                        
                        
                        
                        int KHCP;
                        KHCP = (QK * 2) + (KK * 3) + (AK * 4)+JK  ; // Rastgele dağıtılan eldeki puanın hesaplanması
                        KHCPuan.Text = "";
                        KHCPuan.Text = KHCP.ToString();
                        label56.Text = label49.Text + label48.Text + label47.Text + label46.Text;
                        // Kuzeyin el dağılım Kontrolleri Dengeli/Dengesiz
                        int dagilim;
                        dagilim = Convert.ToInt32(label56.Text);
                        if (_dengeli.Equals(dagilim))
                        {
                            label60.ForeColor = Color.Blue;
                            label60.Text = "Dengeli";
                        }
                        else if (_yariDengeli.Equals(dagilim))
                        {
                            label60.Text = "Yarı Dengeli";
                        }
                        else label60.Text = "Dengesiz";
                    }
                    else if (sayi < 52) //Doğu kartların dağılımı
                    {
                        AKT.Reverse();
                        ListBoxDogu.Items.Add(AKT);
                        ListBoxDogu.Sorted = true; //Kartların gruplandırılarak dizilmesi
                        string[] dogu = new string[ListBoxDogu.Items.Count];

                        for (int i = 0; i < ListBoxDogu.Items.Count; i++)
                        {
                            dogu[i] = ListBoxDogu.Items[i].ToString();
                            dataGridView1.Rows[3].Cells[i].Value = dogu[i];
                        }

                        //Puanları Hesaplama
                        ClubSayiD();
                        label50.Text = ClubSayiD().ToString();
                        KaroSayiD();
                        label51.Text = KaroSayiD().ToString();
                        KorSayiD();
                        label52.Text = KorSayiD().ToString();
                        PikSayiD();
                        label53.Text = PikSayiD().ToString();
                        PuanJD();
                        label32.Text = PuanJD().ToString();
                        PuanQD();
                        label31.Text = PuanQD().ToString();
                        PuanKD();
                        label30.Text = PuanKD().ToString();
                        PuanAD();
                        label29.Text = PuanAD().ToString();
                        int JD;
                        JD = Convert.ToInt32(label32.Text);
                        int QD;
                        QD = Convert.ToInt32(label31.Text);
                        int KD;
                        KD = Convert.ToInt32(label30.Text);
                        int AD;
                        AD = Convert.ToInt32(label29.Text);
                        int DHCP;
                        DHCP = JD + (QD * 2) + (KD * 3) + (AD * 4); // Rastgele dağıtılan eldeki puanın hesaplanması
                        DHCPuan.Text = "";
                        DHCPuan.Text = DHCP.ToString();
                        label57.Text = label50.Text + label51.Text + label52.Text + label53.Text;
                        // Doğunun el dağılım Kontrolleri Dengeli/Dengesiz
                        int dagilim;
                        dagilim = Convert.ToInt32(label57.Text);
                        if (_dengeli.Equals(dagilim))
                        {
                            label61.ForeColor = Color.Blue;
                            label61.Text = "Dengeli";
                        }
                        else if (_yariDengeli.Equals(dagilim))
                        {
                            label61.Text = "Yarı Dengeli";
                        }
                        else label61.Text = "Dengesiz";
                    }
                    //Toplam puanların hesaplanması/kontrolü ---- TotaHCP= Tüm destedeki puanların toplamı(40)
                    int GTHCP;
                    GTHCP = Convert.ToInt32(GHCPuan.Text);
                    int BTHCP;
                    BTHCP = Convert.ToInt32(BHCPuan.Text);
                    int KTHCP;
                    KTHCP = Convert.ToInt32(KHCPuan.Text);
                    int DTHCP;
                    DTHCP = Convert.ToInt32(DHCPuan.Text);
                    int THCP;
                    THCP = GTHCP + BTHCP + KTHCP + DTHCP;
                    TotalHCP.Text = THCP.ToString();
                    sayi++;
                }
            }
            picGuney.Image = CombineImages(ListBoxGuney.Items.Cast<string>().ToArray(),0);
            picKuzey.Image = CombineImages(ListBoxKuzey.Items.Cast<string>().ToArray(),0);
            picBati.Image = CombineImages(ListBoxBati.Items.Cast<string>().ToArray(), 0);
            picDogu.Image = CombineImages(ListBoxDogu.Items.Cast<string>().ToArray(), 0);

        }

            

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}