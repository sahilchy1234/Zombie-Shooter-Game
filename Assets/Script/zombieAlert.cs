using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAlert : MonoBehaviour
{

    public ZombieAI zombie;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Physics Shell"))
        {
            zombie.masterAlert = true;
        }
    }
}
