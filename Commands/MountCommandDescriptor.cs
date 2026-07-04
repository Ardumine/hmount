using HCore.Modules.Base;

namespace HCore.Packages.HMount.Commands;

public class MountCommandDescriptor : IModuleDescriptor
{
    public string Name => "HCore.Packages.HMount.MountCmd";

    public string FriendlyName => "mount command";

    public Type ImplementType => typeof(MountCommandImplement);

    public Type InterfaceType => typeof(IOneshotCommand);
}
