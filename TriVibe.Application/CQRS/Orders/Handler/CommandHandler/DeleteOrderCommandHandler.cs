using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.CommandHandler;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, ResponseModel<DeleteOrderCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteOrderCommandResponse>> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
        await _unitOfWork.Orders.DeleteAsync(order);
        await _unitOfWork.SaveChangesAsync();

        var response = new DeleteOrderCommandResponse { Success = true };
        return new ResponseModel<DeleteOrderCommandResponse>(response);
    }
}
