using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace RemontUnderKey.DependencyInjection.Interfaces
{
    public interface IModule
    {
        void Register(IUnityContainer container);
    }
}