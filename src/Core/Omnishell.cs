using Core.Painter;
using Core.Resolver;
using Core.Segments;
using Core.Utils;

namespace Core;

public class Omnishell : IOmnishell
{
	private readonly IConfigurationReader _configurationReader;
	private readonly IConfigProvider _configProvider;
	private readonly ISegmentRegistry _segmentRegistry;
	private readonly ISegmentResolver _segmentResolver;
	private readonly ISegmentPainter _segmentPainter;
	private readonly ISegmentPrinter _segmentPrinter;
	private readonly IObjectRepository _objectRepository;

	public IPSContext Context { get; }

	public Omnishell
	(
		IConfigurationReader configurationReader,
		IConfigProvider configProvider,
		ISegmentRegistry segmentRegistry,
		ISegmentResolver segmentResolver,
		ISegmentPainter segmentPainter,
		ISegmentPrinter segmentPrinter,
		IPSContext shellContext,
		IObjectRepository objectRepository
	)
	{
		_configurationReader = configurationReader;
		_configProvider = configProvider;
		_segmentRegistry = segmentRegistry;
		_segmentResolver = segmentResolver;
		_segmentPainter = segmentPainter;
		_segmentPrinter = segmentPrinter;
		Context = shellContext;
		_objectRepository = objectRepository;
	}

	public string PrintPrompt()
	{
		_configurationReader.ReadAndSet();
		_configProvider.ReadAndSetProfile();
		_configProvider.ReadAndSetFormats();
		_segmentRegistry.RegisterCustomSegments();
		_segmentRegistry.ReadAndSetSegments();
		_segmentResolver.ResolveSegments();
		_segmentPainter.PaintSegments();
		_segmentPrinter.PrintSegments();
		return _objectRepository.Prompt;
	}
}