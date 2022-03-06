using System.Collections.Generic;
using System.Linq;
using System.Net;
using Moq;
using UniSpyServer.Servers.Chat.Entity.Structure;
using UniSpyServer.Servers.Chat.Handler;
using UniSpyServer.UniSpyLib.Abstraction.Interface;
using UniSpyServer.UniSpyLib.Encryption;
using Xunit;

namespace UniSpyServer.Servers.Chat.Test
{
    public class GameTest
    {
        private Client _client;
        public GameTest()
        {
            var serverMock = new Mock<IServer>();
            serverMock.Setup(s => s.ServerID).Returns(new System.Guid());
            serverMock.Setup(s => s.ServerName).Returns("Chat");
            serverMock.Setup(s => s.Endpoint).Returns(new IPEndPoint(IPAddress.Any, 6666));
            var sessionMock = new Mock<ITcpSession>();
            sessionMock.Setup(s => s.RemoteIPEndPoint).Returns(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888));
            sessionMock.Setup(s => s.Server).Returns(serverMock.Object);
            _client = new Client(sessionMock.Object);
        }

        [Fact]
        public void Civilization4()
        {
            var rawRequests = new List<string>(){
                "CRYPT des 1 anno1701",
                "USRIP",
                "USER X419pGl4sX|18 127.0.0.1 peerchat.gamespy.com :aa3041ada9385b28fc4d4e47db288769",
                "NICK a1701-5",
                "CDKEY 81123-67814-77652-27631-11723-47707-22638-10701",
                "JOIN #GSP!anno1701 ","MODE #GSP!anno1701",
                @"GETCKEY #GSP!anno1701 * 008 0 :\b_flags","WHO a1701-5",
                "JOIN #GSP!anno1701!M9zK0KJaKM ",
                "MODE #GSP!anno1701!M9zK0KJaKM",
                @"SETCKEY #GSP!anno1701 a1701-5 :\b_flags\s",
                @"SETCKEY #GSP!anno1701!M9zK0KJaKM a1701-5 :\b_flags\sh",
                @"GETCKEY #GSP!anno1701!M9zK0KJaKM * 009 0 :\b_flags",
                "TOPIC #GSP!anno1701!M9zK0KJaKM :test",
                "MODE #GSP!anno1701!M9zK0KJaKM +l 4",
                "MODE #GSP!anno1701!M9zK0KJaKM -i-p-s+m+n+t+l+e 4",
                "PART #GSP!anno1701 :"
            };

            foreach (var raw in rawRequests)
            {
                new CmdSwitcher(_client, UniSpyEncoding.GetBytes(raw)).Switch();
            }
        }
        [Fact]
        public void TcpMessageSplitingTest()
        {
            var raws = new List<byte[]>(){
                UniSpyEncoding.GetBytes("GETCKEY"),
                UniSpyEncoding.GetBytes(" world"),
                UniSpyEncoding.GetBytes(" hi").Concat(new byte[]{0x0D,0x0A}).ToArray(),
            };
            foreach (var raw in raws)
            {
                _client.TestReceived(raw);
            }
            // Given

            // When

            // Then
        }
        [Fact]
        public void Worms3dTest()
        {
            var serverMock = new Mock<IServer>();
            serverMock.Setup(s => s.ServerID).Returns(new System.Guid());
            serverMock.Setup(s => s.ServerName).Returns("Chat");
            serverMock.Setup(s => s.Endpoint).Returns(new IPEndPoint(IPAddress.Any, 6666));
            var sessionMock = new Mock<ITcpSession>();
            sessionMock.Setup(s => s.RemoteIPEndPoint).Returns(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888));
            sessionMock.Setup(s => s.Server).Returns(serverMock.Object);
            var client1 = new Client(sessionMock.Object);
            sessionMock.Setup(s => s.RemoteIPEndPoint).Returns(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8889));
            var client2 = new Client(sessionMock.Object);
            var raws1 = new List<string>()
            {
                "CRYPT des 1 worms3",
                "USRIP",
                "USER X419pGl4sX|6 127.0.0.1 peerchat.gamespy.com :aa3041ada9385b28fc4d4e47db288769",
                "NICK worms10",
                "JOIN #GPG!622" ,
                "MODE #GPG!622",
                @"GETCKEY #GPG!622 * 024 0 :\username\b_flags",
                "JOIN #GSP!worms3!Ml4lz344lM" ,
                "MODE #GSP!worms3!Ml4lz344lM",
                @"SETCKEY #GPG!622 worms10 :\b_flags\s",
                @"SETCKEY #GSP!worms3!Ml4lz344lM worms10 :\b_flags\sh",
                @"GETCKEY #GSP!worms3!Ml4lz344lM * 025 0 :\username\b_flags",
                "TOPIC #GSP!worms3!Ml4lz344lM :tesr",
                "MODE #GSP!worms3!Ml4lz344lM +l 2",
                "PART #GPG!622 :Joined staging room",
                @"SETCKEY #GSP!worms3!Ml4lz344lM worms10 :\b_firewall\1\b_profileid\6\b_ipaddress\\b_publicip\255.255.255.255\b_privateip\192.168.0.60\b_authresponse\\b_gamever\1073\b_val\0",
                "WHO worms10",
                @"SETCHANKEY #GSP!worms3!Ml4lz344lM :\b_hostname\test\b_hostport\\b_MaxPlayers\2\b_NumPlayers\1\b_SchemeChanging\0\b_gamever\1073\b_gametype\\b_mapname\Random\b_firewall\1\b_publicip\255.255.255.255\b_privateip\192.168.0.60\b_gamemode\openstaging\b_val\0\b_password\1",
                @"GETKEY worms20 026 0 :\b_firewall\b_profileid\b_ipaddress\b_publicip\b_privateip\b_authresponse\b_gamever\b_val",
                @"GETCKEY #GSP!worms3!Ml4lz344lM worms20 027 0 :\b_firewall\b_profileid\b_ipaddress\b_publicip\b_privateip\b_authresponse\b_gamever\b_val",
                @"SETCHANKEY #GSP!worms3!Ml4lz344lM :\b_hostname\test\b_hostport\\b_MaxPlayers\2\b_NumPlayers\1\b_SchemeChanging\0\b_gamever\1073\b_gametype\\b_mapname\Random\b_firewall\1\b_publicip\255.255.255.255\b_privateip\192.168.0.60\b_gamemode\openstaging\b_val\0\b_password\1",
                @"SETCHANKEY #GSP!worms3!Ml4lz344lM :\b_hostname\test\b_hostport\\b_MaxPlayers\2\b_NumPlayers\1\b_SchemeChanging\0\b_gamever\1073\b_gametype\\b_mapname\Random\b_firewall\1\b_publicip\255.255.255.255\b_privateip\192.168.0.60\b_gamemode\openstaging\b_val\0\b_password\1",
                "UTM #GSP!worms3!Ml4lz344lM :MDM |Obj|3|Land.Time|0|LogicalSeed|3891226431|GraphicalSeed|3269271590|Land.RealSeed|3281489942|Land.Theme|Pirate.Lumps|LevelToUse|FE.Level.RandomLand|Land.Ind|0|Wormpot.Reel1|17|Wormpot.Reel2|17|Wormpot.Reel3|17|TimeStamp|6206364",
                "UTM #GSP!worms3!Ml4lz344lM :TDM aA",
                "UTM #GSP!worms3!Ml4lz344lM :SDM ASFE.Scheme.StandardCUnAACADCBBCACBBFFBKBB8C/C3C!A!A*C*C<D*B*B*B*B*B*B3C*B<A*C3CEC!A-C5C-C3C<C*A*B*B*C*B<CEC*B*C<B<D!A*B*B3B3C<D!A<D/C<C<D*C*A",
                "UTM worms20 :APE [01]privateip[02]192.168.0.60[01]publicip[02]255.255.255.255"
            };
            var raws2 = new List<string>()
            {
                "CRYPT des 1 worms3",
                "USRIP",
                "USER X419pGl4sX|7 127.0.0.1 peerchat.gamespy.com :5bb4f409fae8bc5aa1595cb6d5168a1c",
                "NICK worms20",
                "JOIN #GPG!622" ,
                "MODE #GPG!622",
                @"GETCKEY #GPG!622 * 008 0 :\username\b_flags",
                "JOIN #GSP!worms3!Ml4lz344lM" ,
                "MODE #GSP!worms3!Ml4lz344lM",
                @"SETCKEY #GPG!622 worms20 :\b_flags\s",
                @"SETCKEY #GSP!worms3!Ml4lz344lM worms20 :\b_flags\s",
                @"GETCKEY #GSP!worms3!Ml4lz344lM * 009 0 :\username\b_flags",
                "PART #GPG!622 :Joined staging room",
                "UTM #GSP!worms3!Ml4lz344lM :APE [01]privateip[02]192.168.0.141[01]publicip[02]255.255.255.255",
                "WHO worms10",
                @"GETCKEY #GSP!worms3!Ml4lz344lM worms10 010 0 :\b_firewall\b_profileid\b_ipaddress\b_publicip\b_privateip\b_authresponse\b_gamever\b_val",
                "WHO worms20"
            };
            // first process client2, then client1 will get client2 in channel
            foreach (var raw in raws2)
            {
                new CmdSwitcher(client2, UniSpyEncoding.GetBytes(raw)).Switch();
            }
            foreach (var raw in raws1)
            {
                new CmdSwitcher(client1, UniSpyEncoding.GetBytes(raw)).Switch();
            }

        }
    }
}