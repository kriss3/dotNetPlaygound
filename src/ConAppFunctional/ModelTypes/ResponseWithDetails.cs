using System.Net;

namespace ConAppFunctional.ModelTypes;
public record ResponseWithDetails<TSuccess, TFailure>(
		bool IsSuccess, HttpStatusCode Code, string Message, TSuccess Success, TFailure Failure)
	where TSuccess : class
	where TFailure : class;
