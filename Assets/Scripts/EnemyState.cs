using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyState : MonoBehaviour
{
    //=== 列挙型定義 ===
    //--- 敵の生存状態を管理する ---
    private enum eEnemyState
    {
        Survival = 0,
        Death,
        MAX_ENEMYSTATE,
    }

    public enum eEnemyAttribute
    {
        Fire = 0,
        Water,
        Wind,
        Earth,
        MAX_ENEMYATTRIBUTE,
    }


    //=== 変数宣言 ===
    private eEnemyState CurrentEnemyState;
    [SerializeField, Header("敵 属性選択")] public eEnemyAttribute CurrentEnemyAttribute;
    [SerializeField, Header("敵 HP入力")] private float fEnemyLives = 15.0f;


    //=== 初期化処理 ===
    void Start()
    {
        fEnemyLives = 15;
    }

    //=== 更新処理 ===
    void Update()
    {
        
    }

    //=== 接触 処理 ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- 火 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Fire_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Fire_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Fire_Advanced")) { LoseLife(); }

        //--- 水 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Water_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Water_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Water_Advanced")) { LoseLife(); }

        //--- 風 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Wind_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Wind_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Wind_Advanced")) { LoseLife(); }

        //--- 土 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Earth_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Earth_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Earth_Advanced")) { LoseLife(); }

    }

    //=== 自作メソッド ===
    //--- 敵の生存状態を設定 ---
    private void SetEnemyState(eEnemyState newState)
    {
        CurrentEnemyState = newState;
        
        if(CurrentEnemyState == eEnemyState.Death)
        {
            Destroy(this.gameObject);
        }
    }

    //--- ライフを減少させるメソッド ---
    private void LoseLife()
    {
        fEnemyLives -= PlayerAttack.fAttackLevel;
        if (fEnemyLives <= 0)
        {
            SetEnemyState(eEnemyState.Death);
        }
    }



}
