# Discontinued

This project is discontinued and deprecated. Unfortunately, our benefit from the open source project was too low to justify the extra effort to keep it alive.

Meanwhile, development continues and new versions of the Rainbow Folders are now available exclusively on the [Asset Store](http://u3d.as/mor)


Now back to original README content…

# Unity3D Rainbow Folders

[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](https://raw.githubusercontent.com/PhannGor/unity3d-rainbow-folders/master/LICENSE)


Have you ever thought about highlighting often used project folders? This simple but colorful asset allows you to do that!

With "Rainbow Folders" you can set custom icon for any folder in unity project browser:

![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/01.png)
![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/02.png)
![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/03.png)

## Installing

Rainbow Folders is a standard Unity extension and should be installed like any other Unity package. Just drag the RainbowFolders.unitypackage into your current project, or in the Editor go to the drop-down menu Assets → Import Package → Custom Package and then browse to the RainbowFolders.unitypackage file.

When downloading from the Asset Store then Download Manager will automate this process.

![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/02.png)

Once the Importing dialog appears, just click the Import button.

## Installation through Unity-Package-Manager (2019.2+)
 * MenuItem - Window - Package Manager
 * Add package from git url
 * paste https://github.com/Team-on/unity3d-rainbow-folders.git#master

## Folder location

The package will be imported into the `Assets/Plugins/RainbowFolders` folder by default. Most users prefer to keep it here, but you can freely move it wherever you want.  Just go to **Edit → Preferences → Rainbow Folders** and update the folder location:

![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/03.png) 

## Configuring folder icons

To apply custom icon for some folder in your project view, just hold the **Modifier key** and click on any folder icon in Unity project browser. By default, it’s the **Alt key**, but you can change it in **Preferences**.

![Alt-click example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/04.png)

Configuration dialogue will appear, and you'll be able to assign icons to the corresponding folder.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/05.png)

What you need to configure for each folder item, are these fields:

* **Folder Name** - icon will be applied to all folders with that name.
* or **Folder Path** - icon will be applied to a single folder with specified path.
* **Recursive** checkbox - subfolders icons will be changed automatically

Then you need to specify actually icons:
* **Small Icon** - custom icon for the left panel of the project browser (16x16 px)
* **Large Icon** - custom icon for the right panel of the project browser (64x64 px)

Your changes will be applied next time when the project browser will retrieve the focus.

### Presets

You can choose icons from few dozen of presets. Simply click on the star button in configuration dialog, select one of them from the drop-down menu and apply changes.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/07.png)
![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/08.png)

### Revert to default

To reset the folder icon to the default one, just **Alt-click** on it, then press the red cross button in configuration dialogue and apply changes.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/06.png)

### Multi-editing

You can also edit multiple folders at once, just select them all and **Alt-click** at one of their icons.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/09.png)

### Configs List

To view all existing assignments, click on the gear button in the configuration dialog, then take a look at the Inspector.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/10.png)

There is reorderable list with all defined "folder" configurations. You can modify existing items, remove them using "-" button or add new ones by clicking "+" button below.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v07/11.png)

If there is more than one config for the same folder (including recursive assignments), then **latest (lowest) item** in the list will be applied.

## Context menu

All the above functionality is also available via the context menu.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/14.png)

**Right-click** on any folder in project view and select **Rainbow Folders → Apply Custom** to open configuration dialogue.

The **Rainbow Folders → Revert to Default** item will reset corresponding folder icon to the default one.

With **Color, Tag, Type** and **Platform** sub-items you can easily apply custom icons from few dozen of presets, right from the context menu.

Select **Rainbow Folders → Settings** to view all existing assignments in the inspector.

## Upgrading

Please always do a clean import of the **Rainbow Folders** package (delete the old version before importing the new one). Otherwise, you may receive a number of difficult to diagnose issues.
* Backup your settings file (optional):
`Assets/.../RainbowFolders/Editor/Data/RainbowFoldersSettings.asset`
* Delete the `Assets/.../RainbowFolders` folder.
* Delete the `Assets/Editor Default Resources/RainbowFolders` folder, if exists.
* Import the new version from package or from the Asset Store.
* Restore your settings file.
