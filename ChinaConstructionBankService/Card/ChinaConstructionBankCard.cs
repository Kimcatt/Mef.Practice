using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using BankService.Attribute;

namespace ChinaConstructionBankService.Card
{
    [ExportCard(CardType = "ChinaConstructionBank")]
    public class ChinaConstructionBankCard : BankService.Card.ICard
    {
        private double money = 1000;

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
            return $"{nameof(ChinaConstructionBankCard)}#{this.GetHashCode()}";
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
