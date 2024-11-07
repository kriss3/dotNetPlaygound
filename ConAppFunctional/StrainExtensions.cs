namespace ConAppFunctional;

public static class StrainExtensions
{
	public static Strain WithAdditionalInfo(this Strain strain, string additionalInfo)
	{
		strain.Description = additionalInfo;
		return strain;
	}
}
