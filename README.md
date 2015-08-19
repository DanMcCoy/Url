[![McCoy Software Logo](McCoySoftware.png)](http://mccoysoftware.uk)

# Url Utilities
A .Net URL class and related extensions.

[![Join the chat at https://gitter.im/DanMcCoy/UrlUtilities](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/DanMcCoy/UrlUtilities?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

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

