using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Saw : Trap
{
    //----------------template pra adicionar soms
    private AudioSource source;
    //sons aqui, criar uma variavel pra cada efeito sonoro e atualizar via interface unity
    public AudioClip somSaw;
    void initAudio(){//chamar no start
        source = GetComponent<AudioSource>();//adicionar um audiosource no cara
        source.clip = somSaw;
    }

    void playSound(AudioClip soundEffect){//chamar isso qnd quiser tocar sons
        source.PlayOneShot(soundEffect, 1F);
    }
//--------------------------------------------fim do template


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        initAudio();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (active)
        {
            rotate();
        }
        
        
    }

    private void rotate()
    {
        if(!source.isPlaying){
            source.Play();
        }
        transform.Rotate(0.0f, 0.0f, 7.0f, Space.Self);
        
    }
}
