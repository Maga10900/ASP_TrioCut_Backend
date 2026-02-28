using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Command.Request;

public class DeleteOrderCommandRequest : IRequest<ResponseModel<DeleteOrderCommandResponse>>
{
    public Guid Id { get; set; }
}
