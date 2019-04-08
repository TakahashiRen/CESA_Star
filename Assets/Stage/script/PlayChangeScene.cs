using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの変更クラス
/// </summary>
static public class PlayChangeScene
{
    /// <summary>
    /// シーンの変更
    /// </summary>
    /// <param name="name">変更先</param>
    static public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
