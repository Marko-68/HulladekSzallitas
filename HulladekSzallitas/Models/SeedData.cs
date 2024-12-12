using Hulladékszállítás.Models;
using Microsoft.EntityFrameworkCore;

namespace HulladekSzallitas.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<HulladekSzallitasContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Szolgaltatas.Any())
                {
                    context.Szolgaltatas.AddRange(
                        new Szolgaltatas
                        {
                            tipus = "zold",
                            jelentes = "Zöldhulladék"
                        },
                        new Szolgaltatas
                        {
                            tipus = "kom",
                            jelentes = "Kommunális Hulladék"
                        },
                        new Szolgaltatas
                        {
                            tipus = "mua",
                            jelentes = "Műanyag"
                        },
                        new Szolgaltatas
                        {
                            tipus = "pa",
                            jelentes = "Papír"
                        }
                    );
                }
                context.SaveChanges();
                if (!context.Naptar.Any())
                {
                    context.Naptar.AddRange(
                        new Naptar
                        {
                            SzolgaltatasId = 1,
                            datum = new DateTime(2024, 2, 22)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 1,
                            datum = new DateTime(2023, 1, 22)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 2,
                            datum = new DateTime(2024, 5, 22)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 2,
                            datum = new DateTime(2024, 8, 22)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 1,
                            datum = new DateTime(2024, 1, 10)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 4,
                            datum = new DateTime(2024, 6, 10)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 3,
                            datum = new DateTime(2024, 6, 10)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 4,
                            datum = new DateTime(2024, 9, 20)
                        },
                        new Naptar
                        {
                            SzolgaltatasId = 3,
                            datum = new DateTime(2024, 9, 20)
                        }
                    );
                }
                context.SaveChanges();
                if (!context.Lakig.Any())
                {
                    context.Lakig.AddRange(
                        new Lakig
                        {
                            mennyiseg = 1,
                            SzolgaltatasId = 1,
                            igeny = new DateTime(2024, 4, 8)
                        },
                        new Lakig
                        {
                            mennyiseg = 2,
                            SzolgaltatasId = 2,
                            igeny = new DateTime(2024, 8, 16)
                        },
                        new Lakig
                        {
                            mennyiseg = 2,
                            SzolgaltatasId = 3,
                            igeny = new DateTime(2024, 8, 16)
                        },
                        new Lakig
                        {
                            mennyiseg = 3,
                            SzolgaltatasId = 4,
                            igeny = new DateTime(2024, 8, 16)
                        },
                        new Lakig
                        {
                            mennyiseg = 5,
                            SzolgaltatasId = 1,
                            igeny = new DateTime(2024, 4, 16)
                        },
                        new Lakig
                        {
                            mennyiseg = 30,
                            SzolgaltatasId = 1,
                            igeny = new DateTime(2024, 1, 16)
                        },
                        new Lakig
                        {
                            mennyiseg = 15,
                            SzolgaltatasId = 2,
                            igeny = new DateTime(2024, 3, 16)
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
