using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Enums;

namespace TriVibe.Application.CQRS.Orders.Command.Request;

public class UpdateOrderStatusCommandRequest : IRequest<ResponseModel<UpdateOrderStatusCommandResponse>>
{
    public Guid OrderId { get; set; }
    public OrderStatus Status { get; set; }
}
