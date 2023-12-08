#if NETSTANDARD2_0
#nullable disable
#else
#nullable enable
#endif

using ShopifySharp.Credentials;

namespace ShopifySharp.Factories;

public interface ICollectionListingServiceFactory
{
    // ReSharper disable once UnusedMember.Global
    ICollectionListingService Create(ShopifyRestApiCredentials credentials);
}

public class CollectionListingServiceFactory(
    #if NETSTANDARD2_0
    IRequestExecutionPolicy requestExecutionPolicy = null
    #else
    IRequestExecutionPolicy? requestExecutionPolicy = null
    #endif
) : ICollectionListingServiceFactory
{
    public virtual ICollectionListingService Create(ShopifyRestApiCredentials credentials)
    {
        var service = new CollectionListingService(credentials.ShopDomain, credentials.AccessToken);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }
}
