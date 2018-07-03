using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Barrel : MonoBehaviour, IGenerated {
    private Player playerReference;
    private float currentZRotation;
    private SpriteRenderer sprite;
    [SerializeField]
    private float forceAjust;
    [SerializeField]
    private Slider forceUI;
    private int controllerForce = 1;
    [SerializeField]
    private GameObject effectExplosion;

    private void Awake()
    {
     
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        forceUI = GameObject.FindGameObjectWithTag("BarrelUI").GetComponent<Slider>();
    }
    private void Update()
    {
       
        if (playerReference != null)
        {
           
            if (Input.GetKey(KeyCode.Mouse0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
            
                if (forceAjust > 1)
                {
                    controllerForce = -1;
                } else if (forceAjust < 0)
                {
                    controllerForce = 1;
                }
                forceAjust += Time.deltaTime * controllerForce;
                AjustForceUI(forceAjust);
            }else
            {
                Rotate(GameUtils.BARRIL_VELOCITY);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                ShootPlayer();
            }
        }
    }
    private void AjustForceUI(float forceAjust)
    {
        forceUI.transform.position = transform.position + Vector3.up * 2;
        forceUI.gameObject.SetActive(true);
        forceUI.value = forceAjust;
    }
    private void DisableUI()
    {
        forceUI.gameObject.SetActive(false);
    }
    private Vector3 Direction()
    {
        return transform.up;
    }
    private void Rotate(float velocity)
    {
        Vector3 currentEuler = new Vector3(0, 0, currentZRotation);
        transform.eulerAngles = currentEuler;
        currentZRotation += Time.deltaTime * velocity;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Player reference = other.GetComponent<Player>();
        if(reference != null)
        {
            playerReference = reference;
            playerReference.DisableSprite();
            playerReference.DisableRigidBody();
            playerReference.SetPosition(transform.position);
        }
    }
    private void ShootPlayer()
    {
        DisableUI();
        Vector3 direction = Direction();
        playerReference.EnableRigidBody();
        playerReference.RunShootAnimation();
        playerReference.EnableSprite();
        playerReference.Velocity = direction * GameUtils.BARRIL_FORCE * forceAjust;
        playerReference = null;
        StartCoroutine(EffectExplosion());
    }
    IEnumerator EffectExplosion()
    {
        sprite.enabled = false;
        effectExplosion.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
    
}
