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

using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    public class RainbowFoldersWelcome : EditorWindow
    {
        private const string TITLE = "Rainbow Folders";

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static void ShowWindow(Vector2 position)
        {
            var window = GetWindow<RainbowFoldersWelcome>();
            window.position = new Rect(position, new Vector2(window.position.width, window.position.height));
            //window.position.Set(position.x, position.y, window.position.width, window.position.height);
            window.Show();

        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        protected void OnGUI()
        {
            EditorGUILayout.LabelField("With \"Rainbow Folders\" you can set custom icon for any folder in unity project browser");
        }
    }
}