using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeSprites : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    public int[] NeedLvl = new int[4];
    public SpriteRenderer currentSprite;
    public Upgrade currentlvl;

    void Update()
    {

        for (int i = 0; i < sprites.Length; i++)
        {
            if (currentlvl.currentUpgrade == NeedLvl[i] && currentSprite.sprite != sprites[i])
            {
                currentSprite.sprite = sprites[i];
            }
        }
    }
}
