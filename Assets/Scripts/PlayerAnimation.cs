using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- 格納用 ---
    private Animator Anime;
    private GameManager gameManager;

    //--- 検知用フラグ ---
    public static bool bIsJump = false;              // ジャンプアニメーション中か判定するフラグ

    //=== 初期化 処理 ===
    void Start()
    {
        gameManager = GameManager.Instance;         // GameManagerを取得
        Anime = GetComponent<Animator>();           // Animator情報を格納
    }

    //=== 更新 処理 ===
    void Update()
    {
        //=== プレイヤーアニメーション ===
        if(Anime != null)
        {
            //=== 待機モーション ===
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- 物理 待機状態 ---
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


                //--- 各属性 待機状態 ---
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


            //=== ジャンプアニメーション ===
            if (!bIsJump && PlayerController.bIsJump)
            {
                switch (gameManager.CurrentPlayerAttackMethod)
                {
                    //--- 物理 攻撃状態 ---
                    case GameManager.ePlayerAttackMethod.Physics:
                        // 物理攻撃時はすべての属性アニメーションをfalseに設定
                        Anime.SetBool("Jump_Normal", true);
                        bIsJump = true;

                        break;

                    //--- 魔法 攻撃状態 ---
                    case GameManager.ePlayerAttackMethod.Magic:
                        switch (gameManager.CurrentPlayerAttributeState)
                        {
                            // 火 属性
                            case GameManager.ePlayerAttributeState.Fire:
                                Anime.SetBool("Jump_Fire", true);
                                bIsJump = true;

                                break;
                            // 水 属性
                            case GameManager.ePlayerAttributeState.Water:
                                Anime.SetBool("Jump_Water", true);
                                bIsJump = true;

                                break;
                            // 風 属性
                            case GameManager.ePlayerAttributeState.Wind:
                                Anime.SetBool("Jump_Wind", true);
                                bIsJump = true;

                                break;
                            // 土 属性
                            case GameManager.ePlayerAttributeState.Earth:
                                Anime.SetBool("Jump_Earth", true);
                                bIsJump = true;

                                break;
                            default:
                                break;
                        }

                        break;
                }
            }
            else if (bIsJump && !PlayerController.bIsJump)
            {
                switch (gameManager.CurrentPlayerAttackMethod)
                {
                    //--- 物理 攻撃状態 ---
                    case GameManager.ePlayerAttackMethod.Physics:
                        // 物理攻撃時はすべての属性アニメーションをfalseに設定
                        Anime.SetBool("Jump_Normal", false);
                        bIsJump = false;

                        break;

                    //--- 魔法 攻撃状態 ---
                    case GameManager.ePlayerAttackMethod.Magic:
                        switch (gameManager.CurrentPlayerAttributeState)
                        {
                            // 火 属性
                            case GameManager.ePlayerAttributeState.Fire:
                                Anime.SetBool("Jump_Fire", false);
                                bIsJump = false;

                                break;
                            // 水 属性
                            case GameManager.ePlayerAttributeState.Water:
                                Anime.SetBool("Jump_Water", false);
                                bIsJump = false;

                                break;
                            // 風 属性
                            case GameManager.ePlayerAttributeState.Wind:
                                Anime.SetBool("Jump_Wind", false);
                                bIsJump = false;

                                break;
                            // 土 属性
                            case GameManager.ePlayerAttributeState.Earth:
                                Anime.SetBool("Jump_Earth", false);
                                bIsJump = false;

                                break;
                            default:
                                break;
                        }

                        break;
                }
            }
        }
        else
        {
            Debug.Log("PlayerAnimation：Animetor情報がありません");
        }
    }

    //=== 自作メソッド ===
    //--- 物理 攻撃アニメーションをオンにする関数
    public void PlayerPhysicsAttackAnimation()
    {
        //--- 物理 攻撃状態 ---
        Anime.SetBool("Attack_Physics", true);
    }

    //--- 魔法 攻撃アニメーションをオンにする関数
    public void PlayerMagicAttackAnimation()
    {
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // 火 属性
            case GameManager.ePlayerAttributeState.Fire:
                Anime.SetBool("Attack_Magic_Fire", true);

                break;
            // 水 属性
            case GameManager.ePlayerAttributeState.Water:
                Anime.SetBool("Attack_Magic_Water", true);

                break;
            // 風 属性
            case GameManager.ePlayerAttributeState.Wind:
                Anime.SetBool("Attack_Magic_Wind", true);

                break;
            // 土 属性
            case GameManager.ePlayerAttributeState.Earth:
                Anime.SetBool("Attack_Magic_Earth", true);

                break;
            default:
                break;
        }
    }

    //--- 攻撃アニメーションをオフにする関数 ---
    public void PlayerAttackAnimationEnd()
    {
        if (Anime.GetBool("Attack_Physics") ||
            Anime.GetBool("Attack_Magic_Fire") ||
            Anime.GetBool("Attack_Magic_Water") ||
            Anime.GetBool("Attack_Magic_Wind") ||
            Anime.GetBool("Attack_Magic_Earth"))
        {
            PlayerAttackPhysicsAnimationEnd();
            PlayerAttackFireAnimationEnd();
            PlayerAttackWindAnimationEnd();
            PlayerAttackWaterAnimationEnd();
            PlayerAttackEarthAnimationEnd();
        }
    }

    public void PlayerAttackPhysicsAnimationEnd()
    {
        Anime.SetBool("Attack_Physics", false);

    }

    public void PlayerAttackFireAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Fire", false);

    }

    public void PlayerAttackWaterAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Water", false);

    }

    public void PlayerAttackWindAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Wind", false);

    }

    public void PlayerAttackEarthAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Earth", false);
    }
}