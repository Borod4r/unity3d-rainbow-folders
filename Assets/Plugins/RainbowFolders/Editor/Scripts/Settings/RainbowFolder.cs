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

using System;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor.Settings
{
    [Serializable]
    public class RainbowFolder
    {
        public KeyType Type;
        public string Key;
        public bool IsRecursive;

        public Texture2D SmallIcon;
        public Texture2D LargeIcon;

        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        public RainbowFolder(RainbowFolder value)
        {
            Type = value.Type;
            Key = value.Key;
            IsRecursive = value.IsRecursive;
            SmallIcon = value.SmallIcon;
            LargeIcon = value.LargeIcon;
        }

        public RainbowFolder(KeyType type, string key)
        {
            Type = type;
            Key = key;
        }

        public RainbowFolder(KeyType type, string key, FolderIconPair icons)
        {
            Type = type;
            Key = key;
            SmallIcon = icons.SmallIcon;
            LargeIcon = icons.LargeIcon;
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public void CopyFrom(RainbowFolder target)
        {
            Type = target.Type;
            Key = target.Key;
            IsRecursive = target.IsRecursive;
            SmallIcon = target.SmallIcon;
            LargeIcon = target.LargeIcon;
        }

        public bool HasAtLeastOneIcon()
        {
            return SmallIcon != null || LargeIcon != null;
        }

        //---------------------------------------------------------------------
        // Nested
        //---------------------------------------------------------------------

        public enum KeyType
        {
            Name,
            Path
        }
    }
}