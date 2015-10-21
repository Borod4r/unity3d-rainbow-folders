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

using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Borodar.RainbowFolders.Editor.Settings
{
    public class RainbowFoldersSettings : ScriptableObject
    {
        public const string RESOURCE_NAME = "RainbowFoldersSettings";

        public List<RainbowFolder> Folders;

        public static RainbowFoldersSettings Load()
        {
            var settings = Resources.Load<RainbowFoldersSettings>(RESOURCE_NAME);
            if (settings == null)
            {
                RainbowFoldersEditorUtility.CreateAsset<RainbowFoldersSettings>(RESOURCE_NAME, "Assets/Resources");
                settings = Resources.Load<RainbowFoldersSettings>(RESOURCE_NAME);
            }
            return settings;
        }

        public Texture2D GetTextureByFolderName(string folderName, bool small = true)
        {
            if (IsNullOrEmpty(Folders)) return null;

            var folder = Folders.FirstOrDefault(x => x.Name.Equals(folderName));
            if (folder == null) return null;

            return small ? folder.SmallIcon : folder.LargeIcon;
        }

        private static bool IsNullOrEmpty(ICollection collection)
        {
            if (collection != null)
            {
                return (collection.Count == 0);
            }
            return true;
        }
    }
}