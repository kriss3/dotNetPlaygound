﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMediatorPattern.ChatApp;
public abstract class TeamMember
{
    public string Name { get; }
    private ChatRoom _chatRoom;
    public TeamMember(string name)
    {
        this.Name = name;
    }

    internal void SetChatRoom(ChatRoom chatRoom) 
    {
        _chatRoom = chatRoom;
    }








}
