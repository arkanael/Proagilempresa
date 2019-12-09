using AutoMapper;
using ProagilEmpresa.Application.Dtos;
using ProAgilEmpresa.Application.Dtos;
using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.Infra.CrossCutting.Identity.Identity;

namespace ProAgilEmpresa.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoConsultaDto>().ReverseMap();
                cfg.CreateMap<Produto, ProdutoCadastroDto>().ReverseMap();
                cfg.CreateMap<Produto, ProdutoEdicaoDto>().ReverseMap();

                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<User, UserLoginDto>().ReverseMap();

            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}


