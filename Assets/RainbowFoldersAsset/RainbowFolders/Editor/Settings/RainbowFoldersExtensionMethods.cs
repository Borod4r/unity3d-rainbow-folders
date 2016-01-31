using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Borodar.RainbowFolders.Editor.Settings;

namespace Borodar.RainbowFolders.Editor
{
    public static class RainbowFoldersExtensionMethods
    {
        public static void ColorizeFolder(this List<RainbowFolder> folders, string path, RainbowColorFolder colorIcons)
        {
            var folder = folders.SingleOrDefault(x => x.Key == path);
            if (folder == null)
            {
                folders.Add(new RainbowFolder
                {
                    Key = path,
                    Type = RainbowFolder.KeyType.Path,
                    SmallIcon = colorIcons.SmallIcon,
                    LargeIcon = colorIcons.LargeIcon
                });
            }
            else
            {
                folder.SmallIcon = colorIcons.SmallIcon;
                folder.LargeIcon = colorIcons.LargeIcon;
            }
        }
    }
}