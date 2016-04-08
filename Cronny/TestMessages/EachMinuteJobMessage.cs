namespace Cronny.TestMessages
{
    //TODO: move it to test project
    [CronnyJob("0 0/1 * 1/1 * ? *", fireOnStart: true)]
    public class EachMinuteJobMessage
    {
    }
}