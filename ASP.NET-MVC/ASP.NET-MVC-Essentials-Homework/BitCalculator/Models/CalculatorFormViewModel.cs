using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitCalculator.Models
{
    public class CalculatorFormViewModel
    {
        private IList units;

        public CalculatorFormViewModel()
        {
            this.Units = new List<StorageUnit>
                             {
                                 new StorageUnit
                                     {
                                         Name = "Bit",
                                         Value = 1.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Byte",
                                         Value = 8.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Kilobit",
                                         Value = 1000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Kilobyte",
                                         Value = 8000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Megabit",
                                         Value = 1000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Megabyte",
                                         Value = 8000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Gigabit",
                                         Value = 1000000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Gigabyte",
                                         Value = 8000000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Terabit",
                                         Value = 1000000000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Terabyte",
                                         Value = 8000000000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Petabit",
                                         Value = 1000000000000000.0m
                                     },
                                 new StorageUnit
                                     {
                                         Name = "Petabyte",
                                         Value = 8000000000000000.0m
                                     }
                             };
        }

        public IList Units
        {
            get
            {
                return this.units;
            }

            set
            {
                this.units = value;
            }
        }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public string Kilo { get; set; }
    }
}