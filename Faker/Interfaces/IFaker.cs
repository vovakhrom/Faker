using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Interfaces
{
    public interface IFaker
    {
        object Create(Type type);
    }

}