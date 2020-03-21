using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace APBD2.Models
{
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            if (x == null || y == null)
                return false;
            return x.Imie.Equals(y.Imie) && x.Nazwisko.Equals(y.Nazwisko) && x.NumerIndeksu.Equals(y.NumerIndeksu);
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
