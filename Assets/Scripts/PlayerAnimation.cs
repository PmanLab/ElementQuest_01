using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- 格納用 ---
    private Animator Anime;
    private GameManager gameManager;

    // ジャンプ中かどうかを判定するフラグ
    public static bool isJump = false;

    //=== 初期化 処理 ===
    void Start()
    {
        gameManager = GameManager.Instance;         // GameManagerを取得
        Anime = GetComponent<Animator>();           // Animator情報を格納
    }

    //=== 更新 処理 ===
    void Update()
    {
        //=== アニメーション ===
        //--- 待機モーション ---
        switch (gameManager.CurrentPlayerAttackMethod)
        {
            //--- 物理 攻撃状態 ---
            case GameManager.ePlayerAttackMethod.Physics:
                if (!Anime.GetBool("Idol_Normal"))
                {
                    Anime.SetBool("Idol_Fire", false);
                    Anime.SetBool("Idol_Water", false);
                    Anime.SetBool("Idol_Wind", false);
                    Anime.SetBool("Idol_Earth", false);
                    Anime.SetBool("Idol_Normal", true);
                }

                break;


            //--- 魔法 攻撃状態 ---
            case GameManager.ePlayerAttackMethod.Magic:
                if (Anime.GetBool("Idol_Normal"))
                { Anime.SetBool("Idol_Normal", false); }
                else
                {
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        // 火 属性
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Idol_Earth", false);
                            Anime.SetBool("Idol_Fire", true);
                            break;
                        // 水 属性
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Idol_Fire", false);
                            Anime.SetBool("Idol_Water", true);
                            break;
                        // 風 属性
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Idol_Water", false);
                            Anime.SetBool("Idol_Wind", true);
                            break;
                        // 土 属性
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Idol_Wind", false);
                            Anime.SetBool("Idol_Earth", true);
                            break;
                        default:
                            break;
                    }
                }
                break;

        }

        //--- ジャンプ ---
        if (PlayerController.isJump == true && !isJump)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- 物理 攻撃状態 ---
                case GameManager.ePlayerAttackMethod.Physics:
                    // 物理攻撃時はすべての属性アニメーションをfalseに設定
                    Anime.SetBool("Jump_Normal", true);
                    isJump = true;

                    break;

                //--- 魔法 攻撃状態 ---
                case GameManager.ePlayerAttackMethod.Magic:
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        // 火 属性
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Jump_Fire", true);
                            isJump = true;

                            break;
                        // 水 属性
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Jump_Water", true);
                            isJump = true;

                            break;
                        // 風 属性
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Jump_Wind", true);
                            isJump = true;

                            break;
                        // 土 属性
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Jump_Earth", true);
                            isJump = true;

                            break;
                        default:
                            break;
                    }

                    break;
            }
        }
        else if (isJump && !PlayerController.isJump)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- 物理 攻撃状態 ---
                case GameManager.ePlayerAttackMethod.Physics:
                    // 物理攻撃時はすべての属性アニメーションをfalseに設定
                    Anime.SetBool("Jump_Normal", false);
                    isJump = false;

                    break;

                //--- 魔法 攻撃状態 ---
                case GameManager.ePlayerAttackMethod.Magic:
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        // 火 属性
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Jump_Fire", false);
                            isJump = false;

                            break;
                        // 水 属性
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Jump_Water", false);
                            isJump = false;

                            break;
                        // 風 属性
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Jump_Wind", false);
                            isJump = false;

                            break;
                        // 土 属性
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Jump_Earth", false);
                            isJump = false;

                            break;
                        default:
                            break;
                    }

                    break;
            }
        }
    }
}