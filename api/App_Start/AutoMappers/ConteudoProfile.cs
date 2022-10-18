﻿using AutoMapper;
using TemplateApi.Api.Extensions;
using TemplateApi.Dominio.Comandos.ConteudoCmds;
using TemplateApi.Api.DataModels.ConteudoDataModel;

namespace TemplateApi.Api.App_Start.AutoMappers
{
    public class ConteudoProfile : Profile
    {
        public ConteudoProfile()
        {
            #region InserirConteudoCmd

            CreateMap<InserirConteudoDataModel, InserirConteudoCmd>()
                .ForMember(cmd => cmd.Titulo, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Titulo));
                })
                .ForMember(cmd => cmd.Alias, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Alias));
                })
                .ForMember(cmd => cmd.Texto, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Texto));
                })
                .ForMember(cmd => cmd.Status, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Status)
                            && dest.InputTypeEhValido(x => x.Status, src.Status));
                });

            #endregion

            #region FiltrarConteudoCmd

            CreateMap<FiltrarConteudoDataModel, FiltrarConteudoCmd>()
                .ForMember(cmd => cmd.Texto, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Texto));
                })
                .ForMember(cmd => cmd.Pagina, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Pagina)
                            && dest.InputTypeEhValido(x => x.Pagina, src.Pagina));
                })
                .ForMember(cmd => cmd.Maximo, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Maximo)
                            && dest.InputTypeEhValido(x => x.Maximo, src.Maximo));
                })
                .ForMember(cmd => cmd.CalcularPaginacao, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.CalcularPaginacao)
                            && dest.InputTypeEhValido(x => x.CalcularPaginacao, src.CalcularPaginacao));
                })
                .ForMember(cmd => cmd.Contexto, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Contexto)
                            && dest.InputTypeEhValido(x => x.Contexto, src.Contexto));
                })
                .ForMember(cmd => cmd.Conteudo, opts =>
                {
                    opts.Condition((src, dest, srcMember) 
                        => src.PropriedadeRegistrada(x => x.Conteudo)
                            && dest.InputTypeEhValido(x => x.Conteudo, src.Conteudo));
                })
                .ForMember(cmd => cmd.Status, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Status)
                            && dest.InputTypeEhValido(x => x.Status, src.Status));
                });

            #endregion

            #region EditarConteudoCmd

            CreateMap<EditarConteudoDataModel, EditarConteudoCmd>()
                .ForMember(cmd => cmd.Conteudo, opts =>
                {
                    opts.Condition((src, dest, srcMember) 
                        => src.PropriedadeRegistrada(x => x.Conteudo)
                            && dest.InputTypeEhValido(x => x.Conteudo, src.Conteudo));
                })
                .ForMember(cmd => cmd.Titulo, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Titulo));
                })
                .ForMember(cmd => cmd.Alias, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Alias));
                })
                .ForMember(cmd => cmd.Texto, opts =>
                {
                    opts.Condition((src, dest, srcMember) 
                        => src.PropriedadeRegistrada(x => x.Texto));
                })
                .ForMember(cmd => cmd.Status, opts =>
                {
                    opts.Condition((src, dest, srcMember) 
                        => src.PropriedadeRegistrada(x => x.Status)
                            && dest.InputTypeEhValido(x => x.Status, src.Status));
                });

            #endregion

            #region ExcluirConteudoCmd

            CreateMap<ExcluirConteudoDataModel, ExcluirConteudoCmd>()
                .ForMember(cmd => cmd.Conteudo, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Conteudo)
                            && dest.InputTypeEhValido(x => x.Conteudo, src.Conteudo));
                });

            #endregion
        }
    }
}
