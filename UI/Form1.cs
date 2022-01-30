using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HtmlAgilityPack;
using System.Text;
using Newtonsoft.Json;
using System.Net.NetworkInformation;


namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static void programRun(string city)
        {
            string kaupunki = "";
            
            if (city.Equals("nolla"))
            {
                kaupunki = readCity();
            }
            else
            {

                kaupunki = city;
                writeCity(kaupunki);
            }
            Console.WriteLine("Kaupunki: " + kaupunki);
            IDictionary<string, string> houses = new Dictionary<string, string>();
            IWebDriver driver = new ChromeDriver(@"C:\Users\Antero Päivärinta\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net6.0");
            var options = new ChromeOptions();
            options.AddArgument("headless");
            String sss = String.Format("https://www.etuovi.com/myytavat-asunnot/{0}", kaupunki);
            driver.Navigate().GoToUrl(sss);
            List<House> information = new List<House>();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            //options.AddArgument("headless");
            driver.FindElement(By.XPath(".//button[contains(text(), 'Hyväksy')]")).Click();  //cookies
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
            //".//button[@class='theme__button__1YqFK theme__flat__13aFK theme__button__1YqFK theme__squared__17Uvn theme__neutral__1F1Jf Button__button__3K-jn Pagination__button__3H2wX']"
            IReadOnlyCollection<IWebElement> lukuelement = driver.FindElements(By.XPath(".//button[@class='theme__button__1YqFK theme__flat__13aFK theme__button__1YqFK theme__squared__17Uvn theme__neutral__1F1Jf Button__button__3K-jn Pagination__button__3H2wX']"));
            Console.WriteLine("SIZE: " + lukuelement.Count);
           // Console.WriteLine(lukuelement.ElementAt(0).GetAttribute("textContent"));
            //Console.WriteLine(lukuelement.ElementAt(1).GetAttribute("textContent"));
            int sizeapartments= Int16.Parse(lukuelement.ElementAt(lukuelement.Count-1).GetAttribute("textContent"));
            Console.WriteLine("SiteSize: ", lukuelement.ElementAt(lukuelement.Count - 1).GetAttribute("textContent"));
            //"theme__button__1YqFK theme__flat__13aFK theme__button__1YqFK theme__squared__17Uvn theme__neutral__1F1Jf Button__button__3K-jn Pagination__button__3H2wX";
            //MuiSvgIcon - root NavigateNext__NavigateNextIcon - sc - 3gszra - 0 ecOPLz
            //'MuiButtonBase-root MuiButton-root MuiButton-contained Button-sc-10dzaao-0 dHbhNS Pagination__paginationButton__SL_gh MuiButton-containedPrimary'
            for (int z = 0; z < sizeapartments-1;z ++)
            {
                List<string> parts = new List<string>();
                parts.Clear();
                Console.WriteLine("parts length: " + parts.Count());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                //< a class="MuiTypography-root MuiLink-root MuiLink-underlineHover InfoSegment__noStyleLink__2e28Y MuiTypography-colorPrimary"
                IReadOnlyCollection<IWebElement> ok = driver.FindElements(By.CssSelector("h4"));
                var TableRows = ok.ToList();
                Console.WriteLine("Tablerows length: " + TableRows.Count);
                TableRows.RemoveAt(30);
                int iiSize = TableRows.Count - (TableRows.Count - 30);
                Console.WriteLine("iiSIze: " + iiSize);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);

                for (int ii = 0; ii < iiSize; ii++)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50000);
                    parts.Add(TableRows.ElementAt(ii).GetAttribute("textContent"));
                    Console.WriteLine("Testi: " + parts[ii]);
                }
                TableRows.Clear();
                Console.WriteLine("tablerow: " + TableRows.Count);
                //for (int index = 0; index < dictionary.Count; index++)
                //  for (KeyValuePair<string, string> ele1 in houses)
                for (int index = 0; index < parts.Count; index++)
                {
                    Console.WriteLine("Line: " + index);
                    // var ele1= houses.ElementAt(index);
                    // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                    //Console.WriteLine("Lien check. Tutkitaan: "+ele1.Key+" ja "+ parts[m]);
                    if (houses.ContainsKey(parts[index]))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(parts[index]);
                        houses.Add(parts[index], "yes");
                        string e = parts[index];
                        string total = String.Format(".//h4[contains(text(),'{0}')]", e);
                        driver.FindElement(By.XPath(total)).Click();
                        IReadOnlyCollection<IWebElement> el = driver.FindElements(By.XPath(".//div[@class='flexboxgrid__col-xs-12__1I1LS flexboxgrid__col-sm-8__2jfMv CompactInfoRow__content__3jGt4']"));
                        //IReadOnlyCollection<IWebElement> sizElement = driver.FindElements(By.XPath(".//a[@class='MuiTypography-root MuiLink-root MuiLink-underlineHover InfoSegment__noStyleLink__2e28Y MuiTypography-colorPrimary']"));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                        String url = driver.Url;
                        Console.WriteLine("URL: " + url);
                        HtmlWeb web = new HtmlWeb();
                        HtmlDocument doc = web.Load(url);
                        // Console.WriteLine("KONTENT: " + doc.DocumentNode.OuterHtml);
                        string[] words = doc.DocumentNode.OuterHtml.Split(new string[] { "div class=" }, StringSplitOptions.None);

                        string rv = "not";
                        string nh = "not";
                        string x = "sprice"; //neliöhinnan muuttuja
                        string r = "r"; 
                        string kayttoonotto = "kayttoonotto";
                        string kv = "";
                        for (int zz = 0; zz < words.Length; zz++)
                        {
                            if (words[zz].Contains("Rakennusv"))
                            {
                                Console.WriteLine("Rakennusvuosi löytyi!");
                                r = words[zz + 1];
                                break;
                            }
                        } //etsitään rakennusvuoosi

                        for (int i = 0; i < words.Length; i++)
                        {

                            if (words[i].Contains("Neliöhin"))
                            {

                                x = words[i + 1];
                                break;
                            }
                        } //etsitään neliöhinta
                        for (int kerroin = 0; kerroin < words.Length; kerroin++)
                        {

                            if (words[kerroin].Contains("Käyttöönottov"))
                            {
                                
                                kayttoonotto = words[kerroin + 1];
                                break;
                            }
                        } //etsitään käyttöönottovuosi


                        string ra = "";//tallennetaan rakennusvuosi ra-muuttujaan
                        string a = "";
                        Console.WriteLine("RAKENNUSVUOSI: " + ra);


                        if (x.Equals("sprice"))
                        {
                            a = "check";
                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                            //driver.FindElement(By.XPath(".//span[@class = 'MuiButton-label']")).Click();  //TAKAISIN
                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);     
                        }
                        else
                        {
                            string title = x.Substring(x.IndexOf(">") + 1, 20);

                            foreach (char c in title)
                            {

                                char k = '€';

                                if (c.Equals(k))
                                {
                                    break;
                                }
                                else
                                {
                                    char f = c;

                                    a = a + c;

                                }
                            }
                            //MuiTypography-root MuiLink-root MuiLink-underlineHover InfoSegment__noStyleLink__2e28Y MuiTypography-colorPrimary
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                        }
                        if (r.Equals("r"))
                        {
                            ra = "check";
                        }
                        else
                        {
                            Console.WriteLine("k" + x);
                            string juujuu = r.Substring(r.IndexOf(">") + 1, 4);
                            foreach (char merkki in juujuu)
                            {

                                char kk = '>';

                                if (merkki.Equals(kk))
                                {
                                    break;
                                }
                                else
                                {


                                    ra = ra + merkki;

                                }
                            }
                        }
                        if (kayttoonotto.Equals("kayttoonotto"))
                        {

                            kv = "check";
                        }
                        else
                        {
                            string kayttoonottoteksti = kayttoonotto.Substring(kayttoonotto.IndexOf(">") + 1, 4);
                            foreach (char t in kayttoonottoteksti)
                            {
                                char mm = '>';
                                if (t.Equals('m'))
                                {
                                    break;
                                }
                                else
                                {
                                    kv = kv + t;
                                }


                            }
                        }

                        string koko = "";
                        IReadOnlyCollection<IWebElement> sizElement = driver.FindElements(By.XPath(".//a[@class='MuiTypography-root MuiLink-root MuiLink-underlineHover InfoSegment__noStyleLink__2e28Y MuiTypography-colorPrimary']"));
                        for (int s = 0; s < sizElement.Count; s++)
                        {
                            Console.WriteLine("Content: " + s + "  " + sizElement.ElementAt(s).GetAttribute("textContent"));
                            koko = sizElement.ElementAt(s).GetAttribute("textContent");
                            if ((koko.Equals("Yksiö") || koko.Equals("Kaksio") || koko.Equals("Kolmio")))
                            {
                                if (koko.Equals("Yksiö"))
                                {
                                    koko = "1";
                                    break;
                                }
                                if (koko.Equals("Kaksio"))
                                {
                                    koko = "2";
                                    break;
                                }
                                if (koko.Equals("Kolmio"))
                                {
                                    koko = "3";
                                    break;

                                }
                            }
                            else
                            {
                                //new string[] { "125" }, StringSplitOptions.None)
                                string[] tekstit = koko.Split(new string[] { " " }, StringSplitOptions.None);
                                if (tekstit.Length == 2)
                                {
                                    koko = tekstit[0];
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                        //string size = sizElement.ElementAt(0).GetAttribute("textContent");


                        Console.WriteLine("Neliöhinta: " + a + " suuruus: " + koko + " ,rakennusvuosi: " + ra + "Käyttöönotto; " + kv);
                        House house = new House(url, a, parts[index]);
                        information.Add(house);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                        //string c=x.Substring(index1, index2);
                        driver.FindElement(By.XPath(".//span[@class = 'MuiButton-label']")).Click();  //TAKAISIN
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100000);
                        //Console.WriteLine("{0} and {1}",ele1.Key, ele1.Value);

                    }

                }
                houses.Clear();
                parts.Clear();
                TableRows.Clear();
                Console.WriteLine("Taberows content size in end: " + TableRows.Count());
                Console.WriteLine("Yritetetään clickata");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                //string nextlink = sss+"&sivu="+z;
                //driver.Navigate().GoToUrl(nextlink);
                driver.FindElement(By.XPath(".//button[@class ='MuiButtonBase-root MuiButton-root MuiButton-contained Button-sc-10dzaao-0 dHbhNS Pagination__paginationButton__SL_gh MuiButton-containedPrimary' ]")).Click();
                Console.WriteLine("Clicked");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);

            }


            List<House> Sort = information.OrderBy(o => o.getPrice()).ToList();
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(@"cd C:\Code\testireact");
            // cmd.StandardInput.WriteLine("node server.js");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            Console.WriteLine("LISTA ALKAA TÄSTÄ:");
            for (int ppp = 0; ppp < Sort.Count; ppp++)
            {
                Console.WriteLine(Sort[ppp].getText());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:3001");
                Object postData =
                   new
                   {
                       name = Sort[ppp].getAddress(),
                       link = Sort[ppp].getLink(),
                       price = Sort[ppp].getPrice()
                   };
                request.Method = "POST";
                request.ContentType = "application/json";

                string postBody = JsonConvert.SerializeObject(postData);

                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(postBody);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string result = sr.ReadToEnd();

                    Console.WriteLine(result);
                }
            }

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(@"cd C:\Code\testireact");
            cmd.StandardInput.WriteLine("npm start");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            // var Json = JsonConvert.SerializeObject(testione);
            // optional
            // driver.Close();
        }
        public static string readCommand()
        {
            string command = File.ReadAllText(@"C:\Code\acommand.txt");
            return command;
        }
        public static string readCity()
        {
            string city = File.ReadAllText(@"C:\Code\city.txt");
            return city;

        }
        public static void writeCity(string city)
        {
            StreamWriter sw = new StreamWriter(@"C:\Code\city.txt");
            sw.WriteLine(city);
            sw.Flush();
            sw.Close();
        }

        public void clearFile()
        {
            File.WriteAllText("C://Code/city.txt", String.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cityOfField = textBox1.Text;
            lblHelloWorld.Text = "Status: In process..";
            if (cityOfField == "")
            {
                programRun("nolla");
            }
            else
            {
                programRun(cityOfField);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("This works");
        }

        private void lbHelloWorld_Click(object sender, EventArgs e)
        {

        }

        private void lblHelloWorld_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
            textBox1.Width = 250;
            textBox1.Height = 50;
            textBox1.Multiline = true;
            textBox1.BackColor = Color.Blue;
            textBox1.ForeColor = Color.White;
            textBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Console.WriteLine("Hello?");
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(@"cd C:\Code\testireact");
            cmd.StandardInput.WriteLine("npm start");
            cmd.StandardInput.WriteLine("node server.js");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }
    }
}
