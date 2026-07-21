
Dictionary
        <
            (
                string url_repo,
                string git_branch
            ),
            string[]
        > 
            ExternalReposToDownload;
            
ExternalReposToDownload = new Dictionary
                                    <
                                        (
                                            string url_repo,
                                            string git_branch
                                        ),
                                        string[]
                                    >
                                        ()
{
    {
        (
            url_repo:   "https://github.com/dotnet/maui/archive/refs/heads/main.zip",
            git_branch: "main" 
        ),
        new string[]
        {
            "source",
            "MAUI",
        }
    },
    {
        (
            url_repo:   "https://github.com/xamarin/Xamarin.Forms/archive/refs/heads/5.0.0.zip",
            git_branch: "5.0.0"
        ),
        new string[]
        {
            "source",
            "Xamarin.Forms",
        }
    },
    {
        (
            url_repo:   "https://github.com/dotnet/maui-samples/archive/refs/heads/main.zip",
            git_branch: "main"
        ),
        new string[]
        {
            "samples",
            "maui",
            "dotnet",
            "maui-samples",
        }
    },
    {
        (
            url_repo:   "https://github.com/behl1anmol/Todo.me/archive/refs/heads/master.zip",
            git_branch: "master"
        ),
        new string[]
        {
            "samples",
            "maui",
            "Todo.me"
        }
    },
    {
        (
            url_repo:   "https://github.com/naweed/MauiScientificCalculator/archive/refs/heads/main.zip",
            git_branch: "master"
        ),
        new string[]
        {
            "samples",
            "maui",
            "ScientificCalculator"
        }
    },
    {
        (
            url_repo:   "https://github.com/jsuarezruiz/netmaui-chat-app-challenge/archive/refs/heads/main.zip",
            git_branch: "master"
        ),
        new string[]
        {
            "samples",
            "maui",
            "ChatApp"
        }
    },
    {
        (
            url_repo:   "https://github.com/microsoft/dotnet-podcasts/archive/refs/heads/main.zip",
            git_branch: "master"
        ),
        new string[]
        {
            "samples",
            "maui",
            "dotnet-podcasts"
        }
    },
    {
        (
            url_repo:   "https://github.com/davidortinau/WeatherTwentyOne/archive/refs/heads/main.zip",
            git_branch: "master"
        ),
        new string[]
        {
            "samples",
            "maui",
            "WeatherTwentyOne"
        }
    },
    {
        (
            url_repo:   "https://github.com/drasticactions/WeatherTwentyTwo/archive/refs/heads/main.zip",
            git_branch: "master"
        ),
        new string[]
        {
            "samples",
            "maui",
            "TodWeatherTwentyTwo"
        }
    },
};