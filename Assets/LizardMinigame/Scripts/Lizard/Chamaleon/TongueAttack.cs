using System.Collections;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    public float damage;
    public float timeBetweenAttacks;
    public Transform tongue;
    private AttackHitBox hitBox;
    public float forwardDuration;
    public float backDuration;
    private RatDetector detector;
    private Coroutine tongueCoroutine;
    private Animator chamaleonAnim;
    void Start()
    {
        chamaleonAnim = GetComponent<Animator>();
        hitBox = tongue.gameObject.GetComponent<AttackHitBox>();
        hitBox.damage = damage;
        detector = GetComponent<RatDetector>();
    }

    void Update()
    {
        if (detector.ratInSight)
        {
            if (tongueCoroutine == null)
            {
                tongueCoroutine = StartCoroutine(TongueForward());
            }
        }
    }

    IEnumerator TongueForward()
    {
        float time = 0;
        print("tongue forward");
        chamaleonAnim.SetBool("Attacking",true);
        hitBox.enabled = true;
        while (time < forwardDuration)
        {
            time += Time.deltaTime;
            tongue.localPosition = Vector2.Lerp(Vector2.zero, Vector2.right * detector.detectLength, time/forwardDuration);
            yield return null;
        }
        time = forwardDuration;
        tongue.localPosition = Vector2.right * detector.detectLength;
        tongueCoroutine = StartCoroutine(TongueBack());
    }

    IEnumerator TongueBack()
    {
        float time = 0;
        hitBox.ClearHitObjects();
        while (time < backDuration)
        {
            time += Time.deltaTime;
            tongue.localPosition = Vector2.Lerp(Vector2.right * detector.detectLength, Vector2.zero, time / backDuration);
            yield return null;
        }
        print("tongue back");
        time = forwardDuration;
        tongue.localPosition = Vector2.zero;
        hitBox.enabled = false;
        chamaleonAnim.SetBool("Attacking", false);
        yield return new WaitForSeconds(timeBetweenAttacks);
        if (detector.ratInSight)
        {
            tongueCoroutine = StartCoroutine(TongueForward());
        } else
        {
            tongueCoroutine = null;
        }
    }
}
