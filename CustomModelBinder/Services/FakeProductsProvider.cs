namespace CustomModelBinder.Services
{
    using Models;

    public class FakeProductsProvider : IProductsProvider
    {
        public Product GetProduct(int id)
        {
            var fakeProduct = new Product()
            {
                Id = id,
                Name = "Fake",
                Category = "Fake",
                Description = "Fake product",
            };

            return fakeProduct;
        }
    }
}