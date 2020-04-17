using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{/*
    public Animator anim;
    Hero myHero;

    void Start()
    {
        anim = GetComponent<Animator>();
        myHero = new Hero(anim);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myHero.KeySpace();   
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            myHero.KeyW();
        }
        myHero.DoUpdate();
    }
}

public interface IState
{
    void KeySpace();
    void KeyW();
    // void KeyA();
    // void KeyS();
    // void KeyD();
    // void KeyE();
    void OnUpdate();
};

public class HeroStanding : IState
{
    private Hero hero;

    public HeroStanding(Hero hero)
    {
        this.hero = hero;
    }
    public virtual void Enter()
    {
        Debug.Log("Idle anim Starting");
        hero.animState.Play("Idle", 0, 0);
    }
    public void OnUpdate()
    {
        
    }
    public void KeySpace()
    {
        Debug.Log("Got Space while Standing!");

    }
    public void KeyW()
    {
        Debug.Log("Got W while standing!");
        hero.state = hero.GetState("heroJumping");
    }
}

public class HeroJumping : IState
{
    private Hero hero;

    public HeroJumping(Hero hero)
    {
        this.hero = hero;
    }

    public virtual void Enter()
    {
        Debug.Log("Jump Anim Starting");
        hero.animState.Play("Jump", 0, 0);
    }
    public void OnUpdate()
    {
        if (hero.animState.GetCurrentAnimatorStateInfo(0).IsName("Idle") && hero.animState.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) 
        {
            Debug.Log("Jump Anim Finished");
            hero.state = hero.GetState("heroStanding");
        }
    }
    public void KeySpace()
    {
        Debug.Log("Got Space while Jumping!");
    }
    public void KeyW()
    {
        Debug.Log("Got W while Jumping!");
    }
}

public class Hero
{
    public IState state;

    private HeroStanding heroStanding;
    private HeroJumping heroJumping;

    public Animator animState;

    public Hero(Animator anim)
    {
        animState = anim;

        heroStanding = new HeroStanding(this);
        heroJumping = new HeroJumping(this);

        state = GetState("heroStanding");
    }

    public IState GetState(string stateId)
    {
        switch (stateId)
        {
            case "heroStanding":               
                heroStanding.Enter();
                return heroStanding;
            case "heroJumping":
                heroJumping.Enter();
                return heroJumping;
            default:
                return null;
        }
    }

    public void DoUpdate()
    {
        state.OnUpdate();
    }

    public void KeySpace()
    {
        state.KeySpace();
    }

    public void KeyW()
    {
        state.KeyW();
    }
    */
}
