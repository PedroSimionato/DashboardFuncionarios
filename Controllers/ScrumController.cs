using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers
{
    public class ScrumController : Controller
    {
        
        private readonly ApplicationDbContext _database;
        
        public ScrumController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(ScrumMasterDTO scrumMasterDTO)
        {
            if(ModelState.IsValid)
            {
                var scrum = new ScrumMaster();
                scrum.Id = scrumMasterDTO.Id;
                scrum.Nome = scrumMasterDTO.Nome;
                scrum.Letras = scrumMasterDTO.Letras;
                _database.Scrums.Add(scrum);
                _database.SaveChanges();
                return View("../Account/Register");
            }
            else
            {
                ViewBag.Tecnologias = _database.Tecnologias.ToList();
                return View("../Adm/NovoScrum");
            }
        }

        public IActionResult Dailys()
        {
            var dailys = _database.Dailys.Include(d => d.Starter).Include(d => d.Modulo)
            .Where(d => d.Status == true).ToList();
            return View(dailys);
        }

        public IActionResult NovaDaily()
        {
            ViewBag.Modulos = _database.Modulos.ToList();
            ViewBag.Starters = _database.Starters.ToList();
            return View();
        }

        public IActionResult EditarDaily(int id)
        {
            var daily = _database.Dailys.First(d => d.Id == id);
            var dailyDTO = new DailyDTO();
            dailyDTO.Id = id;
            dailyDTO.StarterId = daily.Starter.Id;
            dailyDTO.ModuloId = daily.Modulo.Id;
            if (daily.Presenca == true)
            dailyDTO.Presenca = 1;
            else
            dailyDTO.Presenca = 0;
            dailyDTO.Impedimento = daily.Impedimento;
            dailyDTO.Fazendo = daily.Fazendo;
            dailyDTO.Feito = daily.Feito;
            dailyDTO.Data = daily.Data;
            ViewBag.Modulos = _database.Modulos.ToList();
            ViewBag.Starters = _database.Starters.ToList();
            return View(dailyDTO);
        }

    }    
}