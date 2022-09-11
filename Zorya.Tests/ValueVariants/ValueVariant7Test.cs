﻿using System.Drawing;
using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant7Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual((byte) 10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(true, v.TryGet(out byte _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }
    
    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(7, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
    }
}