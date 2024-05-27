using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollect : MonoBehaviour
{
    public int points = 0;
    public GameObject claimPrompt;

    [SerializeField] private TMPro.TextMeshProUGUI pointScoreText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            Destroy(collision.gameObject);
            points++;
            pointScoreText.text = points.ToString();
        }
    }

    void Update()
    {
        if (points == 10)
        {
            claimPrompt.SetActive(true);
        }
    }
}
