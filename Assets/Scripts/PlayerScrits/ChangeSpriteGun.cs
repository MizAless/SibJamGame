using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteGun : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    public int[] NeedLvl = new int[4];
    public SpriteRenderer currentSprite;
    public SpriteRenderer weapon1;
    public GameObject weapon2;
    public GameObject arm2;
    public Upgrade currentlvl;

    void Update()
    {
        for (int i = 1; i < sprites.Length; i++)
        {
            if (currentlvl.currentUpgrade == NeedLvl[i] && currentSprite.sprite != sprites[i])
            {
                weapon1.enabled = false;
                weapon2.SetActive(true);

                arm2.SetActive(false);
                currentSprite.sprite = sprites[i];
            }

                    
            
        }
    }
}
