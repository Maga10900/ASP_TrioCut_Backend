namespace TriVibe.Application.CQRS.PaymentCards.Query.Response;

public class GetPaymentCardByIdQueryResponse
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public Guid UserId { get; set; }
}
