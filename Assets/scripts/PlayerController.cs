using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Effects;
using DG.Tweening;
using UnityEditor;
using UnityEngine.Events;
using UnityStandardAssets.Utility;

public class PlayerController : MonoBehaviour
{
    public static HitEvent onPlayerHit = new HitEvent();
    public TextMesh text;
    public AlgebraOperator algebraOperator;
    public RayCastOperator rayCastOperator;
    [SerializeField] GameObject endMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject options;

    private Queue<GameObject> operators = new Queue<GameObject>();
    private float _operatorSpeed;
    private bool isFired;
    private Transform _hit;
    private TextHandler _textHandler;

    void Start()
    {
        _textHandler = GetComponent<TextHandler>();
        //onPlayerHit.AddListener((vec)=> Debug.Log(vec.x +","+vec.y +","+vec.z +": Hitted"));
        _operatorSpeed = 0.5f;

    }
    
    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !isFired && !endMenu.activeSelf && !pauseMenu.activeSelf && !options.activeSelf)
        {
            
            Fire();
            
        }
    }

    void Fire()
    {
        
        GameObject _algebraOperator ;
        RaycastHit hit;     
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,1 << 8))
        {          
            if (hit.transform != null)
            {
                isFired = true;
                _hit = hit.transform;
                _algebraOperator = Instantiate(GenerateOperator(), transform.position, Quaternion.identity);

                rayCastOperator.setRayCastHit(hit);

                rayCastOperator.Addoperator(_algebraOperator);

                MoveIslem(_algebraOperator, hit);
            }
        }
    }

    private GameObject GenerateOperator()
    {
        while (operators.Count < 4)
        {
            int i = Random.Range(0, 4);

            operators.Enqueue(algebraOperator._operators[i]);

        }
        
        GameObject go = operators.Dequeue();
        _textHandler.textHandler(text,operators);
        return go;

    }

    
    void MoveIslem(GameObject algebraOperator, RaycastHit hit)
    {

        algebraOperator.transform.position = transform.position;

        algebraOperator.transform.DOMove(hit.point, _operatorSpeed).OnComplete(() => {

            CalculatorManager.islem = algebraOperator.GetComponent<AlgebraOperator>()._Operator; // Calc managerdaki islemi burdan belirliorz
            Destroy(algebraOperator.gameObject, _operatorSpeed);
            isFired = false;

            FindObjectOfType<AudioManager>().Play("Hit");
            FindObjectOfType<ParticleManager>().Play(hit.point);


            onPlayerHit.Invoke(hit.point);

            
        });
        
    }

}

[System.Serializable]
public class HitEvent : UnityEvent<Vector3>
{
}