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
