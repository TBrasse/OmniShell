namespace Core;

public interface IOmnishell
{
	string PrintPrompt();

	Configuration GetConfiguration();

	void SetConfiguration(Configuration configuration);

	IPSContext Context { get; }
}