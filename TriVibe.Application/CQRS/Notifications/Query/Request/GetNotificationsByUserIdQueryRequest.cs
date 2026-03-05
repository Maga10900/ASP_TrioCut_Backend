using MediatR;
using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Application.CQRS.Notifications.Query.Request;

public class GetNotificationsByUserIdQueryRequest : IRequest<List<Notification>>
{
    public Guid UserId { get; set; }
}
