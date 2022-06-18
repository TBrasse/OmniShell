using System.Collections.Generic;

namespace Omnishell.Core
{
	internal interface ISegmentDictionary
	{
		IEnumerable<IBaseSegment> GetOrderedSegments(LinkedList<string> LinkedOrder);
	}
}