using DataAccessLayer.Concrete;
using TravelerCoreProject.CQRS.Commands.DestinationCommands;

namespace TravelerCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        //güncelleme metodu:
        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.DayNight = command.Daynight;
            values.Price= command.Price;
            values.Capacity = command.Capacity;
            _context.SaveChanges();
        }
    }
}
