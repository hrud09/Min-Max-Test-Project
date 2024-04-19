using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectArround : MonoBehaviour
{
    public LayerMask objectLayer;
    public RectTransform popUp;
    public TMP_Text nameText;
    public Transform lastUiPoint;
    private void Update()
    {
        if (lastUiPoint != null)
        {
            popUp.position = Camera.main.WorldToScreenPoint(lastUiPoint.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.layer == 6)
            {
                Object obj = other.gameObject.GetComponent<Object>();
                nameText.text = obj.name;
                lastUiPoint = obj.uiPoint;
                popUp.gameObject.SetActive(true);
               // popUp.
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.layer == 6)
            {
                lastUiPoint = null;
                nameText.text = "";            
                popUp.gameObject.SetActive(false);
                // popUp.
            }
        }
    }
}
