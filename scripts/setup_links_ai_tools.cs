#!/usr/bin/env dotnet run

#:property TargetFrameworks=net10.0
#:property PublishAot=false

#:package Figgle.Fonts@0.6.6

string msg;

msg = "moljac@HolisticWare";
Console.WriteLine
            (
                Figgle.Fonts.FiggleFonts.Standard.Render(msg)
            );
msg = "setting up links";
Console.WriteLine
            (
                Figgle.Fonts.FiggleFonts.Standard.Render(msg)
            );


Console.WriteLine($"Directory.GetCurrentDirectory()                             = {Directory.GetCurrentDirectory()}");
Console.WriteLine($"Environment.CurrentDirectory                                = {Environment.CurrentDirectory}");
Console.WriteLine($"System.Reflection.Assembly.GetExecutingAssembly().Location  = {System.Reflection.Assembly.GetExecutingAssembly().Location}");
Console.WriteLine($"System.AppContext.BaseDirectory                             = {System.AppContext.BaseDirectory}");
Console.WriteLine($"AppDomain.CurrentDomain.BaseDirectory                       = {AppDomain.CurrentDomain.BaseDirectory}");
Console.WriteLine($"typeof(Program).GetType().Assembly.Location                 = {typeof(Program).GetType().Assembly.Location}");
Console.WriteLine($"");

// System.IO.Directory.CreateSymbolicLink
//                                 (
//                                     ".agents/skills/dotnet-test-run-single-file-app/",
//                                     ".claude/skills/dotnet-test-run-single-file-app"
//                                 );

