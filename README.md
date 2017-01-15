# E-Business
###  An online store about vacation reservations in Bulgaria

The project is based on the book - Beginning ASP.NET E-Commerce.

It is written using SQL Server 2016 and Visual Studio 2016 Enterprise.

Fixing issues from using newer version of VS and .NET:

1. ASP.NET Web Administration Tool is missing after VS 2010, which I managed to fix by the following article:
https://blogs.msdn.microsoft.com/webdev/2013/08/19/accessing-the-asp-net-web-configuration-tool-in-visual-studio-2013/


2. *WebForms UnobtrusiveValidationMode requires a ScriptResourceMapping for 'jquery'. Please add a ScriptResourceMapping named jquery(case-sensitive).*

Add the following key to your web.config

```
<appSettings>
  <add key="ValidationSettings:UnobtrusiveValidationMode" value="None" />
</appSettings>
```
3. If you created the website with the Web Application Template (like I did), you will miss a class called ProfileCommon. It is usually dynamically created based on the user profile that you have in your database. Example:

```
// It already has all the properties you have in the database
ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;
profile.SomeCustomProperty = String.Empty;
```

In you web application you can fix that using the class that ```HttpContext.Current.Profile``` returns ```ProfileBase```
```
ProfileBase profile = HttpContext.Current.Profile;
profile["SomeCustomProperty"] = String.Empty;
```
