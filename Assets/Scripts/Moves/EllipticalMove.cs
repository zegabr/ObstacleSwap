using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalMove : Trap
{
    public Vector3 initialPos, center;
    public float A, B;
    private float t;

    public float velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        t = Vector3.Angle((initialPos - center), new Vector3(1, 0, 0));
        initialPos = center + new Vector3( A * Mathf.Cos(t), B * Mathf.Sin(t), 0);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (active)
        {
            move();
        }
        else
        {
            returnToInitialPosition();
        }
    }

    private void move()
    {
        t+= velocity;
        gameObject.transform.position = center + new Vector3( A * Mathf.Cos(t), B * Mathf.Sin(t), 0);
    }

    private void returnToInitialPosition()
    {
        if (Vector3.Distance(initialPos, gameObject.transform.position) > 0.4)
        {
            move();
        }
        else
        {
            t = Vector3.Angle((initialPos - center), new Vector3(1, 0, 0));
        }
    }
}
