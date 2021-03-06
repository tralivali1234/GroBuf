﻿using System;

using GroBuf.DataMembersExtracters;

using NUnit.Framework;

namespace GroBuf.Tests
{
    [TestFixture]
    public class TestNull
    {
        [SetUp]
        public void SetUp()
        {
            serializer = new Serializer(new PropertiesExtractor());
        }

        [Test]
        public void TestClass()
        {
            var o = (A)null;
            var data = serializer.Serialize(o);
            var oo = serializer.Deserialize<A>(data);
            Assert.IsNotNull(oo);
            Assert.IsNull(oo.S);
            Assert.IsNull(oo.B);
        }

        [Test]
        public void Test()
        {
            string str1 = @"CcHanVu6d9II";
            string str2 = @"CSPQYxIrDtII";
            string str3 = @"CcVGItItgdII";
            byte[] arr1 = Convert.FromBase64String(str1);
            byte[] arr2 = Convert.FromBase64String(str2);
            byte[] arr3 = Convert.FromBase64String(str3);

            Console.WriteLine(serializer.Deserialize(typeof(long), arr1));
            Console.WriteLine(serializer.Deserialize(typeof(long), arr2));
            Console.WriteLine(serializer.Deserialize(typeof(long), arr3));
        }

        [Test]
        public void Test2()
        {
            string prev = @"AUABAAD7+4dqyAWRww4aAAAANAA2ADAANwAxADEANwA4ADgANAA1ADQANQCXKqz0ofYgEw4MAAAAMQAyADMANAA1ADYAFI0lnUuxneQOIgAAAC0EQARBBE4EFiEgAFQESwROBEwEQARRBFIERQQWIU4EQgRH7QmXijQ1ZQ4GAAAAUABDAEUAXhnc9MHO7eQNAAAEAAAAAACAiwgAAAAAAArEJGM3c/EEDgQAAAAxADgApgAewED9ehAOAAAAALFSl1huRAAoDhQAAAAwBFMEVwRKBEgEIABCBFEERQRMBMiPwB3tzcafDgAAAABuqp+2NkzVrQ4AAAAARiPpxDURBAcNAAADAAAAAAD4KgAAAAAAAIp4qF30h5M6DgwAAAA0ADQALAAwADAAMAAS37VDXHzi1g4AAAAAtZyIcmn4UY8OAAAAAA==";
            string curr = @"AUABAAD7+4dqyAWRww4aAAAANAA2ADAANwAxADEANwA4ADgANAA1ADQANQCXKqz0ofYgEw4MAAAAMQAyADMANAA1ADYAFI0lnUuxneQOIgAAAC0EQARBBE4EFiEgAFQESwROBEwEQARRBFIERQQWIU4EQgRH7QmXijQ1ZQ4GAAAAUABDAEUAXhnc9MHO7eQNAAACAAAAAADgFQAAAAAAAArEJGM3c/EEDgQAAAAxADgApgAewED9ehAOAAAAALFSl1huRAAoDhQAAAAwBFMEVwRKBEgEIABCBFEERQRMBMiPwB3tzcafDgAAAABuqp+2NkzVrQ4AAAAARiPpxDURBAcNAAADAAAAAAD4KgAAAAAAAIp4qF30h5M6DgwAAAA0ADQALAAwADAAMAAS37VDXHzi1g4AAAAAtZyIcmn4UY8OAAAAAA==";
            Console.WriteLine(DebugViewBuilder.DebugView(Convert.FromBase64String(curr)));
        }

        public class A
        {
            public string S { get; set; }
            public B B { get; set; }
        }

        public class B
        {
            public int[] Ints { get; set; }
        }

        private Serializer serializer;
    }
}