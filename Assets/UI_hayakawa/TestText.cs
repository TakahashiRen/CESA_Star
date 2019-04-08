using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestText : MonoBehaviour
{
    // テスト用
    public GameObject m_test;

    // 保存
    private UI_Script m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_ui = m_test.GetComponent<UI_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) m_ui.DrawText("z");
        if (Input.GetKeyDown(KeyCode.X)) m_ui.DrawText("x");
        if (Input.GetKeyDown(KeyCode.C)) m_ui.DrawText("c");
        if (Input.GetKeyDown(KeyCode.V)) m_ui.DrawText("v");
        if (Input.GetKeyDown(KeyCode.B)) m_ui.DrawText("b");

        if (Input.GetKeyDown(KeyCode.Space)) m_ui.DrawSwitch();

    }
}
