using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool isTriggered = false;

    [SerializeField]
    public Dialogue dialogue;

    private EventManager theEM;

    void Start()
    {
        theEM = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered == false)
        {
            if (collision.gameObject.name == "Player")
            {
                theEM.ShowDialogue(dialogue);
                isTriggered = true;
            }
        }
        
    }

    public bool IsTriggered()
    {
        return true;
    }
}
