# dotNetPlayground Repository

Main container for exploration of number of different dotNet concepts in C#. This will be full framework project.

## Description

This repository is part of the project: Life as a Code.
Frequent development of verity of dotNet concepts.
Focus on C# 101 including practicing new concepts but not limited to
algorithms, data structures, core dotNet ideas.

## Change Log:

04/15 Added a new project: playing with lambda. I wanted to have a playground for extension methods with some twists to it.
I wanted to get more familiar with the latest additions to this functional feature of the language

- Minor update to the project. Lambda can now accept two connection and spit fully populated one.
- Add new examples of extension to specifically target object transformation inside code block. That exercise will help with creation of ad-hoc extension methods.
- Current work: upgrading each project to a dotnet 8 and C# 10/12 syntax
- Next step: modeling using functional C#. Code examples from ROP Railway Oriented Programming. I would like to to master creating primitive times with built in validation (let's get away from using strings)
- Adding a new project. Experimenting with Service Worker. The simple project will monitor website (google) health status. It will run on period and report status to the console and a log file.
- Log library: Serilog, Added Windows service library to implement this background worker as a win service
- Adding .md file for this project with commands to install service, start it and destroy their service
- Adding two new projects:  
   1.Playing with RestSharp.  
   2.Learning new patterns, Strategy pattern and Results pattern.  
  Both research is based on Pluralsight, LinkedIn Learning and YT. Added a driver class and implementation  It contains Result type that encapsulates Error type
- Adding Command Pattern project. This is an attempt to isolate all the projects that are related to Design Patterns to push them into its own repo
- Continue to the next pattern and this time adding analysis first with mermaid diagram upfront
- Next tasks to follow will be Result and Option pattern. I want to explore creating endpoints with no or minimum exception throwing.   
- Playing with Guard clauses i.e. Ardalis lib;
- Regular and Custom guards for Null and specific i out checkn  
- Property based testing;
- Working on Refit (learning new http client library); 
