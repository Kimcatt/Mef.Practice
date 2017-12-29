using Mef.Practice.Service.Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mef.Practice.Shell
{
    public class CalculatorLauncher
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;


        private CalculatorLauncher()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog("Calculators"));


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


        public static void Launch(string[] args)
        {
            CalculatorLauncher p = new CalculatorLauncher(); //Composition is performed in the constructor
            String s;
            Console.WriteLine("Enter Expression:");
            while (true)
            {
                s = Console.ReadLine();
                //Console.WriteLine(s);
                Console.WriteLine(p.calculator.Calculate(s));
                Console.WriteLine("Enter Expression:");
            }


        }
    }
}
