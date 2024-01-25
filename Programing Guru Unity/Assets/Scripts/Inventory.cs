using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    public List<Item> items = new List<Item>();
    PlayerManager pManager;
    public InventoryUI invui;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;


    public bool AddItem(Item _item)
    {
        if (items.Count < 7)
        {
            items.Add(_item);
            invui.RedrawSlotUI();
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
                fieldItems.DestroyItem();
        }
    }
}
