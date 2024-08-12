using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace ProjectDemo.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var apitürü = "USD";
            string link = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(link);

            string USDALIS= xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            ViewBag.usdalıs = USDALIS;
            string USDSATIS = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            ViewBag.usdsatıs = USDSATIS;

            string EURALIS = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            ViewBag.euralıs = EURALIS;
            string EURSATIS = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            ViewBag.eursatıs = EURSATIS;





            //var apitürü = "USD";
            //var api = "https://currency-exchange.p.rapidapi.com/exchange?from=" + apitürü + "&to=TRY&q=1.0";

            //#region
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri(api),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", "766201b3f6mshe3564640b1a7567p163900jsn86df570a56df" },
            //        { "x-rapidapi-host", "currency-exchange.p.rapidapi.com" },
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    ViewBag.UsdtoTry = body;                   //USD
            //}
            //#endregion
            //#region
            //var client2 = new HttpClient();
            //var request2 = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=Eur&to=TRY&q=1.0"),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", "766201b3f6mshe3564640b1a7567p163900jsn86df570a56df" },
            //        { "x-rapidapi-host", "currency-exchange.p.rapidapi.com" },
            //    },
            //};
            //using (var response = await client2.SendAsync(request2))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    ViewBag.EurtoTry = body;                   //EUR
            //}
            //#endregion
            //#region
            //var client3 = new HttpClient();
            //var request3 = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", "766201b3f6mshe3564640b1a7567p163900jsn86df570a56df" },
            //        { "x-rapidapi-host", "currency-exchange.p.rapidapi.com" },
            //    },
            //};
            //using (var response = await client3.SendAsync(request3))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    ViewBag.PoutoTry = body;                  //POU
            //}
            //#endregion
            return View();
        }

    }
}

