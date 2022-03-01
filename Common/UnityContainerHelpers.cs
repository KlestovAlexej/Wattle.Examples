using System;
using Unity;

namespace ShtrihM.Wattle3.Examples.Common
{
    public static class UnityContainerHelpers
    {
        public static T ResolveWithDefault<T>(this IUnityContainer container, Func<T> defaultValue)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (defaultValue == null)
            {
                throw new ArgumentNullException(nameof(defaultValue));
            }

            if (TryResolve<T>(container, out var result))
            {
                return result;
            }

            result = defaultValue();

            container.RegisterInstance(result, InstanceLifetime.External);

            return result;
        }

        private static bool TryResolve<T>(this IUnityContainer container, out T result)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (container.IsRegistered<T>())
            {
                result = container.Resolve<T>();

                return true;
            }

            result = default;

            return false;
        }
    }
}
