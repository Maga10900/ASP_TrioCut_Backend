using MediatR;
using TriVibe.Application.CQRS.Workers.Query.Request;
using TriVibe.Application.CQRS.Workers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Workers.Handler.QueryHandler;

public class GetWorkerByIdQueryHandler : IRequestHandler<GetWorkerByIdQueryRequest, ResponseModel<GetWorkerByIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkerByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetWorkerByIdQueryResponse>> Handle(GetWorkerByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var worker = await _unitOfWork.Workers.GetByIdAsync(request.Id);
        
        var response = new GetWorkerByIdQueryResponse
        {
            Id = worker.Id,
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            Email = worker.Email,
            PhoneNumber = worker.PhoneNumber,
            Age = worker.Age,
            ProfilePhoto = worker.ProfilePhoto,
            Description = worker.Description,
            Rating = worker.Rating,
            Job = worker.Job
        };
        
        return new ResponseModel<GetWorkerByIdQueryResponse>(response);
    }
}
