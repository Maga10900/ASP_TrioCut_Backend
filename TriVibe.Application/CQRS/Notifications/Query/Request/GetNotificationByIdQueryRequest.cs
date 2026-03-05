using MediatR;
using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Application.CQRS.Notifications.Query.Request;

public class GetNotificationByIdQueryRequest : IRequest<Notification>
{
    public Guid Id { get; set; }
}
