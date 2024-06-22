using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- Ši”[—pƒCƒ“ƒXƒ^ƒ“ƒX ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;

    //--- ƒVƒŠƒAƒ‰ƒCƒY•Ï” ---
    [SerializeField, Header("Šî–{ UŒ‚—Í")] public float fAttackLevel = 5.0f;

    //--- ŒŸ’m—pƒtƒ‰ƒO ---
    

    //=== ‰Šú‰»ˆ— ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // ƒCƒ“ƒXƒ^ƒ“ƒXî•ñæ“¾
        playerInputSystem.Enable();                         // “ü—Íó•tŠJn
        gameManager = GameManager.Instance;                 // GameManager‚ğæ“¾
    }

    //=== XVˆ— ===
    void Update()
    {
        //=== ”ñƒ|[ƒY‰æ–Ê ˆ— ===
        if (!PlayerController.isPaused)
        {
            //--- UŒ‚•û–@•ÏX ---
            ChangeAttack();
            //--- ‘®«•ÏX ---
            ChangeChangAttribute();
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
                // –‚–@UŒ‚ ˆ—
                case GameManager.ePlayerAttackMethod.Magic:
                    MagicAttack();

                    break;
                default:
                    break;
            }
        }
    }

    //--- •¨—UŒ‚ ---
    void PhysicsAttack()
    {

    }

    //--- –‚–@UŒ‚ ---
    void MagicAttack()
    {
        //--- UŒ‚’iŠK ”»’èˆ— ---
        switch (gameManager.CurrentPlayerAttackStage)
        {
            // ‰‹‰
            case GameManager.ePlayerAttackStageState.Beginner:
                BeginnerMagicAttack();
                break;
            // ’†‹‰
            case GameManager.ePlayerAttackStageState.Intermediate:
                IntermediateMagicAttack();
                break;
            // ã‹‰
            case GameManager.ePlayerAttackStageState.Advanced:
                AdvancedMagic();
                break;
            default:
                break;
        }

    }

    //--- ‰‹‰–‚–@ ---
    void BeginnerMagicAttack()
    {
        //--- ‘®«”»’è ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // ‰Î ‘®«
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // … ‘®«
            case GameManager.ePlayerAttributeState.Water:

                break;
            // •— ‘®«
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // “y ‘®«
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }

    //--- ’†‹‰–‚–@ ---
    void IntermediateMagicAttack()
    {
        //--- ‘®«”»’è ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // ‰Î ‘®«
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // … ‘®«
            case GameManager.ePlayerAttributeState.Water:

                break;
            // •— ‘®«
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // “y ‘®«
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }

    //--- ã‹‰–‚–@ ---
    void AdvancedMagic()
    {
        //--- ‘®«”»’è ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // ‰Î ‘®«
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // … ‘®«
            case GameManager.ePlayerAttributeState.Water:

                break;
            // •— ‘®«
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // “y ‘®«
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }
}
