namespace WebApp.Common.Application
{
    using System.Threading.Tasks;
    using WebApp.Common.Domain;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
