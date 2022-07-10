﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DotNetCore.API.Template.Site.DataModel.StorageDataModel
{
    public class InserirStorageDataModel
    {
        private IList<IFormFile> _arquivo;
        /// <summary>
        /// O peso do arquivo não pode ser maior que 100 kb, 
        /// e os tipos permitidos são imagens, textos ou planilhas.
        /// </summary>
        public IList<IFormFile> Arquivo
        {
            get => _arquivo ??= new List<IFormFile>();
            set => _arquivo = value ?? new List<IFormFile>();
        }
    }
}
