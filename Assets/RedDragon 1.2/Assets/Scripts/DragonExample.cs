using UnityEngine;
using System.Collections;

public class DragonExample : MonoBehaviour
{
    private Animator anim;
    int IdleSimple;
    int IdleAgressive;
    int IdleRestless;
    int Walk;
    int BattleStance;
    int Bite;
    int FireAttack;
    int FlyingFWD;
    int FlyingAttack;
    int Hover;
    int Lands;
    int TakeOff;
    int Die;
    public GameObject objectActivatorGameObject;
    private ActivateObject objectActivator;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        IdleSimple = Animator.StringToHash("IdleSimple");
        IdleAgressive = Animator.StringToHash("IdleAgressive");
        IdleRestless = Animator.StringToHash("IdleRestless");
        Walk = Animator.StringToHash("Walk");
        BattleStance = Animator.StringToHash("BattleStance");
        Bite = Animator.StringToHash("Bite");
        FireAttack = Animator.StringToHash("FireAttack");
        FlyingFWD = Animator.StringToHash("FlyingFWD");
        FlyingAttack = Animator.StringToHash("FlyingAttack");
        Hover = Animator.StringToHash("Hover");
        Lands = Animator.StringToHash("Lands");
        TakeOff = Animator.StringToHash("TakeOff");
        Die = Animator.StringToHash("Die");
        objectActivator = objectActivatorGameObject.GetComponent<ActivateObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     anim.SetBool(IdleSimple, false);
        //     anim.SetBool(IdleAgressive, false);
        //     anim.SetBool(IdleRestless, false);
        //     anim.SetBool(Walk, false);
        //     anim.SetBool(BattleStance, false);
        //     anim.SetBool(Bite, false);
        //     anim.SetBool(FireAttack, true);
        //     anim.SetBool(FlyingFWD, false);
        //     anim.SetBool(FlyingAttack, false);
        //     anim.SetBool(Hover, false);
        //     anim.SetBool(Lands, false);
        //     anim.SetBool(TakeOff, false);
        //     anim.SetBool(Die, false);
        // }
        // else
        // {
        //     anim.SetBool(IdleSimple, false);
        //     anim.SetBool(IdleAgressive, false);
        //     anim.SetBool(IdleRestless, false);
        //     anim.SetBool(Walk, false);
        //     anim.SetBool(BattleStance, false);
        //     anim.SetBool(Bite, false);
        //     anim.SetBool(FireAttack, false);
        //     anim.SetBool(FlyingFWD, false);
        //     anim.SetBool(FlyingAttack, false);
        //     anim.SetBool(Hover, false);
        //     anim.SetBool(Lands, false);
        //     anim.SetBool(TakeOff, false);
        //     anim.SetBool(Die, false);
        // }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FireAttack"))
        {
            objectActivator.activateObject = true;
        }
        else
        {
            objectActivator.activateObject = false;
        }
    }
}
