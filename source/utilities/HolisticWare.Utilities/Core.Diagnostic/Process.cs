using System.Diagnostics;

namespace Core.Diagnostics;

/// <summary>
/// Result of executing a process via <see cref="Process"/>.
/// </summary>
public sealed class ProcessResult
{
    /// <summary>Standard output captured from the executed process.</summary>
    public string StandardOutput { get; init; } = string.Empty;

    /// <summary>Standard error captured from the executed process.</summary>
    public string StandardError { get; init; } = string.Empty;

    /// <summary>Exit code returned by the process.</summary>
    public int ExitCode { get; init; }
}

/// <summary>
/// Core.Diagnostics.Process wrapper class for System.Diagnostics.Process
///     *   CommandLine
///         *   stdio/stderr redirection
///         *   Parsing
///         *   Multiline
/// </summary>
public partial class
                                    Process
{
    public
                                        Process
                                        (
                                            string command_line
                                        )
    {
        
        this.command_line = command_line;
        (string program_binary_application, string arguments) t = SplitCommandLine(command_line);
            
        this.program_binary_application = t.program_binary_application;
        this.arguments = t.arguments;
        
        this.ProgramBinaryExecutable = t.program_binary_application;
        this.Arguments = t.arguments;
        
        return;
    }
    
    public
                                        Process
                                        (
                                            string program_binary_application,
                                            string arguments
                                        )
    {
        this.program_binary_application = program_binary_application;
        this.arguments = arguments;
        this.command_line = $"{program_binary_application} {arguments}";
        
        return;
    }
    
    private 
        string
                                        command_line;

    /// <summary>
    /// BinaryExecutable to run
    /// </summary>
    public
        string
                                    CommandLine
    {
        get
        {
            return  this.command_line;
        }
        set
        {
            (string program_binary_application, string arguments) t = Process.SplitCommandLine(value);
            
            this.program_binary_application = t.program_binary_application;
            this.arguments = t.arguments;

            return;
        }
    }

    private 
        string
                                        program_binary_application;
    /// <summary>
    /// BinaryExecutable to run
    /// </summary>
    public
        string
                                        ProgramBinaryExecutable
    {
        get
        {
            return  this.program_binary_application;
        }

        set
        {
            this.program_binary_application = value;
            this.command_line = $"{this.program_binary_application} {this.arguments}";

            return;
        }
    }

    private 
        string
                                        arguments;
    
    /// <summary>
    /// BinaryExecutable to run
    /// </summary>
    public
        string
                                    Arguments
    {
        get
        {
            return  this.arguments;
        }

        set
        {
            this.arguments = value;
            this.command_line = $"{this.program_binary_application} {this.arguments}";
            
            return;
        }
    }

    public static
        (
            string program_binary_application,
            string arguments
        )

                                    SplitCommandLine
                                    (
                                        string command_line
                                    )
    {
        if (string.IsNullOrWhiteSpace(command_line))
            return ("", "");

        int idx = command_line.IndexOf(" ", StringComparison.InvariantCulture);

        if (idx < 0)
            return (command_line, "");

        string str_1 = command_line.Substring(0, idx);
        string str_2 = command_line.Substring(idx + 1);

        return  (str_1, str_2);
    }
    
    /// <summary>
    /// Synchronously starts the process, waits for exit, and captures stdout/stderr.
    /// </summary>
    public ProcessResult Start()
    {
        using System.Diagnostics.Process p = InternalStart();
        p.WaitForExit();
        return new ProcessResult
        {
            StandardOutput = p.StandardOutput.ReadToEnd(),
            StandardError = p.StandardError.ReadToEnd(),
            ExitCode = p.ExitCode,
        };
    }

    /// <summary>
    /// Asynchronously starts the process, waits for exit, and captures stdout/stderr.
    /// </summary>
    public async Task<ProcessResult> StartAsync()
    {
        using System.Diagnostics.Process p = InternalStart();
        await p.WaitForExitAsync().ConfigureAwait(false);
        string standardOutput = await p.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
        string standardError = await p.StandardError.ReadToEndAsync().ConfigureAwait(false);

        return new ProcessResult
        {
            StandardOutput = standardOutput,
            StandardError = standardError,
            ExitCode = p.ExitCode,
        };
    }

    private System.Diagnostics.Process InternalStart()
    {
        System.Diagnostics.ProcessStartInfo psi = new()
                                                    {
                                                        FileName = this.ProgramBinaryExecutable,
                                                        Arguments = this.Arguments,
                                                        UseShellExecute = false,
                                                        RedirectStandardOutput = true,
                                                        RedirectStandardError = true,
                                                        CreateNoWindow = true,
                                                    };
        System.Diagnostics.Process p = new ();
        p.StartInfo = psi;
        p.Start();

        return p;
    }
}
