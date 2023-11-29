using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeController : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public TMP_Dropdown functionDropdown;
    public TMP_Dropdown input1Dropdown;
    public TMP_Dropdown input2Dropdown;
    public Perceptron perceptronAND;
    public Perceptron perceptronOR;
    public Perceptron perceptronNAND;
    public Perceptron perceptronXOR;
    private Perceptron activePerceptron;

    void Start()
    {
        activePerceptron = perceptronOR;

        functionDropdown.value = 0;
        functionDropdown.RefreshShownValue();

        input1Dropdown.value = 0;
        input1Dropdown.RefreshShownValue();

        input2Dropdown.value = 0;
        input2Dropdown.RefreshShownValue();

        functionDropdown.onValueChanged.AddListener(delegate { ChangeActivePerceptron(functionDropdown.value); UpdateOutputCubeColor(); });
        input1Dropdown.onValueChanged.AddListener(delegate { UpdateCubeColor(cube1, input1Dropdown.value); UpdateOutputCubeColor(); });
        input2Dropdown.onValueChanged.AddListener(delegate { UpdateCubeColor(cube2, input2Dropdown.value); UpdateOutputCubeColor(); });
    }

    void ChangeActivePerceptron(int index)
    {

        activePerceptron = index switch
        {
            1 => perceptronAND,
            0 => perceptronOR,
            2 => perceptronNAND
        };
    }

    void UpdateCubeColor(GameObject cube, int value)
    {
        Color color = value == 1 ? Color.white : Color.black;
        cube.GetComponent<Renderer>().material.color = color;
    }

    void UpdateOutputCubeColor()
    {
        double output = activePerceptron.CalcOutput(input1Dropdown.value, input2Dropdown.value);
        UpdateCubeColor(cube3, output == 1 ? 1 : 0);
    }
}
