﻿using Doctrina.ExperienceApi.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Doctrina.ExperienceApi.Server.Mvc.ModelBinding.Binders
{
    public class StatementCollectionModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (!context.Metadata.IsComplexType)
            {
                return null;
            }

            // string propName = context.Metadata.ParameterName;
            // if (propName == null)
            // {
            //     return null;
            // }

            var modelType = context.Metadata.ModelType;
            if (modelType == null)
            {
                return null;
            }

            if (modelType == typeof(StatementCollection))
            {
                return new BinderTypeModelBinder(typeof(StatementCollectionModelBinder));
            }

            return null;
        }
    }
}
