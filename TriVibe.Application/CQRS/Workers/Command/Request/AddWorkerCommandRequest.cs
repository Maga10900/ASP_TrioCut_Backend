using MediatR;
using TriVibe.Application.CQRS.Workers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Workers.Command.Request;

public class AddWorkerCommandRequest : IRequest<ResponseModel<AddWorkerCommandResponse>>
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
    public string? Job { get; set; }
}
