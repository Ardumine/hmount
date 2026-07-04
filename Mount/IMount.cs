using HCore.Modules.Base;

namespace HCore.Packages.HMount.Mount;

/// <summary>
/// The fstab mounter. On <see cref="IRunnable.Run"/> it reads <c>/etc/fstab</c>
/// and mounts every listed filesystem through the privileged <c>@vfs</c> kernel
/// service. Runs once at boot as a service, then stays resident in <c>/proc</c>.
/// <para>Provides individual <see cref="Mount"/> and <see cref="Unmount"/> methods
/// callable from the shell's <c>mount</c>/<c>unmount</c> commands.</para>
/// </summary>
public interface IMount : IRunnable
{
    /// <summary>
    /// Parse and mount every entry in <paramref name="fstabPath"/> (defaults to
    /// <c>/etc/fstab</c>). Returns the number of filesystems successfully mounted.
    /// </summary>
    int MountAll(string fstabPath = "/etc/fstab");

    /// <summary>
    /// Mount a single filesystem. Parameters mirror the fstab format:
    /// <c>source mountPoint fsType [options]</c>.
    /// <para>Local types (<c>hostfs</c>/<c>memfs</c>/<c>tmpfs</c>/<c>devfs</c>) are
    /// mounted through <c>@vfs</c>; <c>nexus</c> is mounted through <c>@afcp</c>.</para>
    /// <para>Options (comma-separated): <c>ro</c>/<c>rw</c>, <c>replace</c>.</para>
    /// Returns a human-readable status string. Throws on failure.
    /// </summary>
    string Mount(string source, string mountPoint, string fsType, string options = "rw");

    /// <summary>
    /// Unmount the filesystem at <paramref name="mountPoint"/>, whether local
    /// (<c>@vfs</c>) or remote (<c>@afcp</c>). Returns a human-readable status
    /// string. Throws on failure.
    /// </summary>
    string Unmount(string mountPoint);
}
