using MediatR;
using TriVibe.Application.CQRS.Services.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Services.Command.Requset;

public class DeleteServiceCommandRequest:IRequest<ResponseModel<DeleteServiceCommandResponse>>
{
	public Guid Id { get; set; }
}
