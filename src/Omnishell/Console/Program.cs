// See https://aka.ms/new-console-template for more information

using Core;

IOmnishell omnishell = OmnishellFactory<ConsoleConfiguration>.Build<IOmnishell>();
System.Console.WriteLine("Prompt:");
System.Console.Write(omnishell.PrintPrompt());
System.Console.WriteLine("End.");
