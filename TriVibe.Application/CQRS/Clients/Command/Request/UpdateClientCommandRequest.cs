using MediatR;
using TriVibe.Application.CQRS.Clients.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Clients.Command.Request;

public class UpdateClientCommandRequest : IRequest<ResponseModel<UpdateClientCommandResponse>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string? ProfilePhoto { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }
}
