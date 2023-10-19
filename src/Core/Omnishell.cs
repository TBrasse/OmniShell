﻿using Core.Painter;
using Core.Resolver;
using Core.Segments;

namespace Core;

public class Omnishell : IOmnishell
{
	private readonly IConfigReader _configReader;
	private readonly IConfigWriter _configWriter;
	private readonly ISegmentRegistry _segmentRegistry;
	private readonly ISegmentResolver _segmentResolver;
	private readonly ISegmentPainter _segmentPainter;
	private readonly ISegmentPrinter _segmentPrinter;
	public IPSContext Context { get; }

	public Omnishell
	(
		IConfigReader configReader,
		IConfigWriter configWriter,
		ISegmentRegistry segmentRegistry,
		ISegmentResolver segmentResolver,
		ISegmentPainter segmentPainter,
		ISegmentPrinter segmentPrinter,
		IPSContext shellContext
	)
	{
		_configReader = configReader;
		_configWriter = configWriter;
		_segmentRegistry = segmentRegistry;
		_segmentResolver = segmentResolver;
		_segmentPainter = segmentPainter;
		_segmentPrinter = segmentPrinter;
		Context = shellContext;
	}

	public string PrintPrompt()
	{
		Profile profile = _configReader.GetProfile();
		_segmentRegistry.RegisterCustomSegments(profile.Segments);
		AbstractSegment[] orderedSegments = _segmentRegistry.GetSegments(profile.LinkedOrder);
		(AbstractSegment[] resolvedSegments, string[] promptSegments) = _segmentResolver.ResolveSegments(orderedSegments);
		AbstractSegment[] paintedSegments = _segmentPainter.PaintSegments(resolvedSegments, profile.Formats);
		_segmentPrinter.Print(paintedSegments);
		return string.Join("", promptSegments);
	}

	public Configuration GetConfiguration()
	{
		return _configReader.GetConfiguration();
	}

	public void SetConfiguration(Configuration configuration)
	{
		_configWriter.Write(configuration);
	}
}