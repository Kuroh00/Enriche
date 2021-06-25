using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CharaScript : MonoBehaviour
{
    GameObject chara;
    SpriteRenderer spriteR;
    Sprite[] sprites;
    public static int spriteIndex;
    Vector3 charaPos;
    Vector3 targetPos;
    Vector3 ogPos;
    public static int johnOrjane;
    public static Vector3 charaPosNew;
    float speed = 1000.0f;
    float interval = 1.0f;
    private void Awake()
    {
        if (johnOrjane == 0)
        {
            sprites = Resources.LoadAll("Chara_Male", typeof(Sprite)).Cast<Sprite>().ToArray();
        }
        else if (johnOrjane == 1)
        {
            sprites = Resources.LoadAll("Chara_Female", typeof(Sprite)).Cast<Sprite>().ToArray();
        }
        for (int a = 0; a < 5; a++)
        {
            Debug.Log(sprites[a]);
        }
    }
    void Start()
    {
        chara = this.gameObject;
        spriteR = chara.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        charaPos = chara.transform.position;
        ogPos = charaPos;
        charaPosNew = ogPos;
        spriteR.sprite = sprites[4];
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        charaPos = chara.transform.position;
        targetPos = charaPosNew;
        if (targetPos != charaPos)
        {
            spriteR.sprite = sprites[spriteIndex];
            chara.transform.position = Vector3.MoveTowards(charaPos, targetPos, step);
        }
        else if(interval > 0 && charaPos == targetPos && charaPos != ogPos)
        {
            spriteR.sprite = sprites[4];
            powerUps.bonusAdd();
            interval -= Time.deltaTime;
        }
        else if (charaPos != ogPos && GamePlay.a == 4 && interval <= 0)
        {
            charaPosNew = ogPos;

            if (spriteIndex == 0)
            {
                spriteIndex = 3;
            }
            else if (spriteIndex == 1)
            {
                spriteIndex = 2;
            }
            else if (spriteIndex == 2)
            {
                spriteIndex = 1;
            }
            else if (spriteIndex == 3)
            {
                spriteIndex = 1;
            }
        }
        else if (charaPos == targetPos && GamePlay.a == 4 && interval <= 0)
        {
            spriteR.sprite = sprites[4];
            GamePlay.a = 5;
            interval = 0.5f;
        }
    }
}
