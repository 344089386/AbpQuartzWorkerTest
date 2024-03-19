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
    public class Test2Worker : QuartzBackgroundWorkerBase
    {
        public Test2Worker()
        {
            JobDetail = JobBuilder.Create<Test2Worker>().WithIdentity(nameof(Test2Worker)).Build();
            ScheduleJob = async scheduler =>
            {
                if (!await scheduler.CheckExists(JobDetail.Key))
                {
                    await scheduler.ScheduleJob(JobDetail, Trigger);
                }
            };
            Trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(Test2Worker))
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(1).RepeatForever().WithMisfireHandlingInstructionFireNow())
                .Build();
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("222222222");

            await Task.CompletedTask;
        }
    }
}
