namespace DataModel
{
    public class AirLinesEntity
    {
        public AirLines AirLines { get; set; }
        public Pilots Pilots { get; set; }
        public Planes Planes { get; set; }
        public ServiceStaff ServiceStaff { get; set; }
        public Companies Companies { get; set; }

        public AirLinesEntity()
        {

        }
    }
}
