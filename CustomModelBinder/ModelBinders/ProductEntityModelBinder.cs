namespace CustomModelBinder.ModelBinders
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Services;

    public class ProductEntityModelBinder : IModelBinder
    {
        private readonly IProductsProvider _productsProvider;

        public ProductEntityModelBinder(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var id = 0;
            if (!int.TryParse(value, out id))
            {
                // Non-integer arguments result in model state errors
                bindingContext.ModelState.TryAddModelError(modelName, "Product Id must be an integer.");
                return Task.CompletedTask;
            }

            var model = _productsProvider.GetProduct(id);
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
