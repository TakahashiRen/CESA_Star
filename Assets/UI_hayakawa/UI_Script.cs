using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    // 保存用　
    //private SpriteRenderer m_spriteRender;

    private Text m_text;
    
    // 画像
    private Image m_image;


    // Start is called before the first frame update
    void Start()
    {
        m_text = gameObject.transform.GetChild(0).GetComponent<Text>();
        m_image = gameObject.GetComponent<Image>();
    }

    /// <summary>
    /// 表示のOn/Off
    /// </summary>
    public void DrawSwitch()
    {
        // 画像
        m_image.enabled = m_image.enabled ? false : true;
        // テキスト
        m_text.enabled = m_image.enabled;
    }

    /// <summary>
    /// テキストの読み込み
    /// </summary>
    /// <param name="text">変更文字列</param>
    public void DrawText(string text)
    {
        m_text.text = text;
    }

    /// <summary>
    /// 現在の描画状態の取得
    /// </summary>
    /// <returns></returns>
    public bool GetEnabled()
    {
        return m_image.enabled;
    }
}
