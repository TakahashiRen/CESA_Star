using UnityEngine;

/// <summary>
/// シーンの変更 (Title -> )
/// </summary>
public class ChangeTitleScene : MonoBehaviour {
    /// <summary>
    /// 更新
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayChangeScene.ChangeScene("Stage_01");
        }
    }
}
