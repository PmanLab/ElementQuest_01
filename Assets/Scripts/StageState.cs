using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageState : MonoBehaviour
{
    //--- 検知用フラグ ---
    public static bool bIsContactMagic = false;

    //=== 初期化処理 ===
    void Start()
    {
        
    }

    //=== 更新処理 ===
    void Update()
    {
        
    }

    //=== 接触 処理 ===
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- 火 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Fire_Beginner"))       { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Fire_Intermediate"))   { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Fire_Advanced"))       { Destroy(PlayerMagicAttack.bullet); }

        //--- 水 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Water_Beginner"))      { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Water_Intermediate"))  { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Water_Advanced"))      { Destroy(PlayerMagicAttack.bullet); }

        //--- 風 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Wind_Beginner"))       { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Wind_Intermediate"))   { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Wind_Advanced"))       { Destroy(PlayerMagicAttack.bullet); }

        //--- 土 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Earth_Beginner"))      { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Earth_Intermediate"))  { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Earth_Advanced"))      { Destroy(PlayerMagicAttack.bullet); }
    }*/
}
