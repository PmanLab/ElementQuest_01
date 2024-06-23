using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- 格納用インスタンス ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;
    private PlayerAnimation playerAnimation;

    //--- シリアライズ変数 ---
    [SerializeField, Header("基本 攻撃力")] public float fAttackLevel = 5.0f;

    //--- 検知用フラグ ---
    public static bool isAttack = false;    // 攻撃検知用


    //=== 初期化処理 ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // インスタンス情報取得
        playerInputSystem.Enable();                         // 入力受付開始
        gameManager = GameManager.Instance;                 // GameManagerを取得
        playerAnimation = GetComponent<PlayerAnimation>();

    }

    //=== 更新処理 ===
    void Update()
    {
        //=== 非ポーズ画面時 & 非ジャンプ時 処理 ===
        //if (!PlayerController.isPaused && !PlayerAnimation.isJump)
        if (!PlayerController.isPaused)
        {
            if (!PlayerAnimation.isJump)
            {
                //--- 攻撃方法変更 ---
                ChangeAttack();


                //--- 属性変更 ---
                if (gameManager.CurrentPlayerAttackMethod ==
                    GameManager.ePlayerAttackMethod.Magic)
                { ChangeChangAttribute(); }
            }

            //--- 攻撃処理 ---
            Attack();

        }
    }


    //=== 自作メソッド ===
    //--- 攻撃方法変更 ---
    void ChangeAttack()
    {
        //--- 攻撃方法変更 ---
        if (playerInputSystem.Player.ChangeAttackMethod.triggered)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                // 物理
                case GameManager.ePlayerAttackMethod.Physics:
                    gameManager.SetPlayerAttackMethodState(
                        GameManager.ePlayerAttackMethod.Magic);

                    break;
                // 魔法
                case GameManager.ePlayerAttackMethod.Magic:
                    gameManager.SetPlayerAttackMethodState(
                        GameManager.ePlayerAttackMethod.Physics);

                    break;
            }


            Debug.Log("攻撃 方法を【 " + gameManager.CurrentPlayerAttackMethod + " 】に変更しました");

        }
    }

    //--- 攻撃属性変更 ---
    void ChangeChangAttribute()
    {
        //--- 属性変更 ---
        if (playerInputSystem.Player.ChangAttribute.triggered)
        {
            //--- 変更処理 ---
            switch (gameManager.CurrentPlayerAttributeState)
            {

                // 火 属性
                case GameManager.ePlayerAttributeState.Fire:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Water);

                    break;
                // 水 属性
                case GameManager.ePlayerAttributeState.Water:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Wind);

                    break;
                // 風 属性
                case GameManager.ePlayerAttributeState.Wind:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Earth);

                    break;
                // 土 属性
                case GameManager.ePlayerAttributeState.Earth:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Fire);

                    break;
                default:
                    break;
            }

            Debug.Log("攻撃 属性を【 " + gameManager.CurrentPlayerAttributeState + " 】に変更しました");

        }
    }

    //--- 攻撃処理 ---
    void Attack()
    {
        //--- 攻撃処理 ---
        if (playerInputSystem.Player.Attack.triggered)
        {

            isAttack = true;    // 攻撃 検知フラグON

            if (isAttack)
            {
                Debug.Log("攻撃 方法【 " + gameManager.CurrentPlayerAttackMethod + " 】");
                Debug.Log("攻撃 属性【 " + gameManager.CurrentPlayerAttributeState + " 】");
                Debug.Log("攻撃 段階【 " + gameManager.CurrentPlayerAttackStage + " 】");

                //--- 攻撃方法 判定処理 ---
                switch (gameManager.CurrentPlayerAttackMethod)
                {
                    // 物理攻撃 処理
                    case GameManager.ePlayerAttackMethod.Physics:
                        PhysicsAttack();

                        break;
                    //--- 魔法 攻撃状態 ---
                    case GameManager.ePlayerAttackMethod.Magic:
                        MagicAttack();

                        break;
                }

            }

        }

        if(!isAttack)
        {
            playerAnimation.PlayerAttackAnimationEnd();
        }
    }

    //--- 攻撃終了フラグ検知 ---
    void AttackEnd()
    {
        isAttack = false;
    }

    //--- 物理攻撃 ---
    void PhysicsAttack()
    {
        playerAnimation.PlayerPhysicsAttackAnimation(); // 攻撃アニメーション
    }

    //--- 魔法攻撃 ---
    void MagicAttack()
    {
        playerAnimation.PlayerMagicAttackAnimation();   // 攻撃アニメーション

        //--- 攻撃段階 判定処理 ---
        switch (gameManager.CurrentPlayerAttackStage)
        {
            // 初級
            case GameManager.ePlayerAttackStageState.Beginner:
                BeginnerMagicAttack();
                break;
            // 中級
            case GameManager.ePlayerAttackStageState.Intermediate:
                IntermediateMagicAttack();
                break;
            // 上級
            case GameManager.ePlayerAttackStageState.Advanced:
                AdvancedMagic();
                break;
            default:
                break;
        }

    }

    //--- 初級魔法 ---
    void BeginnerMagicAttack()
    {
        //--- 属性判定 ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // 火 属性
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // 水 属性
            case GameManager.ePlayerAttributeState.Water:

                break;
            // 風 属性
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // 土 属性
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }

    //--- 中級魔法 ---
    void IntermediateMagicAttack()
    {
        //--- 属性判定 ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // 火 属性
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // 水 属性
            case GameManager.ePlayerAttributeState.Water:

                break;
            // 風 属性
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // 土 属性
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }

    //--- 上級魔法 ---
    void AdvancedMagic()
    {
        //--- 属性判定 ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // 火 属性
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // 水 属性
            case GameManager.ePlayerAttributeState.Water:

                break;
            // 風 属性
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // 土 属性
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }
}