using CSS.Application.Services.Interfaces;

namespace CSS.Application.Services;
public class CurrentTime : ICurrentTime
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;


}