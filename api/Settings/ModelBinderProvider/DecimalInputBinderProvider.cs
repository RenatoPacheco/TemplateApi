﻿using System;
using TemplateApi.Compartilhado.ObjetosDeValor;
using TemplateApi.Api.Settings.ModelBinder;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace TemplateApi.Api.Settings.ModelBinderProvider
{
    public class DecimalInputBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DecimalInput) || context.Metadata.ModelType == typeof(DecimalInput?))
            {
                return new BinderTypeModelBinder(typeof(DecimalInputModelBinder));
            }

            return null;
        }
    }
}
