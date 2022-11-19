using Core.Painter;

namespace Core;

public class Profile
{
	public Profile()
	{
		Order = new string[0];
		Formats = new Dictionary<string, Format>();
	}

	private string[] order;
	public LinkedList<string> LinkedOrder { get; internal set; }
	public string[] Order
	{
		get { return order; }
		set
		{
			order = value;
			LinkedOrder = new LinkedList<string>(value);
		}
	}
	public Dictionary<string, Format> Formats { get; set; }
}