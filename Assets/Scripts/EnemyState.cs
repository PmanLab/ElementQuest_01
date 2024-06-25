using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyState : MonoBehaviour
{
    //=== 列挙型定義 ===
    //--- 敵の生存状態 を管理する列挙 ---
    private enum eEnemyState
    {
        Survival = 0,
        Death,
        MAX_ENEMYSTATE,
    }

    //--- 敵属性 を管理する列挙 ---
    private enum eEnemyAttribute
    {
        Fire = 0,
        Water,
        Wind,
        Earth,
        MAX_ENEMYATTRIBUTE,
    }

    //--- 魔法接触時の属性判定 を管理する列挙 ---
    private enum eHitMagicAttribute
    {
        Normal = 0,
        Fire,
        Water,
        Wind,
        Earth,
        MAX_HITMAGICATTRIBUTE,

    }


    //=== 変数宣言 ===
    private eEnemyState CurrentEnemyState = eEnemyState.Survival;
    private eHitMagicAttribute hitMagicAttribute;
    [SerializeField, Header("敵 属性選択")] private eEnemyAttribute CurrentEnemyAttribute;
    [SerializeField, Header("敵 HP入力")] private float fEnemyLives = 15.0f;


    //=== 初期化処理 ===
    void Start()
    {
        
    }

    //=== 更新処理 ===
    void Update()
    {
        
    }

    //=== 接触 処理 ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        //--- 火 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Fire_Beginner")) { LoseLife(eHitMagicAttribute.Fire); }
        if (collision.gameObject.CompareTag("Fire_Intermediate")) { LoseLife(eHitMagicAttribute.Fire); }
        if (collision.gameObject.CompareTag("Fire_Advanced")) { LoseLife(eHitMagicAttribute.Fire); }

        //--- 水 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Water_Beginner")) { LoseLife(eHitMagicAttribute.Water); }
        if (collision.gameObject.CompareTag("Water_Intermediate")) { LoseLife(eHitMagicAttribute.Water); }
        if (collision.gameObject.CompareTag("Water_Advanced")) { LoseLife(eHitMagicAttribute.Water); }

        //--- 風 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Wind_Beginner")) { LoseLife(eHitMagicAttribute.Wind); }
        if (collision.gameObject.CompareTag("Wind_Intermediate")) { LoseLife(eHitMagicAttribute.Wind); }
        if (collision.gameObject.CompareTag("Wind_Advanced")) { LoseLife(eHitMagicAttribute.Wind); }

        //--- 土 魔法があたった時 ---
        if (collision.gameObject.CompareTag("Earth_Beginner")) { LoseLife(eHitMagicAttribute.Earth); }
        if (collision.gameObject.CompareTag("Earth_Intermediate")) { LoseLife(eHitMagicAttribute.Earth); }
        if (collision.gameObject.CompareTag("Earth_Advanced")) { LoseLife(eHitMagicAttribute.Earth); }

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
    private void LoseLife(eHitMagicAttribute newState)
    {
        hitMagicAttribute = newState;

        switch(hitMagicAttribute)
        {
            // 物理 攻撃を受けたとき
            case eHitMagicAttribute.Normal:
                fEnemyLives -= (PlayerAttack.fAttackLevel / 4.0f);
                break;
            // 火 属性魔法を受けたとき
            case eHitMagicAttribute.Fire:
                switch (CurrentEnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 2.0f);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 2.0f);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                }
                break;
            // 水 属性魔法を受けたとき
            case eHitMagicAttribute.Water:
                switch (CurrentEnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 2.0f);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 2.0f);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                }
                break;
            // 風 属性魔法を受けたとき
            case eHitMagicAttribute.Wind:
                switch (CurrentEnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 2.0f);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 2.0f);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                }
                break;
            // 土 属性魔法を受けたとき
            case eHitMagicAttribute.Earth:
                switch (CurrentEnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 1.5f);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 1.5f);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                }
                break;
        }

        if (fEnemyLives <= 0)
        {
            SetEnemyState(eEnemyState.Death);
        }


    }



}
