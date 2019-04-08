﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンの変更
/// </summary>
public class ChangeSceneResult : MonoBehaviour
{
    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        PlayChangeScene.ChangeScene("Stage_01");
    }
}
