using System;

namespace Homework.NamePrinter.EventsArgs
{
    public class NamePrinterEventArgs : EventArgs
    {
        public NamePrinterEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
