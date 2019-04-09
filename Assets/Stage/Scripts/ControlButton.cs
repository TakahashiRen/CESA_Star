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

    // 星のプレイヤー
    public GameObject m_player;
    // プレイヤースクリプト
    private PlayerControl m_playerControl;
    
    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // 子オブジェクト追加
        for(int i= 0; i < gameObject.transform.childCount; i++){
            m_button.Add(gameObject.transform.GetChild(i).GetComponent<Image>());
        }
        m_playerControl = m_player.GetComponent<PlayerControl>();
    }


    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        // 色の変更
        ChangeColor();
    }

    /// <summary>
    /// 色の変更
    /// </summary>
    void ChangeColor()
    {
        var state = m_playerControl.GetState();
        for(int i= 0; i < state.Count; i++) {
            if(state[i] != 0) m_button[i].color = m_afterColor;
            else m_button[i].color = m_baceColor;
        }
    }
}
