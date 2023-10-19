using Core.Painter;

namespace Core;

public class Profile
{
	public Profile()
	{
		Order = new List<string>();
		Formats = new Dictionary<string, Format>();
		Segments = new Dictionary<string, string>();
		Styles = new Dictionary<string, string>();
	}

	private List<String> order;
	public LinkedList<string> LinkedOrder { get; internal set; }
	public List<String> Order
	{
		get { return order; }
		set
		{
			order = value;
			LinkedOrder = new LinkedList<string>(value);
		}
	}

	public Dictionary<string, Format> Formats { get; set; }
	public Dictionary<string, string> Segments { get; set; }
	public Dictionary<string, string> Styles { get; set; }
}