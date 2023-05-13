# Demo project to integrate OData with .Net Core 5



### Packages used:
1. .Net Core 5
2. OData (Version 7.6.3)
3. Entity Framework Core 5.0
4. Microsoft.AspNetCore.Mvc.NewtonsoftJson (To work with the odata $select)




### To run the project:
1. Download the source code
2. Build the code
3. Open Tools => Package Manager Console.
    Enter the command "Update-Database" // This command will update the database schema
4. Run the project directly from the IDE or create a docker image and run



### Database:
By default, the project connects to the localdb. To connect it to a different database, modify the `appsettings.json` file. 

Default Data:

Some default data has been added to the tables. To add more data, you can use Swagger and make a POST request to the API.



### Sample Queries:

This project consists of 2 entities: Product and Supplier, which are associated with a one-to-many mapping.

Number Filter: `https://localhost:5001/api/Products?$filter=supplierId eq 2`

String Filter: `https://localhost:5001/api/Products?$filter=name eq 'Product3'`

Select: `https://localhost:5001/api/Products?$select=name` // allows the clients to requests a limited set of properties for each entity 

Top: `https://localhost:5001/api/Products?$top=3`

Sort: `https://localhost:5001/api/Products?$orderby=Id desc`

Skip and Top: `https://localhost:5001/api/Products?$orderby=Id desc&$top=2&$skip=1`

Please remember to adjust the URL based on the port number on which the application is running.

### Findings:

When returning an IEnumerable from the datastore (like the Repository Pattern), filtering occurs on the server, causing all data to be loaded onto the web server and the filter conditions to be executed there. However, utilizing IQueryable from the Data Access Layer allows for the filters to be passed directly to the database, resulting in improved performance by conducting the data filtering at the source.

### Entity Framework Generated Database Query:
#### When returning IEnumberable:
API: `https://localhost:5001/api/Products?$filter=supplierId eq 2` // uses IEnumerable 

DB Query: SELECT [p].[Id], [p].[IsActive], [p].[Name], [p].[Price], [p].[SupplierId] 
FROM [Products] AS [p]


#### When returning IQueryable:<br/>
API: `https://localhost:44386/api/Products/GetProducts?$filter=supplierId eq 2` //uses IQueryable 

DB Query: exec sp_executesql N'SELECT [p].[Id], [p].[IsActive], [p].[Name], [p].[Price], [p].[SupplierId] 
FROM [Products] AS [p] 
WHERE [p].[SupplierId] = @__TypedProperty_0',N'@__TypedProperty_0 int',@__TypedProperty_0=2
