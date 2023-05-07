using OnionCrafter.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
{
    //IServiceOptions debe de tener tipado
    public class UnitOfWorkSettings : IServiceOptions
    {
        public bool UseLogger { get; set; }
    }
}