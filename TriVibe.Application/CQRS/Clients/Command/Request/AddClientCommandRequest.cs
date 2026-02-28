using MediatR;
using TriVibe.Application.CQRS.Clients.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Clients.Command.Request;

public class AddClientCommandRequest : IRequest<ResponseModel<AddClientCommandResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string? ProfilePhoto { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }
}
