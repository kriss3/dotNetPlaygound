## Async/Await Project description.
PS project follows Filip Eckberg.
Name: Asynchronous Programming in C#

### Non-tech changes
- Attempt to add RestSharp lib and update the project.
- This project will also contain some temporary weird commits as I'm taking git advanced course using commaind line.
   It is finally time to get away from GUI :)
- Adding ultimate guide/cheat sheet, based on Mosh Hamedani's teaching.

## 
Commands I want to master:
1. git init  
	Description: Initializes a new Git repository in the current directory.  
    Usage: `git init`

2. git clone  
	Description: Creates a copy of an existing Git repository from a remote server.  
	Usage: `git clone <repository-url> `

3. git add
	Description: Stages changes in the working directory for the next commit.
	Usage:
	``` 
		git add <file>
		git add .
	```


4. git commit
	Description: Records the changes in the staging area along with a message.
	Usage: ` git commit -m "Commit message"`

5. git status
	Description: Shows the status of changes as untracked, modified, or staged.
	Usage: `git status`

6. git push
	Description: Uploads local repository content to a remote repository.
	Usage: `git push <remote> <branch>`

7. git pull
	Description: Fetches and merges changes from a remote repository to the local repository.
	Usage: `git pull <remote> <branch>`

8. git fetch
	Description: Downloads objects and refs from another repository.
	Usage: `git fetch <remote> `

9. git merge
	Description: Combines sequences of commits into one unified history.
	Usage:
	```
	git merge <branch>
	```

10. git branch
	Description: Lists, creates, or deletes branches.
	Usage: 
	`git branch <branch-name>`
	`git branch -d <branch-name>`

11. git checkout
	Description: Switches branches or restores working directory files.
	Usage: 
	```
	git checkout <branch>`
	git checkout -b <new-branch>
	```
12. git log
	Description: Shows the commit history for the repository.
	Usage:
	```
	git log
	```
13. git reset
	Description: Resets current HEAD to a specified state.
	Usage:
	```
	git reset --hard <commit>
	git reset --soft <commit>
	```  
14. git revert
	Description: Creates a new commit that undoes the changes made by a previous commit.
	Usage:
	```
	git revert <commit>
	```  

15. git rebase   
	Description: Reapplies commits on top of another base tip.
	Usage:
	```
	git rebase <branch>
	```

16. git stash
Description: Temporarily shelves changes you've made to your working copy so you can work on something else, then reapply them later.
Usage:

git stash
git stash apply
17. git remote
Description: Manages set of tracked repositories.
Usage:

git remote add <name> <url>
git remote -v

18. git tag  
	Description: Creates, lists, deletes, or verifies a tag object signed with GPG.
	Usage: 
	```
	git tag <tag-name>
	git tag

	```