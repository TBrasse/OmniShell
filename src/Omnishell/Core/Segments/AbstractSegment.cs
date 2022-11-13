using Core.Painter;
using Core.Shell;

namespace Core.Segments;

public abstract class AbstractSegment
{
	virtual public string Name { get; set; }
	virtual public Format Format { get; set; }
	virtual public string Value { get; set; }
	virtual public PaintedString Prefix { get; set; }
	virtual public PaintedString Center { get; set; }
	virtual public PaintedString Suffix { get; set; }
	abstract public bool Resolve(IShellExecutor shell);
	virtual public Task<bool> ResolveAsync(IShellExecutor shell){
		return Task<bool>.Run(() => Resolve(shell));
	}
}