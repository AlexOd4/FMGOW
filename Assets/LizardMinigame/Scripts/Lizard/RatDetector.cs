using UnityEngine;

public class RatDetector : MonoBehaviour
{

    public float detectLength;
    public Vector3 direction;

    public bool ratInSight = false;
    private LayerMask layer;
    private RatHealth ratHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layer = LayerMask.GetMask("Rat");
    }

    // Update is called once per frame
    void Update()
    {
        if( Physics.Raycast(transform.position,direction,out RaycastHit hit,detectLength,layer) )
        {
            ratHealth = hit.collider.gameObject.GetComponent<RatHealth>();
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (ratHealth != null) 
            {
                //print("Rat detected");
                ratInSight = true;
            } else
            {
                ratInSight=false;
            }
        }

        if(ratHealth == null)
        {
            ratInSight = false;
        }
        
    }
}
