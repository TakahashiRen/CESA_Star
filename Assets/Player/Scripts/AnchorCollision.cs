using UnityEngine;

/// <summary>
/// アンカーの当たり判定情報
/// </summary>
public class AnchorCollision : MonoBehaviour
{
    // 当たり判定変数
    public bool m_collisionFlag { get; set; } = false;

    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="other">当たったものの情報</param>
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Wall")   m_collisionFlag = true;
    }
}
