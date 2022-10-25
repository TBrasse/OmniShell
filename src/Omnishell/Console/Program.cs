// See https://aka.ms/new-console-template for more information

IOmnishell shell = OmnishellFactory<ConsoleConfiguration>.Build<IOmnishell>();
System.Console.WriteLine("Prompt:");
shell.GetPrompt();
System.Console.WriteLine("End.");