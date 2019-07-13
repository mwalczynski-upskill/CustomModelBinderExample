namespace CustomModelBinder.ModelBinderProviders
{
    using System;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using ModelBinders;
    using Models;

    public class ProductEntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            if (context.Metadata.ModelType == typeof(Product))
            {
                return new BinderTypeModelBinder(typeof(ProductEntityModelBinder));
            }

            return null;
        }
    }
}
