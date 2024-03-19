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
    public class Test1Worker : QuartzBackgroundWorkerBase
    {
        public Test1Worker()
        {
            JobDetail = JobBuilder.Create<Test1Worker>().WithIdentity(nameof(Test1Worker)).Build();
            ScheduleJob = async scheduler =>
            {
                if (!await scheduler.CheckExists(JobDetail.Key))
                {
                    await scheduler.ScheduleJob(JobDetail, Trigger);
                }
            };
            Trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(Test1Worker))
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(1).RepeatForever().WithMisfireHandlingInstructionFireNow())
                .Build();
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("1111111");

            await Task.CompletedTask;
        }
    }
}
