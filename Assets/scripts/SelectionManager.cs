using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private RayCastOperator _rayCastOperator;
    private RayCastoperatorOutline _rayCastoperatorOutline;
    private OutlineResponse _outlineResponse;

    private List<Transform> _selectedAlgebra;

    // Start is called before the first frame update
    void Start()
    {
        _rayCastOperator = GameObject.Find("RayCastOperator").GetComponent<RayCastOperator>();
        _rayCastoperatorOutline = GetComponent<RayCastoperatorOutline>();
        _outlineResponse = GetComponent<OutlineResponse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectedAlgebra != null)
        {
            foreach (Transform t in _selectedAlgebra)
            {
                _outlineResponse.OnDeselect(t);
            }
        }


        _rayCastoperatorOutline.Check(_rayCastOperator._ray);
        _selectedAlgebra = _rayCastoperatorOutline.GetSelection();

        if (_selectedAlgebra != null)
        {
            foreach (Transform t in _selectedAlgebra) {
                                
                _outlineResponse.OnSelect(t);
             }
        }
        
    }
}
