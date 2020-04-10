using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aircompany
{
    public class Airport
    {
        private static readonly string[] TO_STRING_DECORE_ELEMENTS = { "Airport{planes=", ", ", "}" };

        private List<Plane> _planes;
        public IEnumerable<Plane> Planes
        {
            get => _planes;
            private set => _planes = value.ToList();
        }


        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return _planes.Where(plane => plane is PassengerPlane).Select(plane => (PassengerPlane)plane).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.Where(plane => plane is MilitaryPlane).Select(plane => (MilitaryPlane)plane).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((firstPlane, secondPlane) => firstPlane.PassengersCapacity > secondPlane.PassengersCapacity ? firstPlane : secondPlane);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(plane => plane.Type == MilitaryType.TRANSPORT).ToList();
        }

        public Airport GetAirportSortedByMaxDistance()
        {
            return new Airport(_planes.OrderBy(plane => plane.MaxFlightDistance));
        }

        public Airport GetAirportSortedSortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(plane => plane.MaxSpeed));
        }

        public Airport GetAirportSortedSortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(plane => plane.MaxLoadCapacity));
        }

        public override string ToString()
        {
            StringBuilder outString = new StringBuilder(TO_STRING_DECORE_ELEMENTS[0]);
            outString.Append(string.Join(TO_STRING_DECORE_ELEMENTS[1], _planes.Select(plane => plane.Model)));
            outString.Append(TO_STRING_DECORE_ELEMENTS[2]);
            return outString.ToString();
        }
    }
}