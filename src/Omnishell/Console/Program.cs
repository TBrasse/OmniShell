// See https://aka.ms/new-console-template for more information

using Console;

IOmnishell shell = OmnishellFactory<ConsoleConfiguration>.Build<IOmnishell>();
System.Console.WriteLine("Prompt:");
shell.PrintPrompt();
System.Console.WriteLine("End.");