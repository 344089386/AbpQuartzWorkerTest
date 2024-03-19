﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Acme.BookStore;

public class BookStoreHostedService : IHostedService
{
    private readonly IAbpApplicationWithExternalServiceProvider _abpApplication;
    private readonly HelloWorldService _helloWorldService;

    public BookStoreHostedService(HelloWorldService helloWorldService, IAbpApplicationWithExternalServiceProvider abpApplication)
    {
        _helloWorldService = helloWorldService;
        _abpApplication = abpApplication;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _helloWorldService.SayHelloAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _abpApplication.ShutdownAsync();
    }
}
