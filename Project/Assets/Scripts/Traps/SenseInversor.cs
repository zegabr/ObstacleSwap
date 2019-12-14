using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseInversor : Trap
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
        GameObject player = GameObject.Find(("Player" + Game.turno));
        player.GetComponent<Player>().changeSenses(active);
    }
}
