using System;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document
{
    public class DomainObjectTemplateDocument : IDomainObjectTemplate
    {
        private DomainObjectTemplateDocument(
            DateTime valueDateTime, 
            long valueLong, 
            int? valueInt)
        {
            Value_DateTime = valueDateTime;
            Value_Long = valueLong;
            Value_Int = valueInt;
        }

        public readonly DateTime Value_DateTime;
        public readonly long Value_Long;
        public readonly int? Value_Int;
    }
}