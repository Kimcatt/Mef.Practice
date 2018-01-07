using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using BankService.Card;
using System.ComponentModel.Composition.Hosting;

namespace Practice.Mef.Shell
{
    class Program
    {

        //[ImportMany(typeof(ICard))]
        //public IEnumerable<ICard> Cards { get; set; }

        //其中AllowRecomposition=true参数就表示运行在有新的部件被装配成功后进行部件集的重组.
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<ICard, IMetaData>> Cards { get; set; }

        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            WriteLine("All cards provided...", ConsoleColor.Green);
            foreach (var c in pro.Cards)
            {
                Console.WriteLine("" + c.Value.GetCountInfo());
            }

            foreach(var item in pro.Cards)
            {
                if (item.Metadata.CardType == "BankOfChina")
                {
                    WriteLine("Bank Service provided by Bank Of China...", ConsoleColor.Green);
                    ICard card = item.Value;
                    Console.WriteLine("Acount original: $" + card.Money);
                    Console.WriteLine("Acount save money: $" + 100);
                    card.SaveMoney(100);
                    Console.WriteLine("Acount balance: $" + card.Money);
                    Console.WriteLine("Acount withdraw money: $" + 200);
                    card.WithdrawMoney(200);
                    Console.WriteLine("Acount balance: $" + card.Money);
                }
                else if (item.Metadata.CardType == "ChinaConstructionBank")
                {
                    WriteLine("Bank Service provided by China Construction Bank...", ConsoleColor.Green);
                    ICard card = item.Value;
                    Console.WriteLine("Acount original: $" + card.Money);
                    Console.WriteLine("Acount save money: $" + 100);
                    card.SaveMoney(100);
                    Console.WriteLine("Acount balance: $" + card.Money);
                    Console.WriteLine("Acount withdraw money: $" + 200);
                    card.WithdrawMoney(200);
                    Console.WriteLine("Acount balance: $" + card.Money);
                }
            }


            SerializerLauncher.Launch();
            //Calculator demo
            CalculatorLauncher.Launch(null);

            Console.Read();
        }

        private static void WriteLine(string s, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            ConsoleColor color = Console.ForegroundColor;    
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(s);
            Console.ForegroundColor = color;
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog("Cards");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
