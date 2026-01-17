using MediatR;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Customers.Command.Request;

public class DeleteCustomerCommandRequest:IRequest<ResponseModel<DeleteCustomerCommandResponse>>
{
    public Guid Id { get; set; }
}
