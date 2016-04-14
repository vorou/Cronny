namespace Cronny.Tests
{
    [CronnyJob("0 0/1 * 1/1 * ? *", fireOnStart: true)]
    public class EachMinuteJobMessage
    {
    }
}