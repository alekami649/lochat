using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochat.Utilities;

public static class ArrayUtilities
{
    public static bool InRange(this object obj, params object[] array)
    {
        return array.Contains(obj);
    }
}
