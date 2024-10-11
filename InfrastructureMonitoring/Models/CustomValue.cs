using Acme.Wattle.Json.Extensions;
using Acme.Wattle.Json.ValueData;

namespace Acme.Wattle.Examples.InfrastructureMonitoring.Models;

/// <summary>
/// Произвольное значение в снимке.
/// </summary>
public class CustomValue
{
    // ReSharper disable once UnusedMember.Global
    [ValueData(typeof(CustomValue))]
    [JsonTypeIdEx(nameof(CustomValue))]
    public sealed class ValueData : TypedValueData<CustomValue>
    {
        public ValueData(CustomValue data)
            : base(nameof(CustomValue), data)
        {
        }
    }

    public int Value1;
    public string Value2;
    public byte[] Value3;
}