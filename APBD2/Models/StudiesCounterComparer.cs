using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace APBD2.Models
{
    class StudiesCounterComparer : IEqualityComparer<StudiesCounter>
    {
        public bool Equals([AllowNull] StudiesCounter x, [AllowNull] StudiesCounter y)
        {
            if (x == null || y == null)
                return false;
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode([DisallowNull] StudiesCounter obj)
        {
            return obj.GetHashCode();
        }
    }
}
