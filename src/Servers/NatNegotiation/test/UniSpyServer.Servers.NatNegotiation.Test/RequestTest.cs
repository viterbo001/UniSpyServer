using System;
using UniSpyServer.Servers.NatNegotiation.Entity.Enumerate;
using UniSpyServer.Servers.NatNegotiation.Entity.Structure.Request;
using Xunit;

namespace UniSpyServer.Servers.UniSpyServer.Servers.NatNegotiation.Test
{
    public class RequestTest
    {
        [Fact]
        public void InitTest()
        {
            var rawRequest = new byte[] {
            0xfd, 0xfc, 0x1e, 0x66, 0x6a, 0xb2, 0x03,
            0x00,
            0x00, 0x00, 0x03, 0x09, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var request = new InitRequest(rawRequest);
            request.Parse();
            Assert.Equal(RequestType.Init, request.CommandName);
            Assert.Equal((int)151191552, request.Cookie);
            Assert.Equal((byte)0, request.ClientIndex);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal((byte)3, request.Version);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal(NatPortType.NN1, request.PortType);
        }
        [Fact]
        public void AddressTest()
        {
            var rawRequest = new byte[] { 0xfd, 0xfc, 0x1e, 0x66, 0x6a, 0xb2, 0x03, 0x0a, 0x00, 0x00, 0x03, 0x09, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var request = new AddressCheckRequest(rawRequest);
            request.Parse();
            Assert.Equal(RequestType.AddressCheck, request.CommandName);
            Assert.Equal((int)151191552, request.Cookie);
            Assert.Equal((byte)0, request.ClientIndex);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal((byte)3, request.Version);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal(NatPortType.NN1, request.PortType);
        }
        [Fact]
        public void ErtAckTest()
        {
            var rawRequest = new byte[] {
            0xfd, 0xfc, 0x1e, 0x66, 0x6a, 0xb2, 0x03,
            0x03,
            0x00, 0x00, 0x03, 0x09,
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var request = new ErtAckRequest(rawRequest);
            request.Parse();
            Assert.Equal(RequestType.ErtAck, request.CommandName);
            Assert.Equal((int)151191552, request.Cookie);
            Assert.Equal((byte)0, request.ClientIndex);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal((byte)3, request.Version);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal(NatPortType.NN1, request.PortType);
        }
        [Fact]
        public void NatifyTest()
        {
            var rawRequest = new byte[] {
            0xfd, 0xfc, 0x1e, 0x66, 0x6a, 0xb2, 0x03,
            0x0c,
            0x00, 0x00, 0x03, 0x09,
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var request = new ErtAckRequest(rawRequest);
            request.Parse();
            Assert.Equal(RequestType.NatifyRequest, request.CommandName);
            Assert.Equal((int)151191552, request.Cookie);
            Assert.Equal((byte)0, request.ClientIndex);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal((byte)3, request.Version);
            Assert.Equal((byte)0, request.UseGamePort);
            Assert.Equal(NatPortType.NN1, request.PortType);
        }
        [Fact(Skip = "Not implemented")]
        public void ReportTest()
        {

        }
    }
}
