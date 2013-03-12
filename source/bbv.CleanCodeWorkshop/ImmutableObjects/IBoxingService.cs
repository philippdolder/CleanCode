namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    using System.Collections.Generic;

    public interface IBoxingService
    {
        Parcel Box(IEnumerable<Position> order);
    }
}