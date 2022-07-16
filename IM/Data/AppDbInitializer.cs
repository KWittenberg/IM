namespace IM.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();



            //Product
            if (!context.Product.Any())
            {
                context.Product.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductCategoryId = 1,
                            Title = "Almanah Gimnazije",
                            Description = "Iako se pišu monografije o samo onim osobama koje su, kako se to obično kaže ‘postigle’ nešto o životu, a onda svakako da su završile gimnaziju, ja sam se opredijelio da navedem sve učenike upisnike te školske godine 1948./49.",
                            Quantity = 100,
                            Price = 200,
                            },
                        });
                context.SaveChanges();
            }
        }
    }
}
