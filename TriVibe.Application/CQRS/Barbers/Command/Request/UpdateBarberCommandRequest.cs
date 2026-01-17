using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
namespace TriVibe.Application.CQRS.Barbers.Command.Request;

public class UpdateBarberCommandRequest:IRequest<ResponseModel<UpdateBarberCommandResponse>>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}
