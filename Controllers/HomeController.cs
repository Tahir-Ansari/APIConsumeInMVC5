using ConsumeAPI.Models;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumeAPI.Controllers
{
    public class HomeController : Controller
    {

      
       readonly string Baseurl = "https://catfact.ninja";
       readonly string Baseurl1 = "https://dog.ceo/";


        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetCat()
        {
            Cats CatInfoo = new Cats();
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
              
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
                HttpResponseMessage Res = await client.GetAsync("/fact");
              
                if (Res.IsSuccessStatusCode)
                {
                   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    
                    CatInfoo = JsonConvert.DeserializeObject<Cats>(CatResponse);

                }
                //returning the employee list to view
                return View(CatInfoo);
            }
        }


        

        public async Task<ActionResult> GetImagesOfDog()
        {
            Dogs DgInfoo = new Dogs();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl1);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/breeds/image/random");

                if (Res.IsSuccessStatusCode)
                {

                    var CatResponse =await Res.Content.ReadAsStringAsync();
                    //Deserializing the response recieved from web api and storing into the Employee list

                    DgInfoo = JsonConvert.DeserializeObject<Dogs>(CatResponse);
                }
                //returning the employee list to view
                return View(DgInfoo);
            }
        }


    }
}