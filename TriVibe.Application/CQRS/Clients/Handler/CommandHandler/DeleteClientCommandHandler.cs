using MediatR;
using TriVibe.Application.CQRS.Clients.Command.Request;
using TriVibe.Application.CQRS.Clients.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Clients.Handler.CommandHandler;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommandRequest, ResponseModel<DeleteClientCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteClientCommandResponse>> Handle(DeleteClientCommandRequest request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id);
        
        await _unitOfWork.Clients.DeleteProfileAsync(client);
        await _unitOfWork.SaveChangesAsync();

        var response = new DeleteClientCommandResponse
        {
            Success = true,
            Message = "Client deleted successfully"
        };

        return new ResponseModel<DeleteClientCommandResponse>(response);
    }
}
