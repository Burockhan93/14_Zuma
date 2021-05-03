using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgebraAdder : MonoBehaviour
{  

    [SerializeField] private Storage storage;

    void Start()
    {
       
    }
    public void AddAlgebraOnGame(int calculatedValue, int index)
    {
        GameObject test = algebraCreator(calculatedValue);

        test.transform.position = ElementContainerController.items[index].position;

        if (test.GetComponent<AlgebraModel>())
        {
           test.transform.parent = ElementContainerController.items[index];
           ItemRegulator.Itemregulator(index);

        }

    }

    public void AddAlgebra(int model)
    {
        var j = ElementContainerController.items.Count;      
        GameObject addedModel = algebraCreator(model); 
        addedModel.transform.position = ElementContainerController.items[j - 1].transform.position;
        addedModel.transform.parent = ElementContainerController.items[j - 1];

    }

    private GameObject algebraCreator(int value)
    {
        if (value < 10)
        {

            GameObject one = Instantiate(storage.allAlgebra[value]);

            one.GetComponent<AlgebraModel>().setValue(value);
            one.transform.localScale -= one.transform.localScale / 6;

            return one;
        }

        int a = value % 10;
        int b = value / 10;

        
        GameObject zero = new GameObject();

        GameObject first = Instantiate(storage.allAlgebra[a]);       
        first.transform.localScale -= first.transform.localScale / 3;
        first.transform.parent = zero.transform;
        first.transform.position -= new Vector3(0, 0, -0.2f);
        Destroy(first.GetComponent<AlgebraModel>());


        GameObject second = Instantiate(storage.allAlgebra[b]);
        second.transform.localScale -= second.transform.localScale / 3;
        second.transform.parent = zero.transform;
        second.transform.position -= new Vector3(0, 0, 0.2f);
        Destroy(second.GetComponent<AlgebraModel>());

        zero.AddComponent<AlgebraModel>();
        zero.GetComponent<AlgebraModel>().setValue(value);
        
        return zero;

    }
}
