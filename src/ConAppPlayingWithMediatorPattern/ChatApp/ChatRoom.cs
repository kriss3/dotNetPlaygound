using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMediatorPattern.ChatApp;
public abstract class ChatRoom
{
	public abstract void Register(TeamMember member);
	public abstract void Send(string from, string message);
}
