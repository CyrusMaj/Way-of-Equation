using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationSelector : MonoBehaviour
{
    public GameObject DivButton_Selection;
    public GameObject SubButton_Selection;
    public GameObject AddButton_Selection;

    int stance = 1;

    void Update()
    {
        SelectStance();
    }

    void SelectStance()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            stance++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stance--;
        }

        if(stance > 3)
        {
            stance = 1;
        }
        if (stance < 1)
        {
            stance = 3;
        }

        if (stance == 1)
        {
            DivButton_Selection.SetActive(true);
        }
        else
            DivButton_Selection.SetActive(false);

        if (stance == 2)
        {
            SubButton_Selection.SetActive(true);
        }
        else
            SubButton_Selection.SetActive(false);

        if (stance == 3)
        {
            AddButton_Selection.SetActive(true);
        }
        else
            AddButton_Selection.SetActive(false);
    }
}
