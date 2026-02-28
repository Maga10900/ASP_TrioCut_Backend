using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.CommandHandler;

public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, ResponseModel<UpdateOrderStatusCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateOrderStatusCommandResponse>> Handle(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
    {
        var orderList = await _unitOfWork.Orders.GetAllAsync();
        var order = orderList.FirstOrDefault(o => o.Id == request.OrderId);
        
        if (order == null)
        {
            return new ResponseModel<UpdateOrderStatusCommandResponse>(new UpdateOrderStatusCommandResponse
            {
                Success = false,
                Message = "Order not found."
            });
        }

        order.Status = request.Status;
        _unitOfWork.Orders.Update(order);
        
        // Optionally create a notification here, though typical flow is Worker updating status and Client getting notified.
        // For now, updating the status is enough.
        
        await _unitOfWork.SaveChangesAsync();

        var response = new UpdateOrderStatusCommandResponse
        {
            Success = true,
            OrderId = order.Id,
            Message = $"Order status updated to {request.Status}"
        };

        return new ResponseModel<UpdateOrderStatusCommandResponse>(response);
    }
}
