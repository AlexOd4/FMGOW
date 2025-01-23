using UnityEngine;

public class TileComponent : MonoBehaviour
{

    GameObject objectOnTile;
    public SpriteRenderer sRendrer;
    [SerializeField]
    GameObject spawnObject;

    private void Start()
    {
        sRendrer = GetComponent<SpriteRenderer>();
        if(spawnObject != null)
        {
            objectOnTile = Instantiate(spawnObject, transform.position, Quaternion.identity);
            objectOnTile.transform.SetParent(transform, true);
        }
    }
    public bool HasGameObject()
    {
        return objectOnTile != null;
    }

    public bool SetGameObject(GameObject newObject,Vector3 offset,bool overrideObject = false)
    {
        bool beenSet = false;
        if(overrideObject && objectOnTile != null)
        {
            //Destroy(objectOnTile);
            objectOnTile = null;
            objectOnTile = Instantiate(newObject,transform.position + offset,Quaternion.identity);
            objectOnTile.transform.SetParent(transform,true);  
            beenSet = true;
        }
        if(objectOnTile == null)
        {
            objectOnTile = Instantiate(newObject, transform.position + offset, Quaternion.identity);
            objectOnTile.transform.SetParent(transform, true);
            beenSet = true;
        }
        //Destroy(newObject);
        return beenSet;
    }

    public void RemoveGameObject()
    {
        Destroy(objectOnTile);
        objectOnTile = null;
    }
}
