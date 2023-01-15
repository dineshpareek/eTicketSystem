using eTicketSystem.Data;
using eTicketSystem.Data.Interface;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;

namespace eTicketSystem.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service = null;
        public MovieController(IMovieService serv)
        {
            _service = serv;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var data = await _context.Movies.ToListAsync();
        //    return View(data);
        //}
        //public async Task<IActionResult> Index(string sortField, string currentSortField, string currentSortOrder, string currentFilter, string SearchString="", int pageNo=1)
        public IActionResult Index()
        {
            //https://dotnetlead.com/net/paging-and-sorting-using-asp-net-core-razor-page-web-api-and-entity-framework/2267/
            //https://www.codingame.com/playgrounds/5363/paging-with-entity-framework-core
            //https://localhost:7091/Movie?sortField=Description&currentSortField=Name&currentSortOrder=Desc

            var employees = _service.GetAll(x => x.Cinema);
            /*
            if (SearchString != null)
            {
                pageNo = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewData["CurrentSort"] = sortField;
            ViewBag.CurrentFilter = SearchString;
            if (!String.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.Title.Contains(SearchString));//.ToList();
            }

            //sorting 
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "StartDate";
                ViewBag.SortOrder = "Asc";
            }
            else
            {
                if (currentSortField == sortField)
                {
                    ViewBag.SortOrder = currentSortOrder == "Asc" ? "Desc" : "Asc";
                }
                else
                {
                    ViewBag.SortOrder = "Asc";
                }
                ViewBag.SortField = sortField;
            }
            //System.Reflection.PropertyInfo propertyInfo = typeof(Movie).GetProperty(ViewBag.sortField);
            ////var propertyInfo = typeof(Movie).GetProperty(ViewBag.SortField);
            //if (ViewBag.SortOrder == "Asc")
            //{
            //    employees = employees.OrderBy(s => propertyInfo.GetValue(s, null));//.ToList();
            //}
            //else
            //{
            //    employees = employees.OrderByDescending(s => propertyInfo.GetValue(s, null));//.ToList();
            //}
            var wemployees = employees.GetPaged(pageNo, 10);
            //int pageSize = 3;
            */
            return View(employees);
        }

        public IActionResult IndexDB()
        {
            /*
            //using (var dbContext = new dbContext())
            {
                //await _context.Database.EnsureDeletedAsync();
            }
            List<Movie> m = new List<Movie>();
            string key = "Top250Movies";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://imdb-api.com/en/API/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = await client.GetAsync($"{key}/k_pysckjz9").ConfigureAwait(false))
                {

                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    var resp = JsonConvert.DeserializeObject<Top250Data>(responseContent);
                    //return Json(responseContent);
                    //{ "id":"tt0111161","rank":"1","title":"The Shawshank Redemption","fullTitle":"The Shawshank Redemption (1994)","year":"1994","image":"https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX128_CR0,3,128,176_AL_.jpg","crew":"Frank Darabont (dir.), Tim Robbins, Morgan Freeman","imDbRating":"9.2","imDbRatingCount":"2581251"}
                    foreach (var r in resp.Items)
                    {
                        m.Add(
                            new Movie()
                            {
                                Title = r.Title,
                                RefId=r.Id,

                                fullTitle = r.FullTitle,
                                Description = $"This is the {r.FullTitle} movie description",
                                Year=Convert.ToInt32(r.Year),
                                crew=r.Crew,
                                ImDbRating= Convert.ToDouble(r.IMDbRating),
                                ImDbRatingCount=Convert.ToInt32(r.IMDbRatingCount),  

                                Price = 3*(Convert.ToDouble(r.IMDbRating)),
                                ImageURL = r.Image,
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(10),
                                CinemaId = 3,
                                ProducerId = 3,
                                MovieCategory = MovieCategory.Other
                            });
                    }
                    _context.Movies.AddRange(m);
                    _context.SaveChanges();
                    return Json(responseContent);
                }
                }
                var _client = new RestClient("https://reqres.in/");
            var request = new RestRequest("https://imdb-api.com/en/API/");
            var responses = await _client.ExecuteGetAsync(request);
            if (!responses.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }
            //var userList = JsonSerializer.Deserialize(response.Content);
            */
            return View();

        }

    }

    
}
