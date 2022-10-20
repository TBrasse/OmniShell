using Core;

public class Omnishell : IOmnishell
{
    private readonly IConfigurationReader _configurationReader;

    public Omnishell
    (
        IConfigurationReader configurationReader
    )
    {
        _configurationReader = configurationReader;
    }

    public void GetPrompt()
    {
        Configuration configuration = _configurationReader.Read();
        //select Active Profile
        //process segments:
            //get configured segments => get and enqueue for execution
            //execute segments => execute enqueue for painting
            //paint segments with styles => paint enqueue for printing ?
            //print segments
        throw new NotImplementedException();
    }
}