using Acme.Wattle.DomainObjects.Common;

namespace Acme.Wattle.Examples.Common;

public class WorkflowExceptionPolicy : DefaultWorkflowExceptionPolicy
{
    public WorkflowExceptionPolicy()
        : base(CommonWorkflowExceptionErrorCodesBuilder.New())
    {
    }
}