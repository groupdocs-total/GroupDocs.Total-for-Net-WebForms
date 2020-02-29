using System;
using System.IO;
using System.Linq;

namespace GroupDocs.Total.WebForms.Products.Metadata.Util.Directory
{
    public static class DirectoryUtils
    {
        internal static bool IsFullPath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }
    }
}