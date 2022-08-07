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
    public class MovementsProfile : Profile
    {
        public MovementsProfile()
        {
            CreateMap<VMMovimientos, Movimientos>()
                 .ForMember(
                    dest => dest.mo_fecha,
                    opt => opt.MapFrom(src => $"{src.fecha}")
                )
             .ForMember(
                    dest => dest.mo_tipo_movimiento,
                    opt => opt.MapFrom(src => $"{src.tipo_movimiento}")
                )
             .ForMember(
                    dest => dest.mo_valor,
                    opt => opt.MapFrom(src => $"{src.valor}")
                )
             .ForMember(
                    dest => dest.mo_saldo,
                    opt => opt.MapFrom(src => $"{src.saldo}")
                )
              .ForMember(dest => dest.cuenta,
             opts => opts.MapFrom(
                 src =>


                 new Cuentas
                 {
                     Id = src.cuenta.Id,
                     cu_numero_cuenta = src.cuenta.numero_cuenta,
                     cu_tipo_cuenta = src.cuenta.tipo_cuenta,
                     cu_saldo_inicial = src.cuenta.saldo_inicial,
                     cu_estado = src.cuenta.estado,

                     cliente = src.cuenta.cliente != null ?

                new Clientes
                {

                    cl_contraseña = src.cuenta.cliente.contraseña,
                    cl_estado = src.cuenta.cliente.estado,
                    Id = src.cuenta.cliente.Id,
                    pr_direccion = src.cuenta.cliente.direccion,
                    pr_edad = src.cuenta.cliente.edad,
                    pr_genero = src.cuenta.cliente.genero,
                    pr_identificacion = src.cuenta.cliente.identificacion,
                    pr_nombre = src.cuenta.cliente.nombre,
                    pr_telefono = src.cuenta.cliente.telefono


                } : null



                 }
             ));
            CreateMap<Movimientos, VMMovimientos>()
                 .ForMember(
                    dest => dest.fecha,
                    opt => opt.MapFrom(src => $"{src.mo_fecha}")
                )
             .ForMember(
                    dest => dest.tipo_movimiento,
                    opt => opt.MapFrom(src => $"{src.mo_tipo_movimiento}")
                )
             .ForMember(
                    dest => dest.valor,
                    opt => opt.MapFrom(src => $"{src.mo_valor}")
                )
             .ForMember(
                    dest => dest.saldo,
                    opt => opt.MapFrom(src => $"{src.mo_saldo}")
                )
              .ForMember(dest => dest.cuenta,
             opts => opts.MapFrom(
                 src => new VMCuentas
                 {
                     Id = src.cuenta.Id,
                     numero_cuenta = src.cuenta.cu_numero_cuenta,
                     tipo_cuenta = src.cuenta.cu_tipo_cuenta,
                     saldo_inicial = src.cuenta.cu_saldo_inicial,
                     estado = src.cuenta.cu_estado,
                     cliente = new VMClientes
                     {

                         contraseña = src.cuenta.cliente.cl_contraseña,
                         estado = src.cuenta.cliente.cl_estado,
                         Id = src.cuenta.cliente.Id,
                         direccion = src.cuenta.cliente.pr_direccion,
                         edad = src.cuenta.cliente.pr_edad,
                         genero = src.cuenta.cliente.pr_genero,
                         identificacion = src.cuenta.cliente.pr_identificacion,
                         nombre = src.cuenta.cliente.pr_nombre,
                         telefono = src.cuenta.cliente.pr_telefono


                     }



                 }
             ));

            CreateMap<Movimientos, VmReporteMovimientos>()
               .ForMember(
                  dest => dest.Fecha,
                  opt => opt.MapFrom(src => $"{src.mo_fecha}")
              )
           .ForMember(
                  dest => dest.Tipo,
                  opt => opt.MapFrom(src => $"{src.mo_tipo_movimiento}")
              )
           .ForMember(
                  dest => dest.Movimiento,
                  opt => opt.MapFrom(src => $"{src.mo_valor}")
              )
           .ForMember(
                  dest => dest.SaldoDisponible,
                  opt => opt.MapFrom(src => $"{src.mo_saldo}")
              )
            .ForMember(dest => dest.NumeroCuenta,
           opts => opts.MapFrom(
               src => $"{src.cuenta.cu_numero_cuenta}")
           )
             .ForMember(dest => dest.Cliente,
           opts => opts.MapFrom(
               src => $"{src.cuenta.cliente.pr_nombre}")
           )
             .ForMember(dest => dest.Estado,
           opts => opts.MapFrom(
               src => $"{src.cuenta.cu_estado}")
           )
           .ForMember(dest => dest.SaldoInicial,
           opts => opts.MapFrom(
               src => $"{src.cuenta.cu_saldo_inicial}")






          );


        }
    }
}
