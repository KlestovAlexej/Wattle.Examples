using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.Wattle3.Examples.Common;

public class ExceptionPolicy : BaseExceptionPolicy
{
    public ExceptionPolicy(ITimeService timeService)
        : base(timeService)
    {
    }

    protected override ValueTask<WorkflowException> DoApplyWorkflowExceptionAsync(WorkflowException exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyWorkflowExceptionAsync [{exception.Message}]");

        return base.DoApplyWorkflowExceptionAsync(exception, cancellationToken);
    }

    protected override WorkflowException DoApplyWorkflowException(WorkflowException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyWorkflowException [{exception.Message}]");

        return base.DoApplyWorkflowException(exception);
    }

    protected override ValueTask<WorkflowException> DoApplyUnexpectedExceptionAsync(Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyUnexpectedExceptionAsync [{exception.Message}]");

        return base.DoApplyUnexpectedExceptionAsync(exception, cancellationToken);
    }

    protected override ValueTask<WorkflowException> DoApplyMappersExceptionAsync(MappersException exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyMappersExceptionAsync [{exception.Message}]");

        return base.DoApplyMappersExceptionAsync(exception, cancellationToken);
    }

    protected override ValueTask<WorkflowException> DoApplyInternalExceptionAsync(InternalException exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoApplyInternalExceptionAsync [{exception.Message}]");

        return base.DoApplyInternalExceptionAsync(exception, cancellationToken);
    }

    protected override ValueTask DoNotfyWorkflowExceptionAsync(WorkflowException exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyWorkflowExceptionAsync [{exception.Message}]");

        return base.DoNotfyWorkflowExceptionAsync(exception, cancellationToken);
    }

    protected override void DoNotfyWorkflowException(WorkflowException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyWorkflowException [{exception.Message}]");

        base.DoNotfyWorkflowException(exception);
    }

    protected override ValueTask DoNotfyMappersExceptionAsync(MappersException exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyMappersExceptionAsync [{exception.Message}]");

        return base.DoNotfyMappersExceptionAsync(exception, cancellationToken);
    }

    protected override void DoNotfyMappersException(MappersException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyMappersException [{exception.Message}]");

        base.DoNotfyMappersException(exception);
    }

    protected override ValueTask DoNotfyInternalExceptionAsync(InternalException exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyInternalExceptionAsync [{exception.Message}]");

        return base.DoNotfyInternalExceptionAsync(exception, cancellationToken);
    }

    protected override void DoNotfyInternalException(InternalException exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyInternalException [{exception.Message}]");

        base.DoNotfyInternalException(exception);
    }

    protected override ValueTask DoNotfyUnexpectedExceptionAsync(Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyUnexpectedExceptionAsync [{exception.Message}]");

        return base.DoNotfyUnexpectedExceptionAsync(exception, cancellationToken);
    }

    protected override void DoNotfyUnexpectedException(Exception exception)
    {
        Console.WriteLine($"ExceptionPolicy.DoNotfyUnexpectedException [{exception.Message}]");

        base.DoNotfyUnexpectedException(exception);
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
