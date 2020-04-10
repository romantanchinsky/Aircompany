using System.Linq;
using System.Text;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private static readonly string TO_STRING_DECORE_ELEMENT_PASSENGERS_CAPACITY = ", passengersCapacity=";

        public int PassengersCapacity { get; private set; }

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            PassengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            if (obj is PassengerPlane plane)
            {
                return base.Equals(obj) &&
                       PassengersCapacity == plane.PassengersCapacity;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode *= HASH_SUMMAND + base.GetHashCode();
            hashCode *= HASH_SUMMAND + PassengersCapacity.GetHashCode();
            return hashCode;
        }
       
        public override string ToString()
        {
            StringBuilder stringToAdd = new StringBuilder(TO_STRING_DECORE_ELEMENT_PASSENGERS_CAPACITY);
            stringToAdd.Append(PassengersCapacity);
            stringToAdd.Append(TO_STRING_DECORE_ELEMENTS.Last());
            return base.ToString().Replace(TO_STRING_DECORE_ELEMENTS.Last(), stringToAdd.ToString());
        }               
    }
}