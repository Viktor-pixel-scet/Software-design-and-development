using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDevice
    {
        void ShowInfo();
        string Brand { 
            get; 
        }
        decimal Price { 
            get; 
        }
        string Specifications { 
            get; 
        }
    }

    public interface ITechFactory
    {
        string BrandName { 
            get; 
        }
        IDevice CreateLaptop();
        IDevice CreateSmartphone();
        IDevice CreateEBook();
        IDevice CreateNetbook();
        IDevice CreateTablet();
        IDevice CreateSmartwatch();
        IDevice CreateTV();
        IDevice CreateSpeaker();
        IDevice CreateCamera();
        IDevice CreateAccessory();
    }
}