using MediatR;

using TriVibe.Application.CQRS.Users.Command.Request;
using TriVibe.Application.CQRS.Users.Command.Response;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Users.Handler.CommandHandler;

public class RegistrationUserCommandHandler : IRequestHandler<RegistrationUserCommandRequest, ResponseModel<RegistrationUserCommandResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public RegistrationUserCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ResponseModel<RegistrationUserCommandResponse>> Handle(RegistrationUserCommandRequest request, CancellationToken cancellationToken)
	{
		var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
		if (user != null)
			throw new Exception("This email is already registered");
		var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);
		var newUser = new User
		{
			FirstName = request.FirstName,
			LastName = request.LastName,
			Email = request.Email,
			PasswordHash = hashedPassword,
			PhoneNumber = request.PhoneNumber,
			UserType = request.UserType,
			Age = request.Age
		};
		await _unitOfWork.Users.RegisterAsync(newUser);
		await _unitOfWork.SaveChangesAsync();
		var response = new RegistrationUserCommandResponse
		{
			Id = newUser.Id,
			Firstname = newUser.FirstName,
			Lastname = newUser.LastName,
			Email = newUser.Email,
		};
		return new ResponseModel<RegistrationUserCommandResponse>(response);

	}
}
