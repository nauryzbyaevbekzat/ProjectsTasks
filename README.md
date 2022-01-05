A way to start a project.

For development with this project, we can use various tools. If our working platform is Windows, then we can use the full-featured Visual Studio development environment.

The Visual Studio 2019 installer can be downloaded from https://www.visualstudio.com/downloads/. In this case, it doesn't matter which edition of VS to use - free Community or paid Professional or Enterprise.

So, let's download the VS 2019 installer and run it. And since we will be working with ASP.NET Core, then select the ASP.NET and web application development item in the installation program.
In addition, you must select another item Cross-platform .NET development

You also need to install MsSQL for the database (https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads).
During the development, the approach was used CODE FIRST .
In a Code First approach, you focus on your application and start creating classes for it, rather than designing your database first and then creating classes that match your database design.

In the file appsettings.json , you can specify you can give the name of your server name .
Example :
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-OJOOSLO\\SQLEXPRESS;Database=akvelondb;Trusted_Connection=True;"
  }
}

My server name - DESKTOP-OJOOSLO\\SQLEXPRESS . At the first start, the database will be automatically created .



Technologies that were used : 
1. ASP.NET CORE WEB API 
2. Entity Framework Core
3. Database MsSQL


Description of technologies:

1.The Web API provides a way to build an ASP.NET application that is specifically tailored to work in the REST (Representation State Transfer) style. The REST architecture assumes the use of the following HTTP request methods or types to communicate with the server: GET , POST , PUT , DELETE


2.The Entity Framework introduces Microsoft's object-relational mapping (ORM) technology for data access. Entity Framework Core allows you to abstract from the database itself and its tables and work with data as objects of a class, regardless of the type of storage. If at the physical level we operate with tables, indexes, primary and foreign keys, but at the conceptual level that Entity Framework offers us, we are already working with objects.

3.Microsoft SQL Server is a relational database management system developed by Microsoft. As a database server, it is a software product with the primary function of storing and retrieving data as requested by other software applications—which may run either on the same computer or on another computer across a network (including the Internet). Microsoft markets at least a dozen different editions of Microsoft SQL Server, aimed at different audiences and for workloads ranging from small single-machine applications to large Internet-facing applications with many concurrent users.

