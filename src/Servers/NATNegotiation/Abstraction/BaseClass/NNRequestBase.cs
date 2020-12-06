﻿using UniSpyLib.Extensions;
using NATNegotiation.Entity.Enumerate;
using System;
using System.Collections.Generic;
using UniSpyLib.Abstraction.BaseClass;

namespace NATNegotiation.Abstraction.BaseClass
{
    /// <summary>
    /// NatNeg request base
    /// </summary>
    public class NNRequestBase : UniSpyRequestBase
    {
        public static readonly byte[] MagicData = { 0xfd, 0xfc, 0x1e, 0x66, 0x6a, 0xb2 };
        public static readonly int Size = 12;

        //public NatPacketType PacketType { get; set; }
        public new NatPacketType CommandName
        {
            get { return (NatPacketType)base.CommandName; }
            set { base.CommandName = value; }
        }
        public new byte[] RawRequest
        {
            get { return (byte[])base.RawRequest; }
        }
        public byte Version;
        public uint Cookie;



        public NNRequestBase(byte[] rawRequest) : base(rawRequest)
        {
        }

        public override object Parse()
        {
            if (RawRequest.Length < Size)
            {
                return false;
            }

            Version = RawRequest[MagicData.Length];
            CommandName = (NatPacketType)RawRequest[MagicData.Length + 1];
            Cookie = BitConverter.ToUInt32(ByteTools.SubBytes(RawRequest, MagicData.Length + 2, 4));

            return true;
        }

        public virtual byte[] BuildResponse()
        {
            List<byte> data = new List<byte>();
            data.AddRange(MagicData);
            data.Add(Version);
            data.Add((byte)CommandName);
            data.AddRange(BitConverter.GetBytes(Cookie));

            return data.ToArray();
        }
    }
}
