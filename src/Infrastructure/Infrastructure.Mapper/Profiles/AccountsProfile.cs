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
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<VMCuentas, Cuentas>()

               .ForMember(
                    dest => dest.cu_tipo_cuenta,
                    opt => opt.MapFrom(src => $"{src.tipo_cuenta}")
                )
             .ForMember(
                    dest => dest.cu_numero_cuenta,
                    opt => opt.MapFrom(src => $"{src.numero_cuenta}")
                )
             .ForMember(
                    dest => dest.cu_saldo_inicial,
                    opt => opt.MapFrom(src => $"{src.saldo_inicial}")
                )
             .ForMember(
                    dest => dest.cu_estado,
                    opt => opt.MapFrom(src => $"{src.estado}")
                )
               .ForMember(dest => dest.cliente,
             opts => opts.MapFrom(
                 src => new Clientes
                 {
                     Id = src.cliente.Id,
                     cl_contraseña = src.cliente.contraseña,
                     pr_direccion = src.cliente.direccion,
                     pr_edad = src.cliente.edad,
                     cl_estado = src.cliente.estado,
                     pr_genero = src.cliente.genero,
                     pr_identificacion = src.cliente.identificacion,
                     pr_nombre = src.cliente.nombre,
                     pr_telefono = src.cliente.telefono


                 }
             ));

            CreateMap<Cuentas, VMCuentas>()

               .ForMember(
                    dest => dest.tipo_cuenta,
                    opt => opt.MapFrom(src => $"{src.cu_tipo_cuenta}")
                )
             .ForMember(
                    dest => dest.numero_cuenta,
                    opt => opt.MapFrom(src => $"{src.cu_numero_cuenta}")
                )
             .ForMember(
                    dest => dest.saldo_inicial,
                    opt => opt.MapFrom(src => $"{src.cu_saldo_inicial}")
                )
             .ForMember(
                    dest => dest.estado,
                    opt => opt.MapFrom(src => $"{src.cu_estado}")
                )
             .ForMember(dest => dest.cliente,
             opts => opts.MapFrom(
                 src => new VMClientes
                 {
                     Id = src.cliente.Id,
                     contraseña = src.cliente.cl_contraseña,
                     direccion = src.cliente.pr_direccion,
                     edad = src.cliente.pr_edad,
                     estado = src.cliente.cl_estado,
                     genero = src.cliente.pr_genero,
                     identificacion = src.cliente.pr_identificacion,
                     nombre = src.cliente.pr_nombre,
                     telefono = src.cliente.pr_telefono


                 }
             ));


        }
    }
}
