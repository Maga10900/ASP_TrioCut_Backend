using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Command.Request;
using TriVibe.Application.CQRS.PaymentCards.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.PaymentCards.Handler.CommandHandler;

public class UpdatePaymentCardCommandHandler : IRequestHandler<UpdatePaymentCardCommandRequest, ResponseModel<UpdatePaymentCardCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePaymentCardCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdatePaymentCardCommandResponse>> Handle(UpdatePaymentCardCommandRequest request, CancellationToken cancellationToken)
    {
        var card = await _unitOfWork.PaymentCards.GetByIdAsync(request.Id);

        card.CardNumber = request.CardNumber;
        card.CardHolderName = request.CardHolderName;
        card.ExpirationDate = request.ExpirationDate;
        card.CVV = request.CVV;

        await _unitOfWork.PaymentCards.UpdateAsync(card);
        await _unitOfWork.SaveChangesAsync();

        var response = new UpdatePaymentCardCommandResponse { Success = true };
        return new ResponseModel<UpdatePaymentCardCommandResponse>(response);
    }
}
