using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- 格納用インスタンス ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;
    private PlayerMagicAttack playerMagicAttack;
    private PlayerAnimation playerAnimation;
    private Animator Anime;

    //--- シリアライズ変数 ---
    [SerializeField, Header("基本 攻撃力")] public static float fAttackLevel = 5.0f;

    //--- 検知用フラグ ---
    public static bool isAttack = false;    // 攻撃検知用


    //=== 初期化処理 ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();                // インスタンス情報を取得
        playerInputSystem.Enable();                                 // 入力受付開始
        gameManager = GameManager.Instance;                         // GameManagerを取得
        playerAnimation = GetComponent<PlayerAnimation>();          // プレイヤーアニメーション情報を取得
        playerMagicAttack = GetComponent<PlayerMagicAttack>();      // プレイヤー魔法攻撃情報を取得
        Anime = GetComponent<Animator>();                           // animator情報を取得

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
        if (!isAttack)
        {
            //--- 攻撃処理 ---
            if (playerInputSystem.Player.Attack.triggered)
            {
                isAttack = true;    // 攻撃 検知フラグON

                //--- 攻撃フラグON & 攻撃アニメーションしていないとき ---

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

        }
    }

    //--- 攻撃終了フラグ検知 ---
    public void AttackEnd()
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

        //--- 属性判定 ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // 火 属性
            case GameManager.ePlayerAttributeState.Fire:
                //--- 攻撃段階 判定 ---
                switch(gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.FireBeginnerAttack();
                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.FireIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.FireAdvancedAttack();

                        break;
                }

                break;
            // 水 属性
            case GameManager.ePlayerAttributeState.Water:
                //--- 攻撃段階 判定 ---
                switch (gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.WaterBeginnerAttack();
                        
                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.WaterIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.WaterAdvancedAttack();

                        break;
                }

                break;
            // 風 属性
            case GameManager.ePlayerAttributeState.Wind:
                //--- 攻撃段階 判定 ---
                switch (gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.WindBeginnerAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.WindIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.WindAdvancedAttack();

                        break;
                }

                break;
            // 土 属性
            case GameManager.ePlayerAttributeState.Earth:
                //--- 攻撃段階 判定 ---
                switch (gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.EarthBeginnerAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.EarthIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.EarthAdvancedAttack();

                        break;
                }

                break;
            default:
                break;
        }
    }
}