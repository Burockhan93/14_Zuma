using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineResponse : MonoBehaviour
{
    public void OnSelect(Transform selection)
    {
        if (selection != null)
        {
            var outline = selection.GetComponent<Outline>();
            if (outline != null)
            {
                outline.OutlineWidth = 15;
                outline.OutlineColor = Color.cyan;
            }
        }

    }

    public void OnDeselect(Transform selection)
    {
        if (selection != null)
        {

            var outline = selection.GetComponent<Outline>();
            if (outline != null) outline.OutlineWidth = 0;
        }
    }
}
