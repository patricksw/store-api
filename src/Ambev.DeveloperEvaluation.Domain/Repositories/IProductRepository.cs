using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    Task<IEnumerable<string>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> GetProductByCategoryAsync(string category, CancellationToken cancellationToken = default);

    Task<bool> IsContainsProductIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}