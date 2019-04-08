using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float m_speed;

   


    Anchor1 anchor1 = GameObject.Find("anchor2").GetComponent<Anchor1>();
    Anchor2 anchor2 = GameObject.Find("anchor3").GetComponent<Anchor2>();
    Anchor3 anchor3 = GameObject.Find("anchor4").GetComponent<Anchor3>();
    Anchor4 anchor4 = GameObject.Find("anchor5").GetComponent<Anchor4>();


    // Start is called before the first frame update
    void Start()
    {
        m_speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0.0f, m_speed, 0.0f);

        if (anchor1.state == 2)
        {
            transform.RotateAround(anchor1.pos,
                  -Vector3.forward
                  , m_speed);

            Debug.Log("aa");
        }
        else if(anchor2.state == 2)
        {
            transform.RotateAround(anchor2.pos,
                  -Vector3.forward
                  , m_speed);

            Debug.Log("bb");

        }
        else if (anchor3.state == 2)
        {
            transform.RotateAround(anchor3.pos,
                  -Vector3.forward
                  , m_speed);
        }
        else if (anchor4.state == 2)
        {
            transform.RotateAround(anchor4.pos,
                  -Vector3.forward
                  , m_speed);
        }



    }

}
