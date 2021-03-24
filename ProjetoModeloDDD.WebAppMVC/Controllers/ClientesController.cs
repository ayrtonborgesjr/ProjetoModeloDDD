using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.WebAppMVC.ViewModels;

namespace ProjetoModeloDDD.WebAppMVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteAppService clienteAppService, IEFCoreRepository<Cliente> repo, IMapper mapper)
        {
            _clienteAppService = clienteAppService;
            _mapper = mapper;
        }

        // GET: ClientesController
        public async Task<IActionResult> Index()
        {
            var objList = await _clienteAppService.GetAllClientes();
            var objVM = new List<ClienteViewModel>();
            foreach (var obj in objList)
            {
                objVM.Add(_mapper.Map<ClienteViewModel>(obj));
            }

            return View(objVM);
        }

        public async Task<IActionResult> Especiais()
        {
            var objList = await _clienteAppService.ObterClientesEspeciais();
            var objVM = new List<ClienteViewModel>();
            foreach (var obj in objList)
            {
                objVM.Add(_mapper.Map<ClienteViewModel>(obj));
            }

            return View(objVM);
        }

        // GET: ClientesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var obj = await _clienteAppService.GetClienteById(id);
            var objVM = _mapper.Map<ClienteViewModel>(obj);

            return View(objVM);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteVM)
        {
            if (ModelState.IsValid)
            {
                var clienteObj = _mapper.Map<Cliente>(clienteVM);
                if (await _clienteAppService.Add(clienteObj))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", $"Something went wrong when saving the record {clienteVM.Nome}");
                }
            }

            return View(clienteVM);
        }

        // GET: ClientesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var obj = await _clienteAppService.GetClienteById(id);
            var objVM = _mapper.Map<ClienteViewModel>(obj);

            return View(objVM);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteViewModel clienteVM)
        {
            if (ModelState.IsValid)
            {
                var clienteObj = _mapper.Map<Cliente>(clienteVM);
                if (await _clienteAppService.Update(clienteObj))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", $"Something went wrong when updating the record {clienteVM.Nome}");
                }
            }

            return View(clienteVM);
        }

        // GET: ClientesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _clienteAppService.GetClienteById(id);
            var objVM = _mapper.Map<ClienteViewModel>(obj);

            return View(objVM);
        }

        // POST: ClientesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var cliente = await _clienteAppService.GetClienteById(id);
                if (await _clienteAppService.Delete(cliente))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", $"Something went wrong when deleting the record");
                }
            }

            return View();
        }
    }
}
