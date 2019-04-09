using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間計測
/// </summary>
public class ResultTime : MonoBehaviour
{
    // 時間
    float m_timer = 0;
    // テキスト
    Text m_text;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // コンポーネントの取得
        m_text = gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// 更新  
    /// </summary>
    void Update()
    {
        // 時間の計測
        m_timer += Time.deltaTime;

        // 時間の表示
        m_text.text = m_timer.ToString();
    }

    /// <summary>
    /// クリア時間の保存
    /// </summary>
    public void SeveTime()
    {
        // 時間の保存
        //ScoreData.time = m_timer;
    }
}
