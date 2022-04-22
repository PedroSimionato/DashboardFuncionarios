using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    public class DailyController : Controller
    {
        private readonly ApplicationDbContext _database;

        public DailyController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(DailyDTO dailyDTO)
        {
            if (ModelState.IsValid)
            {
                var daily = new Daily();
                daily.Id = dailyDTO.Id;
                daily.Data = dailyDTO.Data;
                daily.Fazendo = dailyDTO.Fazendo;
                daily.Feito = dailyDTO.Feito;
                daily.Impedimento = dailyDTO.Impedimento;
                if(dailyDTO.Presenca == 0)
                {
                    daily.Presenca = false;
                }
                else
                daily.Presenca = true;
                daily.Modulo = _database.Modulos.First(mod => mod.Id == dailyDTO.ModuloId);
                daily.Starter = _database.Starters.First(star => star.Id == dailyDTO.StarterId);
                daily.Status = true;
                _database.Dailys.Add(daily);
                _database.SaveChanges();
                return RedirectToAction("Dailys", "Master");
            }
            else
            {
                ViewBag.Modulos = _database.Modulos.ToList();
                ViewBag.Starters = _database.Starters.ToList();
                return View("../Master/NovaDaily");
            }
        }

        public IActionResult Atualizar(DailyDTO dailyDTO)
        {
            if (ModelState.IsValid)
            {
                var daily = _database.Dailys.First(d => d.Id == dailyDTO.Id);
                daily.Data = dailyDTO.Data;
                daily.Fazendo = dailyDTO.Fazendo;
                daily.Feito = dailyDTO.Feito;
                daily.Impedimento = dailyDTO.Impedimento;
                if(dailyDTO.Presenca == 0)
                {
                    daily.Presenca = false;
                }
                else
                daily.Presenca = true;
                daily.Modulo = _database.Modulos.First(mod => mod.Id == dailyDTO.ModuloId);
                daily.Starter = _database.Starters.First(star => star.Id == dailyDTO.StarterId);
                _database.Dailys.Update(daily);
                _database.SaveChanges();
                return RedirectToAction("Dailys", "Master");
            }
            else
            {
                ViewBag.Modulos = _database.Modulos.ToList();
                ViewBag.Starters = _database.Starters.ToList();
                return View("../Master/EditarDaily");
            }
        }

        public IActionResult Deletar(int id)
        {
            var daily = _database.Dailys.First(d => d.Id == id);
            daily.Status = false;
            _database.Dailys.Update(daily);
            _database.SaveChanges();
            return RedirectToAction("Dailys", "Master");
        }
        
    }
}