using System.Linq;
using TyskaForSmaUpptackare.Models;

namespace TyskaForSmaUpptackare.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Abcs.Any())
            {
                context.Abcs.AddRange(
                    new Abc { Name = "Aa", AudioUrl = "~/audio/A.mp3" },
                    new Abc { Name = "Bb", AudioUrl = "~/audio/B.mp3" },
                    new Abc { Name = "Cc", AudioUrl = "~/audio/C.mp3" },
                    new Abc { Name = "Dd", AudioUrl = "~/audio/D.mp3" },
                    new Abc { Name = "Ee", AudioUrl = "~/audio/E.mp3" },
                    new Abc { Name = "Ff", AudioUrl = "~/audio/F.mp3" },
                    new Abc { Name = "Gg", AudioUrl = "~/audio/G.mp3" },
                    new Abc { Name = "Hh", AudioUrl = "~/audio/H.mp3" },
                    new Abc { Name = "Ii", AudioUrl = "~/audio/I.mp3" },
                    new Abc { Name = "Jj", AudioUrl = "~/audio/J.mp3" },
                    new Abc { Name = "Kk", AudioUrl = "~/audio/K.mp3" },
                    new Abc { Name = "Ll", AudioUrl = "~/audio/L.mp3" },
                    new Abc { Name = "Mm", AudioUrl = "~/audio/M.mp3" },
                    new Abc { Name = "Nn", AudioUrl = "~/audio/N.mp3" },
                    new Abc { Name = "Oo", AudioUrl = "~/audio/O.mp3" },
                    new Abc { Name = "Pp", AudioUrl = "~/audio/P.mp3" },
                    new Abc { Name = "Qq", AudioUrl = "~/audio/Q.mp3" },
                    new Abc { Name = "Rr", AudioUrl = "~/audio/R.mp3" },
                    new Abc { Name = "Ss", AudioUrl = "~/audio/S.mp3" },
                    new Abc { Name = "Tt", AudioUrl = "~/audio/T.mp3" },
                    new Abc { Name = "Uu", AudioUrl = "~/audio/U.mp3" },
                    new Abc { Name = "Vv", AudioUrl = "~/audio/V.mp3" },
                    new Abc { Name = "Ww", AudioUrl = "~/audio/W.mp3" },
                    new Abc { Name = "Xx", AudioUrl = "~/audio/X.mp3" },
                    new Abc { Name = "Yy", AudioUrl = "~/audio/Y.mp3" },
                    new Abc { Name = "Zz", AudioUrl = "~/audio/Z.mp3" },
                    new Abc { Name = "Ää", AudioUrl = "~/audio/Ä.mp3" },
                    new Abc { Name = "Öö", AudioUrl = "~/audio/Ö.mp3" },
                    new Abc { Name = "Üü", AudioUrl = "~/audio/Ü.mp3" },
                    new Abc { Name = "ẞ", AudioUrl = "~/audio/ss.mp3" }
                );
                context.SaveChanges();
            }

            if (!context.Animals.Any())
            {
                context.Animals.AddRange(
                    new Animal { Name = "Affe", ImageUrl = "/img/tfsu-affe.png", AudioUrl = "/audio/Affe.mp3" },
                    new Animal { Name = "Bär", ImageUrl = "/img/tfsu-bär.png", AudioUrl = "/audio/Bar.mp3" },
                    new Animal { Name = "Chamäleon", ImageUrl = "/img/tfsu-Chamäleon.png", AudioUrl = "/audio/Chamaleon.mp3" },
                    new Animal { Name = "Dachs", ImageUrl = "/img/tfsu-dachs.png", AudioUrl = "/audio/Dachs.mp3" },
                    new Animal { Name = "Elefant", ImageUrl = "/img/tfsu-elefant.png", AudioUrl = "/audio/Elefant.mp3" },
                    new Animal { Name = "Fuchs", ImageUrl = "/img/tfsu-fuchs.png", AudioUrl = "/audio/Fuchs.mp3" },
                    new Animal { Name = "Giraffe", ImageUrl = "/img/tfsu-giraffe.png", AudioUrl = "/audio/Giraffe.mp3" },
                    new Animal { Name = "Hase", ImageUrl = "/img/tfsu-hase.png", AudioUrl = "/audio/Hase.mp3" },
                    new Animal { Name = "Igel", ImageUrl = "/img/tfsu-igel.png", AudioUrl = "/audio/Igel.mp3" },
                    new Animal { Name = "Jaguar", ImageUrl = "/img/tfsu-jaguar.png", AudioUrl = "/audio/Jaguar.mp3" },
                    new Animal { Name = "Känguru", ImageUrl = "/img/tfsu-känguru.png", AudioUrl = "/audio/Kanguru.mp3" },
                    new Animal { Name = "Löwe", ImageUrl = "/img/tfsu-lowe.png", AudioUrl = "/audio/Lowe.mp3" },
                    new Animal { Name = "Maus", ImageUrl = "/img/tfsu-maus.png", AudioUrl = "/audio/Maus.mp3" },
                    new Animal { Name = "Nilpferd", ImageUrl = "/img/tfsu-nilpferd.png", AudioUrl = "/audio/Nilpferd.mp3" },
                    new Animal { Name = "Otter", ImageUrl = "/img/tfsu-otter.png", AudioUrl = "/audio/Otter.mp3" },
                    new Animal { Name = "Pferd", ImageUrl = "/img/tfsu-pferd.png", AudioUrl = "/audio/Pferd.mp3" },
                    new Animal { Name = "Qualle", ImageUrl = "/img/tfsu-qualle.png", AudioUrl = "/audio/Qualle.mp3" },
                    new Animal { Name = "Reh", ImageUrl = "/img/tfsu-reh.png", AudioUrl = "/audio/Reh.mp3" },
                    new Animal { Name = "Schlange", ImageUrl = "/img/tfsu-schlange.png", AudioUrl = "/audio/Schlange.mp3" },
                    new Animal { Name = "Tiger", ImageUrl = "/img/tfsu-tiger.png", AudioUrl = "/audio/Tiger.mp3" },
                    new Animal { Name = "Uhu", ImageUrl = "/img/tfsu-uhu.png", AudioUrl = "/audio/Uhu.mp3" },
                    new Animal { Name = "Vogel", ImageUrl = "/img/tfsu-vogel.png", AudioUrl = "/audio/Vogel.mp3" },
                    new Animal { Name = "Wal", ImageUrl = "/img/tfsu-wal.png", AudioUrl = "/audio/Wal.mp3" },
                    new Animal { Name = "Xerus", ImageUrl = "/img/tfsu-xerus.png", AudioUrl = "/audio/Xerus.mp3" },
                    new Animal { Name = "Yak", ImageUrl = "/img/tfsu-yak.png", AudioUrl = "/audio/Yak.mp3" },
                    new Animal { Name = "Zebra", ImageUrl = "/img/tfsu-zebra.png", AudioUrl = "/audio/Zebra.mp3" }
                );
                context.SaveChanges();
            }

            if (!context.NumberOneTwos.Any())
            {
                context.NumberOneTwos.AddRange(
                    new NumberOneTwo { Name = "1", AudioUrl = "/audio/eins.mp3" },
                    new NumberOneTwo { Name = "2", AudioUrl = "/audio/zwei.mp3" },
                    new NumberOneTwo { Name = "3", AudioUrl = "/audio/drei.mp3" },
                    new NumberOneTwo { Name = "4", AudioUrl = "/audio/vier.mp3" },
                    new NumberOneTwo { Name = "5", AudioUrl = "/audio/funf.mp3" },
                    new NumberOneTwo { Name = "6", AudioUrl = "/audio/sechs.mp3" },
                    new NumberOneTwo { Name = "7", AudioUrl = "/audio/sieben.mp3" },
                    new NumberOneTwo { Name = "8", AudioUrl = "/audio/acht.mp3" },
                    new NumberOneTwo { Name = "9", AudioUrl = "/audio/neun.mp3" }
                );
                context.SaveChanges();
            }

            if (!context.NumbersTens.Any())
            {
                context.NumbersTens.AddRange(
                    new NumbersTen { Name = "10", AudioUrl = "/audio/Zehn.mp3" },
                    new NumbersTen { Name = "20", AudioUrl = "/audio/Zwanzig.mp3" },
                    new NumbersTen { Name = "30", AudioUrl = "/audio/Dreisig.mp3" },
                    new NumbersTen { Name = "40", AudioUrl = "/audio/Vierzig.mp3" },
                    new NumbersTen { Name = "50", AudioUrl = "/audio/Funfzig.mp3" },
                    new NumbersTen { Name = "60", AudioUrl = "/audio/Sechzig.mp3" },
                    new NumbersTen { Name = "70", AudioUrl = "/audio/Siebzig.mp3" },
                    new NumbersTen { Name = "80", AudioUrl = "/audio/Achtzig.mp3" },
                    new NumbersTen { Name = "90", AudioUrl = "/audio/Neunzig.mp3" }
                );
                context.SaveChanges();
            }

            if (!context.NumbersHundred.Any())
            {
                context.NumbersHundred.AddRange(
                    new NumbersHundred { Name = "100", AudioUrl = "/audio/Hundert.mp3" },
                    new NumbersHundred { Name = "200", AudioUrl = "/audio/Zweihundert.mp3" },
                    new NumbersHundred { Name = "300", AudioUrl = "/audio/Dreihundert.mp3" },
                    new NumbersHundred { Name = "400", AudioUrl = "/audio/Vierhundert.mp3" },
                    new NumbersHundred { Name = "500", AudioUrl = "/audio/Funfhundert.mp3" },
                    new NumbersHundred { Name = "600", AudioUrl = "/audio/Sechshundert.mp3" },
                    new NumbersHundred { Name = "700", AudioUrl = "/audio/Siebenhundert.mp3" },
                    new NumbersHundred { Name = "800", AudioUrl = "/audio/Achthundert.mp3" },
                    new NumbersHundred { Name = "900", AudioUrl = "/audio/Neunhundert.mp3" },
                    new NumbersHundred { Name = "1000", AudioUrl = "/audio/Tausend.mp3" }
                );
                context.SaveChanges();
            }


            if (!context.Products.Any())
            {
                var products = new List<Product>
    {
        new Product
        {
            Name = "Haus",
            Description = "Upptäck olika rum och saker som finns i huset",
            ImageUrl = "/img/tfsu-house.webp",
            Price = 665.00m,
            AudioUrl = "/audio/tfsu-hus.mp3"
        },
        new Product
        {
            Name = "Flugzeug",
            Description = "Upptäck vad som finns i flygplanet",
            ImageUrl = "/img/tfsu-flygplan.webp",
            Price = 250.00m,
            AudioUrl = "/audio/tfsu-flugplan.mp3"
        },
        new Product
        {
            Name = "Auto",
            Description = "Vad finns i och på bilen?",
            ImageUrl = "/img/tfsu-bil.webp",
            Price = 250.00m,
            AudioUrl = "/audio/tfsu-bil.mp3"
        }
    };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.ProductItems.Any())
            {
                var haus = context.Products.FirstOrDefault(p => p.Name == "Haus");
                var flugzeug = context.Products.FirstOrDefault(p => p.Name == "Flugzeug");
                var auto = context.Products.FirstOrDefault(p => p.Name == "Auto");

                if (haus != null)
                {
                    context.ProductItems.AddRange(
                        new ProductItem { Name = "Küche", ImageUrl = "/img/tfsu-kok.webp", AudioUrl = "/audio/tfsu-kuche.mp3", ProductId = haus.ProductId },
                        new ProductItem { Name = "Wohnzimmer", ImageUrl = "/img/tfsu-vardagsrum.webp", AudioUrl = "/audio/tfsu-vardagsrum.mp3", ProductId = haus.ProductId },
                        new ProductItem { Name = "Saal", ImageUrl = "/img/tfsu-hall.webp", AudioUrl = "/audio/tfsu-hall.mp3", ProductId = haus.ProductId }
                    );
                }

                if (flugzeug != null)
                {
                    context.ProductItems.AddRange(
                            new ProductItem { Name = "Cockpit", ImageUrl = "/img/tfsu-cockpit.webp", AudioUrl = "/audio/tfsu-cockpit.mp3", ProductId = flugzeug.ProductId },
                            new ProductItem { Name = "Fenster", ImageUrl = "/img/tfsu-flygfonster.webp", AudioUrl = "/audio/tfsu-fonster.mp3", ProductId = flugzeug.ProductId },
                            new ProductItem { Name = "Fernseher", ImageUrl = "/img/tfsu-flygtv.webp", AudioUrl = "/audio/tfsu-tv.mp3", ProductId = flugzeug.ProductId },
                            new ProductItem { Name = "Flugbegleiterin", ImageUrl = "/img/tfsu-flygvardinna.webp", AudioUrl = "/audio/tfsu-flygvardinnagubbe.mp3", ProductId = flugzeug.ProductId }
                    );
                }

                if (auto != null)
                {
                    context.ProductItems.AddRange(
                        new ProductItem { Name = "Rückspiegel", ImageUrl = "/img/tfsu-backspegel.webp", AudioUrl = "/audio/tfsu-sidspegel.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Gürtel", ImageUrl = "/img/tfsu-bilbalte.webp", AudioUrl = "/audio/tfsu-balte.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Autositz", ImageUrl = "/img/tfsu-bilstol.webp", AudioUrl = "/audio/tfsu-barnstol.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Vordersitz", ImageUrl = "/img/tfsu-framsate.webp", AudioUrl = "/audio/tfsu-framsate.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Handbremse", ImageUrl = "/img/tfsu-handbroms.webp", AudioUrl = "/audio/tfsu-handbroms.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Armaturenbrett", ImageUrl = "/img/tfsu-instrumentpanel.webp", AudioUrl = "/audio/tfsu-instrumentpanel.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Lenkrad", ImageUrl = "/img/tfsu-ratt.webp", AudioUrl = "/audio/tfsu-ratt.mp3", ProductId = auto.ProductId },
                        new ProductItem { Name = "Schalthebel", ImageUrl = "/img/tfsu-vaxel.webp", AudioUrl = "/audio/tfsu-vaxel.mp3", ProductId = auto.ProductId }
                    );
                }

                context.SaveChanges();
            }

            if (!context.ProductParts.Any())
            {
                var kuche = context.ProductItems.FirstOrDefault(i => i.Name == "Küche");
                var wohnzimmer = context.ProductItems.FirstOrDefault(i => i.Name == "Wohnzimmer");
                var saal = context.ProductItems.FirstOrDefault(i => i.Name == "Saal");

                if (kuche != null)
                {
                    context.ProductParts.AddRange(
                        new ProductPart { Name = "Löffel", AudioUrl = "/audio/tfsu-loffel.mp3", ImageUrl = "/img/tfsu-spoon.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Messer", AudioUrl = "/audio/tfsu-messer.mp3", ImageUrl = "/img/tfsu-knife.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Gabel", AudioUrl = "/audio/tfsu-gabel.mp3", ImageUrl = "/img/tfsu-gaffel.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Tasse", AudioUrl = "/audio/tfsu-tasse.mp3", ImageUrl = "/img/tfsu-mugg.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Topf", AudioUrl = "/audio/tfsu-topf.mp3", ImageUrl = "/img/tfsu-kastrull.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Bratpfanne", AudioUrl = "/audio/tfsu-bratpfanne.mp3", ImageUrl = "/img/tfsu-stekpanna.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Tisch", AudioUrl = "/audio/tfsu-tisch.mp3", ImageUrl = "/img/tfsu-bord.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Stuhl", AudioUrl = "/audio/tfsu-stuhl.mp3", ImageUrl = "/img/tfsu-stol.png", ProductItemId = kuche.ItemId },
                        new ProductPart { Name = "Mikrowellenofen", AudioUrl = "/audio/tfsu-mikrowellenofen.mp3", ImageUrl = "/img/tfsu-mikro.png", ProductItemId = kuche.ItemId }
                    );
                }

                if (wohnzimmer != null)
                {
                    context.ProductParts.AddRange(
                        new ProductPart { Name = "Sofa", AudioUrl = "/audio/tfsu-soffa.mp3", ImageUrl = "/img/tfsu-soffa.png", ProductItemId = wohnzimmer.ItemId },
                        new ProductPart { Name = "Fernseher", AudioUrl = "/audio/tfsu-tv.mp3", ImageUrl = "/img/tfsu-tv.png", ProductItemId = wohnzimmer.ItemId },
                        new ProductPart { Name = "Fernsehbox", AudioUrl = "/audio/tfsu-dosa.mp3", ImageUrl = "/img/tfsu-dosa.png", ProductItemId = wohnzimmer.ItemId },
                        new ProductPart { Name = "Sessel", AudioUrl = "/audio/tfsu-fotolj.mp3", ImageUrl = "/img/tfsu-fotolj.png", ProductItemId = wohnzimmer.ItemId },
                        new ProductPart { Name = "Lampe", AudioUrl = "/audio/tfsu-lampa.mp3", ImageUrl = "/img/tfsu-lampa.png", ProductItemId = wohnzimmer.ItemId }
                    );
                }

                if (saal != null)
                {
                    context.ProductParts.AddRange(
                        new ProductPart { Name = "Element", AudioUrl = "/audio/tfsu-element.mp3", ImageUrl = "/img/tfsu-element.webp", ProductItemId = saal.ItemId },
                        new ProductPart { Name = "Schlüsselschrank", AudioUrl = "/audio/tfsu-nycklar.mp3", ImageUrl = "/img/tfsu-nyckelskap.webp", ProductItemId = saal.ItemId },
                        new ProductPart { Name = "Haustür", AudioUrl = "/audio/tfsu-ytterdorr.mp3", ImageUrl = "/img/tfsu-ytterdorr.webp", ProductItemId = saal.ItemId },
                        new ProductPart { Name = "Spiegel", AudioUrl = "/audio/tfsu-spegel.mp3", ImageUrl = "/img/tfsu-spegel.webp", ProductItemId = saal.ItemId }
                    );
                }

                context.SaveChanges();
            }





        }
    }
}
