using ClassLibrary.Models.Kiaomi;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Factories
{
    public class KiaomiFactory : ITechFactory
    {
        public string BrandName => "Kiaomi";

        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
        public INetbook CreateNetbook() => new KiaomiNetbook();
        public IEBook CreateEBook() => new KiaomiEBook();
        
        public ITablet CreateTablet() => throw new NotImplementedException();
        public ISmartwatch CreateSmartwatch() => throw new NotImplementedException();
        public ITV CreateTV() => throw new NotImplementedException();
        public ISpeaker CreateSpeaker() => throw new NotImplementedException();
        public ICamera CreateCamera() => throw new NotImplementedException();
        public IAccessory CreateAccessory() => throw new NotImplementedException();
    }
}