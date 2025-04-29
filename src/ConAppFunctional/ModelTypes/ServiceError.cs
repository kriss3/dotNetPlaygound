//using Cova.ServiceErrors.Errors;

//namespace ConAppFunctional.ModelTypes;

//public abstract class ServiceError(string message, Exception innerException) : Exception(message, innerException)
//{
//	public abstract string ErrorType { get; }

//	public abstract IEnumerable<ErrorCode> ErrorCodes { get; }

//	public virtual required string ErrorCodeDocumentation { get; set; }

//	public abstract T Match<T>(
//		Func<PersistenceDataError, T> persistenceDataError, 
//		Func<UnexpectedError, T> unexpectedError, 
//		Func<ValidationError, T> validationError, 
//		Func<MappingError, T> mappingError, 
//		Func<AuthorizationError, T> authorizationError, 
//		Func<AuthenticationError, T> authenticationError, 
//		Func<CustomError, T> customError);
//}