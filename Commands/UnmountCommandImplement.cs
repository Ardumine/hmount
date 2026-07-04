using HCore.Modules.Base;

namespace HCore.Packages.HMount.Commands;

public sealed class UnmountCommandImplement : BaseImplement, IOneshotCommand
{
    private string[] _args = [];

    public void SetArguments(string[] args) => _args = args;

    public void Run()
    {
        ShellContext.RequireArgs(_args, 2,
            "usage: unmount <mountpoint>");

        var mountPoint = _args[1];

        var fstab = Host.GetModuleInterface<Mount.IMount>("fstab");
        var result = fstab.Unmount(mountPoint);
        Console.WriteLine(result);
    }
}
