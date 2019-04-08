using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー操作
/// </summary>
public class PlayerControl : MonoBehaviour
{
    // 速さ
    public float m_speed;
    // アンカー
    public List<GameObject> m_anchor = new List<GameObject>();
    // アンカーの移動範囲(半径設定)
    public float m_len;
    
    // アンカーの状態 
    // 0 = プレイヤーにくっついている
    // 1 = 離れている(移動中
    // 2 = 離れている(移動完了
    // 3 = 戻っている(移動中
    private List<uint> m_anchorFlag = new List<uint>();

    // アンカーの初期位置の保存場所よん♡
    private List<Vector3> m_startPosition = new List<Vector3>();

    /// <summary>
    /// 対応キーの設定
    /// </summary>
    private enum StrKey { E, W, O, P, Q, NOME };
    // キー
    private KeyCode[] m_key = { KeyCode.E, KeyCode.W, KeyCode.O, KeyCode.P, KeyCode.Q };

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        for(int i = 0; i < (int)StrKey.NOME; i++) {
            // 状態の初期
            m_anchorFlag.Add(0);
            // 初期位置の保存
            m_startPosition.Add(m_anchor[i].transform.localPosition);
        }    
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        transform.position += Vector3.up * m_speed;
        // アンカーの更新
        AnchorUpdate();
    }


    /// <summary>
    /// アンカーの発射
    /// </summary>
    /// <param name="num">変更したいアンカー番号</param>
    void AnchorPush(int num)
    {
        // キー判定
        if (Input.GetKey(m_key[num])) m_anchorFlag[num] = 1;
    }

    /// <summary>
    /// アンカーの移動処理
    /// </summary>
    /// <param name="num">変更したいアンカー番号</param>
    void AnchorMove(int  num)
    {
        m_anchor[num].transform.position += m_anchor[num].transform.up * m_speed;

        // 最大距離の計測
        if (Vector3.Distance(m_anchor[num].transform.position, transform.position) > m_len) {
            m_anchorFlag[num] = 3;
        }
    }

    /// <summary>
    /// アンカーの固定
    /// </summary>
    /// <param name="num">アンカー番号</param>
    void AnchorFixed(int num)
    {

    }

    /// <summary>
    /// アンカーを戻す
    /// </summary>
    /// <param name="num">アンカー番号</param>
    void AnchorReturn(int num)
    {        
        m_anchor[num].transform.position += -(m_anchor[num].transform.up) * m_speed;

        // 元の位置に戻ったかの確認
        if(Vector3.Distance(m_anchor[num].transform.localPosition, m_startPosition[num]) < 0.2f) {
            // 少しのずれを調整
            m_anchor[num].transform.localPosition = m_startPosition[num];
            // 状態を戻すS
            m_anchorFlag[num] = 0;
        }
    }

    /// <summary>
    /// アンカーの更新
    /// </summary>
    void AnchorUpdate()
    {
        for(int i = 0; i < (int)StrKey.NOME;i++) {

            switch (m_anchorFlag[i]) {
                    // プレイヤーにくっついている
                case 0:
                    // アンカーの発射
                    AnchorPush(i);
                    break;

                    // 離れている(移動中
                case 1:
                    // アンカーの移動
                    AnchorMove(i);
                    break;

                    // 離れている(壁に引っ付き状態
                case 2:
                    break;

                    // 戻っている(移動中
                case 3:
                    // アンカーを戻す
                    AnchorReturn(i);
                    break;

                    // その他
                default:
                    break;
            }
        }
    }
}
