using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    private Rigidbody2D rigi;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool isStoped;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public void Update()
    {
        if (!isStoped)
        {

            Vector2 currentRotation = transform.localEulerAngles;
            Vector2 currentVelocity = rigi.velocity;
            Vector3 deltVector = rigi.velocity - currentRotation;
            Vector3 newRotation = Vector3.zero;
            if (deltVector != Vector3.zero)
            {
                if (deltVector.x > 0)
                {
                    transform.localScale = Vector3.one * 4;
                    newRotation.z = -Quaternion.LookRotation(deltVector).eulerAngles.x;
                }
                else if (deltVector.x < 0)
                {
                    Vector3 scale = Vector3.one * 4;
                    scale.x = -scale.x;
                    transform.localScale = scale;
                    newRotation.z = Quaternion.LookRotation(deltVector).eulerAngles.x;
                }

            }
            transform.eulerAngles = newRotation;

            Die();
        }
    }
    private void Die()
    {
        if(transform.position.y < -50)
        {
            StopPlayer();
            UIManager.instance.LoseGame();
        }
    }
    IEnumerator DieAnimation()
    {
        SetPosition(Vector3.zero);
        DisableRigidBody();
        yield return new WaitForSeconds(2);
        EnableRigidBody();
    }
    public Vector2 Velocity
    {
        set
        {
            rigi.velocity = value;
        }
    }
    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
    public void DisableSprite()
    {
        sprite.enabled = false;
    }
    public void DisableRigidBody()
    {
        rigi.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void EnableRigidBody()
    {
        rigi.constraints = RigidbodyConstraints2D.None;
    }
    public void EnableSprite()
    {
        sprite.enabled = true;
    }
    public void RunShootAnimation()
    {
        anim.Play("Player_Roll");
    }
    
    public void StopPlayer()
    {
        DisableRigidBody();
        DisableSprite();
        isStoped = true;
    }
    public void PlayPlayer()
    {
        EnableRigidBody();
        EnableSprite();
        isStoped = false;
    }
}
