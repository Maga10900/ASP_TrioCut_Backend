using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.CommandHandler;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, ResponseModel<AddOrderCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddOrderCommandResponse>> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Clients.GetByIdAsync(request.ClientId);
        await _unitOfWork.Workers.GetByIdAsync(request.WorkerId);

        var order = new Order
        {
            WorkerId = request.WorkerId,
            ClientId = request.ClientId,
            Salary = request.Salary,
            Address = request.Address,
            Photos = request.Photos,
            Details = request.Details
        };

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.SaveChangesAsync(); // Save to get the Order ID if it's strictly necessary for notification
        
        var notification = new Notification
        {
            WorkerId = request.WorkerId,
            OrderId = order.Id,
            Message = "You have received a new order query.",
            IsRead = false
        };

        await _unitOfWork.Notifications.AddAsync(notification);
        await _unitOfWork.SaveChangesAsync();

        var response = new AddOrderCommandResponse
        {
            Success = true,
            Id = order.Id,
            WorkerId = order.WorkerId
        };

        return new ResponseModel<AddOrderCommandResponse>(response);
    }
}
