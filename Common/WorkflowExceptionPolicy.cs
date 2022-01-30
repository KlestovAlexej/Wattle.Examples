using ShtrihM.Wattle3.DomainObjects.Common;

namespace ShtrihM.Wattle3.Examples.Common;

public class WorkflowExceptionPolicy : DefaultWorkflowExceptionPolicy
{
    public WorkflowExceptionPolicy()
        : base(CommonWorkflowExceptionErrorCodesBuilder.New())
    {
    }
}