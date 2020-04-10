using System.Collections.Generic;
using System.Text;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        protected static string[] TO_STRING_DECORE_ELEMENTS = { "Plane{", "model='", "', maxSpeed=", ", maxFlightDistance=", ", maxLoadCapacity=", "}" };

        protected const int HASH_SUMMAND = -1521134295;

        public string Model { get; private set; }
        public int MaxSpeed { get; private set; }
        public int MaxFlightDistance { get; private set; }
        public int MaxLoadCapacity { get; private set; }

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            Model = model;
            MaxSpeed = maxSpeed;
            MaxFlightDistance = maxFlightDistance;
            MaxLoadCapacity = maxLoadCapacity;
        }

        public override string ToString()
        {
            StringBuilder outString = new StringBuilder(TO_STRING_DECORE_ELEMENTS[0]);
            outString.Append(TO_STRING_DECORE_ELEMENTS[1]);
            outString.Append(Model);
            outString.Append(TO_STRING_DECORE_ELEMENTS[2]);
            outString.Append(MaxSpeed);
            outString.Append(TO_STRING_DECORE_ELEMENTS[3]);
            outString.Append(MaxFlightDistance);
            outString.Append(TO_STRING_DECORE_ELEMENTS[4]);
            outString.Append(MaxLoadCapacity);
            outString.Append(TO_STRING_DECORE_ELEMENTS[5]);
            return outString.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Plane plane)
            {
                return Model == plane.Model &&
                       MaxSpeed == plane.MaxSpeed &&
                       MaxFlightDistance == plane.MaxFlightDistance &&
                       MaxLoadCapacity == plane.MaxLoadCapacity;
            }
                return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode *= HASH_SUMMAND + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode *= HASH_SUMMAND + MaxSpeed.GetHashCode();
            hashCode *= HASH_SUMMAND + MaxFlightDistance.GetHashCode();
            hashCode *= HASH_SUMMAND + MaxLoadCapacity.GetHashCode();
            return hashCode;
        }        
    }
}