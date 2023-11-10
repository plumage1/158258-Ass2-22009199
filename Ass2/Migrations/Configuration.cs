using System.Web.Security;

namespace Ass2.Migrations
{
    using System;
    using System.Data.Entity;
    using Ass2.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Drawing;

    using System.Threading;

    internal sealed class Configuration : DbMigrationsConfiguration<Ass2.Data.Ass2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ass2.Data.Ass2Context";
        }

        protected override void Seed(Ass2.Data.Ass2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var destinies = new List<Destiny>
 {
 new Destiny {Name = "Memory",Description = "The Star God \"Fuli\" in Charge of Memory" },
 new Destiny {Name = "Abundant",Description ="Pharmacist - Abundant Destiny" },
 new Destiny {Name = "Conservation", Description ="Kriper - The Destiny of Conservation"},
 new Destiny {Name = "Destruction", Description = "Nanuk - The Destiny of Destruction"},
 new Destiny {Name = "Harmony" , Description ="Xi Pei-The Destiny of Harmony"},
 new Destiny {Name = "Hunting" , Description ="Lan - The Destiny of Hunting"},
 new Destiny {Name = "Nothingness" , Description ="IX - The Destiny of Nothingness"},
 new Destiny {Name = "Wisdom" , Description ="The Fate of Wisdom\r\n"},
  };
            destinies.ForEach(c => context.Destinies.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var characters = new List<Characters>
            {
            new Characters { Name = "Topaz and Numby", Description = "\tOctober 27, 2023.Topa, a senior cadre of the Strategic Investment Department under Starpeace Corporation,leads the Special Debt Inspection Group.", DestinyID = destinies.Single(c => c.Name == "Hunting").ID },
            new Characters { Name = "Jingliu", Description = "\tOctober 11, 2023. The former Luofu Sword Head was the famous founder of the Cloud Cavalry Army, which was undefeated.", DestinyID = destinies.Single(c => c.Name == "Destruction").ID },
            new Characters { Name = "Fu Xuan", Description = "September 20, 2023.The head of the Divine Boat \"Luo Fu\" Tai Bu Si..", DestinyID = destinies.Single(c => c.Name == "Conservation").ID },
            new Characters { Name = "Dan Heng • Imbibitor Lunae", Description = "August 30, 2023.The unknown nature of Dan Heng, inheriting the power of Yin Yuejun as a wise body.", DestinyID = destinies.Single(c => c.Name == "Destruction").ID },
            new Characters { Name = "Kafka", Description = "August 9th, 2023.A member of the Star Core Hunter, a hunter of Tianyi V.", DestinyID = destinies.Single(c => c.Name == "Nothingness").ID },
            new Characters { Name = "Blade", Description = "July 19, 2023.A member of the Star Core Hunter, a swordsman who abandoned his blade.", DestinyID = destinies.Single(c => c.Name == "Destruction").ID },
            new Characters { Name = "Luocha", Description = "June 28, 2023.Golden haired and elegant Tian Wai Shang.", DestinyID = destinies.Single(c => c.Name == "Abundant").ID },
            new Characters { Name = "Silver Wolf", Description = "June 7th, 2023.The Super Hacker of Star Core Hunter.", DestinyID = destinies.Single(c => c.Name == "Nothingness").ID },
            new Characters { Name = "Jing Yuan", Description = "May 17, 2023.One of the Seven Heavenly Generals of Emperor Bow.", DestinyID = destinies.Single(c => c.Name == "Wisdom").ID },
            new Characters { Name = "Yanqing", Description = "\tApril 26, 2023.Sword Child Martial Bone.", DestinyID = destinies.Single(c => c.Name == "Hunting").ID },
            new Characters { Name = "Bailu", Description = "\tApril 26, 2023.the Little Ghost's \"Dragon Girl Carrying Medicine\".", DestinyID = destinies.Single(c => c.Name == "Abundant").ID },
            new Characters { Name = "Himeko", Description = "April 26, 2023.The navigator of the Star Dome train.", DestinyID = destinies.Single(c => c.Name == "Wisdom").ID },
            new Characters { Name = "Gepard", Description = "April 26, 2023.Silver Maned Iron Garrison Officer.", DestinyID = destinies.Single(c => c.Name == "Conservation").ID },
        };
            characters.ForEach(c => context.Characters.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
}

}

        
    

