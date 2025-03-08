using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategoryProduct;

public class GetAllCategoryProductCommand : IRequest<IEnumerable<string>> { }