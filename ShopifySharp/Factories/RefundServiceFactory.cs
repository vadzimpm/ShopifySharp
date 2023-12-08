#if NETSTANDARD2_0
#nullable disable
#else
#nullable enable
#endif

using ShopifySharp.Credentials;

namespace ShopifySharp.Factories;

public interface IRefundServiceFactory
{
    // ReSharper disable once UnusedMember.Global
    IRefundService Create(ShopifyRestApiCredentials credentials);
}

public class RefundServiceFactory(
    #if NETSTANDARD2_0
    IRequestExecutionPolicy requestExecutionPolicy = null
    #else
    IRequestExecutionPolicy? requestExecutionPolicy = null
    #endif
) : IRefundServiceFactory
{
    public virtual IRefundService Create(ShopifyRestApiCredentials credentials)
    {
        var service = new RefundService(credentials.ShopDomain, credentials.AccessToken);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }
}
