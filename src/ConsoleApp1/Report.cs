namespace ConAppPlayingWithFactoryMethod;

internal class Report : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
