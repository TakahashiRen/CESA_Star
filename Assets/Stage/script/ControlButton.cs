using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタンUIの色変更
/// </summary>
public class ControlButton : MonoBehaviour
{
    // 色を変えるボタン
    private List<Image> m_button = new List<Image>();

    // 変わる色
    public Color m_afterColor;
    public Color m_baceColor;


    // E W O P Q
    /// <summary>
    /// 対応キーの設定
    /// </summary>
    private enum StrKey {E,W,O,P,Q,NOME};
    // キー
    private KeyCode[] m_key = { KeyCode.E, KeyCode.W, KeyCode.O, KeyCode.P, KeyCode.Q };
    
    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // 子オブジェクト追加
        for(int i= 0; i < gameObject.transform.childCount; i++){
            m_button.Add(gameObject.transform.GetChild(i).GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i <  (int)StrKey.NOME; i++){
            if (Input.GetKey(m_key[i])) m_button[i].color = m_afterColor;
            else m_button[i].color = m_baceColor;
        }
    }
}
