using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlgebraDestroyer : MonoBehaviour
{
    
    public int DestroyNearestItems(List<Transform> transforms)
    {
        int index = 0;
        foreach (var item in transforms)
        {
            for (int i = 0; i < ElementContainerController.items.Count; i++)
            {
                
                if (ElementContainerController.items[i].Equals(item))
                {
                    if (i >= index)
                        index = i;
                    
                    Destroy(ElementContainerController.items[i].GetChild(0).gameObject);
                }
            }

        }
        return index;
    }

    public void DestroyEverything()
    {
        Debug.Log("Destroy everything");
        

        for (int i=0; i< ElementContainerController.items.Count; i++)
        {
            Destroy(ElementContainerController.items[i].gameObject);
        }

        ElementContainerController.items = new List<Transform>();
    }

    public void OneElementDestroyer(int index)
    {
        StartCoroutine(Wait(index));  

    }

    IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(ElementContainerController.items[index].GetChild(0).gameObject);
        ItemRegulator.Itemregulator(index);
    }
}
