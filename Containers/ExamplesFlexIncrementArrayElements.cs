using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.Containers;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Testing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;

namespace ShtrihM.Wattle3.Examples.QueueProcessors;

/// <summary>
/// Примеры массива элементов неограниченного размера.
/// </summary>
[TestFixture]
public class ExamplesFlexIncrementArrayElements
{
    /// <summary>
    /// Выделение памяти для элементов - byte.
    /// </summary>
    [Test]
    [TestCase(4_000_000_000, Description = "Выделяем 4 ГБ памяти")]
    [TestCase(30_000_000_000, Description = "Выделяем 30 ГБ памяти")]
    public void Example_Byte_Expand(long size)
    {
        BaseTests.GcCollectMemory();
        var step1Memory = GC.GetTotalMemory(true);

        var sw = Stopwatch.StartNew();

        var array = new FlexIncrementArrayElements<byte>(new FlexIncrementArrayOptions(10_000_00, 10));
        Assert.AreEqual(0, array.Length);

        // Выделяем память.
        array.Expand(size);

        Assert.AreEqual(size, array.Length);
        sw.Stop();
        var step2Memory = GC.GetTotalMemory(true);
        Console.WriteLine($"Элементов массива типа byte : {array.Length:##,###}");
        Console.WriteLine($"Выделено памяти (байт)      : {(step2Memory - step1Memory):##,###}");
        Console.WriteLine($"Время                       : {sw.Elapsed}");
    }

    /// <summary>
    /// Выделение памяти для элементов - Guid.
    /// </summary>
    [Test]
    [TestCase(1_000_000_000, Description = "Выделяем 17 ГБ памяти")]
    [TestCase(3_000_000_000, Description = "Выделяем 51 ГБ памяти")]
    public void Example_Guid_Expand(long size)
    {
        BaseTests.GcCollectMemory();
        var step1Memory = GC.GetTotalMemory(true);

        var sw = Stopwatch.StartNew();

        var array = new FlexIncrementArrayElements<Guid>(new FlexIncrementArrayOptions(10_000_00, 10));
        Assert.AreEqual(0, array.Length);

        // Выделяем память.
        array.Expand(size);

        Assert.AreEqual(size, array.Length);
        sw.Stop();
        var step2Memory = GC.GetTotalMemory(true);
        Console.WriteLine($"Элементов массива типа Guid : {array.Length:##,###}");
        Console.WriteLine($"Выделено памяти (байт)      : {(step2Memory - step1Memory):##,###}");
        Console.WriteLine($"Время                       : {sw.Elapsed}");
    }

    /// <summary>
    /// Заполнение памяти и сравнение с byte[].
    /// </summary>
    [Test]
    [TestCase(100_000_000, Description = "Выделяем 100 МБ памяти - время теста примерно 4 минуты.")]
    public void Example_Byte_Compare(long size)
    {
        // Тест FlexIncrementArrayElements
        {
            Console.WriteLine("Тест FlexIncrementArrayElements");
            Console.WriteLine();

            var sw = Stopwatch.StartNew();

            var array = new FlexIncrementArrayElements<byte>(new FlexIncrementArrayOptions(10_000_00, 10));
            Assert.AreEqual(0, array.Length);

            // Выделяем память.
            array.Expand(size);

            Assert.AreEqual(size, array.Length);
            sw.Stop();
            Console.WriteLine($"Элементов массива      : {array.Length:##,###}");
            Console.WriteLine($"Выделено памяти (байт) : {array.Length:##,###}");
            Console.WriteLine($"Время                  : {sw.Elapsed}");
            Console.WriteLine();

            sw = Stopwatch.StartNew();

            // Заполняем память
            Parallel.For(0L, array.Length, i => array[i] = (byte)(i & 0xFF));

            sw.Stop();
            Console.WriteLine($"Время заполнения памяти : {sw.Elapsed}");
            Console.WriteLine();

            sw = Stopwatch.StartNew();

            // Проверяем память
            Parallel.For(0L, array.Length, i => Assert.AreEqual((byte)(i & 0xFF), array[i]));

            sw.Stop();
            Console.WriteLine($"Время проверки памяти : {sw.Elapsed}");

            sw = Stopwatch.StartNew();

            // Проверяем память
            var index = 0;
            foreach (var item in array)
            {
                Assert.AreEqual((byte)(index & 0xFF), item);
                ++index;
            }

            sw.Stop();
            Console.WriteLine($"Время проверки памяти : {sw.Elapsed}");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
        }

        // Тест byte[]
        {
            Console.WriteLine();
            Console.WriteLine("Эталонный тест byte[]");
            Console.WriteLine();

            var sw = Stopwatch.StartNew();

            // Выделяем память.
            var array = new byte[size];

            Assert.AreEqual(size, array.Length);
            sw.Stop();
            Console.WriteLine($"Элементов массива      : {array.Length:##,###}");
            Console.WriteLine($"Выделено памяти (байт) : {array.Length:##,###}");
            Console.WriteLine($"Время                  : {sw.Elapsed}");
            Console.WriteLine();

            sw = Stopwatch.StartNew();

            // Заполняем память
            Parallel.For(0L, array.Length, i => array[i] = (byte)(i & 0xFF));

            sw.Stop();
            Console.WriteLine($"Время заполнения памяти : {sw.Elapsed}");
            Console.WriteLine();

            sw = Stopwatch.StartNew();

            // Проверяем память
            Parallel.For(0L, array.Length, i => Assert.AreEqual((byte)(i & 0xFF), array[i]));

            sw.Stop();
            Console.WriteLine($"Время проверки памяти : {sw.Elapsed}");

            sw = Stopwatch.StartNew();

            // Проверяем память
            var index = 0;
            foreach (var item in array)
            {
                Assert.AreEqual((byte)(index & 0xFF), item);
                ++index;
            }

            sw.Stop();
            Console.WriteLine($"Время проверки памяти : {sw.Elapsed}");
        }
    }

    /// <summary>
    /// Основные функции.
    /// </summary>
    [Test]
    public void Example()
    {
        var array = new FlexIncrementArrayElements<int>(new FlexIncrementArrayOptions(10_000_00, 10));
        Assert.AreEqual(0, array.Length);

        // Выделяем память.
        array.Expand(2);

        // Чтение и запись в позицию.
        array[0] = 111;
        Assert.AreEqual(111, array[0]);
        Assert.AreEqual(0, array[1]);

        // Обмен элементов местами
        array.Swap(0, 1);
        Assert.AreEqual(0, array[0]);
        Assert.AreEqual(111, array[1]);
    }
}
