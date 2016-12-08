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

using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EditorUtility = Borodar.RainbowFolders.Editor.RainbowFoldersEditorUtility;

namespace Borodar.RainbowFolders.Editor
{
    public class FolderTagsStorage : ScriptableObject
    {
        private const string RELATIVE_PATH = "Editor/Data/FolderTagsStorage.asset";

        public List<FolderTag> ColorFolderTags;

        //---------------------------------------------------------------------
        // Instance
        //---------------------------------------------------------------------

        private static FolderTagsStorage _instance;

        [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
        public static FolderTagsStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = EditorUtility.LoadFromAsset<FolderTagsStorage>(RELATIVE_PATH);

                return _instance;
            }
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public FolderIconPair GetIconsByTag(FolderTagName tag)
        {
            var taggedFolder = ColorFolderTags.Single(x => x.Tag == tag);
            return new FolderIconPair { SmallIcon = taggedFolder.SmallIcon, LargeIcon = taggedFolder.LargeIcon };
        }
    }
}
