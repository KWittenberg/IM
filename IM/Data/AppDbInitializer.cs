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
                        //new Product()
                        //{
                        //    ProductCategoryId = 1,
                        //    Title = "Groblja Požeske Doline",
                        //    ShortDescription = "Jedinstvena publikacija o grobljima Požeške doline, odnosno bivšeg kotara i općine Požega.",
                        //    Description =  "Jedinstvena publikacija o grobljima Požeške doline, odnosno bivšeg kotara i općine Požega, koja obrađuje tu tematiku na preko 160 stranica teksta i 60 kolor fotografija. Obzirom na razvedenost naselja - 207 i 159 groblja sa preko 700.000 m2 grobnih zemljišta, knjiga predstavlja do sada jedinu takovu publikaciju u Županiji, ali i šire.",
                        //    Author = "Tomislav Wittenberg",
                        //    Image = "/img/1996 Groblja Pozeske Doline/1996 Groblja Pozeske Doline 00.jpg",
                        //    Available = true,
                        //    Quantity = 70,
                        //    Price = 200,
                        //    Discount = false,
                        //    DiscountPrice = 150,
                        //    StartDate = DateTime.Now,
                        //    EndDate = DateTime.Now,
                        //    YearOfPublication = 1996,
                        //    Publisher = "Bolta",
                        //    Isbn = "978-953-9700-00-0",
                        //    BookCategory = BookCategory.Monography,
                        //    BookBinding = BookBinding.Soft,
                        //    NumberOfPages = 190,
                        //    Width = 170,
                        //    Height = 240,
                        //    Thickness = 10,
                        //    Weight = 350
                        //},
                        //new Product()
                        //{
                        //    ProductCategoryId = 1,
                        //    Title = "Rudina",
                        //    ShortDescription = "Rudina je bila centar ili bolje rečeno središte centralne Slavonije u kojoj se spaja sve ono najbolje toga vremena.",
                        //    Description = "Rudina je bila centar ili bolje rečeno središte centralne Slavonije u kojoj se spaja sve ono najbolje toga vremena. 'Rudina se rudila od crvenih fresaka.' - Akademik Matko Peić. 'Ono što benediktinski samostan Rudinu i crkvu Sv. Mihovila čini izuzetnim u čitavoj Hrvatskoj zapravo je arhitektonska figuralna plastika.' - Gjuro Szabo 'Umjetnički izraz prisutan na ostacima bebediktinske opatije Rudina nosi određenu poruku vremena i prostora na tlu Hrvatske.' - Lidija Ivančević - Španiček, prof.",
                        //    Author = "Tomislav Wittenberg",
                        //    Image = "/img/1997 Rudina/1997 Rudina 11.jpg",
                        //    Available = true,
                        //    Quantity = 116,
                        //    Price = 300,
                        //    Discount = true,
                        //    DiscountPrice = 250,
                        //    StartDate = DateTime.Now,
                        //    EndDate = DateTime.Now.AddDays(30),
                        //    YearOfPublication = 1997,
                        //    Publisher = "Bolta",
                        //    Isbn = "978-953-9730-00-0",
                        //    BookCategory = BookCategory.Monography,
                        //    BookBinding = BookBinding.Hard,
                        //    NumberOfPages = 126,
                        //    Width = 223,
                        //    Height = 290,
                        //    Thickness = 16,
                        //    Weight = 845
                        //},
                        new Product()
                        {
                            ProductCategoryId = 1,
                            Title = "Puvarija",
                            ShortDescription = "Prva cjelovita obrada sjeverno-zapadnog dijela Dilj-gore i naselja na diljskim padinama, od srednjeg vijeka do današnjih dana.",
                            Description = "Prva cjelovita obrada sjeverno-zapadnog dijela Dilj-gore i naselja na diljskim padinama, od srednjeg vijeka do današnjih dana.",
                            Author = "Tomislav Wittenberg",
                            Image = "/img/1998 Puvarija/Puvarija 00.jpg",
                            Available = true,
                            Quantity = 100,
                            Price = 300,
                            Discount = true,
                            DiscountPrice = 250,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30),
                            YearOfPublication = 1998,
                            Publisher = "Bolta",
                            Isbn = "978-953-97322-1-2",
                            BookCategory = BookCategory.Monography,
                            BookBinding = BookBinding.Soft,
                            NumberOfPages = 314,
                            Width = 164,
                            Height = 234,
                            Thickness = 17,
                            Weight = 910
                        },
                    });
                context.SaveChanges();
            }
        }
    }
}