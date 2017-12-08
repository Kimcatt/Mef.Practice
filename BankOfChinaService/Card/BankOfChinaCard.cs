using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using BankService.Card;
using BankService.Attribute;

namespace BankOfChinaService.Card
{
    //[Export(typeof(ICard))]
    [ExportCard(CardType = "BankOfChina")]
    public class BankOfChinaCard : BankService.Card.ICard
    {
        private double money = 3000;

        public double Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public string GetCountInfo()
        {
            return $"{nameof(BankOfChinaCard)}#{this.GetHashCode()}";
        }

        public void SaveMoney(double money)
        {
            this.money += money;
        }

        public void WithdrawMoney(double money)
        {
            this.money -= money;
        }
    }
}
