using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart;

public class GetAllCartCommand : IRequest<IEnumerable<GetCartResult>> { }