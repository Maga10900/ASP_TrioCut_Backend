using MediatR;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Customers.Command.Request;

public class UpdateCustomerCommandRequest:IRequest<ResponseModel<UpdateCustomerCommandResponse>>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public int Age { get; set; }
}
