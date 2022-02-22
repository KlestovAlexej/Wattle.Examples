using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Primitives;
using System;

namespace ShtrihM.Wattle3.Examples.Common;

public class ExceptionPolicy : BaseExceptionPolicy
{
    public ExceptionPolicy(ITimeService timeService)
        : base(timeService)
    {
    }

    protected override WorkflowException DoApplyWorkflowException(WorkflowException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyWorkflowException [{exception.Message}]");

        return base.DoApplyWorkflowException(exception);
    }

    protected override void DoNotfyWorkflowException(WorkflowException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyWorkflowException [{exception.Message}]");
    }

    protected override void DoNotfyMappersException(MappersException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyMappersException [{exception.Message}]");
    }

    protected override void DoNotfyInternalException(InternalException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyInternalException [{exception.Message}]");
    }

    protected override void DoNotfyUnexpectedException(Exception exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyUnexpectedException [{exception.Message}]");
    }

    protected override WorkflowException DoApplyMappersException(MappersException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyMappersException [{exception.Message}]");

        var workflowExceptionPolicy = ServiceProviderHolder.Instance.GetRequiredService<IWorkflowExceptionPolicy>();
        var result =
            workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                exception.Message,
                exception.ToString());

        return result;
    }

    protected override WorkflowException DoApplyInternalException(InternalException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyInternalException [{exception.Message}]");

        var workflowExceptionPolicy = ServiceProviderHolder.Instance.GetRequiredService<IWorkflowExceptionPolicy>();
        var result =
            workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                exception.Message,
                exception.ToString());

        return result;
    }

    protected override WorkflowException DoApplyUnexpectedException(Exception exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyUnexpectedException [{exception.Message}]");

        var workflowExceptionPolicy = ServiceProviderHolder.Instance.GetRequiredService<IWorkflowExceptionPolicy>();
        var result =
            workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                exception.Message,
                exception.ToString());

        return result;
    }
}
