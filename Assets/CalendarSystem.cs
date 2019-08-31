using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarSystem : MonoBehaviour
{
	public Text textCalendar;

	public int minuteDurationInSeconds = 60;
	public int dayDurationInMinutes = 10;
	public int monthDurationInDays = 30;
	public int yearDurationInMonths = 12;
	public float totalSeconds = 0f;
	public float seconds;
	public int minutes;
	public int days;
	public int months;
	public int years;
	public float startTime;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		seconds = Time.timeSinceLevelLoad + startTime;

		minutes = (int) (seconds / minuteDurationInSeconds);

		days = minutes / dayDurationInMinutes;
		months = days / monthDurationInDays;
		years = months / yearDurationInMonths;

		seconds %= minuteDurationInSeconds;
		days %= monthDurationInDays;
		months %= yearDurationInMonths;

		textCalendar.text = $"Ano {years + 1} Mês {months + 1} Dia {days + 1}";
    }
}
