using ConApp_Exercises_2;

namespace ConAppPlayingWithFactoryMethod;

internal class Resume : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
