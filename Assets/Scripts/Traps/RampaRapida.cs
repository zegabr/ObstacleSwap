using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampaRapida : Trap
{
    //----------------template pra adicionar soms
    private AudioSource source;
    //sons aqui, criar uma variavel pra cada efeito sonoro e atualizar via interface unity
    public AudioClip somRampa;

    void initAudio()
    {//chamar no start
        source = GetComponent<AudioSource>();//adicionar um audiosource no cara
        source.clip = somRampa;
    }

    void playSound(AudioClip soundEffect)
    {//chamar isso qnd quiser tocar sons
        source.PlayOneShot(soundEffect, 1F);
    }
    //--------------------------------------------fim do template
    
    public float force;
    private Vector3 initialPos, finalPos;

    // Start is called before the first frame update
    void Start()
    {
        force = 4500;
        base.Start();
        initAudio();
        finalPos = gameObject.transform.position;
        initialPos = finalPos - new Vector3(0,5,0);
        gameObject.transform.position = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (active)
        {
            gameObject.transform.position = finalPos;
        }
        else
        {
            gameObject.transform.position = initialPos;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (active)
            {
                playSound(somRampa);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * force);
                other.gameObject.GetComponent<Player>().shootX();

            }
        }
    }
}
