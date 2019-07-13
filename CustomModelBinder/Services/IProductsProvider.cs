namespace CustomModelBinder.Services
{
    using Models;

    public interface IProductsProvider
    {
        Product GetProduct(int id);
    }
}