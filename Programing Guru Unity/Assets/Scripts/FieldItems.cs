using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    GameManager manager;
    PlayerManager pManager;

    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = _item.itemImage;
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroyItem()
    {
        Debug.Log("Destroy");
        Destroy(gameObject);
        if (Input.GetButtonDown("Jump") && pManager.scanObject != null)
        {
            manager.Action(pManager.scanObject);
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
    }
}
