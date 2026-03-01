using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Command.Request;

public class AddOrderCommandRequest : IRequest<ResponseModel<AddOrderCommandResponse>>
{
    public Guid WorkerId { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; }
    public List<string>? Photos { get; set; }
    public string? Details { get; set; }
    public Guid ClientId { get; set; }
}
