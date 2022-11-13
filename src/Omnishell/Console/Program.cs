// See https://aka.ms/new-console-template for more information

using Core;

IOmnishell omnishell = OmnishellFactory<ConsoleConfiguration>.Build<IOmnishell>();
System.Console.WriteLine("Prompt:");
omnishell.PrintPrompt();
System.Console.WriteLine("End.");
