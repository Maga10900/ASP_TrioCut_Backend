using MediatR;
using TriVibe.Application.CQRS.Clients.Query.Request;
using TriVibe.Application.CQRS.Clients.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Clients.Handler.QueryHandler;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQueryRequest, ResponseModel<GetClientByIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetClientByIdQueryResponse>> Handle(GetClientByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id);

        var response = new GetClientByIdQueryResponse
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            Age = client.Age,
            ProfilePhoto = client.ProfilePhoto,
            Description = client.Description,
            Rating = client.Rating
        };

        return new ResponseModel<GetClientByIdQueryResponse>(response);
    }
}
