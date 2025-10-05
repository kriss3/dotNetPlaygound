namespace ConAppPlayingWithFactoryMethod.Model;

internal class Resume : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
