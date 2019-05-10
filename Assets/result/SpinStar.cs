using UnityEngine;

/// <summary>
/// 星の回転
/// </summary>
public class SpinStar : MonoBehaviour
{
    // 速さ
    public float m_speed;

    // Update is called once per frame
    void Update()
    {
        // 回転
        transform.Rotate(Vector3.forward, m_speed);  
    }
}
