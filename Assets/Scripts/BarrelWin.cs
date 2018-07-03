using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelWin : MonoBehaviour, IGenerated {

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Player reference = other.GetComponent<Player>();
        if (reference != null)
        {
            reference.DisableSprite();
            reference.DisableRigidBody();
            reference.SetPosition(transform.position);
            Debug.Log("Win");
            UIManager.instance.WinGame();
        }
    }
}
