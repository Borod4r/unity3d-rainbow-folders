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

using System.Diagnostics.CodeAnalysis;
using System.IO;
using Borodar.RainbowItems.Editor.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowItems.Editor
{
    public class CustomEditorUtility
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static void DrawTextureGUI(Rect position, Sprite sprite)
        {
            var actualSpriteRect = new Rect(sprite.rect.x / sprite.texture.width, sprite.rect.y / sprite.texture.height, sprite.rect.width / sprite.texture.width, sprite.rect.height / sprite.texture.height);

            var actualSize = position.size;
            actualSize.y *= (sprite.rect.height / sprite.rect.width);

            var actualPosition = new Rect(position.x, position.y + (position.size.y - actualSize.y) / 2, actualSize.x, actualSize.y);
            GUI.DrawTextureWithTexCoords(actualPosition, sprite.texture, actualSpriteRect);
        }

        [MenuItem("Rainbow Items/Create Settings File")]
        public static void CreateSettingsAssetFile()
        {
            CreateAsset<CustomBrowserIconSettings>();
        }

        public static void CreateAsset<T>() where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();

            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == string.Empty)
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != string.Empty)
            {
                path = path.Replace(Path.GetFileName(path), string.Empty);
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T) + ".asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}