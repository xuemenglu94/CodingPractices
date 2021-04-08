using System.Collections.Generic;

namespace Singleton
{
    public class EqualityComparer : EqualityComparer<President>
    {
        public override bool Equals(President x, President y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.GetHashCode() == y.GetHashCode();
        }

        public override int GetHashCode(President obj)
        {
            return obj.GetHashCode();
        }
    }
}
