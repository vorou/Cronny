using Fixie;

namespace Cronny.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class FixieConvention : Convention
    {
        public FixieConvention()
        {
            ClassExecution.CreateInstancePerClass();
        }
    }
}