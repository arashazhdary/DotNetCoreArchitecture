namespace Architecture.Application;

public sealed record GetUserHandler : IHandler<GetUserRequest, UserModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserModel>> HandleAsync(GetUserRequest request)
    {
        var user = await _userRepository.GetModelAsync(request.Id);

        return Result<UserModel>.Success(user);
    }
}
