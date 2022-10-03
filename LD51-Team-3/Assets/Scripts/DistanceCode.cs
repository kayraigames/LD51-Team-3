using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCode : MonoBehaviour
{
    public GameObject startPos;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = (startPos.transform.position.x + this.transform.position.x);
        scoreText.text = distance.ToString("F1");
    }
}
