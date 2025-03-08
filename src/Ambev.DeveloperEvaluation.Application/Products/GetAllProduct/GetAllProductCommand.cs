using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;

public class GetAllProductCommand : IRequest<IEnumerable<GetProductResult>> { }