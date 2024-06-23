using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    //--- 格納用 ---
    private Animator Anime;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;     // GameManagerを取得
        Anime = GetComponent<Animator>();       // Animator情報を格納
    }

    void Update()
    {
        //=== UIアニメーション ===
        if (Anime != null)
        {
            //=== 攻撃状態 UIアニメーション 切り替え ===
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- 物理攻撃 アニメーション ---
                case GameManager.ePlayerAttackMethod.Physics:
                    if (!Anime.GetBool("Fist"))
                    {
                        Anime.SetBool("Fire", false);
                        Anime.SetBool("Water", false);
                        Anime.SetBool("Wind", false);
                        Anime.SetBool("Earth", false);
                        Anime.SetBool("Fist", true);
                    }

                    break;
                //=== 魔法攻撃 アニメーション ===
                case GameManager.ePlayerAttackMethod.Magic:
                    if(Anime.GetBool("Fist"))
                    { Anime.SetBool("Fist", false); }

                    //--- 属性変更 アニメーション ---
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Earth", false);
                            Anime.SetBool("Fire", true);

                            break;
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Fire", false);
                            Anime.SetBool("Water", true);

                            break;
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Water", false);
                            Anime.SetBool("Wind", true);

                            break;
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Wind", false);
                            Anime.SetBool("Earth", true);

                            break;
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("UIAnimation：Animetor情報がありません");
        }



    }
}
