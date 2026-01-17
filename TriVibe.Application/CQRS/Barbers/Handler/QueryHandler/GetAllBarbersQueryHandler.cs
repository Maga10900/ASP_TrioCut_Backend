using MediatR;
using TriVibe.Application.CQRS.Barbers.Query.Request;
using TriVibe.Application.CQRS.Barbers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Barbers.Handler.QueryHandler;

public class GetAllBarbersQueryHandler : IRequestHandler<GetAllBarbersQueryRequest, Pagination<GetAllBarbersQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBarbersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Pagination<GetAllBarbersQueryResponse>> Handle(GetAllBarbersQueryRequest request, CancellationToken cancellationToken)
    {
        var barbers = await _unitOfWork.Barbers.GetAllAsync();
        var totalItems = barbers.Count;
        var pagedCategories = barbers
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(b => new GetAllBarbersQueryResponse
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Description = b.Description,
                UserType = b.UserType,
                Email = b.Email,
                ImageUrl = b.ImageUrl,
                PhoneNumber = b.PhoneNumber,
                Age = b.Age
            })
            .ToList();
        var response = new Pagination<GetAllBarbersQueryResponse>(pagedCategories, totalItems, request.Page, request.Size);
        return response;
    }
}
