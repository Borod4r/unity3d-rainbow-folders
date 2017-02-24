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

using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    public static class RainbowFoldersPresetsMenu
    {
        private const string MENU_COLORIZE = "Colors/";
        private const string MENU_TAG = "Tags/";
        private const string MENU_TYPE = "Types/";
        private const string MENU_PLATFORM = "Platforms/";

        // Colors
        private static readonly GUIContent COLOR_RED = new GUIContent(MENU_COLORIZE + "Red");
        private static readonly GUIContent COLOR_VERMILION = new GUIContent(MENU_COLORIZE + "Vermilion");
        private static readonly GUIContent COLOR_ORANGE = new GUIContent(MENU_COLORIZE + "Orange");
        private static readonly GUIContent COLOR_YELLOW_ORANGE = new GUIContent(MENU_COLORIZE + "Yellow-Orange");
        private static readonly GUIContent COLOR_YELLOW = new GUIContent(MENU_COLORIZE + "Yellow");
        private static readonly GUIContent COLOR_LIME = new GUIContent(MENU_COLORIZE + "Lime");
        private static readonly GUIContent COLOR_GREEN = new GUIContent(MENU_COLORIZE + "Green");
        private static readonly GUIContent COLOR_BONDI_BLUE = new GUIContent(MENU_COLORIZE + "Bondi Blue");
        private static readonly GUIContent COLOR_BLUE = new GUIContent(MENU_COLORIZE + "Blue");
        private static readonly GUIContent COLOR_INDIGO = new GUIContent(MENU_COLORIZE + "Indigo");
        private static readonly GUIContent COLOR_VIOLET = new GUIContent(MENU_COLORIZE + "Violet");
        private static readonly GUIContent COLOR_MAGENTA = new GUIContent(MENU_COLORIZE + "Magenta");

        // Tags
        private static readonly GUIContent TAG_RED = new GUIContent(MENU_TAG + "Red");
        private static readonly GUIContent TAG_VERMILION = new GUIContent(MENU_TAG + "Vermilion");
        private static readonly GUIContent TAG_ORANGE = new GUIContent(MENU_TAG + "Orange");
        private static readonly GUIContent TAG_YELLOW_ORANGE = new GUIContent(MENU_TAG + "Yellow-Orange");
        private static readonly GUIContent TAG_YELLOW = new GUIContent(MENU_TAG + "Yellow");
        private static readonly GUIContent TAG_LIME = new GUIContent(MENU_TAG + "Lime");
        private static readonly GUIContent TAG_GREEN = new GUIContent(MENU_TAG + "Green");
        private static readonly GUIContent TAG_CYAN = new GUIContent(MENU_TAG + "Cyan");
        private static readonly GUIContent TAG_BLUE = new GUIContent(MENU_TAG + "Blue");
        private static readonly GUIContent TAG_DARK_BLUE = new GUIContent(MENU_TAG + "Dark Blue");
        private static readonly GUIContent TAG_VIOLET = new GUIContent(MENU_TAG + "Violet");
        private static readonly GUIContent TAG_MAGENTA = new GUIContent(MENU_TAG + "Magenta");

        // Types
        private static readonly GUIContent TYPE_AUDIO = new GUIContent(MENU_TYPE + "Audio");
        private static readonly GUIContent TYPE_BRACKETS = new GUIContent(MENU_TYPE + "Brackets");
        private static readonly GUIContent TYPE_EDITOR = new GUIContent(MENU_TYPE + "Editor");
        private static readonly GUIContent TYPE_EXTENSIONS = new GUIContent(MENU_TYPE + "Extensions");
        private static readonly GUIContent TYPE_FONTS = new GUIContent(MENU_TYPE + "Fonts");
        private static readonly GUIContent TYPE_MATERIALS = new GUIContent(MENU_TYPE + "Materials");
        private static readonly GUIContent TYPE_MESHES = new GUIContent(MENU_TYPE + "Meshes");
        private static readonly GUIContent TYPE_PLUGINS = new GUIContent(MENU_TYPE + "Plugins");
        private static readonly GUIContent TYPE_PREFABS = new GUIContent(MENU_TYPE + "Prefabs");
        private static readonly GUIContent TYPE_RAINBOW = new GUIContent(MENU_TYPE + "Rainbow");
        private static readonly GUIContent TYPE_RESOURCES = new GUIContent(MENU_TYPE + "Resources");
        private static readonly GUIContent TYPE_SCENES = new GUIContent(MENU_TYPE + "Scenes");
        private static readonly GUIContent TYPE_SCRIPTS = new GUIContent(MENU_TYPE + "Scripts");
        private static readonly GUIContent TYPE_SHADERS = new GUIContent(MENU_TYPE + "Shaders");
        private static readonly GUIContent TYPE_TERRAINS = new GUIContent(MENU_TYPE + "Terrains");
        private static readonly GUIContent TYPE_TEXTURES = new GUIContent(MENU_TYPE + "Textures");

        // Platforms
        private static readonly GUIContent PLATFORM_ANDROID = new GUIContent(MENU_PLATFORM + "Android");
        private static readonly GUIContent PLATFORM_IOS = new GUIContent(MENU_PLATFORM + "iOS");
        private static readonly GUIContent PLATFORM_MAC = new GUIContent(MENU_PLATFORM + "Mac");
        private static readonly GUIContent PLATFORM_WEBGL = new GUIContent(MENU_PLATFORM + "WebGL");
        private static readonly GUIContent PLATFORM_WINDOWS = new GUIContent(MENU_PLATFORM + "Windows");

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static void ShowDropDown(Rect position, RainbowFolder folder)
        {
            var menu = new GenericMenu();

            // Colors
            menu.AddItem(COLOR_RED,           false, RedCallback,          folder);
            menu.AddItem(COLOR_VERMILION,     false, VermilionCallback,    folder);
            menu.AddItem(COLOR_ORANGE,        false, OrangeCallback,       folder);
            menu.AddItem(COLOR_YELLOW_ORANGE, false, YellowOrangeCallback, folder);
            menu.AddItem(COLOR_YELLOW,        false, YellowCallback,       folder);
            menu.AddItem(COLOR_LIME,          false, LimeCallback,         folder);
            menu.AddItem(COLOR_GREEN,         false, GreenCallback,        folder);
            menu.AddItem(COLOR_BONDI_BLUE,    false, BondiBlueCallback,    folder);
            menu.AddItem(COLOR_BLUE,          false, BlueCallback,         folder);
            menu.AddItem(COLOR_INDIGO,        false, IndigoCallback,       folder);
            menu.AddItem(COLOR_VIOLET,        false, VioletCallback,       folder);
            menu.AddItem(COLOR_MAGENTA,       false, MagentaCallback,      folder);

            // Tags
            menu.AddItem(TAG_RED,           false, TagRedCallback,          folder);
            menu.AddItem(TAG_VERMILION,     false, TagVermilionCallback,    folder);
            menu.AddItem(TAG_ORANGE,        false, TagOrangeCallback,       folder);
            menu.AddItem(TAG_YELLOW_ORANGE, false, TagYellowOrangeCallback, folder);
            menu.AddItem(TAG_YELLOW,        false, TagYellowCallback,       folder);
            menu.AddItem(TAG_LIME,          false, TagLimeCallback,         folder);
            menu.AddItem(TAG_GREEN,         false, TagGreenCallback,        folder);
            menu.AddItem(TAG_CYAN,          false, TagCyanCallback,         folder);
            menu.AddItem(TAG_BLUE,          false, TagBlueCallback,         folder);
            menu.AddItem(TAG_DARK_BLUE,     false, TagDarkBlueCallback,     folder);
            menu.AddItem(TAG_VIOLET,        false, TagVioletCallback,       folder);
            menu.AddItem(TAG_MAGENTA,       false, TagMagentaCallback,      folder);

            //Types
            menu.AddItem(TYPE_AUDIO,      false, AudioCallback,      folder);
            menu.AddItem(TYPE_BRACKETS,   false, BracketsCallback,   folder);
            menu.AddItem(TYPE_EDITOR,     false, EditorCallback,     folder);
            menu.AddItem(TYPE_EXTENSIONS, false, ExtensionsCallback, folder);
            menu.AddItem(TYPE_FONTS,      false, FontsCallback,      folder);
            menu.AddItem(TYPE_MATERIALS,  false, MaterialsCallback,  folder);
            menu.AddItem(TYPE_MESHES,     false, MeshesCallback,     folder);
            menu.AddItem(TYPE_PLUGINS,    false, PluginsCallback,    folder);
            menu.AddItem(TYPE_PREFABS,    false, PrefabsCallback,    folder);
            menu.AddItem(TYPE_RAINBOW,    false, RainbowCallback,    folder);
            menu.AddItem(TYPE_RESOURCES,  false, ResourcesCallback,  folder);
            menu.AddItem(TYPE_SCENES,     false, ScenesCallback,     folder);
            menu.AddItem(TYPE_SCRIPTS,    false, ScriptsCallback,    folder);
            menu.AddItem(TYPE_SHADERS,    false, ShadersCallback,    folder);
            menu.AddItem(TYPE_TERRAINS,   false, TerrainsCallback,   folder);
            menu.AddItem(TYPE_TEXTURES,   false, TexturesCallback,   folder);

            //Platfroms
            menu.AddItem(PLATFORM_ANDROID, false, AndroidCallback, folder);
            menu.AddItem(PLATFORM_IOS, false, IosCallback, folder);
            menu.AddItem(PLATFORM_MAC, false, MacCallback, folder);
            menu.AddItem(PLATFORM_WEBGL, false, WebGLCallback, folder);
            menu.AddItem(PLATFORM_WINDOWS, false, WindowsCallback, folder);

            menu.DropDown(position);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static void Colorize(FolderColorName color, RainbowFolder folder)
        {
            var icons = FolderColorsStorage.Instance.GetIconsByColor(color);
            folder.SmallIcon = icons.SmallIcon;
            folder.LargeIcon = icons.LargeIcon;
        }

        private static void AssignTag(FolderTagName tag, RainbowFolder folder)
        {
            var icons = FolderTagsStorage.Instance.GetIconsByTag(tag);
            folder.SmallIcon = icons.SmallIcon;
            folder.LargeIcon = icons.LargeIcon;
        }

        private static void AssingType(FolderTypeName type, RainbowFolder folder)
        {
            var icons = FolderTypesStorage.Instance.GetIconsByType(type);
            folder.SmallIcon = icons.SmallIcon;
            folder.LargeIcon = icons.LargeIcon;
        }

        private static void AssingPlatform(FolderPlatformName platform, RainbowFolder folder)
        {
            var icons = FolderPlatformsStorage.Instance.GetIconsByType(platform);
            folder.SmallIcon = icons.SmallIcon;
            folder.LargeIcon = icons.LargeIcon;
        }

        //---------------------------------------------------------------------
        // Callbacks
        //---------------------------------------------------------------------

        // Colors

        private static void RedCallback(object folder)
        { Colorize(FolderColorName.Red, folder as RainbowFolder); }

        private static void VermilionCallback(object folder)
        { Colorize(FolderColorName.Vermilion, folder as RainbowFolder); }

        private static void OrangeCallback(object folder)
        { Colorize(FolderColorName.Orange, folder as RainbowFolder); }

        private static void YellowOrangeCallback(object folder)
        { Colorize(FolderColorName.YellowOrange, folder as RainbowFolder); }

        private static void YellowCallback(object folder)
        { Colorize(FolderColorName.Yellow, folder as RainbowFolder); }

        private static void LimeCallback(object folder)
        { Colorize(FolderColorName.Lime, folder as RainbowFolder); }

        private static void GreenCallback(object folder)
        { Colorize(FolderColorName.Green, folder as RainbowFolder); }

        private static void BondiBlueCallback(object folder)
        { Colorize(FolderColorName.BondiBlue, folder as RainbowFolder); }

        private static void BlueCallback(object folder)
        { Colorize(FolderColorName.Blue, folder as RainbowFolder); }

        private static void IndigoCallback(object folder)
        { Colorize(FolderColorName.Indigo, folder as RainbowFolder); }

        private static void VioletCallback(object folder)
        { Colorize(FolderColorName.Violet, folder as RainbowFolder); }

        private static void MagentaCallback(object folder)
        { Colorize(FolderColorName.Magenta, folder as RainbowFolder); }

        // Tags

        private static void TagRedCallback(object folder)
        { AssignTag(FolderTagName.Red, folder as RainbowFolder); }

        private static void TagVermilionCallback(object folder)
        { AssignTag(FolderTagName.Vermilion, folder as RainbowFolder); }

        private static void TagOrangeCallback(object folder)
        { AssignTag(FolderTagName.Orange, folder as RainbowFolder); }

        private static void TagYellowOrangeCallback(object folder)
        { AssignTag(FolderTagName.YellowOrange, folder as RainbowFolder); }

        private static void TagYellowCallback(object folder)
        { AssignTag(FolderTagName.Yellow, folder as RainbowFolder); }

        private static void TagLimeCallback(object folder)
        { AssignTag(FolderTagName.Lime, folder as RainbowFolder); }

        private static void TagGreenCallback(object folder)
        { AssignTag(FolderTagName.Green, folder as RainbowFolder); }

        private static void TagCyanCallback(object folder)
        { AssignTag(FolderTagName.Cyan, folder as RainbowFolder); }

        private static void TagBlueCallback(object folder)
        { AssignTag(FolderTagName.Blue, folder as RainbowFolder); }

        private static void TagDarkBlueCallback(object folder)
        { AssignTag(FolderTagName.DarkBlue, folder as RainbowFolder); }

        private static void TagVioletCallback(object folder)
        { AssignTag(FolderTagName.Violet, folder as RainbowFolder); }

        private static void TagMagentaCallback(object folder)
        { AssignTag(FolderTagName.Magenta, folder as RainbowFolder); }

        // Types

        private static void PrefabsCallback(object folder)
        { AssingType(FolderTypeName.Prefabs, folder as RainbowFolder); }

        private static void ScenesCallback(object folder)
        { AssingType(FolderTypeName.Scenes, folder as RainbowFolder); }

        private static void ScriptsCallback(object folder)
        { AssingType(FolderTypeName.Scripts, folder as RainbowFolder); }

        private static void ExtensionsCallback(object folder)
        { AssingType(FolderTypeName.Extensions, folder as RainbowFolder); }

        private static void PluginsCallback(object folder)
        { AssingType(FolderTypeName.Plugins, folder as RainbowFolder); }

        private static void TexturesCallback(object folder)
        { AssingType(FolderTypeName.Textures, folder as RainbowFolder); }

        private static void MaterialsCallback(object folder)
        { AssingType(FolderTypeName.Materials, folder as RainbowFolder); }

        private static void AudioCallback(object folder)
        { AssingType(FolderTypeName.Audio, folder as RainbowFolder); }

        private static void BracketsCallback(object folder)
        { AssingType(FolderTypeName.Brackets, folder as RainbowFolder); }

        private static void FontsCallback(object folder)
        { AssingType(FolderTypeName.Fonts, folder as RainbowFolder); }

        private static void EditorCallback(object folder)
        { AssingType(FolderTypeName.Editor, folder as RainbowFolder); }

        private static void ResourcesCallback(object folder)
        { AssingType(FolderTypeName.Resources, folder as RainbowFolder); }

        private static void ShadersCallback(object folder)
        { AssingType(FolderTypeName.Shaders, folder as RainbowFolder); }

        private static void TerrainsCallback(object folder)
        { AssingType(FolderTypeName.Terrains, folder as RainbowFolder); }

        private static void MeshesCallback(object folder)
        { AssingType(FolderTypeName.Meshes, folder as RainbowFolder); }

        private static void RainbowCallback(object folder)
        { AssingType(FolderTypeName.Rainbow, folder as RainbowFolder); }

        // Platfroms

        private static void AndroidCallback(object folder)
        { AssingPlatform(FolderPlatformName.Android, folder as RainbowFolder); }

        private static void IosCallback(object folder)
        { AssingPlatform(FolderPlatformName.iOS, folder as RainbowFolder); }

        private static void MacCallback(object folder)
        { AssingPlatform(FolderPlatformName.Mac, folder as RainbowFolder); }

        private static void WebGLCallback(object folder)
        { AssingPlatform(FolderPlatformName.WebGL, folder as RainbowFolder); }

        private static void WindowsCallback(object folder)
        { AssingPlatform(FolderPlatformName.Windows, folder as RainbowFolder); }
    }
}