using Quartz;

namespace Cronny
{
    public class SendMessageJob<TMessage> : IJob where TMessage : class, new()
    {
        public void Execute(IJobExecutionContext context)
        {
            CronnyControl.Bus.Publish(new TMessage());
        }
    }
}