using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
	public TextMeshProUGUI label;
	public int score;

	public void UpdateScore( int newScore ) {
		score = newScore;
		label.text = score.ToString();
	}
}
