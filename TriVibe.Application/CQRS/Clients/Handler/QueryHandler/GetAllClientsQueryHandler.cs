using MediatR;
using TriVibe.Application.CQRS.Clients.Query.Request;
using TriVibe.Application.CQRS.Clients.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Clients.Handler.QueryHandler;

public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQueryRequest, ResponseModel<List<GetAllClientsQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllClientsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<List<GetAllClientsQueryResponse>>> Handle(GetAllClientsQueryRequest request, CancellationToken cancellationToken)
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        
        var response = clients.Select(c => new GetAllClientsQueryResponse
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            ProfilePhoto = c.ProfilePhoto,
            Rating = c.Rating
        }).ToList();

        return new ResponseModel<List<GetAllClientsQueryResponse>>(response);
    }
}
