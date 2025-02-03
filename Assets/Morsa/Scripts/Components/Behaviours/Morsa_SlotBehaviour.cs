using UnityEngine;

public class Morsa_SlotBehaviour : MonoBehaviour
{
    [SerializeField] public bool client;
    public Morsa_CardBehaviour card;
    float maxDistance = 30f;

    void Update()
    {
        if (card != null && Vector2.Distance(transform.position, card.transform.position) > maxDistance) card.Slide(transform.position);
    }

    public void Unlink()
    {
        card = null;
    }

    public void Link(Morsa_CardBehaviour newCard)
    {
        card = newCard;
        card.Slide(transform.position);
        card.Link(this);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (card == null &&
            collider.GetComponent<Morsa_CardBehaviour>() &&
            collider.GetComponent<Morsa_CardBehaviour>().linkable &&
            collider.GetComponent<Morsa_CardBehaviour>().linkedSlot.client != client)
        {
            Link(collider.GetComponent<Morsa_CardBehaviour>());
        }
    }
}