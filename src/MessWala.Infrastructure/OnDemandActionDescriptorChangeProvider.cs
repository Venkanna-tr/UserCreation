using System.Threading;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Primitives;

namespace MessWala.Infrastructure
{
    public class OnDemandActionDescriptorChangeProvider : IActionDescriptorChangeProvider
    {
        public CancellationTokenSource TokenSource { get; private set; }

        public IChangeToken GetChangeToken()
        {
            TokenSource = new CancellationTokenSource();
            return new CancellationChangeToken(TokenSource.Token);
        }
    }
}
