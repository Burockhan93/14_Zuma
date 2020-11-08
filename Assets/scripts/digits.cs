using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digits : MonoBehaviour
{
     sayi sahenSayi;
     public List<sayi> numberPrefabs = new List<sayi>();

    numbers _number;
    public int value;
    
    
     enum numbers 
    {
        one,two,three,four,eight
    }

    public sayi create()
    {
        

        int rand = Random.Range(1, 6); // 5 is eight

        switch (rand)
        {
            case 1:
                sahenSayi = Instantiate(numberPrefabs[0], transform.position, Quaternion.identity);
                sahenSayi.value = 1;
                _number = numbers.one;
                defineValue();

                break;
            case 2:
                sahenSayi = Instantiate(numberPrefabs[1], transform.position, Quaternion.identity);
                _number = numbers.two;
                sahenSayi.value = 2;
                defineValue();
                break;
            case 3:
                sahenSayi = Instantiate(numberPrefabs[2], transform.position, Quaternion.identity);
                _number = numbers.three;
                sahenSayi.value = 3;
                defineValue();
                break;
            case 4:
                sahenSayi = Instantiate(numberPrefabs[3], transform.position, Quaternion.identity);
                _number = numbers.four;
                sahenSayi.value = 4;
                defineValue();
                break;
            case 5:
                sahenSayi = Instantiate(numberPrefabs[4], transform.position, Quaternion.Euler(0,0,-90));
                _number = numbers.eight;
                sahenSayi.value = 8;
                defineValue();
                break;
            default:
                break;
        }

        return sahenSayi;
    }

    void defineValue()
    {
        if (_number == numbers.one)
        {
            value = 1;
        }
        if (_number == numbers.two)
        {
            value = 2;
        }
        if (_number == numbers.three)
        {
            value = 3;
        }
        if (_number == numbers.four)
        {
            value = 4;
        }
        if (_number == numbers.eight)
        {
            value = 8;
        }

    }


}
