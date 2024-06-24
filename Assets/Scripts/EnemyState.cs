using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyState : MonoBehaviour
{
    //=== �񋓌^��` ===
    //--- �G�̐�����Ԃ��Ǘ����� ---
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


    //=== �ϐ��錾 ===
    private eEnemyState CurrentEnemyState;
    [SerializeField, Header("�G �����I��")] public eEnemyAttribute CurrentEnemyAttribute;
    [SerializeField, Header("�G HP����")] private float fEnemyLives = 15.0f;


    //=== ���������� ===
    void Start()
    {
        fEnemyLives = 15;
    }

    //=== �X�V���� ===
    void Update()
    {
        
    }

    //=== �ڐG ���� ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Fire_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Fire_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Fire_Advanced")) { LoseLife(); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Water_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Water_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Water_Advanced")) { LoseLife(); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Wind_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Wind_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Wind_Advanced")) { LoseLife(); }

        //--- �y ���@������������ ---
        if (collision.gameObject.CompareTag("Earth_Beginner")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Earth_Intermediate")) { LoseLife(); }
        if (collision.gameObject.CompareTag("Earth_Advanced")) { LoseLife(); }

    }

    //=== ���상�\�b�h ===
    //--- �G�̐�����Ԃ�ݒ� ---
    private void SetEnemyState(eEnemyState newState)
    {
        CurrentEnemyState = newState;
        
        if(CurrentEnemyState == eEnemyState.Death)
        {
            Destroy(this.gameObject);
        }
    }

    //--- ���C�t�����������郁�\�b�h ---
    private void LoseLife()
    {
        fEnemyLives -= PlayerAttack.fAttackLevel;
        if (fEnemyLives <= 0)
        {
            SetEnemyState(eEnemyState.Death);
        }
    }



}
