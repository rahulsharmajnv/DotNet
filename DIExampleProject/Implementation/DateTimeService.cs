// Implementations
using DIExampleProject.Interfaces;

namespace DIExampleProject.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        private readonly DateTime _now;
        public DateTimeService()
        {
            _now = DateTime.Now;
        }
        public DateTime Now() => _now;
    }
}