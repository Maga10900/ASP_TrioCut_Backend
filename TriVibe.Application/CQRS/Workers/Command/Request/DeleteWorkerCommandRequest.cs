using MediatR;
using TriVibe.Application.CQRS.Workers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Workers.Command.Request;

public class DeleteWorkerCommandRequest : IRequest<ResponseModel<DeleteWorkerCommandResponse>>
{
    public Guid Id { get; set; }
}
