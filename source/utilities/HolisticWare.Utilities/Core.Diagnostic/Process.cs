using System.Diagnostics;

namespace Core.Diagnostics;

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
        int idx = command_line.IndexOf(" ", StringComparison.InvariantCulture);

        string str_1 = command_line.Substring(0, idx);
        string str_2 = command_line.Substring(idx + 1);
        
        return  (str_1, str_2);
    }
    
    public
        System.Diagnostics.Process?
                                    Start
                                    (
                                    )
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
        p.ErrorDataReceived += Process_OnErrorDataReceived;
        p.OutputDataReceived += Process_OnOutputDataReceived;
        p.EnableRaisingEvents = true;
        p.Start();
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
        p.WaitForExit();

        return p;
    }

    protected 
        void
                                        Process_OnErrorDataReceived
                                        (
                                            object sender,
                                            DataReceivedEventArgs e
                                        )
    {
        return;
    }
    
    protected
        void
                                        Process_OnOutputDataReceived
                                        (
                                            object sender,
                                            DataReceivedEventArgs e
                                        )
    {
        return;
    }
}
