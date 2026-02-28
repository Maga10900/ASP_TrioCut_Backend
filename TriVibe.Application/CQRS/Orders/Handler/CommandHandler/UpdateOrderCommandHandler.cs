using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.CommandHandler;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, ResponseModel<UpdateOrderCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateOrderCommandResponse>> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = request.Id,
            WorkerId = request.WorkerId,
            Salary = request.Salary,
            Address = request.Address,
            Photos = request.Photos,
            Details = request.Details,
            UpdatedDate = DateTime.Now
        };

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();

        var response = new UpdateOrderCommandResponse { Success = true };
        return new ResponseModel<UpdateOrderCommandResponse>(response);
    }
}
