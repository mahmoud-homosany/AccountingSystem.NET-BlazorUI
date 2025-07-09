using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Shared
{
    public class ResultView<T>
    {
        public T? Entity { get; set; }
        public string? MSG { get; set; }
        public bool? IsSucess { get; set; }
    }
}
