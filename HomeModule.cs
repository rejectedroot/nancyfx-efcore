using System;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;

namespace NancyEFCore
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Hello from Nancy running on CoreCLR");

            // Get("/db", args =>
            // {
            //     using (var db = new CustomerContext())
            //     {
            //         db.Customers.Add(new Customer { Id = Guid.NewGuid().ToString(), FirstName = "Steve", LastName = "Smith" });
            //         db.Customers.Add(new Customer { Id = Guid.NewGuid().ToString(), FirstName = "Will", LastName = "Smith" });
            //         db.Customers.Add(new Customer { Id = Guid.NewGuid().ToString(), FirstName = "Nancy", LastName = "Framework" });
            //         db.Customers.Add(new Customer { Id = Guid.NewGuid().ToString(), FirstName = "False", LastName = "Possession" });
            //         db.Customers.Add(new Customer { Id = Guid.NewGuid().ToString(), FirstName = "Nine", LastName = "Army" });
            //         db.Customers.Add(new Customer { Id = Guid.NewGuid().ToString(), FirstName = "Win", LastName = "Daisel" });

            //         db.SaveChanges(); // For persisting the changes to database.

            //         return Response.AsJson(db.Customers.ToList());
            //     }
            // });

            Get("/customers", _ =>
            {
                using (var db = new CustomerContext())
                {
                    return Response.AsJson(db.Customers.ToList(), HttpStatusCode.OK);
                }
            });

            Get("/customers/{id:guid}", args =>
            {
                using (var db = new CustomerContext())
                {
                    string Id = args.id;
                    var customer = db.Customers.Where(b => b.Id == Id).First();
                    return Response.AsJson(customer, HttpStatusCode.OK);
                }
            });

            Post("/customers", _ =>
            {
                using (var db = new CustomerContext())
                {
                    var customer = this.Bind<Customer>();
                    customer.Id = Guid.NewGuid().ToString();
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return Response.AsJson(customer, HttpStatusCode.Created);
                }
            });

            Put("/customers/{id:guid}", args =>
            {
                using (var db = new CustomerContext())
                {
                    string Id = args.id;
                    var customer = this.Bind<Customer>();
                    customer.Id = Id;
                    db.Customers.Update(customer);
                    db.SaveChanges();
                    return Response.AsJson(customer, HttpStatusCode.Accepted);
                }
            });

            Delete("/customers/{id:guid}", args =>
            {
                using (var db = new CustomerContext())
                {
                    string Id = args.id;
                    var customer = db.Customers.Where(c => c.Id == Id).First();
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    return Response.AsJson(customer, HttpStatusCode.OK);
                }
            });
        }
    }
}