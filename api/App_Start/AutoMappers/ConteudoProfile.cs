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
                .ForMember(cmd => cmd.Titulo, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return src.PropriedadeRegistrada(x => x.Titulo);
                    });
                }).ForMember(cmd => cmd.Alias, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return src.PropriedadeRegistrada(x => x.Alias);
                    });
                }).ForMember(cmd => cmd.Texto, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return src.PropriedadeRegistrada(x => x.Texto);
                    });
                }).ForMember(cmd => cmd.Status, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Status, src.Status)
                            && src.PropriedadeRegistrada(x => x.Status);
                    });
                });

            #endregion

            #region FiltrarConteudoCmd

            CreateMap<FiltrarConteudoDataModel, FiltrarConteudoCmd>()
                .ForMember(cmd => cmd.Texto, opts => {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                }).ForMember(cmd => cmd.Contexto, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Contexto, src.Contexto)
                            && srcMember != null;
                    });
                }).ForMember(cmd => cmd.Conteudo, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Conteudo, src.Conteudo)
                            && srcMember != null;
                    });
                }).ForMember(cmd => cmd.Status, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Status, src.Status)
                            && srcMember != null;
                    });
                });

            #endregion

            #region EditarConteudoCmd

            CreateMap<EditarConteudoDataModel, EditarConteudoCmd>()
                .ForMember(cmd => cmd.Conteudo, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Conteudo, src.Conteudo)
                            && src.PropriedadeRegistrada(x => x.Conteudo);
                    });
                }).ForMember(cmd => cmd.Titulo, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return src.PropriedadeRegistrada(x => x.Titulo);
                    });
                }).ForMember(cmd => cmd.Alias, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return src.PropriedadeRegistrada(x => x.Alias);
                    });
                }).ForMember(cmd => cmd.Texto, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return src.PropriedadeRegistrada(x => x.Texto);
                    });
                }).ForMember(cmd => cmd.Status, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Status, src.Status)
                            && src.PropriedadeRegistrada(x => x.Status);
                    });
                });

            #endregion

            #region ExcluirConteudoCmd

            CreateMap<ExcluirConteudoDataModel, ExcluirConteudoCmd>()
                .ForMember(cmd => cmd.Conteudo, opts => {
                    opts.Condition((src, dest, srcMember) => {
                        return dest.InputTypeEhValido(x => x.Conteudo, src.Conteudo)
                            && src.PropriedadeRegistrada(x => x.Conteudo);
                    });
                });

            #endregion
        }
    }
}
