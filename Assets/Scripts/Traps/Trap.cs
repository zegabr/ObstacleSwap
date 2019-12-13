using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Trap : MonoBehaviour
{
    public int id;
    public bool active;

    int getId(){//pega o id da trap
        char [] separator = {' '};
        return (int) Convert.ToInt32(gameObject.name.Split(separator,2, StringSplitOptions.RemoveEmptyEntries)[1]);
    }

    // Start is called before the first frame update
    protected void Start()
    {
        id = getId();
        //Debug.Log(gameObject.name  + " " + id);
        active = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        active = isActive();
    }

    protected bool isActive(){
        return Game.isTrapActive(id);
    }
}
