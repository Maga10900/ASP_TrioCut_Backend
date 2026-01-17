using MediatR;
using TriVibe.Application.CQRS.Customers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Customers.Command.Request;

public class AddCustomerCommandRequest:IRequest<ResponseModel<AddCustomerCommandResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }

}
