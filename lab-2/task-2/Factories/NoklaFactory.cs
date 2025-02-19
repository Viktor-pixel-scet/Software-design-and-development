using ClassLibrary.Models.Nokla;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Factories
{
    public class NoklaFactory : ITechFactory
    {
        public string BrandName => "Nokla";

        public ILaptop CreateLaptop() => new NoklaLaptop();
        public ISmartphone CreateSmartphone() => new NoklaSmartphone();

        public ITablet CreateTablet() => throw new NotImplementedException();
        public INetbook CreateNetbook() => throw new NotImplementedException();
        public IEBook CreateEBook() => throw new NotImplementedException();
        public ISmartwatch CreateSmartwatch() => throw new NotImplementedException();
        public ITV CreateTV() => throw new NotImplementedException();
        public ISpeaker CreateSpeaker() => throw new NotImplementedException();
        public ICamera CreateCamera() => throw new NotImplementedException();
        public IAccessory CreateAccessory() => throw new NotImplementedException();
    }
}