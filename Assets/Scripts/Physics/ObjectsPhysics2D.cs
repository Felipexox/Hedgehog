using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPhysics2D : MonoBehaviour {
    protected Vector2 velocity;
    protected Vector2 acceleration;
    protected Vector2 currentVelocity;
    protected Vector2 currentAcceleration;
    [SerializeField]
    protected float gravityScale;
    public void Update()
    {
        AjustVelocityByAcceleration();
        ApplyVelocityInObject();
    }

    protected void AjustVelocityByAcceleration()
    {
        velocity += acceleration * Time.deltaTime - new Vector2(0, 0.0981f * Time.fixedDeltaTime * gravityScale);
    }
    protected void ApplyVelocityInObject()
    {
        transform.position += new Vector3(velocity.x, velocity.y);
    }
    public Vector2 Velocity
    {
        get
        {
            return velocity;
        }set
        {
            velocity = value;
        }
    }
    public Vector2 Acceleration
    {
        get
        {
            return acceleration;
        }
        set
        {
            acceleration = value;
        }
    }
	
}
