using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            this._scopeFactory = scopeFactory;
            this._mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformPublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage)!;

            switch (eventType.Event)
            {
                case "Platform_Published":
                    System.Console.WriteLine("--> Platform published Event Detected");
                    return EventType.PlatformPublished;
                default:
                    System.Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addPlatform(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                var platfromPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

                try
                {
                    var plat = _mapper.Map<Platform>(platfromPublishedDto);

                    if (!repo.ExternalPlatformExists(plat.ExTernalID))
                    {
                        repo.CreatePlatform(plat);
                        repo.SaveChanges();
                        System.Console.WriteLine("--> Platform added!");
                    }
                    else
                    {
                        System.Console.WriteLine("--> Platfrom already exists");
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"--> Could not add Platform to DB {ex.Message}");

                }
            }
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}