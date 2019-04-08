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
    public float m_anchorSpeed;
    // アンカー
    public List<GameObject> m_anchor = new List<GameObject>();
    public List<AnchorCollision> m_anchorCollList = new List<AnchorCollision>();
    // アンカーの移動範囲(半径設定)
    public float m_len;
    public float m_returnSpeed;

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
            // アンカーの当たり判定情報
            m_anchorCollList.Add(m_anchor[i].GetComponent<AnchorCollision>());
        }    
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().position = transform.position;

        // アンカーの更新
        AnchorUpdate();
        // プレイヤーの移動
        PlayerMove();
        // アンカーのリセット
        ResetAnchorCollision();

        gameObject.GetComponent<Rigidbody>().position = transform.position;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void PlayerMove()
    {
        // 状態リスト
        List<int> state = new List<int>();
        for (int i = 0; i < m_anchorFlag.Count; i++) {
            // 固定状態の確認
            if (m_anchorFlag[i] == 2) {
                // 固定先の保存
                state.Add(i);
            }
        }

        // 固定先がない時
        if(state.Count == 0) {
            transform.position += transform.up * m_speed;
        } else  if(state.Count == 1){
            // 固定先が一つの時
            if (state[0] == (int)StrKey.W || state[0] == (int)StrKey.Q)
                transform.RotateAround(m_anchor[state[0]].transform.position, transform.forward, 5 * m_speed);
            else
                transform.RotateAround(m_anchor[state[0]].transform.position, -transform.forward, 5 * m_speed);
            } else {
            // 何もしない 
        }
    }

    /// <summary>
    /// アンカーの発射
    /// </summary>
    /// <param name="num">変更したいアンカー番号</param>
    void AnchorPush(int num)
    {
        // キー判定
        if (Input.GetKeyDown(m_key[num])) m_anchorFlag[num] = 1;
    }

    /// <summary>
    /// アンカーの移動処理
    /// </summary>
    /// <param name="num">変更したいアンカー番号</param>
    void AnchorMove(int  num)
    {
        m_anchor[num].transform.position += m_anchor[num].transform.up * m_speed;
        if (m_anchorCollList[num].m_collisionFlag) {
            m_anchorFlag[num] = 2;
            return;
        }
        // 最大距離の計測
        if (Vector3.Distance(m_anchor[num].transform.position, transform.position) > m_len) {
            m_anchorFlag[num] = 3;
        }
    }

    /// <summary>
    /// アンカーの当たり判定のリセット
    /// </summary>
    void ResetAnchorCollision()
    {
        for(int i= 0; i < m_anchorFlag.Count; i++) {
            if(m_anchorFlag[i] != 2) {
                m_anchorCollList[i].m_collisionFlag = false;
            }
        }
    }

    /// <summary>
    /// アンカーの固定状態の時
    /// </summary>
    /// <param name="num">アンカー番号</param>
    void AnchorFixed(int num)
    {
        // キー判定
        if (Input.GetKeyDown(m_key[num])) m_anchorFlag[num] = 3;
    }

    /// <summary>
    /// アンカーを戻す
    /// </summary>
    /// <param name="num">アンカー番号</param>
    void AnchorReturn(int num)
    {        
        m_anchor[num].transform.position += -(m_anchor[num].transform.up) * m_returnSpeed;

        // 元の位置に戻ったかの確認
        if(Vector3.Distance(m_anchor[num].transform.localPosition, m_startPosition[num]) < 0.2f) {
            // 当たり判定を初期化
            m_anchorCollList[num].m_collisionFlag = false;
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

                    // アンカー固定(壁に引っ付き状態
                case 2:
                    AnchorFixed(i);
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
    
    /// <summary>
    /// 状態の取得
    /// </summary>
    /// <returns>現在の状態リスト</returns>
    public List<uint> GetState()
    {
        return m_anchorFlag;
    }
}
