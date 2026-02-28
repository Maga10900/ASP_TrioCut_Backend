using MediatR;
using TriVibe.Application.CQRS.Workers.Query.Request;
using TriVibe.Application.CQRS.Workers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Workers.Handler.QueryHandler;

public class GetAllWorkerQueryHandler : IRequestHandler<GetAllWorkerQueryRequest, ResponseModel<List<GetAllWorkerQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWorkerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<List<GetAllWorkerQueryResponse>>> Handle(GetAllWorkerQueryRequest request, CancellationToken cancellationToken)
    {
        var workers = await _unitOfWork.Workers.GetAllAsync();
        
        var response = workers.Select(w => new GetAllWorkerQueryResponse
        {
            Id = w.Id,
            FirstName = w.FirstName,
            LastName = w.LastName,
            Email = w.Email,
            PhoneNumber = w.PhoneNumber,
            Age = w.Age,
            ProfilePhoto = w.ProfilePhoto,
            Description = w.Description,
            Rating = w.Rating,
            Job = w.Job
        }).ToList();
        
        return new ResponseModel<List<GetAllWorkerQueryResponse>>(response);
    }
}
