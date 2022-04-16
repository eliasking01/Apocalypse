using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiGunAnim : MonoBehaviour
{
    public Animator anim;

    void OnTriggerStay2D(Collider2D target1)
    {
        if (target1.tag == "Enemy")
        {
            anim.ResetTrigger("EnemyGone");
            anim.SetTrigger("SeeEnemy");
        }
    }

    void OnTriggerExit2D(Collider2D target2)
    {
        if (target2.tag == "Enemy")
        {
            anim.ResetTrigger("SeeEnemy");
            anim.SetTrigger("EnemyGone");
        }
    }
}
