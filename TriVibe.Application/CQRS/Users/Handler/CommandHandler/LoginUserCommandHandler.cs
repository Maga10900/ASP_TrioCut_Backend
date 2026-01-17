using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TriVibe.Application.CQRS.Users.Command.Request;
using TriVibe.Application.CQRS.Users.Command.Response;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Helpers;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Users.Handler.CommandHandler;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, ResponseModel<LoginUserCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoginUserCommandHandler> _logger;

    public LoginUserCommandHandler(
        IUnitOfWork unitOfWork,
        IConfiguration configuration,
        ILogger<LoginUserCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<ResponseModel<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        //var loginProvider = Guid.NewGuid().ToString();  //muxtelif brauzerlerde login olma
        //var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
        //var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);
        //if (user == null || user.PasswordHash != hashedPassword)
        //	throw new Exception("Email or Password is incorrect");
        //var authClaims = new List<Claim>
        //{
        //	new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //	new Claim(ClaimTypes.Name, user.FirstName),
        //	new Claim(ClaimTypes.Email, user.Email),
        //	new Claim("LoginProvider", loginProvider),
        //	new Claim(ClaimTypes.Role, user.UserType.ToString()),
        //};
        //var token = TokenService.CreateToken(authClaims, _configuration);
        //var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        //var response = new LoginUserCommandResponse
        //{
        //	Token = tokenString,
        //	ExpiredDate = token.ValidTo,
        //};
        //return new ResponseModel<LoginUserCommandResponse>(response);



        try
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                _logger.LogWarning("Login attempt with empty email");
                throw new Exception("Email is required");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                _logger.LogWarning("Login attempt with empty password for email: {Email}", request.Email);
                throw new Exception("Password is required");
            }

            // Normalize email (trim and convert to lowercase for case-insensitive lookup)
            var normalizedEmail = request.Email.Trim().ToLowerInvariant();

            _logger.LogInformation("Login attempt for email: {Email}", normalizedEmail);

            // Get user by email (make sure GetByEmailAsync is case-insensitive or normalize in repository)
            var user = await _unitOfWork.Users.GetByEmailAsync(normalizedEmail);

            if (user == null)
            {
                _logger.LogWarning("User not found for email: {Email}", normalizedEmail);
                throw new Exception("Email or Password is incorrect");
            }

            _logger.LogInformation("User found: {UserId}, Email: {Email}", user.Id, user.Email);

            // Hash the provided password using the same algorithm
            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);

            _logger.LogDebug("Password hash comparison - Provided hash: {ProvidedHash}, Stored hash: {StoredHash}",
                hashedPassword?.Substring(0, Math.Min(10, hashedPassword?.Length ?? 0)) + "...",
                user.PasswordHash?.Substring(0, Math.Min(10, user.PasswordHash?.Length ?? 0)) + "...");

            // Compare hashed passwords (case-sensitive comparison)
            if (string.IsNullOrEmpty(user.PasswordHash) || user.PasswordHash != hashedPassword)
            {
                _logger.LogWarning("Invalid password for user: {Email}", normalizedEmail);
                throw new Exception("Email or Password is incorrect");
            }

            // Generate login provider for multi-browser support
            var loginProvider = Guid.NewGuid().ToString();

            // Create JWT claims
            var authClaims = new List<Claim>
            {new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim("LoginProvider", loginProvider),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
            };

            // Generate JWT token
            var token = TokenService.CreateToken(authClaims, _configuration);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            _logger.LogInformation("Login successful for user: {Email}, UserType: {UserType}", user.Email, user.UserType);

            // Create response
            var response = new LoginUserCommandResponse
            {
                Token = tokenString,
                Email = user.Email ?? string.Empty,
                ExpiredDate = token.ValidTo,
            };

            return new ResponseModel<LoginUserCommandResponse>(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login for email: {Email}", request.Email);
            throw; // Re-throw to maintain the original exception
        }

    }
}
