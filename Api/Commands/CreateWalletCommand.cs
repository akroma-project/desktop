using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Api.Commands
{
    public class CreateWalletResponse
    {
        public string WalletName { get; set; }
        public string WalletPassword { get; set; }
        public string WalletPath { get; set; }
    }

    public class CreateWalletCommand : IRequest<CreateWalletResponse> 
    {
        public string Name { get; set; } = "name 1";
        public string Password { get; set; } = "password 1";
        public string Path { get; set; } = "path 1";
    }

    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, CreateWalletResponse>
    {
        public async Task<CreateWalletResponse> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            await Task.FromResult(0);
            return new CreateWalletResponse
            {
                WalletName = "Created Wallet",
                WalletPassword = request.Password,
                WalletPath = request.Path
            };
        }
    }
}