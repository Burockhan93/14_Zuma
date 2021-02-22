using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegulator : MonoBehaviour
{

    public static void Itemregulator(int index)
    {
        for (int i = 0; i < index; i++)
        {
            if (ElementContainerController.items[index - 1 - i].childCount > 0)
            {
                var item = ElementContainerController.items[index - 1 - i];
                item.GetChild(0).transform.position = ElementContainerController.items[index - i].position;
                item.GetChild(0).SetParent(ElementContainerController.items[index - i]);
            }
        }

    }

    
}
