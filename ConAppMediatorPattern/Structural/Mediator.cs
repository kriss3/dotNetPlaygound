using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMediatorPattern.Structural;
public abstract class Mediator
{
	public abstract void Send(string message, Colleague colleague);
}
