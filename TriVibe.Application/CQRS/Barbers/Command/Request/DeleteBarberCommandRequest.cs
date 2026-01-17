using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Barbers.Command.Request;

public class DeleteBarberCommandRequest:IRequest<ResponseModel<DeleteBarberCommandResponse>>
{
    public Guid Id { get; set; }
}
