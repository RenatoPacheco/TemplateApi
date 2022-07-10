﻿using AutoMapper;
using System.Linq;
using DotNetCore.API.Template.Site.ValuesObject;
using DotNetCore.API.Template.Dominio.Comandos.StorageCmds;
using DotNetCore.API.Template.Site.DataModel.StorageDataModel;

namespace DotNetCore.API.Template.Site.AutoMapper
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<InserirStorageDataModel, InserirStorageCmd>()
                .ForMember(m => m.Arquivo, opt => opt.MapFrom(src => src.Arquivo.Select(x => new ArquivoUpload(x)).ToArray()))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
