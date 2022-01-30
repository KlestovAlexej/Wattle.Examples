using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers;

namespace ShtrihM.Wattle3.Examples.Common;

public class ExceptionPolicy : BaseExceptionPolicy
{
    private readonly IWorkflowExceptionPolicy m_workflowExceptionPolicy;

    public ExceptionPolicy(
        ITimeService timeService,
        IWorkflowExceptionPolicy workflowExceptionPolicy,
        ILogger logger = null)
        : base(timeService, logger)
    {
        m_workflowExceptionPolicy =
            workflowExceptionPolicy ?? throw new ArgumentNullException(nameof(workflowExceptionPolicy));
    }

    protected override WorkflowException DoApplyMappersException(MappersException exception)
    {
        var result =
            m_workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                exception.Message,
                exception.ToString());

        return result;
    }

    protected override WorkflowException DoApplyInternalException(InternalException exception)
    {
        var result =
            m_workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                exception.Message,
                exception.ToString());

        return result;
    }

    protected override WorkflowException DoApplyUnexpectedException(Exception exception)
    {
        var result =
            m_workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                exception.Message,
                exception.ToString());

        return result;
    }
}
