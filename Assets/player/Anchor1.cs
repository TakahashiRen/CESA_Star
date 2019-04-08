using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Anchor1 : MonoBehaviour
{
    int m_state;
    Vector3 m_pos;

    // Start is called before the first frame update
    void Start()
    {
        m_state = 0;

        this.transform.parent = GameObject.Find("player").transform;

        m_pos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            m_state = 1;
        }

        if (m_state == 1)
        {
            this.transform.Translate(new Vector3(0.0f, 0.2f, 0.0f));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            m_state = 2;

            this.transform.parent = null;

            state = 2;

            pos = this.transform.position;
        }
    }

    public int state
    {
        get { return m_state; }
        private set { m_state = value; }
    }

    public Vector3 pos
    {
        get { return m_pos; }
        private set { m_pos = value; }
    }

}
