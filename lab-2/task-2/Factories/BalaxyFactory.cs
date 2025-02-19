using ClassLibrary.Models.Balaxy;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Factories
{
    public class BalaxyFactory : ITechFactory
    {
        public string BrandName => "Balaxy";

        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public ISmartphone CreateSmartphone() => new BalaxySmartphone();
        public INetbook CreateNetbook() => new BalaxyNetbook();
        public IEBook CreateEBook() => new BalaxyEBook();

        public ITablet CreateTablet() => throw new NotImplementedException();
        public ISmartwatch CreateSmartwatch() => throw new NotImplementedException();
        public ITV CreateTV() => throw new NotImplementedException();
        public ISpeaker CreateSpeaker() => throw new NotImplementedException();
        public ICamera CreateCamera() => throw new NotImplementedException();
        public IAccessory CreateAccessory() => throw new NotImplementedException();
    }
}