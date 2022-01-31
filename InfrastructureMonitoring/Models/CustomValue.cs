using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Json.ValueData;

namespace ShtrihM.Wattle3.Examples.InfrastructureMonitoring.Models;

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