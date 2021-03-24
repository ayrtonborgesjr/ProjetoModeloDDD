using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.WebAppMVC.ViewModels;

namespace ProjetoModeloDDD.WebAppMVC.AutoMapper
{
    public class ProjetoModeloDDDMappings : Profile
    {
        public ProjetoModeloDDDMappings()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
