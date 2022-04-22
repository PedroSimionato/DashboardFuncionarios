using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers
{
    public class StarterController : Controller
    {
        private readonly ApplicationDbContext _database;

        public StarterController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(StarterDTO starterDTO)
        {
            if(ModelState.IsValid)
            {
                var starter = new Starter();
                starter.Id = starterDTO.Id;
                starter.Nome = starterDTO.Nome;
                starter.Letras = starterDTO.Letras;
                starter.Tecnologia = _database.Tecnologias.First(t=> t.Id == starterDTO.TecnologiaId);
                starter.Programa = _database.Programas.First(p => p.Id == starterDTO.ProgramaId);
                starter.Status = true;
                _database.Starters.Add(starter);
                _database.SaveChanges();
                return RedirectToAction("Index", "Adm");
            }
            else
            {
                ViewBag.Tecnologias = _database.Tecnologias.ToList();
                ViewBag.Programas = _database.Programas.ToList();
                return View("../Adm/NovoStarter");
            }
        }

        public IActionResult Atualizar(StarterDTO starterDTO)
        {
            if(ModelState.IsValid)
            {
                var starter = _database.Starters.Include(s => s.Programa).Include(s => s.Grupo).
                Include(s => s.Tecnologia).First(s => s.Id == starterDTO.Id);
                starter.Id = starterDTO.Id;
                starter.Nome = starterDTO.Nome;
                starter.Letras = starterDTO.Letras;
                starter.Tecnologia = _database.Tecnologias.First(t=> t.Id == starterDTO.TecnologiaId);
                starter.Programa = _database.Programas.First(p => p.Id == starterDTO.ProgramaId);
                starter.Status = true;
                _database.Starters.Update(starter);
                _database.SaveChanges();
                return RedirectToAction("Starters", "Adm");
            }
            else
            {
                ViewBag.Tecnologias = _database.Tecnologias.ToList();
                ViewBag.Programas = _database.Programas.ToList();
                return View("../Adm/EditarStarter/");
            }
        }

        public IActionResult Deletar(int id)
        {
            var starter = _database.Starters.First(s => s.Id == id);
            starter.Status = false;
            _database.Starters.Update(starter);
            _database.SaveChanges();
            return RedirectToAction("Starters", "Adm");
        }
        
    }
}