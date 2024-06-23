using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    //--- Ši”[—p ---
    private Animator Anime;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;     // GameManager‚ğæ“¾
        Anime = GetComponent<Animator>();       // Animatorî•ñ‚ğŠi”[
    }

    void Update()
    {
        //=== ‘®«•ÏX ƒAƒjƒ[ƒVƒ‡ƒ“ ===
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

    }
}
