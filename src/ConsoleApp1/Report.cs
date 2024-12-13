namespace ConApp_Exercises_2;

internal class Report : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
