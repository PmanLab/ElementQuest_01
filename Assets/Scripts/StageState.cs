using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageState : MonoBehaviour
{
    //--- ���m�p�t���O ---
    public static bool bIsContactMagic = false;

    //=== ���������� ===
    void Start()
    {
        
    }

    //=== �X�V���� ===
    void Update()
    {
        
    }

    //=== �ڐG ���� ===
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Fire_Beginner"))       { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Fire_Intermediate"))   { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Fire_Advanced"))       { Destroy(PlayerMagicAttack.bullet); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Water_Beginner"))      { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Water_Intermediate"))  { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Water_Advanced"))      { Destroy(PlayerMagicAttack.bullet); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Wind_Beginner"))       { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Wind_Intermediate"))   { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Wind_Advanced"))       { Destroy(PlayerMagicAttack.bullet); }

        //--- �y ���@������������ ---
        if (collision.gameObject.CompareTag("Earth_Beginner"))      { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Earth_Intermediate"))  { Destroy(PlayerMagicAttack.bullet); }
        if (collision.gameObject.CompareTag("Earth_Advanced"))      { Destroy(PlayerMagicAttack.bullet); }
    }*/
}
