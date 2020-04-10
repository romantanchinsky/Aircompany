using Aircompany.Models;
using System.Text;
using System.Linq;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private static readonly string TO_STRING_DECORE_ELEMENT_TYPE = ", type=";

        public MilitaryType Type { get; private set; }

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            Type = type;
        }

        public override bool Equals(object obj)
        {
            if (obj is MilitaryPlane plane) 
            {
                return base.Equals(obj) &&
                       Type == plane.Type;
            }
            return false;            
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode *= HASH_SUMMAND + base.GetHashCode();
            hashCode *= HASH_SUMMAND + Type.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder stringToAdd = new StringBuilder(TO_STRING_DECORE_ELEMENT_TYPE);
            stringToAdd.Append(Type);
            stringToAdd.Append(TO_STRING_DECORE_ELEMENTS.Last());
            return base.ToString().Replace(TO_STRING_DECORE_ELEMENTS.Last(), stringToAdd.ToString());
        }        
    }
}