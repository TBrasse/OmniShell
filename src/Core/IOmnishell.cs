namespace Core;
public interface IOmnishell
{
	string PrintPrompt();
	IPSContext Context { get; }
}