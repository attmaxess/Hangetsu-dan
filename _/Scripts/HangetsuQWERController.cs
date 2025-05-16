using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangetsuQWERController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private int attackCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (animator.GetBool("BasicAttack").Equals(false)) BasicAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (animator.GetBool("Idle").Equals(true))
            {
                animator.SetBool("Move", true);
                animator.SetBool("Idle", false);
            }
            else if (animator.GetBool("Move").Equals(true))
            {
                animator.SetBool("Move", false);
                animator.SetBool("Idle", true);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            Stop();
        }
    }

    public void OnEndPerformingBasicAttack1()
    {
        Stop("ATK1");
    }
    public void OnEndPerformingBasicAttack2()
    {
        Stop("ATK2");
    }
    public void OnEndPerformingBasicCrit()
    {
        Stop("ATKCrit");
    }

    private void Stop(string stopSkill = "All")
    {
        if (animator.GetBool("Move").Equals(true)) animator.SetBool("Move", false);
        if (animator.GetBool("BasicAttack").Equals(true)) animator.SetBool("BasicAttack", false);
        switch (stopSkill)
        {
            case "All":
                animator.SetBool("ATK1", false);
                animator.SetBool("ATK2", false);
                animator.SetBool("ATKCrit", false);
                break;
            case "ATK1":
                if (animator.GetBool("ATK1").Equals(true)) animator.SetBool("ATK1", false);
                break;
            case "ATK2":
                if (animator.GetBool("ATK2").Equals(true)) animator.SetBool("ATK2", false);
                break;
            case "ATKCrit":
                if (animator.GetBool("ATKCrit").Equals(true)) animator.SetBool("ATKCrit", false);
                break;
        }

        animator.SetBool("Idle", true);
    }

    private void BasicAttack()
    {
        animator.SetBool("BasicAttack", true);
        attackCount++;
        if (attackCount % 4 != 0)
        {
            var randomAtk = Random.Range(0, 2);
            switch (randomAtk)
            {
                case 0:
                    animator.SetBool("ATK1", true);
                    break;
                case 1:
                    animator.SetBool("ATK2", true);
                    break;
            }
        }
        else
        {
            animator.SetBool("ATKCrit", true);
        }
    }
}
