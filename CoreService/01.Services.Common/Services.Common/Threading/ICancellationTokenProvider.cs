using System.Threading;

namespace Services.Common.Threading
{
    public interface ICancellationTokenProvider
    {
        CancellationToken Token { get; }
    }
}