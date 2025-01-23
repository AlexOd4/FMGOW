using UnityEngine;

public class RatAttackDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RatBasicBehaviour ratBehaviour;
    void Start()
    {
        ratBehaviour = transform.parent.gameObject.GetComponent<RatBasicBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LizardHealth>() != null)
        {
            ratBehaviour.lizardHealth = other.gameObject.GetComponent<LizardHealth>();
            StartCoroutine(ratBehaviour.AttackCoroutine());
        }
    }
}
