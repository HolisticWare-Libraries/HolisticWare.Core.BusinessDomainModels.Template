string gh = "https://github.com";

Dictionary
        <
            (
                string url_repo,
                string git_branch
            ),
            string[]
        > 
            ExternalReposToDownload = new()
                                        {
                                            // https://nuget.org/packages?packagetype=dotnettool
                                            {
                                                (
                                                    url_repo:   $"{gh}/cake-build/cake/archive/refs/heads/develop.zip",
                                                    git_branch: "develop" 
                                                ),
                                                new string[]
                                                {
                                                    "dotnet",
                                                    "tool",
                                                    "cake",
                                                }
                                            },
                                            {
                                                (
                                                    url_repo:   $"{gh}/domaindrivendev/Swashbuckle.AspNetCore/archive/refs/heads/master.zip",
                                                    git_branch: "develop" 
                                                ),
                                                new string[]
                                                {
                                                    "dotnet",
                                                    "tool",
                                                    "Swashbuckle.CLI",
                                                }
                                            },
                                        };