using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
   [SerializeField] private ElementContainerController _elementContainer;
    public GameObject dört;

   private void Awake()
   {
      PlayerController.onPlayerHit.AddListener(DestroyNearestItems);
        
   }

   private void DestroyNearestItems(Vector3 vec)
   {
      var transforms = _elementContainer.GetNearestTwoTransforms(vec);
        Calculate(transforms); 

      foreach (var item in transforms)
      {
            if (item.GetChild(0).GetComponent<AlgebraModel>())
            {
                Debug.Log("null degil: "+ item.GetChild(0).GetComponent<AlgebraModel>().getValue());
            }
         //Debug.Log(item.GetChild(0).GetComponent<AlgebraModel>().Value);
         Destroy(item.GetChild(0).gameObject);
      }
   }
    
    private void Calculate(List<Transform> transform)
    {
        int CalculatedValue = 0;
        GameObject model;
        foreach (var item in transform)
        {
            CalculatedValue += item.GetChild(0).GetComponent<AlgebraModel>().getValue();
        }

        if (CalculatedValue == 4) // kendi metodunu yapmamiz gerekecek
        {
            AlgebraModel algebra = new AlgebraModel(CalculatedValue, dört);
            model=Instantiate(algebra._holdable,_elementContainer.items[_elementContainer.getIndextoReturn()].transform.position,Quaternion.identity);
            
            model.GetComponent<AlgebraModel>().setValue(CalculatedValue);
        }

        Debug.Log("Elementcontainerda su kadar eleman var: " +_elementContainer.items.Count);
        
    } 
}
