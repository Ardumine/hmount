using HCore.Modules.Base;

namespace HCore.Packages.HMount.Commands;

public sealed class MountCommandImplement : BaseImplement, IOneshotCommand
{
    private string[] _args = [];

    public void SetArguments(string[] args) => _args = args;

    public void Run()
    {
        ShellContext.RequireArgs(_args, 4,
            "usage: mount <source> <mountpoint> <type> [options]");

        var source = _args[1];
        var mountPoint = _args[2];
        var fsType = _args[3];
        var options = _args.Length > 4 ? _args[4] : "rw";

        var fstab = Host.GetModuleInterface<Mount.IMount>("fstab");
        var result = fstab.Mount(source, mountPoint, fsType, options);
        Console.WriteLine(result);
    }
}
