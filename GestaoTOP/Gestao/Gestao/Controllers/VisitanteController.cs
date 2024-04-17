using System.Linq.Expressions;
using Gestao.Models;
using Gestao.Data;
using Gestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Gestao.Controllers
{
    [Authorize]
    public class VisitanteController : Controller
    {
        private readonly IESContext _context;

        //METODO CONSTRUTOR PARA INJETAR O DB NO _CONTEXT E TER ACCESSO AOS DADOS
        public VisitanteController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            //VAI PERCORRER A TABELA Visitante INTEIRA E VAI MANDAR ORDENADO PRA VIEW (FAMOSO SELECT * FROM)
            var Visitantes = await _context.Visitante
                .Include(i => i.Morador)
                .OrderBy(d => d.Nome)
                .ToListAsync();
            return View(Visitantes);
        }

        //GET: Visitante/CREATE
        [HttpGet]
        public IActionResult Create()
        {
            var instituicoes = _context.Morador.OrderBy(i => i.Nome).ToList();
            instituicoes.Insert(0, new Morador()
            {
                MoradorID = 0,
                Nome = "Selecione o Morador"

            });

            ViewBag.Morador = instituicoes;

            return View();
        }

        //POST Visitante/CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Visitante Visitante, IList<IFormFile> Img)
        {

            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                Visitante.Foto = ms.ToArray();
            }



            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Visitante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Erro", "Não foi possível inserir os dados");
            }
            return View(Visitante);
        }

        //GET EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Visitante = await _context.Visitante.SingleOrDefaultAsync
                (m => m.VisitanteID == id);

            if (Visitante == null)
            {
                return NotFound();
            }

            ViewBag.Instituicoes = new SelectList(_context.Morador.OrderBy(b => b.Nome),
                "MoradorID", "Nome", Visitante.fk_MoradorID);

            return View(Visitante);
        }

        private bool VisitanteExists(long? id)
        {
            return _context.Visitante.Any(e => e.VisitanteID == id);
        }


        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, Visitante Visitante, IList<IFormFile> Img)
        {

            if (id == null)
            {
                return NotFound();
            }

            //var dadosAntigos = _context.Visitante.AsNoTracking().FirstOrDefault(p => p.Id==id);
            var dadosAntigos = _context.Visitante.AsNoTracking().FirstOrDefault(p => p.VisitanteID == id);



            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                Visitante.Foto = ms.ToArray();
            }
            else
            {
                Visitante.Foto = dadosAntigos.Foto;

            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Visitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!VisitanteExists(Visitante.VisitanteID))
                    {
                        return NotFound();
                    }
                }

                ViewBag.Instituicoes = new SelectList(_context.Morador.OrderBy(b => b.Nome),
                "MoradorID", "Nome", Visitante.fk_MoradorID);

                return RedirectToAction(nameof(Index));
            }
            return View(Visitante);
        }

        //DETALHES
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Visitante = await _context.Visitante.SingleOrDefaultAsync
                (m => m.VisitanteID == id);

            _context.Morador.Where(i => Visitante.fk_MoradorID == i.MoradorID).Load();

            if (Visitante == null)
            {
                return NotFound();
            }
            return View(Visitante);
        }

        //GET DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Visitante = await _context.Visitante
                .SingleOrDefaultAsync(d => d.VisitanteID == id);

            _context.Morador.Where(i => Visitante.fk_MoradorID == i.MoradorID).Load();

            if (Visitante == null)
            {
                return NotFound();
            }
            return View(Visitante);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var Visitante = await _context.Visitante.SingleOrDefaultAsync
                (m => m.VisitanteID == id);
            _context.Visitante.Remove(Visitante);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Visitante {Visitante.Nome.ToUpper()} foi removido";

            return RedirectToAction(nameof(Index));
        }




    }



}
