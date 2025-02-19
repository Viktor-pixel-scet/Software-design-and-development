using ClassLibrary.Models.IProne;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Factories
{
    public class IProneFactory : ITechFactory
    {
        public string BrandName => "IProne";

        public ILaptop CreateLaptop() => new IProneLaptop();
        public ISmartphone CreateSmartphone() => new IProneSmartphone();
        public ITablet CreateTablet() => new IProneTablet();
        public INetbook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();

        public ISmartwatch CreateSmartwatch() => throw new NotImplementedException();
        public ITV CreateTV() => throw new NotImplementedException();
        public ISpeaker CreateSpeaker() => throw new NotImplementedException();
        public ICamera CreateCamera() => throw new NotImplementedException();
        public IAccessory CreateAccessory() => throw new NotImplementedException();
    }
}