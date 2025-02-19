using ClassLibrary.Models.Huawea;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Factories
{
    public class HuaweaFactory : ITechFactory
    {
        public string BrandName => "Huawea";

        public ILaptop CreateLaptop() => new HuaweaLaptop();
        public ISmartphone CreateSmartphone() => new HuaweaSmartphone();

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