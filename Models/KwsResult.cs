using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;
internal class KwsResult
{
	public bool IsSuccess { get; }
	public string? Error { get; private set; }
}
