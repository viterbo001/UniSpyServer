﻿using Chat.Entity.Structure;
using Chat.Entity.Structure.ChatChannel;
using Chat.Entity.Structure.ChatCommand;
using GameSpyLib.Common.Entity.Interface;

namespace Chat.Handler.CommandHandler
{

    public class UTMHandler : ChatCommandHandlerBase
    {
        ChatChannelBase _channel;
        new UTM _cmd;
        ChatChannelUser _user;
        public UTMHandler(ISession client, ChatCommandBase cmd) : base(client, cmd)
        {
            _cmd = (UTM)cmd;
        }

        public override void CheckRequest()
        {
            base.CheckRequest();
            if (!_session.UserInfo.GetJoinedChannel(_cmd.ChannelName, out _channel))
            {
                _errorCode = ChatError.Parse;
                return;
            }
            if (!_channel.GetChannelUserBySession(_session, out _user))
            {
                _errorCode = ChatError.Parse;
                return;
            }

            if (_cmd.RequestType == UTMCmdType.UserUTM)
                if (!_channel.GetChannelUserByNickName(_cmd.NickName, out _))
                {
                    _errorCode = ChatError.Parse;
                    return;
                }
        }

        public override void DataOperation()
        {
            base.DataOperation();
          
            switch (_cmd.RequestType)
            {
                case UTMCmdType.ChannelUTM:
                    ChatCommandBase.BuildMessageRPL(
                    $"UTM {_channel.Property.ChannelName}", _cmd.Message);
                    break;
                case UTMCmdType.UserUTM:
                    _sendingBuffer =
                       ChatCommandBase.BuildMessageRPL(
                       $"UTM {_cmd.NickName}", _cmd.Message);
                    break;
            }
        }

        public override void ConstructResponse()
        {
            base.ConstructResponse();
            if (_errorCode > ChatError.NoError)
            {
                //todo send error to client;
            }
        }

        public override void Response()
        {
            if (_sendingBuffer == null || _sendingBuffer == "" || _sendingBuffer.Length < 3)
            {
                return;
            }
            _channel.MultiCast(_sendingBuffer);
        }
    }
}