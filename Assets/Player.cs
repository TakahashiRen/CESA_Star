using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 Pos;
    Vector2 Vec;
    float Sca;
    // Start is called before the first frame update
    void Start()
    {
        Pos = Vector2.zero;
        Vec = Vector2.zero;
        Sca = 1;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0.0f,0.2f,0.0f);
    }
}
