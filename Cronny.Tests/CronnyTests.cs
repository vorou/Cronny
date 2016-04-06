using System;
using System.Threading;
using Shouldly;

namespace Cronny.Tests
{
    public class CronnyTests
    {
        public void Canary()
        {
            true.ShouldBe(true);
        }

        // public void Run_MessageShouldBeSentEachMinute_ShouldReceiveIt()
        // {
        //     var resetEvent = new ManualResetEventSlim();
        //     CronnyControl.Bus.Subscribe<EachMinuteJobMessage>("test", m => resetEvent.Set());
        //     CronnyControl.Run();
        //     try
        //     {
        //         Should.CompleteIn(() => resetEvent.Wait(), TimeSpan.FromMinutes(2));
        //     }
        //     finally
        //     {
        //         CronnyControl.Bus.Dispose();
        //     }
        // }
    }
}
