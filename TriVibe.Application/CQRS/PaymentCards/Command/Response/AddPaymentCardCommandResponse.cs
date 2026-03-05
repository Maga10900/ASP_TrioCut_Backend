namespace TriVibe.Application.CQRS.PaymentCards.Command.Response;

public class AddPaymentCardCommandResponse
{
    public bool Success { get; set; }
    public Guid Id { get; set; }
}
