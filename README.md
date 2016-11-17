## Commands

1. `dotnet restore`
2. `dotnet watch run`
3. `dotnet test`

## Commands for database and migrations
1. `dotnet ef migrations add <migration-name>`
2. `dotnet ef database update`
3. `dotnet ef migrations remove`
4. `dotnet ef database drop`

### Add the NancyFx web boilerplate. I'm going to add a prebuilt project.json which also contains the efcore dependencies.

I found that EF Core tools of preview3 are not working, so we will stick to preview2 for now.

We are using sqlite database as it's easy to use. Let's add the boilerplate of Program.cs and Startup.cs

Cool, let's add default root route.

Yay, it works.

For this tutorial, we will be saving couple of Customers in customer.db database.

### Customer will have First Name and Last Name with Id.

Let's create that class.

We need to add a context for the framework to know what variable will be responsible for handling the database connection just like $db in PHP.

Let's add that now.

Cool, let's add some customers namely,
1. Steve Smith
2. Will Smith
3. Nancy framework
4. False Possession
5. Nine Army
6. Win Daisel

### Let's add a route to query our customers by first name

We need to consult docs for query syntax at docs.efproject.net

Ok let's do this

Hmm, seems docs are outdated

Ok we will do query in next video. Keep reading docs, I'll update the video :)

Good day!