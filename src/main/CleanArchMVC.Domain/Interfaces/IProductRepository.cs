using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces
{
    internal interface IProductRepository
    {
        //Task seria uma ação assincrona (não são em tempo de execução.
        //Nas interfaces são assinaturas de metodos.

        //Pega uma lista de Produtos
        Task<IEnumerable<Product>> GetProductAsync();

        //Pega um Produto
        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);


        //passamos o objeto category do tipo Category
        Task<Product> CreateAsync(Product category);
        Task<Product> UpdateAsync(Product category);
        Task<Product> RemoveAsync(Product category);
    }
}
