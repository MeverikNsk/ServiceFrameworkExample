namespace Vsk.VooDoo.Edo.Domain.Services
{
    using Vsk.VooDoo.Edo.API.Models;

    public interface IPingPongService
    {
        public Task<PongResponse> PingAsync(PingRequest request);
    }
}
