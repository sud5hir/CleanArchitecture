namespace BuberDinner.Application.Common.interfaces.Services;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}