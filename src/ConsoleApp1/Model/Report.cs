namespace ConAppPlayingWithFactoryMethod.Model;

internal class Report : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
