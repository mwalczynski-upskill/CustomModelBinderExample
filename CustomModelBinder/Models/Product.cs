namespace CustomModelBinder.Models
{
    using Microsoft.AspNetCore.Mvc;
    using ModelBinders;

    [ModelBinder(BinderType = typeof(ProductEntityModelBinder))]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
