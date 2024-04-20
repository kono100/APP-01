using Gestao.Data;
using Gestao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Controllers
{
    [Authorize]
    public class MoradorController : Controller
    {
        private readonly IESContext _context;

        // Método construtor para injetar o DB no _context e ter acesso aos dados
        public MoradorController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Vai percorrer a tabela inteira e mandar ordenado pra view (equivalente a SELECT * FROM)
            return View(await _context.Morador.OrderBy(c => c.Nome).ToListAsync());
        }

        // GET: Morador/Create
        [HttpGet]
        public IActionResult Create()
        {
            var moradores = _context.Morador.OrderBy(i => i.Nome).ToList();
            moradores.Insert(0, new Morador()
            {
                MoradorID = 0,
                Nome = "Selecione o Morador"
            });

            ViewBag.Morador = moradores;
            return View();
        }

        // POST Morador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Morador Morador, IList<IFormFile> Img)
        {

            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                Morador.Foto1 = ms.ToArray();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Morador);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Erro", "Não foi possível inserir os dados");
            }
            return View(Morador);

        }

        // GET: Morador/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Morador = await _context.Morador.SingleOrDefaultAsync(m => m.MoradorID == id);

            if (Morador == null)
            {
                return NotFound();
            }
            return View(Morador);
        }

        private bool MoradorExists(long? id)
        {
            return _context.Morador.Any(e => e.MoradorID == id);
        }


        // POST Morador/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, Morador Morador, IList<IFormFile> Img)
        {

            if (id == null)
            {
                return NotFound();
            }

            var dadosAntigos = _context.Morador.AsNoTracking().FirstOrDefault(p => p.MoradorID == id);

            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                Morador.Foto1 = ms.ToArray();
            }
            else
            {
                Morador.Foto1 = dadosAntigos.Foto1;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Morador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!MoradorExists(Morador.MoradorID))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Morador);
        }

        // DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Morador = await _context.Morador.SingleOrDefaultAsync(m => m.MoradorID == id);

            if (Morador == null)
            {
                return NotFound();
            }
            return View(Morador);
        }

        // GET Morador/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Morador = await _context.Morador.SingleOrDefaultAsync(d => d.MoradorID == id);

            if (Morador == null)
            {
                return NotFound();
            }
            return View(Morador);
        }

        // POST Morador/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var relacionados = _context.Veiculo.Where(r => r.fk_MoradorID == id);

            if (relacionados.Any())
            {
                TempData["Erro"] = $"Não é possível excluir o Morador, pois existem os Veiculos associados a ele.";
                return RedirectToAction(nameof(Index));
            }

            var Morador = await _context.Morador.SingleOrDefaultAsync(m => m.MoradorID == id);
            _context.Morador.Remove(Morador);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Morador {Morador.Nome.ToUpper()} foi removido";

            return RedirectToAction(nameof(Index));
        }
    }
}
