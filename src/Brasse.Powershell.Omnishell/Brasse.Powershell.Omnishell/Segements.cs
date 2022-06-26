using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Omnishell.Core
{
    internal class SegmentDictionary : ISegmentDictionary
    {
        private readonly IEnumerable<IBaseSegment> _registeredSegments;
        private IEnumerable<string> _linkedOrder;

        public SegmentDictionary
        (
            IEnumerable<IBaseSegment> registeredSegments,
            IConfigurationReader configurationReader,
            IShell shell
        )
        {
            _registeredSegments = registeredSegments;
            Configuration configuration = configurationReader.Read();
            string profileName = shell.Execute(configuration.Switch).First();
            Profile profile = configuration.Profiles[profileName];
            _linkedOrder = profile.LinkedOrder;
        }

        public IEnumerator<IBaseSegment> GetEnumerator()
        {
            foreach (string segmentName in _linkedOrder)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
