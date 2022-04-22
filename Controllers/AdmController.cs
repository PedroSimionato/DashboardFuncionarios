using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafio.Models;
using Desafio.Data;
using Microsoft.EntityFrameworkCore;
using Desafio.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Desafio.Controllers
{
    [Authorize(Policy = "Adm")]
    public class AdmController : Controller
    {
        private readonly ApplicationDbContext _database;

        public AdmController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Programas()
        {
            var programas = _database.Programas.Where(p => p.Status == true).ToList();
            return View(programas);
        }

        public IActionResult NovoPrograma()
        {
            return View();
        }

        public IActionResult EditarPrograma(int id)
        {
            var programa = _database.Programas.First(p => p.Id == id);
            var progDTO = new ProgramaStarterDTO();
            progDTO.Id = programa.Id;
            progDTO.Turma = programa.Turma;
            progDTO.Inicio = programa.Inicio;
            progDTO.Fim = programa.Fim;
            return View(progDTO);
        }
        

        public IActionResult Tecnologias()
        {
            var tecnologias = _database.Tecnologias.ToList();
            return View(tecnologias);
        }

        public IActionResult NovaTecnologia()
        {
            return View();
        }

        public IActionResult Starters()
        {
            var starters = _database.Starters.Include(st => st.Programa).Include(st => st.Tecnologia).
            Where(st => st.Status == true).Include(st => st.Grupo).ToList();
            return View(starters);
        }

        public IActionResult NovoStarter()
        {
            ViewBag.Tecnologias = _database.Tecnologias.ToList();
            ViewBag.Programas = _database.Programas.Where(p => p.Status == true).ToList();
            return View();
        }

        public IActionResult EditarStarter(int id)
        {
            var starter = _database.Starters.Include(s => s.Programa).Include(s => s.Grupo).Include(s => s.Tecnologia).
            First(s => s.Id == id);
            var starterDTO = new StarterDTO();
            starterDTO.Id = starter.Id;
            starterDTO.Nome = starter.Nome;
            starterDTO.Letras = starter.Letras;
            starterDTO.ProgramaId = starter.Programa.Id;
            starterDTO.TecnologiaId = starter.Tecnologia.Id;
            ViewBag.Tecnologias = _database.Tecnologias.ToList();
            ViewBag.Programas = _database.Programas.Where(p => p.Status == true).ToList();
            return View(starterDTO);
        }

        public IActionResult Scrums()
        {
            var scrums = _database.Scrums.ToList();
            return View(scrums);
        }

        public IActionResult NovoScrum()
        {
            return View();
        }

        public IActionResult Grupos()
        {
            var grupos = _database.Grupos.Include(gr => gr.ScrumMaster).Include(gr => gr.Tecnologia).
            Where(gr => gr.Status == true).ToList();
            return View(grupos);
        }
        
        public IActionResult NovoGrupo()
        {
            ViewBag.Tecnologias = _database.Tecnologias.ToList();
            ViewBag.Scrums = _database.Scrums.ToList();
            return View();
        }

        public IActionResult EditarGrupo(int id)
        {
            var grupo = _database.Grupos.Include(g => g.ScrumMaster).
            Include(g => g.Tecnologia).First(g => g.Id == id);
            var grupoDTO = new GrupoDTO();
            grupoDTO.Id = id;
            grupoDTO.ScrumMasterId = grupo.ScrumMaster.Id;
            grupoDTO.TecnologiaId = grupo.Tecnologia.Id;
             ViewBag.Tecnologias = _database.Tecnologias.ToList();
            ViewBag.Scrums = _database.Scrums.ToList();
            return View(grupoDTO);
        }

        public IActionResult Modulos()
        {
            var modulos = _database.Modulos.Where(mod => mod.Status == true).ToList();
            return View(modulos);
        }


        public IActionResult NovoModulo()
        {
            return View();
        }

        public IActionResult EditarModulo(int id)
        {
            var modulo = _database.Modulos.First(mod => mod.Id == id);
            var moduloDTO = new ModuloDTO();
            moduloDTO.Id = modulo.Id;
            moduloDTO.Nome = modulo.Nome;
            return View(moduloDTO);
        }

        public IActionResult Projetos()
        {
            var projetos = _database.Projetos.Include(proj => proj.Modulo).Include(proj => proj.Starter).
            Where(proj => proj.Status == true).ToList();
            return View(projetos);
        }

        public IActionResult NovoProjeto()
        {
            ViewBag.Modulos = _database.Modulos.ToList();
            ViewBag.Starters = _database.Starters.ToList();
            return View();
        }

        public IActionResult EditarProjeto(int id)
        {
            var projeto = _database.Projetos.Include(proj => proj.Modulo).Include(proj => proj.Starter)
            .First(proj => proj.Id == id);
            var projDTO = new ProjetoDTO();
            projDTO.Id = id;
            projDTO.StarterId = projeto.Starter.Id;
            projDTO.ModuloId = projeto.Modulo.Id;
            projDTO.Avaliacao = projeto.Avaliacao;
            projDTO.Comentario = projeto.Comentario;
            ViewBag.Modulos = _database.Modulos.ToList();
            ViewBag.Starters = _database.Starters.ToList();
            return View(projDTO);
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
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}