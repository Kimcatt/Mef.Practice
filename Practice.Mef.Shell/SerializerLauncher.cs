using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Dynamic;

namespace Practice.Mef.Shell
{
    public class SerializerLauncher
    {
        private CompositionContainer _container;

        [Import]
        public Service.Serialization.ISerializer Serializer { get; set; }

        public SerializerLauncher()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog("Serializers"));


            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        public static void Launch()
        {
            WriteLine("Serializer shell running...", ConsoleColor.Green);
            var v = new Dictionary<string, string>();
            v.Add("A", "a");
            Console.WriteLine(new SerializerLauncher().Serializer.Serialize(v));
            Console.WriteLine(new { Name = "Kimcatt", Loc = "ShangHai" });
        }
    

        private static void WriteLine(string s, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(s);
            Console.ForegroundColor = color;
        }

    }
}
