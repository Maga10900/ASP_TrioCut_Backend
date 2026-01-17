using MediatR;
using TriVibe.Application.CQRS.Services.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
namespace TriVibe.Application.CQRS.Services.Command.Requset;

public class UpdateServiceCommandRequest:IRequest<ResponseModel<UpdateServiceCommandResponse>>
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
	public int DurationInMinutes { get; set; }
}
