using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        Defender defender = otherObject.GetComponent<Defender>();

        if (defender)
        {
            if (otherObject.GetComponent<Gravestone>())
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            } else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }
    }
}
