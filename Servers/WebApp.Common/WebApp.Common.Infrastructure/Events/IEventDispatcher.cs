namespace WebApp.Common.Infrastructure.Events
{
    using System.Threading.Tasks;
    using WebApp.Common.Domain;

    internal interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
