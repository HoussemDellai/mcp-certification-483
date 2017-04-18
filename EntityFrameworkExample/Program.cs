using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
    }

    class MeContext : DbContext
    {
        public MeContext(): base(@"Data Source=:memory:;Version=3;New=True;")
        { }

        public DbSet<Video> VideoLst { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vid = new Video()
            {
                Title = "Titel",
                Description = "Some descriptive text ..."
            };
            var meContext = new MeContext();
            meContext.VideoLst.Add(vid);
            meContext.SaveChanges();
        }
    }
}
