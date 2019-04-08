using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 追従カメラ
/// </summary>
public class MainCamera : MonoBehaviour
{
    // 追いかける対象
    public GameObject m_target;
    // 距離
    public float m_len;

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        // 位置の追従
        transform.position = new Vector3(m_target.transform.position.x, m_target.transform.position.y, m_len);
    }
}
