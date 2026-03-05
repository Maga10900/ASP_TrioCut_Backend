using MediatR;
using TriVibe.Application.CQRS.PaymentCards.Command.Request;
using TriVibe.Application.CQRS.PaymentCards.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.PaymentCards.Handler.CommandHandler;

public class AddPaymentCardCommandHandler : IRequestHandler<AddPaymentCardCommandRequest, ResponseModel<AddPaymentCardCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddPaymentCardCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddPaymentCardCommandResponse>> Handle(AddPaymentCardCommandRequest request, CancellationToken cancellationToken)
    {
        var card = new PaymentCard
        {
            CardNumber = request.CardNumber,
            CardHolderName = request.CardHolderName,
            ExpirationDate = request.ExpirationDate,
            CVV = request.CVV,
            UserId = request.UserId
        };

        await _unitOfWork.PaymentCards.AddAsync(card);
        await _unitOfWork.SaveChangesAsync();

        var response = new AddPaymentCardCommandResponse
        {
            Success = true,
            Id = card.Id
        };

        return new ResponseModel<AddPaymentCardCommandResponse>(response);
    }
}
