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
        }
    }
}
