using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Quartz;
using Volo.Abp.Threading;

namespace Acme.BookStore
{
    public class TestWorker : QuartzBackgroundWorkerBase
    {
        public TestWorker()
        {
            JobDetail = JobBuilder.Create<TestWorker>().WithIdentity(nameof(TestWorker)).Build();
            ScheduleJob = async scheduler =>
            {
                if (!await scheduler.CheckExists(JobDetail.Key))
                {
                    await scheduler.ScheduleJob(JobDetail, Trigger);
                }
            };
            Trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(TestWorker))
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(1).RepeatForever().WithMisfireHandlingInstructionFireNow())
                .Build();
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("000000000");

            await Task.CompletedTask;
        }
    }
}
