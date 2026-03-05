using MediatR;
using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Application.CQRS.Notifications.Query.Request;

public class GetAllNotificationsQueryRequest : IRequest<List<Notification>>
{
}
