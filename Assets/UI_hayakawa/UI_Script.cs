using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    // 保存用　
    private SpriteRenderer m_spriteRender;

    private Text m_text;


    // Start is called before the first frame update
    void Start()
    {
        m_spriteRender = gameObject.GetComponent<SpriteRenderer>();
        m_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーを押す
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrawSwitch();
        }
    }

    /// <summary>
    /// 表示のOn/Off
    /// </summary>
    public void DrawSwitch()
    {
        m_spriteRender.enabled = m_spriteRender.enabled ? false : true;
    }

    //テキストの読み込み
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
        return m_spriteRender.enabled;
    }
}
