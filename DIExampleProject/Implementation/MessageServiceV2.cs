using DIExampleProject.Interfaces;

namespace DIExampleProject.Implementation
{
    public class MessageServiceV2 : IMessageServiceV2
    {
        private readonly IGuidService _guidService;
        private readonly IDateTimeService _dateTimeService;

        public MessageServiceV2(IGuidService guidService, IDateTimeService dateTimeService)
        {
            _guidService = guidService;
            _dateTimeService = dateTimeService;
        }

        public string GetMessage() => $"Time: {_dateTimeService.Now()}, GUID: {_guidService.GetGuid()}";
    }
}