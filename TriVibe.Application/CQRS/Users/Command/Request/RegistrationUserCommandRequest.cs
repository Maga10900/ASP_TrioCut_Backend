using MediatR;
using TriVibe.Application.CQRS.Users.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
namespace TriVibe.Application.CQRS.Users.Command.Request;

public class RegistrationUserCommandRequest:IRequest<ResponseModel<RegistrationUserCommandResponse>>
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string PhoneNumber{ get; set; }
	public int Age { get; set; }
	public UserType UserType { get; set; }
	public string? Job { get; set; }
}
