using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapActivator : MonoBehaviour
{
//----------------template pra adicionar soms
    private AudioSource source;
    //sons aqui, criar uma variavel pra cada efeito sonoro e atualizar via interface unity
    public AudioClip somTrapActivation;
    public AudioClip somTrapDeactivation;


    void initAudio(){//chamar no start
        source = GetComponent<AudioSource>();//adicionar um audiosource no cara
    }

    void playSound(AudioClip soundEffect){//chamar isso qnd quiser tocar sons
        source.PlayOneShot(soundEffect, 1F);
    }

    void stopSound(){
        source.Stop();
    }
//--------------------------------------------fim do template


    public int id ;
    bool active;
    string spriteNames = "PressurePad_1";
    int deactivateSprite = 1, activateSprite = 0;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    int getId(){//pega o id da trap
        char [] separator = {' '};
        return Convert.ToInt32(gameObject.name.Split(separator,2, StringSplitOptions.RemoveEmptyEntries)[1]);
    }

    // Start is called before the first frame update
    void Start()
    {   
        id = getId();
        initAudio();
        active = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Game.activateTrap(id);
        }
        else
        {
            Game.deactivateTrap(id);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //stopSound();
            playSound(somTrapActivation);
            spriteRenderer.sprite = sprites[activateSprite];
            active = true;
            //Debug.Log("apertou botao"); 
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //stopSound();
            playSound(somTrapDeactivation);
            spriteRenderer.sprite = sprites[deactivateSprite];
            active = false;
            //Debug.Log("saiu do botao");
        }
    }

}
