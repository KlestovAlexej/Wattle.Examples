using NUnit.Framework;
using ShtrihM.Wattle3.Containers;

namespace ShtrihM.Wattle3.Examples.Containers;

/// <summary>
/// Примеры массива элементов неограниченного размера с возможностью сортировки и поиска.
/// </summary>
[TestFixture]
public class ExamplesFlexIncrementArrayOrderedElements
{
    /// <summary>
    /// Основные функции.
    /// </summary>
    [Test]
    public void Example()
    {
        var array = new FlexIncrementArrayOrderedElements<int>(new FlexIncrementArrayOptions(10_000_00, 10));
        Assert.AreEqual(0, array.Length);

        // Выделяем память.
        array.Expand(4);

        // Чтение и запись в позицию.
        array[0] = 4;
        array[1] = 1;
        array[2] = 7;
        array[3] = 8;
        Assert.AreEqual(4, array[0]);
        Assert.AreEqual(1, array[1]);
        Assert.AreEqual(7, array[2]);
        Assert.AreEqual(8, array[3]);

        // Сортировка элементов от меньшего к большему
        array.Sort();
        Assert.AreEqual(1, array[0]);
        Assert.AreEqual(4, array[1]);
        Assert.AreEqual(7, array[2]);
        Assert.AreEqual(8, array[3]);

        Assert.AreEqual(0, array.BinarySearch(1));
        Assert.AreEqual(1, array.BinarySearch(4));
        Assert.AreEqual(2, array.BinarySearch(7));
        Assert.AreEqual(3, array.BinarySearch(8));
        Assert.Greater(0, array.BinarySearch(1000000));
    }
}
