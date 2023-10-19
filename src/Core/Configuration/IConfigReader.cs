namespace Core;

public interface IConfigReader
{
	Profile GetProfile();

	Configuration GetConfiguration();
}