using System.Collections;
using UnityEngine;

public class RatBasicBehaviour : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public float timeBetweenAttacks;
    public float damage;
    [HideInInspector]
    public LizardHealth lizardHealth;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(lizardHealth == null)
        {
            transform.position = Vector3.Lerp(transform.position,transform.position + direction, Time.deltaTime*speed);
        }
    }

    public IEnumerator AttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenAttacks);
        while(lizardHealth != null)
        {
            anim.Play("Bite");
            yield return wait;
        }
        
        anim.Play("Walk");
    }

    public void Attack()
    {
        if (lizardHealth != null &&lizardHealth.Damage(damage))
        {
            lizardHealth = null;
        }
        anim.SetTrigger("BiteDone");
    }


}
