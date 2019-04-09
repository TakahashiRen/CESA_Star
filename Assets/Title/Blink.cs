using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// テキスト点滅
/// </summary>
public class Blink : MonoBehaviour {
    // 点滅間隔
    public float m_interval;

    // テキストの一時保存
    private string m_str;
    // テキスト
    private Text m_text;
    // 時間の計測用
    private float m_timer = 0;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start() {
        // テキストの一時保存
        m_text = gameObject.GetComponent<Text>();
        m_str = m_text.text;  
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update() {
        // 時間
        m_timer += Time.deltaTime;
        
        // 文字の変更
        if (m_timer > m_interval) {
            m_text.text = (m_text.text == "") ? m_str : "";
            // 時間の初期化
            m_timer = 0;
        }
    }    
}
