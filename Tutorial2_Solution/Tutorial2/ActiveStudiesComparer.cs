using System;
using System.Collections.Generic;
using System.Text;
using Tutorial2.Models;

namespace Tutorial2
{
    public class ActiveStudiesComparer: IEqualityComparer<ActiveStudies>
    {
        public bool Equals(ActiveStudies x, ActiveStudies y)
        {
            //We use the class StringComparer to compare our objects
            //In the method Equals of the class StringComparer we create to strings from our objects
            //which will be compared
            return StringComparer
                        .InvariantCultureIgnoreCase
                        .Equals($"{x.Name}",
                                $"{y.Name}");
        }

        public int GetHashCode(ActiveStudies obj)
        {
            return StringComparer.
                    CurrentCultureIgnoreCase
                    .GetHashCode($"{obj.Name}");
        }
    }
}
