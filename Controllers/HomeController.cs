using FootballClub.Database;
using FootballClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace FootballClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlayerDTO player)
        {
            Console.WriteLine("test");
            Console.WriteLine(player.TeamId);
            //Console.WriteLine(player.Team.Id);
            //JE CROIS QUE LE CODE S'ARRETE A CETTE CONDITION A VERIFIER   !!!!!!
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            Console.WriteLine("OKKKKKKKKKKKKKKKKKKKKKK - -1 ");

            using (DatabaseContext database = new DatabaseContext())
            {
                Console.WriteLine("OKKKKKKKKKKKKKKKKKKKKKK - 0 ");

                database.Players.Add(new Player { 
                    Firstname = player.Firstname, 
                    Lastname = player.Lastname, 
                    Number = player.Number, 
                    Role = player.Role, 
                    TeamId = player.TeamId
                });
                Console.WriteLine("OKKKKKKKKKKKKKKKKKKKKKK - 1 ");
                database.SaveChanges();
            }
            Console.WriteLine("OKKKKKKKKKKKKKKKKKKKKKK - 1 -2");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateTeam(TeamDTO team)
        {
            if(!ModelState.IsValid)
            {
                return View(team);
            }

            using (DatabaseContext database = new DatabaseContext())
            {
                database.Teams.Add(new Team { Name = team.Name });
                database.SaveChanges();
            }

            return RedirectToAction("Index", "Home");

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
