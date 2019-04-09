using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの変更 (Title -> )
/// </summary>
public class ChangeTitleScene : MonoBehaviour {
    /// <summary>
    /// 更新
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // シーンの変更
            SceneManager.LoadScene("");
            Debug.Log("シーンの移動");
        }
    }
}
