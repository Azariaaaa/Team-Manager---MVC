using FootballClub.Database;
using FootballClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
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
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            using (DatabaseContext database = new DatabaseContext())
            {
                database.Players.Add(new Player { 
                    Firstname = player.Firstname, 
                    Lastname = player.Lastname, 
                    Number = player.Number, 
                    Role = player.Role, 
                    TeamId = player.TeamId
                });

                database.SaveChanges();
            }

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
        public IActionResult DisplayTeams()
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                List<Team> teamList = database.Teams.ToList();

                return View(teamList);
            }
        }

        public IActionResult DisplayTeamByTeamId(int id)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                List<Player> playerListByTeamId = database.Players.Where(x => x.TeamId == id).ToList();
                return View(playerListByTeamId);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
