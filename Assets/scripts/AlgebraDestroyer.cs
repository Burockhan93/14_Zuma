using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading;


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
                    ElementContainerController.items[i].GetChild(0).gameObject.transform.DOShakeScale(0.3f, 0.3f);

                    //if (ElementContainerController.items[i].childCount > 1)
                    //{
                    //    ElementContainerController.items[i].GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.DOShakeScale(0.3f, 0.3f);
                    //    ElementContainerController.items[i].GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.DOShakeScale(0.3f, 0.3f);
                    //}
                    //else
                    //{
                    //    ElementContainerController.items[i].GetChild(0).gameObject.transform.DOShakeScale(0.3f, 0.3f);
                    //}
                        

                    Destroy(ElementContainerController.items[i].GetChild(0).gameObject,0.3f);


                }
            }

        }
        Thread.Sleep(1);
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
    IEnumerator Wait1(int index)
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(ElementContainerController.items[index].GetChild(0).gameObject);
        ItemRegulator.Itemregulator(index);
    }

    public void TwoElementDestroyer()
    {

    }
}
