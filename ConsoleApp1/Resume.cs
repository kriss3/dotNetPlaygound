﻿namespace ConApp_Exercises_2;

internal class Resume : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
