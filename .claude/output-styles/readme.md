

*   https://code.claude.com/docs/en/output-styles

Output Styles vs. Agents
Output styles directly affect the main agent loop and only affect the system prompt. Agents are invoked to handle specific tasks and can include additional settings like the model to use, the tools they have available, and some context about when to use the agent.
​

Output Styles vs. Skills
Output styles modify how Claude responds (formatting, tone, structure) and are always active once selected. Skills are task-specific prompts that you invoke with /skill-name or that Claude loads automatically when relevant. Use output styles for consistent formatting preferences; use skills for reusable workflows and tasks.
