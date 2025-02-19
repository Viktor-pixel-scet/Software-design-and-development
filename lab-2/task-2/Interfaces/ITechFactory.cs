using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_2;

namespace Interfaces
{
    public interface ITechFactory
    {
        string BrandName { get; }
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
        ITablet CreateTablet();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartwatch CreateSmartwatch();
        ITV CreateTV();
        ISpeaker CreateSpeaker();
        ICamera CreateCamera();
        IAccessory CreateAccessory();
    }
}
