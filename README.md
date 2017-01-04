# Unity3D Rainbow Folders

[![Join the chat at https://gitter.im/PhannGor/unity3d-rainbow-folders](https://badges.gitter.im/PhannGor/unity3d-rainbow-folders.svg)](https://gitter.im/PhannGor/unity3d-rainbow-folders?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/tarasleskiv/2USD)

Have you ever thought about highlighting often used project folders? This simple but colorful asset allows you to do that!

With "Rainbow Folders" you can set custom icon for any folder in unity project browser:

![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/01.png)
![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/02.png)
![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/03.png)

## Configuring folder icons

Just hold the **Alt key** and click on any folder icon in Unity project browser.

![Alt-click example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/04.png)

Configuration dialogue will appear, and you'll be able to assign icons to the corresponding folder.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/05.png)

What you need to configure for each folder item, are these fields:

* **Folder Name** - icon will be applied to all folders with that name.
* or **Folder Path** - icon will be applied to a single folder with specified path.

Then you need to specify actually icons:
* **Small Icon** - custom icon for the left panel of the project browser (16x16 px)
* **Large Icon** - custom icon for the right panel of the project browser (64x64 px)

Your changes will be applied next time when the project browser will retrieve the focus.

### Presets

You can choose icons from few dozen of presets. Simply click on the star button in configuration dialogue, select one of them from the drop-down menu and apply changes.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/07.png)
![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/08.png)

### Revert to default

To reset the folder icon to the default one, just **Alt-click** on it, then press the red cross button in configuration dialogue and apply changes.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/06.png)

### Multi-editing

You can also edit multiple folders at once, just select them all and **Alt-click** at one of their icons.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/09.png)

To view all existing assignments, click on the gear button in configuration dialogue, then take a look at the Inspector.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/10.png)

There is reorderable list with all defined "folder" configurations. You can modify existing items, remove them using "-" button or add new ones by clicking "+" button below.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/11.png)

## Context menu

All the above functionality is also available via the context menu.

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/14.png)

**Right-click** on any folder in project view and select **Rainbow Folders → Apply Custom** to open configuration dialogue.

The **Rainbow Folders → Revert to Default** item will reset corresponding folder icon to the default one.

With **Color, Tag, Type** and **Platform** sub-items you can easily apply custom icons from few dozen of presets, right from the context menu.

Select **Rainbow Folders → Settings** to view all existing assignments in the inspector.

## Folder Location

The “Rainbow Folders” asset doesn’t require to be in the root of you project, you can freely move it wherever you want. Then just go to **Edit → Preferences → Rainbow Folders** and update the folder location:

![Configuration dialog](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/stuff/rainbowfolders/images/v05/12.png)

## Community

We have created a special folder `Community Icons` for other users to be able to add their icons! Please fork the repo and submit the pull request after adding your icons to `Community Icons/{your_user_name_here}/`

## Support us

Consider supporting us so we could bring more awesome features to you:

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/tarasleskiv/2USD)
