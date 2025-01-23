using Unity.VisualScripting;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public TileComponent currentTile;
    public GameObject itemForTile;
    //string itemTag = "ItemForTile";
    Color changedColor = new Color(0.4f, 1, 1);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TileComponent>() != null)
        {
            if (currentTile != collision.gameObject.GetComponent<TileComponent>())
            {
                currentTile = collision.gameObject.GetComponent<TileComponent>();

                int[] coords = GridManager.instance.WhereTile(currentTile);
                //print("line " + coords[0] + " column " + coords[1]);
                ChangeColorInCross();
            }
        }
        else
        {
            foreach (TileComponent allTile in GridManager.instance.allTiles.tiles)
            {
                allTile.sRendrer.color = Color.white;
            }
            currentTile = null;
        }

        if (collision.GetComponent<ItemCard>() && itemForTile == null)
        {
            if(CurrencyManager.instance.currency >= collision.GetComponent<ItemCard>().item.GetComponent<LizardObject>().lizard.lizardPrice) 
            { 
                itemForTile = Instantiate(collision.GetComponent<ItemCard>().item,new Vector3(transform.position.x, transform.position.y,0),Quaternion.identity);
                itemForTile.transform.SetParent(transform,true);
            }
        }
    }

    private void ChangeColorInCross()
    {
        foreach(TileComponent allTile in GridManager.instance.allTiles.tiles)
        {
            allTile.sRendrer.color = Color.white;
        }
        int[] coords = GridManager.instance.WhereTile(currentTile);
        foreach(TileComponent lineTile in GridManager.instance.lines[coords[0]].tiles)
        {
            lineTile.sRendrer.color = changedColor;
        }
        foreach (TileComponent columnTile in GridManager.instance.columns[coords[1]].tiles)
        {
            columnTile.sRendrer.color = changedColor;
        }
    }

}
