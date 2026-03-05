using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Command.Request;
using TriVibe.Application.CQRS.PaymentCards.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.PaymentCards.Handler.CommandHandler;

public class DeletePaymentCardCommandHandler : IRequestHandler<DeletePaymentCardCommandRequest, ResponseModel<DeletePaymentCardCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaymentCardCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeletePaymentCardCommandResponse>> Handle(DeletePaymentCardCommandRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.PaymentCards.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();

        var response = new DeletePaymentCardCommandResponse { Success = true };
        return new ResponseModel<DeletePaymentCardCommandResponse>(response);
    }
}
