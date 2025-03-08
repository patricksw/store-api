using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public int Rate { get; set; } = 0;
        public int Count { get; set; } = 0;
    }
}