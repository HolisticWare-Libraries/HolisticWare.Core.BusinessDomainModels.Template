Claude.md

https://codewithmukesh.com/blog/claude-md-mastery-dotnet/

Memory Levels (Highest to Lowest Priority)
Enterprise Policy - Organization-level rules (if using Claude for Teams)
Project Memory - CLAUDE.md in your repository root
Project Rules - Files in .claude/rules/ directory
User Memory - ~/.claude/CLAUDE.md for personal global preferences
Key insight: All levels combine - they don’t replace each other. More specific rules override on conflicts. This means you can have global preferences in your home directory and project-specific overrides in each repository.

File Locations and Their Purpose
Location	Purpose	Commit to Git?
./CLAUDE.md	Project-wide instructions shared with team	Yes
./CLAUDE.local.md	Your personal project preferences	No (add to .gitignore)
./.claude/rules/*.md	Task-specific or folder-specific rules	Yes
~/.claude/CLAUDE.md	Global preferences across all projects	N/A

The Import Syntax
For larger projects, you can split instructions across multiple files using the import syntax:


CLAUDE.md

```markdown
@.claude/rules/architecture.md
@.claude/rules/testing.md
@.claude/rules/api-conventions.md
```


With AI coding tools, there is vertical growth of developers
more people are building. faster than ever.

But in most of the cases its always
prompt -> tweak -> prompt again

And that works, but it doesn't scale
for scaling you need to think about control

There’s a layer basically a folder you must have seen but still most people ignore: ".𝚌𝚕𝚊𝚞𝚍𝚎/"
It’s not just a folder.

It defines how Claude behaves inside your project.
Instructions. Rules. Commands. Permissions. Even memory.

once you start controlling this layer,
you stop repeating yourself.

CLAUDE.md → how your project works
rules/ → how it scales
commands/ → what gets automated
skills/ → claude triggers on its own
settings.json → what is allowed

This is not prompting.
This is configuration.

start small and then scale when needed! link to full breakdown is in comment and let me know how and what are you building with hashtag#claude?
Activate to view larger image,

