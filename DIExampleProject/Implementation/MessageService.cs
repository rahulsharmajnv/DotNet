using DIExampleProject.Interfaces;

namespace DIExampleProject.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IGuidService _guidService;
        private readonly IDateTimeService _dateTimeService;

        public MessageService(IGuidService guidService, IDateTimeService dateTimeService)
        {
            _guidService = guidService;
            _dateTimeService = dateTimeService;
        }

        public string GetMessage() => $"Time: {_dateTimeService.Now()}, GUID: {_guidService.GetGuid()}";
    }
}