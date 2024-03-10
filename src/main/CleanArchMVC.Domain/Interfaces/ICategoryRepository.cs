using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        //Task seria uma ação assincrona (não são em tempo de execução.
        //Nas interfaces são assinaturas de metodos.
        //O recomendado é que no final do metodo colocamos Async

        //Pega uma lista de categorias
        Task<IEnumerable<Category>> GetCategoriesAsync();

        //Pega uma categoria
        Task<Category> GetByIdAsync(int? id);


        //passamos o objeto category do tipo Category
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
    }
}
