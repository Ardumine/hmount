using HCore.Modules.Base;

namespace HCore.Packages.HMount.Commands;

public class UnmountCommandDescriptor : IModuleDescriptor
{
    public string Name => "HCore.Packages.HMount.UnmountCmd";

    public string FriendlyName => "unmount command";

    public Type ImplementType => typeof(UnmountCommandImplement);

    public Type InterfaceType => typeof(IOneshotCommand);
}
