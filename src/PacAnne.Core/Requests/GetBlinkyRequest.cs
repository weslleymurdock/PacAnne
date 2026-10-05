using PacAnne.Core.Ghosts;

namespace PacAnne.Core.Requests;

public readonly struct GetBlinkyRequest : IRequest<IGhost>
{
    public class Handler : IRequestHandler<GetBlinkyRequest, IGhost>
    {
        private readonly IGhostCollection _ghostCollection;

        public Handler(IGhostCollection ghostCollection) => _ghostCollection = ghostCollection;

        public Task<IGhost> Handle(GetBlinkyRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ghostCollection.GetGhost(GhostNickname.Blinky));
        }
    }
}