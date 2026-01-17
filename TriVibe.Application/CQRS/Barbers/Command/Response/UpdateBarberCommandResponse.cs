using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
namespace TriVibe.Application.CQRS.Barbers.Command.Response;

public class UpdateBarberCommandResponse:IRequest<ResponseModel<UpdateBarberCommandResponse>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}
