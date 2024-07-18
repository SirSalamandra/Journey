using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete
{
    public class DeleteTripByIdUseCase
    {
        public void Execute(Guid id)
        {
            var context = new JourneyDbContext();

            var trip = context
                .Trips
                .Include(x => x.Activities)
                .FirstOrDefault(x => x.Id == id);

            if (trip is null)
            {
                throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
            }

            context.Trips.Remove(trip);
            context.SaveChanges();
        }
    }
}
