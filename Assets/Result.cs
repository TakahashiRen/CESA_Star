using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    // テキスト
    private Text m_text;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // コンポーネントの取得
        m_text = gameObject.GetComponent<Text>();
        m_text.text = ScoreData.time.ToString();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        
    }
}
