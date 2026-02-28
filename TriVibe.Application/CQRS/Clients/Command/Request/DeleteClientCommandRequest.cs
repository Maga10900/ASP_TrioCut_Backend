using MediatR;
using TriVibe.Application.CQRS.Clients.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Clients.Command.Request;

public class DeleteClientCommandRequest : IRequest<ResponseModel<DeleteClientCommandResponse>>
{
    public Guid Id { get; set; }
}
