namespace HolisticWare.Utilities;

/// <summary>
/// ProviderHostBackend
///     AI host/provider/backend applicaton
///     *   Ollama
///     *   llama.cpp
///     *   ik_llama.cpp
///     *   lms (LM Studio)
///     *   Jan
///     *   Msty
/// </summary>
public partial class
                                    ProviderHostBackend
{
    /// <summary>
    /// BinaryExecutable to run
    /// </summary>
    public
        string?
                                    CommandLine
    {
        get;
        set;
    }
}
