using UnityEngine;

public class JesusCPlayerManager : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Point1")
        {
            Destroy(collision.gameObject);
            PointsManager.instance.AddPoint10();
            WareManager.Instance.levelPoints += 10;
        }

        if (collision.gameObject.tag == "Point2")
        {
            Destroy(collision.gameObject);
            PointsManager.instance.AddPoint20();
            WareManager.Instance.levelPoints += 20;
        }

        if (collision.gameObject.tag == "Point3")
        {
            Destroy(collision.gameObject);
            PointsManager.instance.AddPoint50();
            WareManager.Instance.levelPoints += 50;
        }

        if (collision.gameObject.tag == "Goal")
        {
            WareManager.Instance.isWin = true;
            WareManager.Instance.wareAnim.Play("Win");

        }

        if (collision.gameObject.tag == "Death")
        {
            WareManager.Instance.isWin = true;
            WareManager.Instance.wareAnim.Play("Loose");
        }
    }
}
