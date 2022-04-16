using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiRotate : MonoBehaviour
{
    public Transform target;
    public Animator anim;

    void OnTriggerStay2D(Collider2D target1)
    {
        if (target1.tag == "Player")
        {
            target = target1.transform;

            Vector3 targ = target.transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            anim.ResetTrigger("EnemyGone");
            anim.SetTrigger("SeeEnemy");
        }
    }

    void OnTriggerExit2D(Collider2D target2)
    {
        if (target2.tag == "Player")
        {
            anim.ResetTrigger("SeeEnemy");
            anim.SetTrigger("EnemyGone");
        }
    }
}