﻿using BankService.Card;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Attribute
{
    /// <summary>
    /// AllowMultiple = false,代表一个类不允许多次使用此属性
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCardAttribute : ExportAttribute
    {
        public ExportCardAttribute() : base(typeof(ICard))
        {

        }

        public string CardType { get; set; }
    }
}
