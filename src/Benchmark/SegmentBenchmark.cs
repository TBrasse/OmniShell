using BenchmarkDotNet.Attributes;
using Core;
using Core.Segments;
using Core.Shell;
using Moq;

public class SegmentBenchmark
{
	private AzContextSegment _azContext;
	private DateSegment _dateSegment;
	private GitSegment _gitSegment;
	private PathSegment _pathSegment;
	private PlatformSegment _platformSegment;
	private PowershellExecutor _shell;

	public SegmentBenchmark()
	{
		Mock<IPSSettingProvider> settingMoq = new Mock<IPSSettingProvider>();
		settingMoq.Setup(x => x.WorkingDirectory).Returns(@"D:\Temp");

		Mock<IPSContext> shellContextMoq = new Mock<IPSContext>();
		shellContextMoq.Setup(x => x.WorkingDir).Returns(@"D:\Temp");

		_shell = new PowershellExecutor(settingMoq.Object);
		_azContext = new AzContextSegment();
		_dateSegment = new DateSegment();
		_gitSegment = new GitSegment(settingMoq.Object);
		_pathSegment = new PathSegment(shellContextMoq.Object);
		_platformSegment = new PlatformSegment();
	}

	//[Benchmark]
	public void AzContextSegment()
	{
		_azContext.Resolve(_shell);
	}

	//[Benchmark]
	public void DataSegment()
	{
		_dateSegment.Resolve(_shell);
	}

	[Benchmark]
	public void GitSegment()
	{
		_gitSegment.Resolve(_shell);
	}

	//[Benchmark]
	public void PathSegment()
	{
		_pathSegment.Resolve(_shell);
	}

	//[Benchmark]
	public void PlatformSegment()
	{
		_platformSegment.Resolve(_shell);
	}
}