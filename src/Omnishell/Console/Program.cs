// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
IOmnishell shell = OmnishellFactory<ConsoleConfiguration>.Build<IOmnishell>();
shell.GetPrompt();