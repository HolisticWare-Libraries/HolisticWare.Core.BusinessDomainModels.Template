export const NotificationPlugin = 
async 
(
  { project, client, $, directory, worktree }
) 
=> 
  {
    return 
    {
      event: async ({ event }) => 
        {
          // Send notification on session completion
          if (event.type === "session.updated") 
          {
            await $`osascript -e 'Notification "Session completed!" with title "opencode"'`
            await $`osascript -e  'say "session updated"'`

            await $`dotnet --info`
            // await $`dotnet run ./notification.cs`
          }
        },
    }
  }