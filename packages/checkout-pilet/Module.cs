using System;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout;

public class Module
{
    public static void Main()
    {
        // this entrypoint shold remain empty
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDataRepository, DataRepository>();
    }
}
