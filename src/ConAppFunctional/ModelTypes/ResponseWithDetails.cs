using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional.ModelTypes;
public record ResponseWithDetails<TSuccess, TFailure>(
		bool IsSuccess, HttpStatusCode Code, string Message, TSuccess Success, TFailure Failure)
	where TSuccess : class
	where TFailure : class;
