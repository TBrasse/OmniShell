using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnishell.Core
{
	internal class SegmentDictionary : ISegmentDictionary
	{
		private readonly IEnumerable<IBaseSegment> _registeredSegments;

		public SegmentDictionary(IEnumerable<IBaseSegment> registeredSegments)
		{
			_registeredSegments = registeredSegments;
		}

		public IEnumerable<IBaseSegment> GetOrderedSegments(LinkedList<string> LinkedOrder)
		{
			foreach (string segmentName in LinkedOrder)
			{
				IBaseSegment foundSegment = null;
				foreach (IBaseSegment segment in _registeredSegments)
				{
					if (segmentName == segment.Name)
					{
						foundSegment = segment;
						break;
					}
				}
				if (foundSegment != null)
				{
					yield return foundSegment;
				}
			}
		}
	}
}
