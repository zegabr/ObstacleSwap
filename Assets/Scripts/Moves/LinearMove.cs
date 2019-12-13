using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : Trap
{

    public Vector3 initialPos, finalPos;
    private Vector3 currentPos;
    private bool going;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        //initialOffset = initialPos;
        //finalOffset = finalPos;
        //initialPos = gameObject.transform.position;
        //finalPos = initialPos + (finalOffset - initialOffset);
        base.Start();
        gameObject.transform.position = initialPos;
        going = true;
        currentPos = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Posição inicial:" + initialPos);
        currentPos = gameObject.transform.position;
        base.Update();
        if (active){
            move();
        }
        else
        {
            returnToInitialPosition();
        }
    }

    private void move()
    {
        Vector3 destiny = going ? finalPos : initialPos;
        going = (going == (Vector3.Distance(destiny, currentPos) > 0.2));
        Vector3 direction = Vector3.Normalize(destiny - currentPos);
        gameObject.transform.Translate(direction * velocity / 10, Space.World);
    }

    private void returnToInitialPosition()
    {
        if (Vector3.Distance(initialPos, currentPos) > 0.2)
        {
            Vector3 direction = Vector3.Normalize(initialPos - currentPos);
            gameObject.transform.Translate(direction * velocity/ 10, Space.World);
        }
    }
}
