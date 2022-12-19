using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsPlayer : MonoBehaviour
{

    public GameObject player;

    public GameObject enemy;

    [Header("Particles Player")]
    public GameObject particulePoison;
    public GameObject particuleXplosion;

    public GameObject particuleTwister;
    public GameObject particuleRock;

    public GameObject mainOptionsSpell;

    private string attack1Player = "ReadyAttack1";
    private string attack2Player = "ReadyAttack2";
    private string attack3Player = "ReadyAttack3";
    private string attackRock = "ReadyRock";

    //Particles Enemy

    private string attackEnemy = "AttackEnemy1";
    private string attackEnemy2 = "AttackEnemy2";
    public GameObject particuleEnemy1;
    public GameObject particuleEnemy2;

    public soundManager soundManager;
    void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
    }
    public void ActiveAnimator(string trigger)
    {
        if(player != null)
        {
            var animator = player.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    private void MainCards()
    {
        mainOptionsSpell.SetActive(false);
    }
    private void MainCardsActive()
    {
        mainOptionsSpell.SetActive(true);
    }
    public void ValueTrigger()
    {
            ActiveAnimator(attack1Player);
            particulePoison.SetActive(true);
            ValueTriggerEnemy2();
            Invoke("InActivePocion",4f);
            Invoke("MainCards",0.2f);
            Invoke("MainCardsActive",4f);
            soundManager.Instance.Play(3);
    }

    private void InActivePocion()
    {
            particulePoison.SetActive(false);
    }

    public void ValueTrigger2()
    {
            soundManager.Instance.Play(4);
            ActiveAnimator(attack2Player);
            particuleXplosion.SetActive(true);
            Invoke("InActiveXplosion",4f);
            ValueTriggerEnemy1();
            Invoke("MainCards",0.2f);
            Invoke("MainCardsActive",3f);
    }

    private void InActiveXplosion()
    {
            particuleXplosion.SetActive(false);
    }
    public void ValueTrigger3()
    {       soundManager.Instance.Play(3);
            ActiveAnimator(attack3Player);
            particuleTwister.SetActive(true);
            Invoke("InActiveTwister",4.5f);
            ValueTriggerEnemy2();
            Invoke("MainCards",0.2f);
            Invoke("MainCardsActive",3.5f);
    }

    private void InActiveTwister()
    {
            particuleTwister.SetActive(false);
    }

    public void ValueTrigger4()
    {       soundManager.Instance.Play(4);
            particuleRock.SetActive(true);
            Invoke("InActiveRock",2.55f);
            ActiveAnimator(attackRock);
            ValueTriggerEnemy1();
            Invoke("MainCards",0.2f);
            Invoke("MainCardsActive",3f);
    }

    private void InActiveRock()
    {
            particuleRock.SetActive(false);
    }

    //Active animator Enemy

    public void ActiveAnimatorEnemy(string trigger)
    {
        if(enemy != null)
        {
            var animatorEnemy = enemy.GetComponent<Animator>();
            if(animatorEnemy != null)
            {
                animatorEnemy.SetTrigger(trigger);
            }
        }
    }

    public void ValueTriggerEnemy1()
    {
            ActiveAnimatorEnemy(attackEnemy);
            particuleEnemy2.SetActive(true);
            Invoke("InActiveAttack1",4f);
    }

    private void InActiveAttack1()
    {
            particuleEnemy2.SetActive(false);
    }

    public void ValueTriggerEnemy2()
    {
            ActiveAnimatorEnemy(attackEnemy2);
            particuleEnemy1.SetActive(true);
            Invoke("InActiveAttack2",3.8f);
    }

    private void InActiveAttack2()
    {
            particuleEnemy1.SetActive(false);
    }
}

