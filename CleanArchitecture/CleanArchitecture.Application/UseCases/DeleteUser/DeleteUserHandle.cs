using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    internal class DeleteUserHandle : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandle(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse?> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);

            if (user == null) return null;

            _userRepository.Delete(user);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteUserResponse>(user);
        }
    }
}
