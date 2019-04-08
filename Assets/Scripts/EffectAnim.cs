using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnim : MonoBehaviour
{
    bool IsAnimeEnd = false;
    public Sprite[] sprite;
    public bool isLoop = false;
    SpriteRenderer spriteRen;
    public int maxTimeCount;
    int spriteNum;
    int timeCount;

	void Start ()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        spriteRen.sprite = sprite[0];
        spriteNum = 0;
        timeCount = 0;
	}
	
	void Update ()
    {
        if (maxTimeCount <= timeCount)
        {
            spriteNum++;
            if (sprite.Length > spriteNum)
            {
                spriteRen.sprite = sprite[spriteNum];
                timeCount = 0;
            }
            else
            {
                if(isLoop)
                {
                    spriteNum = 0;
                    spriteRen.sprite = sprite[spriteNum];
                }
                else
                {
                    IsAnimeEnd = true;
                }
            }
        }
        timeCount++;

        if(IsAnimeEnd)
        {
            Destroy(this.gameObject);
        }
	}

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
