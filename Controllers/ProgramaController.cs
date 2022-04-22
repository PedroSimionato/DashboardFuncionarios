using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    public class ProgramaController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ProgramaController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(ProgramaStarterDTO programaStarterDTO)
        {
            if(ModelState.IsValid)
            {
                var programa = new ProgramaStarter();
                programa.Id = programaStarterDTO.Id;
                programa.Turma = programaStarterDTO.Turma;
                programa.Inicio = programaStarterDTO.Inicio;
                programa.Fim = programaStarterDTO.Fim;
                programa.Status = true;
                _database.Programas.Add(programa);
                _database.SaveChanges();
                return RedirectToAction("Programas", "Adm");
            }
            else
            return View ("../Adm/NovoPrograma");
        }

        public IActionResult Atualizar(ProgramaStarterDTO progDTO)
        {
            if(ModelState.IsValid)
            {
                var programa = _database.Programas.First(p => p.Id == progDTO.Id);
                programa.Turma = progDTO.Turma;
                programa.Inicio = progDTO.Inicio;
                programa.Fim = progDTO.Fim;
                _database.Programas.Update(programa);
                _database.SaveChanges();
                return RedirectToAction("Programas", "Adm");
            }
            else
            return View("../Adm/EditarPrograma");
        }
        

        public IActionResult Deletar(int id)
        {
            var programa = _database.Programas.First(prog => prog.Id == id);
            programa.Status = false;
            _database.Programas.Update(programa);
            _database.SaveChanges();
            return RedirectToAction("Programas", "Adm");
        }
    }
}