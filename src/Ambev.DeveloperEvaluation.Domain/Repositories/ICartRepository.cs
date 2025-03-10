using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);

        Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);

        Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default);
    }
}