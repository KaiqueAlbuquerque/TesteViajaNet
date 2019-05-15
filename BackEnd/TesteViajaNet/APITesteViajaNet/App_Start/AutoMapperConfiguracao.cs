using APITesteViajaNet.ViewModel;
using AutoMapper;
using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITesteViajaNet.App_Start
{
    public class AutoMapperConfiguracao
    {
        public static void MapsConfig()
        {
            Mapper.Initialize(cfg =>
            {
                //Domínio para API
                cfg.CreateMap<Cliente, ClienteViewModel>()
                    .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.ToString()));

                cfg.CreateMap<DadosPagamento, DadosPagamentoViewModel>()
                    .ForMember(dest => dest.Validade, opt => opt.MapFrom(src => src.Validade.ToString()));

                //API para Domínio
                cfg.CreateMap<ClienteViewModel, Cliente>()
                    .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => DateTime.Parse(src.DataNascimento)));

                cfg.CreateMap<DadosPagamentoViewModel, DadosPagamento>()
                    .ForMember(dest => dest.Validade, opt => opt.MapFrom(src => DateTime.Parse(src.Validade)));
            });
        }
    }
}