using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trouvtou.Models;
using System;
using System.Linq;

namespace Trouvtou.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TrouvtouContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TrouvtouContext>>()))
            {
                if (context.Objet.Any())
                {
                    return;   // DB has been seeded
                }

                    var commode = new Rangement()
                    {
                        description="commode habits",
                        couleur="blanc",
                        descriptionDetail="chambre Noé"
                    };
                    var bibliotheque = new Rangement()
                    {
                        description="bibliotheque",
                        couleur="marron",
                        descriptionDetail="salon"
                    };
                    var Armoire = new Rangement()
                    {
                        description="Armoire documents",
                        couleur="blanc",
                        descriptionDetail="salon"
                    };
                    var objets = new Objet[]
                    {
                        new Objet
                        {
                            nom = "scotch",
                            description="rouleau de scotch transparent",
                            typeObjet="fourniture de bureau",
                            dateDernierRangement=DateTime.Parse("2021-09-01"),
                            estConsultable=true,
                            rangement= commode
                        },
                        new Objet
                        {
                            nom = "livre",
                            description="1984 de Geroge Orwell",
                            typeObjet="culturel",
                            dateDernierRangement=DateTime.Parse("2021-12-01"),
                            estConsultable=true,
                            rangement= bibliotheque
                        },
                        new Objet
                        {
                            nom = "diplome",
                            description="baccalaureat",
                            typeObjet="Document",
                            dateDernierRangement=DateTime.Parse("2018-09-01"),
                            estConsultable=false,
                            rangement= Armoire
                        },
                        new Objet
                        {
                            nom = "livre",
                            description="Un monde merveilleux de Aldoux Huxley",
                            typeObjet="Culturel",
                            dateDernierRangement=DateTime.Parse("2020-10-14"),
                            estConsultable=true,
                            rangement= bibliotheque
                        },
                        new Objet
                        {
                            nom = "carte",
                            description="carte de la ville de bordeaux",
                            typeObjet="Document",
                            dateDernierRangement=DateTime.Parse("2021-09-01"),
                            estConsultable=true,
                            rangement= Armoire
                        },
                        new Objet
                        {
                            nom = "jeu",
                            description="loup-garou",
                            typeObjet="Culturel",
                            dateDernierRangement=DateTime.Parse("2001-09-01"),
                            estConsultable=true,
                            rangement= bibliotheque
                        },
                    };
                    

                context.Objet.AddRange(objets);
                context.SaveChanges();
                    
            }
        }
    }
}