/*
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */


using System.Linq;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor
{
    public static class RainbowFoldersExtensionMethods
    {
        public static void ChangeFolderIconsByPath(this RainbowFoldersSettings settings, string path, FolderIconPair icons)
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
                    SmallIcon = icons.SmallIcon,
                    LargeIcon = icons.LargeIcon
                });
            }
            else
            {
                folder.SmallIcon = icons.SmallIcon;
                folder.LargeIcon = icons.LargeIcon;
            }

            EditorUtility.SetDirty(settings);
        }

        public static void RemoveAllByPath(this RainbowFoldersSettings settings, string path)
        {
            settings.Folders.RemoveAll(x => x.Key == path);
        }
    }
}