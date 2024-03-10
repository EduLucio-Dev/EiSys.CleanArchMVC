
using CleanArchMVC.Domain.Validation;
using System.Runtime.CompilerServices;

namespace CleanArchMVC.Domain.Entities
{
    // Sealed pois não vamos herdar essa classe.
    // Os parametros não podem ser alterados diretamente externamente (private set)
    public sealed class Category : EntityBase
    {
        public string? Name { get; private set; }


        //Enriquecimento da nossa classe passando os construtores
        //obrigatorio para alteração dos parametros e validações

        public Category(string name)
        {
            ValidateDomain(name);
        }


        public Category(int id, string name)
        {
            DomainExceptionValidation.when(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        //Relacionamento da categoria com o produto
        //Um para muitos
        public ICollection<Product> Product { get; set; }

        //Chamada do Exception para as validações dos parametros
        private void ValidateDomain(string? name)
        {
            DomainExceptionValidation.when(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.when(name?.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
