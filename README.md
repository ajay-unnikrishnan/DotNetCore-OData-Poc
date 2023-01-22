# DotNetCore-OData-Demo
Demo project to integrate OData with .Net Core 5
<br/><br/>
Packages used
1. .Net Core 5
2. OData (Version 7.6.3)
3. Entity Framework Core 5.0
4. Microsoft.AspNetCore.Mvc.NewtonsoftJson (To work with the odata $select)


<br/>

To run the project locally:
1. Download the source code
2. Build the code
3. Open Tools => Package Manager Console.
    Enter the command "Update-Database" // This will update the database schema
4. Run the project or create a docker image and run

<br/>  

Database:
By default it connects to the localdb. Modify the appsettings.json file to connect it to a different database.

<br/>

Sample Queries:

This project consists of 2 entities Product and Supplier with a one to many mapping.

Number Filter: https://localhost:5001/api/Products?$filter=supplierId eq 3

String Filter: https://localhost:5001/api/Products?$filter=name eq 'Product3'

Select: https://localhost:5001/api/Products?$select=name // allows the clients to requests a limited set of properties for each entity 

Top: https://localhost:5001/api/Products?$top=3

Sort: https://localhost:5001/api/Products?$orderby=Id desc

Skip and Top: https://localhost:5001/api/Products?$orderby=Id desc&$top=2&$skip=1

Change the url based on the port which the app runs.
