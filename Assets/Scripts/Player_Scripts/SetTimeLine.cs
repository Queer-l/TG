using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimeLine : MonoBehaviour
{
    public TimeLine_Manager tlManager;
    public int tl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            tlManager.ChangeTimeLine(tl);
            Destroy(gameObject);
        }
    }
}
