using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画像を揺らす
/// </summary>
public class ShakeImage : MonoBehaviour
{
    // 回転角度
    private float m_angle = 0;   

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        // 揺らす処理
        m_angle += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0 , Mathf.Sin(m_angle) / 2));
    }
}
