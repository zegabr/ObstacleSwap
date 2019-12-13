using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInversor : Trap
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (active)
        {
           // Debug.Log("Ativando anti-gravidade");
            activateTrap();
        }
        else
        {
            //Debug.Log("Desativando anti-gravidade");
            deactivateTrap();
        }
    }

    void activateTrap()
    {
        GameObject player = GameObject.Find(("Player"+Game.turno));
        player.GetComponent<Rigidbody2D>().gravityScale = -6.5F;
    }

    void deactivateTrap()
    {
        GameObject player = GameObject.Find(("Player" + Game.turno));
        player.GetComponent<Rigidbody2D>().gravityScale = 6.5F;
    }
}
