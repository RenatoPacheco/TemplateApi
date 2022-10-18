﻿using AutoMapper;
using TemplateApi.Api.Extensions;
using TemplateApi.Dominio.Comandos.TesteCmds;
using TemplateApi.Api.DataModels.TesteDataModel;

namespace TemplateApi.Api.App_Start.AutoMappers
{
    public class TesteProfile : Profile
    {
        public TesteProfile()
        {
            #region FormatosTesteCmd

            CreateMap<FormatosTesteDataModel, FormatosTesteCmd>()
                .ForMember(cmd => cmd.String, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.String));
                })
                .ForMember(cmd => cmd.Int, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Int)
                            && dest.InputTypeEhValido(x => x.Int, src.Int));
                })
                .ForMember(cmd => cmd.Long, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Long)
                            && dest.InputTypeEhValido(x => x.Long, src.Long));
                })
                .ForMember(cmd => cmd.Decimal, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Decimal)
                            && dest.InputTypeEhValido(x => x.Decimal, src.Decimal));
                })
                .ForMember(cmd => cmd.Double, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Double)
                            && dest.InputTypeEhValido(x => x.Double, src.Double));
                })
                .ForMember(cmd => cmd.Enum, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Enum)
                            && dest.InputTypeEhValido(x => x.Enum, src.Enum));
                })
                .ForMember(cmd => cmd.DateTime, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.DateTime)
                            && dest.InputTypeEhValido(x => x.DateTime, src.DateTime));
                })
                .ForMember(cmd => cmd.TimeSpan, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.TimeSpan)
                            && dest.InputTypeEhValido(x => x.TimeSpan, src.TimeSpan));
                })
                .ForMember(cmd => cmd.Guid, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Guid)
                            && dest.InputTypeEhValido(x => x.Guid, src.Guid));
                })
                .ForMember(cmd => cmd.Bool, opts =>
                {
                    opts.Condition((src, dest, srcMember)
                        => src.PropriedadeRegistrada(x => x.Bool)
                            && dest.InputTypeEhValido(x => x.Bool, src.Bool));
                });
            #endregion
        }
    }
}
