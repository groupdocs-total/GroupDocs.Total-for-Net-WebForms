﻿using System;
using System.Linq;
using System.IO;

namespace GroupDocs.Total.WebForms.Products.Search.Util.Directory
{
    public static class DirectoryUtils
    {
        internal static bool IsFullPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }
    }
}