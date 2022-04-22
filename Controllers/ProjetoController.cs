using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ProjetoController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(ProjetoDTO projetoDTO)
        {
            if(ModelState.IsValid)
            {
                var projeto = new Projeto();
                projeto.Id = projetoDTO.Id;
                projeto.Avaliacao = projetoDTO.Avaliacao;
                projeto.Comentario = projetoDTO.Comentario;
                projeto.Status = true;
                projeto.Modulo = _database.Modulos.First(mod => mod.Id == projetoDTO.ModuloId);
                projeto.Starter = _database.Starters.First(star => star.Id == projetoDTO.StarterId);
                _database.Projetos.Add(projeto);
                _database.SaveChanges();
                return RedirectToAction("Projetos", "Adm");
            }
            else
            {
                ViewBag.Modulos = _database.Modulos.ToList();
                ViewBag.Starters = _database.Starters.ToList();
                return View("../Adm/NovoProjeto");
            }
        }

        public IActionResult Atualizar(ProjetoDTO projDTO)
        {
            if(ModelState.IsValid)
            {
                var projeto = _database.Projetos.First(proj => proj.Id == projDTO.Id);
                projeto.Starter = _database.Starters.First(st => st.Id == projDTO.StarterId);
                projeto.Modulo = _database.Modulos.First(mod => mod.Id == projDTO.ModuloId);
                projeto.Avaliacao = projDTO.Avaliacao;
                projeto.Comentario = projDTO.Comentario;
                _database.Projetos.Update(projeto);
                _database.SaveChanges();
                return RedirectToAction("Projetos", "Adm");
            }
            else
            {
                ViewBag.Modulos = _database.Modulos.ToList();
                ViewBag.Starters = _database.Starters.ToList();
                return View("../Adm/EditarProjeto");
            }
            
        }

        public IActionResult Deletar(int id)
        {
            var proj = _database.Projetos.First(proj => proj.Id == id);
            proj.Status = false;
            _database.Projetos.Update(proj);
            _database.SaveChanges();
            return RedirectToAction("Projetos", "Adm");
        }
    }
}