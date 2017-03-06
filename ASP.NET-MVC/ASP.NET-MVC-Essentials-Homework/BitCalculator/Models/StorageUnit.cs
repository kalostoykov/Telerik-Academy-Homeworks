using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitCalculator.Models
{
    public class StorageUnit
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        [DisplayFormat(DataFormatString = "{0:G8}", ApplyFormatInEditMode = true)]
        public decimal RelativeValue { get; set; }
    }
}