using PrintingHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Containers
{
    public static class GetPathFolderFactory
    {
        public static Func<IGetPathFolder> Create { get; set; }
    }
}
