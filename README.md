# Roarshin Common Tool Library

## Built for Net Core Web Applications.

[![License][License-Badge]][License]

The Common Tool Library is a selection of commonly used pieces of Functionality that I find myself re-writing when build **Net Core Web Applications.** It was Initially built for myself to "hit the ground running" but now have it freely available for anyone interested. If you notice any issues or have a request on something to add, then feel free to post an **issue** or even a **pull request** and I would be happy to take a look.

**NOTE: If you are upgrading from 1.0 to 1.1 then there are breaking change in the upgrade! I honestly thought nobody used this library and was in the process of making it flow easier for myself. I've now added some documentation below on how it works for those who are using it.**

Check out the Authentication Tool Library that I use [here.](https://github.com/stuartaharrison/roarshin-auth-tools)

Has this library helped you? Feel free to buy me a [coffee.](https://www.paypal.com/donate/?hosted_button_id=XFFBGJT8AMLE8) 

You are free to use this library in any commerical and non-commerical products. It's not required but I would appreciate a **nod** in your code if you used my library. Everything comes under the [MIT License.][License]

## Getting Started

The quickest way to import this library into your project is to use the Nuget Package Manager.

`Install-Package Roarshin.CommonTools`

If you're planning to use this with your Net Core Web Application or are using Dependency Injection, you might also want to install the necessary extensions from the sister library.

`Install-Package Roarshin.CommonTools.DependencyInjection`

## Basic Usage

**NOTE: this bit assumes you have the DependencyInjection library also added to your project.**

### Data Store Provider

Something I find myself writing is connection strings for various different data-providers. I've configured this library so it can produce connection strings for the following commonly used data sources:

- MySQL
- PostgresSQL
- MongoDB

This might be a "roundabout" kind of way, but now I have an IDataStoreProvider that I can inject across my repositories or services where I might need my connection settings. **It does not expose the data source password but will allow you to access Host, Port, Username and Database name.**

To use, assume you have your AppSettings.{*}.json file or environment variables configured like so:

```json
{
    "DB_HOST": "localhost",
    "DB_PORT": 27017,
    "DB_USER": "",
    "DB_PASSWORD": "",
    "DB_DATABASE": "mydatabase",
}
```

You can simply configure your Data Provider to add a **singleton** IDataStoreProvider to your IOC.

```c#
public IConfiguration Configuration { get; }

public void ConfigureServices(IServiceCollection services) {
    services.AddRoarshinCommonTools(cfg => {
        cfg.AddDataProvider(
            DataProviders.MongoDb, 
            builder => builder.WithConfiguration(Configuration)
        );
    });

    // setup the rest of your services
}
```

If you do not want to use the Configuration to setup the Data Store Provider, then you can manually set the values through the builder action.

```c#
public void ConfigureServices(IServiceCollection services) {
    services.AddRoarshinCommonTools(cfg => {
        cfg.AddDataProvider(DataProviders.MongoDb, builder => {
            builder.Host("localhost");
            builder.Database("mydatabase");
        });
    });

    // setup the rest of your services
}
```

With my IDataStoreProvider, I tend to then setup my data source client in IOC similar to this:

```c#
services.AddSingleton<IMongoClient>(serviceProvider => {
    var dataProvider = serviceProvider.GetRequiredService<IDataStoreProvider>();
    return new MongoClient(dataProvider.GetConnectionString());
});
```

### Profile Icon Provider

This is a simple method of adding [Gravatar](https://en.gravatar.com/), [Robohash](https://robohash.org/) or even your custom favourite Profile Icon provider. The IProfileIconProvider will do most of the heavy lifting, take the email address of your user account and get the hash & build the URL for you to use on your client-side application.

It's as simple as telling the configuration what provider you would like to use, or none at all if you prefer to use my default! (Gravatar)

```c#
public void ConfigureServices(IServiceCollection services) {
    services.AddRoarshinCommonTools(cfg => {
        // uses the default (Gravatar)
        cfg.AddProfileIconProvider();

        // tell the configuration that you would like to use RoboHash
        cfg.AddProfileIconProvider(ProfileIconProviders.RoboHash);
    });

    // setup the rest of your services
}
```

Custom providers require a little bit more work. You will need to build your class that inherits from the **IProfileIconProvider** interface and then fill in the return for the `string GetIconUrl(string emailAddress)` implementation.

For example, I have build a custom provider that uses the [Avatars](https://avatars.dicebear.com/) library. **NOTE: I'll probably include this in a future release!**

```c#
public class CustomProfileIconProvider : IProfileIconProvider {

    private readonly string _baseUrl = "https://avatars.dicebear.com/api";
    private readonly string _defaultIconSet = "avataaars";

    public string GetIconUrl(string emailAddress) {
        // return some link code here
        // normally in the form of `_baseUrl/_defaultIconSet/md5hashofemail.svg`
    }
}
```

Now we can configure our library tools to use this custom implementation instead of the packaged ones.

```c#
public void ConfigureServices(IServiceCollection services) {
    services.AddRoarshinCommonTools(cfg => {
        // assign the `IProfileIconProvider` to the custom concrete class provided by this func
        cfg.AddProfileIconProvider(() => new CustomProfileIconProvider());
    });

    // setup the rest of your services
}
```


## License

Code released under the [MIT License][License], which means you can use it pretty much however you like! However, I would appreciate a little nod of appreciation if my code helps you and you can always get me a [coffee](https://www.paypal.com/donate/?hosted_button_id=XFFBGJT8AMLE8) as a thank you.

## Roadmap

Currently, I only plan to stick functionality into the library that I would find myself re-writing often. That said, I've come up with a couple of additional components that I plan to add in the future.

- Email Address Verification
- Phone Number Verification
- Message Broker wrappers so that with a flip of a **enum** your message broker technology has changed without affecting the rest of your code.
- Working on an internal message pipeline, but really [MediatR](https://github.com/jbogard/MediatR) has you covered for this.
- Build a Wiki page when this Readme gets too big!

Feel free to also submit any **pull requests** with changes you think will either improve my current code or for new features you would like to see added.
