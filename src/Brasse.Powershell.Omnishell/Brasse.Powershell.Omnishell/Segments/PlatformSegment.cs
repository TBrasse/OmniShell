namespace Omnishell.Core.Segments
{
    class PlatformSegment : BaseSegment
    {
        public override string Name => "platform";
        public override string[] Expressions => new[] {
            "''"
        };
        //"$result = switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{''} 'MacOSX'{''}}",
        //"echo $result"
    }
}
