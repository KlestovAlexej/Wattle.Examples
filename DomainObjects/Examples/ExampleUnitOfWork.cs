using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;
using ShtrihM.Wattle3.Mappers.Primitives;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples
{
    public class ExampleUnitOfWork : BaseUnitOfWork
    {
        public ExampleUnitOfWork(
            UnitOfWorkContext unitOfWorkContext,
            ProxyDomainObjectRegisters registers,
            IUnitOfWorkVisitor visitor,
            bool addStackTrace)
            : base(
                unitOfWorkContext,
                registers,
                visitor,
                addStackTrace)
        {
        }

        protected override async ValueTask<IUnitOfWorkCommitVerifying> DoCreateUnitOfWorkCommitVerifyingAsync(
            CancellationToken cancellationToken = default)
        {
            var register = Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
            var domainObject = await register.NewAsync(DomainObjectTemplateChangeTracker.Instance, cancellationToken).ConfigureAwait(false);
            var result = DoCreateUnitOfWorkCommitVerifying(domainObject.Identity);

            return result;
        }

        protected override IUnitOfWorkCommitVerifying DoCreateUnitOfWorkCommitVerifying()
        {
            var register = Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
            var identity = register.New(DomainObjectTemplateChangeTracker.Instance).Identity;
            var result = DoCreateUnitOfWorkCommitVerifying(identity);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IUnitOfWorkCommitVerifying DoCreateUnitOfWorkCommitVerifying(long identity)
        {
            var result =
                new UnitOfWorkCommitVerifyingDelegate(
                    mappersSessionProvider =>
                    {
                        var entryPoint = (ExampleEntryPoint)ServiceProviderHolder.Instance.GetRequiredService<IEntryPoint>();
                        var mapper = entryPoint.Mappers.GetMapper<IMapperChangeTracker>();
                        var mappersSession = mappersSessionProvider.GetMappersSession();
                        var existsRaw = mapper.ExistsRaw(mappersSession, identity);

                        return (existsRaw ? UnitOfWorkCommitVerifyingResult.Successfully : UnitOfWorkCommitVerifyingResult.Fail);
                    },
                    async mappersSessionProvider =>
                    {
                        var entryPoint = (ExampleEntryPoint)ServiceProviderHolder.Instance.GetRequiredService<IEntryPoint>();
                        var mapper = entryPoint.Mappers.GetMapper<IMapperChangeTracker>();
                        var mappersSession = await mappersSessionProvider.GetMappersSessionAsync().ConfigureAwait(false);
                        var existsRaw = await mapper.ExistsRawAsync(mappersSession, identity).ConfigureAwait(false);

                        return (existsRaw ? UnitOfWorkCommitVerifyingResult.Successfully : UnitOfWorkCommitVerifyingResult.Fail);
                    });

            return result;
        }
    }
}
