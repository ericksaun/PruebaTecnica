using AutoMapper;
using Domain.PruebaTecnica.Models;
using Infrastructure.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<VMClientes, Clientes>()

               .ForMember(
                    dest => dest.pr_telefono,
                    opt => opt.MapFrom(src => $"{src.telefono}")
                )
             .ForMember(
                    dest => dest.cl_estado,
                    opt => opt.MapFrom(src => $"{src.estado}")
                )
             .ForMember(
                    dest => dest.pr_edad,
                    opt => opt.MapFrom(src => $"{src.edad}")
                )
             .ForMember(
                    dest => dest.pr_identificacion,
                    opt => opt.MapFrom(src => $"{src.identificacion}")
                )
              .ForMember(
                    dest => dest.pr_genero,
                    opt => opt.MapFrom(src => $"{src.genero}")
                )
              .ForMember(
                    dest => dest.pr_nombre,
                    opt => opt.MapFrom(src => $"{src.nombre}")
                )
              .ForMember(
                    dest => dest.cl_contraseña,
                    opt => opt.MapFrom(src => $"{src.contraseña}")
                )
               .ForMember(
                    dest => dest.pr_direccion,
                    opt => opt.MapFrom(src => $"{src.direccion}")
                );

        }
    }
}
