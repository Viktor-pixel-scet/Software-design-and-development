using Interfaces;
using System;

namespace ClassLibrary.Models
{
    public abstract class BaseDevice : IDevice
    {
        protected string brand;
        protected decimal price;
        protected string specifications;

        public string Brand => brand;
        public decimal Price => price;
        public string Specifications => specifications;

        public abstract void ShowInfo();
    }
}