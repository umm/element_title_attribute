# Element Title Attribute

## What

* Provide `[ElementTitle("Foo")]` attribute
* Display any SerializeField value to title of array/list elements in Inspector

<img src="https://user-images.githubusercontent.com/838945/45629329-1c44c400-bad1-11e8-8050-d6c086242b6e.png" width="50%" />

* This module inspired by [this post](https://forum.unity.com/threads/how-to-change-the-name-of-list-elements-in-the-inspector.448910/#post-3027279)

## Requirement

* .NET 4.x / C# 6.0

## Install

```shell
yarn add "umm/element_title_attribute#^1.0.0"
```

## Usage

### Before

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnyMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<AnyStructure> AnyStructureList;
}

public enum AnyEnum
{
    Foo,
    Bar,
    Buz,
    Quz,
}

[Serializable]
public struct AnyStructure
{
    [SerializeField] private AnyEnum anyEnum;
}
```

<img src="https://user-images.githubusercontent.com/838945/45629104-932d8d00-bad0-11e8-8b99-b8817a5aefbd.png" width="50%" />

### After

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnyMonoBehaviour : MonoBehaviour
{
    [SerializeField] [ElementTitle("anyEnum")] // Add ElementTitleAttribute
    private List<AnyStructure> AnyStructureList;
}

public enum AnyEnum
{
    Foo,
    Bar,
    Buz,
    Quz,
}

[Serializable]
public struct AnyStructure
{
    [SerializeField] private AnyEnum anyEnum;
}
```

<img src="https://user-images.githubusercontent.com/838945/45629329-1c44c400-bad1-11e8-8050-d6c086242b6e.png" width="50%" />


## License

Copyright (c) 2018 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

