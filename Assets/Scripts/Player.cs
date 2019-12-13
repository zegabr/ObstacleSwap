using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
    public string nome;
    public int id;
    public float velocidade;
    public const float forcaPulo = 2000;
    float maxVelocidade;
	public bool onTheGround, alive, invertSense;	
	public new Rigidbody2D rigidbody;
    private float movimento;
    private bool shooted;

    private bool jaComecou=false;
//----------------template pra adicionar soms
    private AudioSource source;
    //sons aqui, criar uma variavel pra cada efeito sonoro e atualizar via interface unity
    public AudioClip somPulo;
    public AudioClip somMorte;
    public AudioClip somTombo;
    public AudioClip somMorri;
    public AudioClip somColisao;

    void initAudio(){//chamar no start
        source = GetComponent<AudioSource>();
    }

    void playSound(AudioClip soundEffect, float vol=1F){//chamar isso qnd quiser tocar sons
        if(alive){//permite que só o player vivo emita sons
            source.PlayOneShot(soundEffect, 1F);
        }
    }
//--------------------------------------------fim do template

    //Inicialização das variáveis
	void Start () {
        initAudio();//inicializa source
        nome = gameObject.name;
        id = Convert.ToInt32(nome.Substring(6));
        alive = false;
        castigo();
        velocidade = 0;
		rigidbody = GetComponent<Rigidbody2D>();
        invertSense = false;
        shooted = false;
	}
	
	// Update is called once per frame
	void Update () {        
         getMove();
         if(alive){
            Game.setPlayerPosition(transform.position);
         }
        
         if(myTurn() && !alive){
			switchTurn();
		}
	}

    bool myTurn(){
        return id == Game.turno;
    }

	void getMove(){
        if (Input.GetKeyDown("k") && alive)//troca os players de lugar
        {
            playSound(somMorri);
            die();
            return;
        }

        if(id==1){
            if (!shooted){
                movimento = Input.GetAxis("Horizontal1");
            }else{
                shooted = !onTheGround;
            }
            
            if (invertSense){
                movimento *= -1;
            } 
            velocidade = movimento*maxVelocidade;
            if(Input.GetKeyDown("up")){
                if (rigidbody.gravityScale > 0)
                {
                    if (onTheGround)
                    {
                        rigidbody.AddForce(new Vector2(0, forcaPulo));
                        onTheGround = false;
                        playSound(somPulo, 0.5F);
                    }
                }
                else
                {
                    if (onTheGround)
                    {
                        rigidbody.AddForce(new Vector2(0, -forcaPulo));
                        onTheGround = false;
                        playSound(somPulo, 0.5F);
                    }
                }
            }
        }else{
            float movimento = Input.GetAxis("Horizontal2");
            velocidade = movimento*maxVelocidade;
            if(Input.GetKeyDown("w")){
                if (rigidbody.gravityScale > 0)
                {
                    if (onTheGround)
                    {
                        rigidbody.AddForce(new Vector2(0, forcaPulo));
                        onTheGround = false;
                        playSound(somPulo, 0.5F);
                    }
                }
                else
                {
                    if (onTheGround)
                    {
                        rigidbody.AddForce(new Vector2(0, -forcaPulo));
                        onTheGround = false;
                        playSound(somPulo, 0.5F);
                    }
                }
                
            }
        }
        rigidbody.velocity = new Vector2(velocidade,rigidbody.velocity.y);	
        jaComecou |= onTheGround;
        onTheGround = rigidbody.velocity.y == 0||onTheGround;
    }

    public void switchTurn()
    {
        Debug.Log("trocando turno");
        rigidbody.gravityScale = 6.5F;
        if (alive){
			castigo();
		}else{
			ready();
        }
		alive = !alive;
        invertSense = false;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "letal"){
            if (alive){       
                playSound(somMorte);
                die();
            }
        }else if (other.gameObject.tag == "floor"){
            onTheGround = true;
        }else if (other.gameObject.tag == "Finish")
        {
            Control.IrCredito();
        }
        if(jaComecou){
            playSound(somTombo);
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "floor")
        {
            onTheGround = false;
        }
    }

    void die()
    {
        switchTurn();
        Game.nextTurn();
        rigidbody.velocity = new Vector2(0, 0);
    }

    void castigo(){
        transform.position = Game.inicio2; //descomentar isso pra testar velocidade do cara "morto"
        //Debug.Log("foi pro castigo");
        maxVelocidade = 42;
	}

	void ready(){
		transform.position = Game.inicio;
        maxVelocidade = 30;
	}

    public void changeSenses(bool sense)
    {
        invertSense = sense;
    }

    public void shootX()
    {
        movimento = -2;
        onTheGround = false;
        shooted = true;
    }
}
