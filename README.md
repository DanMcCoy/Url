[![McCoy Software Logo](McCoySoftware.png)](http://mccoysoftware.uk)

# Url Utilities
A .Net URL class and related extensions.

### Install
The quickest way to include the library in your project is to install using NuGet.  
First [install NuGet](https://docs.nuget.org/consume/installing-nuget). Then, install [.UrlUtilities](https://www.nuget.org/packages/UrlUtilities/) from the package manager console.

    PM> Install-Package UrlUtilities

### How To Use

```C#

Url url = new Url("http://mccoysoftware.uk");
url.SetQueryParam("KeyA", "ValueA");
url.SetQueryParam("KeyB", "ValueB");
url.SetQueryParam("KeyC", "ValueC");

string urlString = url.ToString(); // http://mccoysoftware.uk/?KeyA=ValueA&KeyB=ValueB&KeyC=ValueC
```

