using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- Ši”[—pƒCƒ“ƒXƒ^ƒ“ƒX ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;
    private PlayerMagicAttack playerMagicAttack;
    private PlayerAnimation playerAnimation;

    //--- ƒVƒŠƒAƒ‰ƒCƒY•Ï” ---
    [SerializeField, Header("Šî–{ UŒ‚—Í")] public static float fAttackLevel = 5.0f;

    //--- ŒŸ’m—pƒtƒ‰ƒO ---
    public static bool isAttack = false;    // UŒ‚ŒŸ’m—p


    //=== ‰Šú‰»ˆ— ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();                // ƒCƒ“ƒXƒ^ƒ“ƒXî•ñæ“¾
        playerInputSystem.Enable();                                 // “ü—Íó•tŠJn
        gameManager = GameManager.Instance;                         // GameManager‚ğæ“¾
        playerAnimation = GetComponent<PlayerAnimation>();          // 
        playerMagicAttack = GetComponent<PlayerMagicAttack>();      //

    }

    //=== XVˆ— ===
    void Update()
    {
        //=== ”ñƒ|[ƒY‰æ–Ê & ”ñƒWƒƒƒ“ƒv ˆ— ===
        //if (!PlayerController.isPaused && !PlayerAnimation.isJump)
        if (!PlayerController.isPaused)
        {
            if (!PlayerAnimation.isJump)
            {
                //--- UŒ‚•û–@•ÏX ---
                ChangeAttack();


                //--- ‘®«•ÏX ---
                if (gameManager.CurrentPlayerAttackMethod ==
                    GameManager.ePlayerAttackMethod.Magic)
                { ChangeChangAttribute(); }
            }

            //--- UŒ‚ˆ— ---
            Attack();

        }
    }


    //=== ©ìƒƒ\ƒbƒh ===
    //--- UŒ‚•û–@•ÏX ---
    void ChangeAttack()
    {
        //--- UŒ‚•û–@•ÏX ---
        if (playerInputSystem.Player.ChangeAttackMethod.triggered)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                // •¨—
                case GameManager.ePlayerAttackMethod.Physics:
                    gameManager.SetPlayerAttackMethodState(
                        GameManager.ePlayerAttackMethod.Magic);

                    break;
                // –‚–@
                case GameManager.ePlayerAttackMethod.Magic:
                    gameManager.SetPlayerAttackMethodState(
                        GameManager.ePlayerAttackMethod.Physics);

                    break;
            }


            Debug.Log("UŒ‚ •û–@‚ğy " + gameManager.CurrentPlayerAttackMethod + " z‚É•ÏX‚µ‚Ü‚µ‚½");

        }
    }

    //--- UŒ‚‘®«•ÏX ---
    void ChangeChangAttribute()
    {
        //--- ‘®«•ÏX ---
        if (playerInputSystem.Player.ChangAttribute.triggered)
        {
            //--- •ÏXˆ— ---
            switch (gameManager.CurrentPlayerAttributeState)
            {

                // ‰Î ‘®«
                case GameManager.ePlayerAttributeState.Fire:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Water);

                    break;
                // … ‘®«
                case GameManager.ePlayerAttributeState.Water:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Wind);

                    break;
                // •— ‘®«
                case GameManager.ePlayerAttributeState.Wind:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Earth);

                    break;
                // “y ‘®«
                case GameManager.ePlayerAttributeState.Earth:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Fire);

                    break;
                default:
                    break;
            }

            Debug.Log("UŒ‚ ‘®«‚ğy " + gameManager.CurrentPlayerAttributeState + " z‚É•ÏX‚µ‚Ü‚µ‚½");

        }
    }

    //--- UŒ‚ˆ— ---
    void Attack()
    {
        //--- UŒ‚ˆ— ---
        if (playerInputSystem.Player.Attack.triggered)
        {

            isAttack = true;    // UŒ‚ ŒŸ’mƒtƒ‰ƒOON

            if (isAttack)
            {
                Debug.Log("UŒ‚ •û–@y " + gameManager.CurrentPlayerAttackMethod + " z");
                Debug.Log("UŒ‚ ‘®«y " + gameManager.CurrentPlayerAttributeState + " z");
                Debug.Log("UŒ‚ ’iŠKy " + gameManager.CurrentPlayerAttackStage + " z");

                //--- UŒ‚•û–@ ”»’èˆ— ---
                switch (gameManager.CurrentPlayerAttackMethod)
                {
                    // •¨—UŒ‚ ˆ—
                    case GameManager.ePlayerAttackMethod.Physics:
                        PhysicsAttack();

                        break;
                    //--- –‚–@ UŒ‚ó‘Ô ---
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

    //--- UŒ‚I—¹ƒtƒ‰ƒOŒŸ’m ---
    void AttackEnd()
    {
        isAttack = false;
    }

    //--- •¨—UŒ‚ ---
    void PhysicsAttack()
    {
        playerAnimation.PlayerPhysicsAttackAnimation(); // UŒ‚ƒAƒjƒ[ƒVƒ‡ƒ“
    }

    //--- –‚–@UŒ‚ ---
    void MagicAttack()
    {
        playerAnimation.PlayerMagicAttackAnimation();   // UŒ‚ƒAƒjƒ[ƒVƒ‡ƒ“

        //--- ‘®«”»’è ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // ‰Î ‘®«
            case GameManager.ePlayerAttributeState.Fire:
                //--- UŒ‚’iŠK ”»’è ---
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
            // … ‘®«
            case GameManager.ePlayerAttributeState.Water:
                //--- UŒ‚’iŠK ”»’è ---
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
            // •— ‘®«
            case GameManager.ePlayerAttributeState.Wind:
                //--- UŒ‚’iŠK ”»’è ---
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
            // “y ‘®«
            case GameManager.ePlayerAttributeState.Earth:
                //--- UŒ‚’iŠK ”»’è ---
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