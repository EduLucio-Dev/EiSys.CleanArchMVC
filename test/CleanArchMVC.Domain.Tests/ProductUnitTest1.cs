using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with validation parameters")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Sabonete", "Para Mãos", 5.5m, 10, "");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with validation Id")]
        public void CreateProduct_WithValidId_ResultObjectValidState()
        {
            Action action = () => new Product(1,"Sabonete", "Para Mãos", 5.5m, 10, "");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with validation Id negative")]
        public void CreateProduct_WithInvalidId_ResultObjectInvalidState()
        {
            Action action = () => new Product(-1, "Sabonete", "Para Mãos", 5.5m, 10, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product with invalid description")]
        public void CreateProduct_WithInvalidDescription_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Sabonete", "P", 5.5m, 10, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Theory]
        [InlineData(-1)]
        public void CreateProduct_WithInvalidStock_ResultObjectInvalidState(int value)
        {
            Action action = () => new Product(1, "Sabonete", "Para mãos", 5.5m, value, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
        [Fact(DisplayName = "Create Product with image null")]
        public void CreateProduct_WithNullImgeName_ResultNoDomainException()
        {
            Action action = () => new Product(1, "Sabonete", "Para mãos", 5.5m, 10, "");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with image null")]
        public void CreateProduct_WithNullImgeName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Sabonete", "Para mãos", 5.5m, 10, "");
            action.Should()
                .NotThrow<NullReferenceException>();
        }

    }
}
