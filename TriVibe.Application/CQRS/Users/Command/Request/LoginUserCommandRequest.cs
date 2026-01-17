using MediatR;
using TriVibe.Application.CQRS.Users.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
namespace TriVibe.Application.CQRS.Users.Command.Request;

public class LoginUserCommandRequest:IRequest<ResponseModel<LoginUserCommandResponse>>
{
	public string Email { get; set; }
	public string Password { get; set; }
}
