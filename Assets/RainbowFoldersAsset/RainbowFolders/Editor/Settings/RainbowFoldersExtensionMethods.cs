using System.Linq;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor
{
    public static class RainbowFoldersExtensionMethods
    {
        public static void ColorizeFolderByPath(this RainbowFoldersSettings settings, string path, RainbowColorFolder colorIcons)
        {
            Undo.RecordObject(settings, "Modify Rainbow Folder Settings");

            var folders = settings.Folders;
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

            EditorUtility.SetDirty(settings);
        }
    }
}