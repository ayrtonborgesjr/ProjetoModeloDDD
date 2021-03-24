using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.WebAppMVC.ViewModels;

namespace ProjetoModeloDDD.WebAppMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoAppService produtoAppService, IClienteAppService clienteAppService, IEFCoreRepository<Produto> repo, IMapper mapper)
        {
            _produtoAppService = produtoAppService;
            _clienteAppService = clienteAppService;
            _mapper = mapper;
        }

        // GET: ProdutosController
        public async Task<IActionResult> Index()
        {
            var produtosList = await _produtoAppService.GetAllProdutos();
            var produtosListViewModel = new List<ProdutoViewModel>();
            foreach (var produtoDomain in produtosList)
            {
                produtosListViewModel.Add(_mapper.Map<ProdutoViewModel>(produtoDomain));
            }

            return View(produtosListViewModel);
        }

        // GET: ProdutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var produtoDomain = await _produtoAppService.GetProdutoById(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produtoDomain);

            return View(produtoViewModel);
        }

        // GET: ProdutosController/Create
        public async Task<IActionResult> Create()
        {
            IEnumerable<Cliente> clientes = await _clienteAppService.GetAllClientes();
            ViewBag.ClienteId = new SelectList(clientes, "ClienteId", "NomeCompleto");

            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProdutoViewModel))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<Produto>(produtoViewModel);
                if (await _produtoAppService.Add(produtoDomain))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                produtoViewModel.Clientes = _clienteAppService.ClienteDropDownList();

                return View(produtoViewModel);
            }


            //return View(produtoViewModel);
            return RedirectToAction("Index");
        }

        // GET: ProdutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var produtoDomain = await _produtoAppService.GetProdutoById(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produtoDomain);

            IEnumerable<Cliente> clientes = await _clienteAppService.GetAllClientes();
            ViewBag.ClienteId = new SelectList(clientes, "ClienteId", "NomeCompleto", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProdutoViewModel))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<Produto>(produtoViewModel);
                if (await _produtoAppService.Update(produtoDomain))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            IEnumerable<Cliente> clientes = await _clienteAppService.GetAllClientes();
            ViewBag.ClienteId = new SelectList(clientes, "ClienteId", "NomeCompleto", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var produtoDomain = await _produtoAppService.GetProdutoById(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produtoDomain);

            return View(produtoViewModel);
        }

        // POST: ProdutosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoDomain = await _produtoAppService.GetProdutoById(id);
            if (await _produtoAppService.Delete(produtoDomain))
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
