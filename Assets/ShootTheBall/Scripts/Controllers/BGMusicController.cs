using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BGMusicController : MonoBehaviour 
{
	public static BGMusicController instance;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		if (instance == null) {
			instance = this;
			return;
		}
		Destroy (gameObject);
	}

	/// <summary>
	/// Starts the background music.
	/// </summary>
	public void StartBGMusic()
	{
		if (AudioManager.instance.isMusicEnabled) 
		{
			if (!GetComponent<AudioSource> ().isPlaying) {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
	/// <summary>
	/// Stops the background music.
	/// </summary>
	public void StopBGMusic()
	{
		GetComponent<AudioSource> ().Stop ();
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		AudioManager.OnMusicStatusChangedEvent += OnMusicStatusChanged;
		Invoke ("StartBGMusic", 0.2F);
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		AudioManager.OnMusicStatusChangedEvent -= OnMusicStatusChanged;
	}

	/// <summary>
	/// Raises the music status changed event.
	/// </summary>
	/// <param name="isSoundEnabled">If set to <c>true</c> is sound enabled.</param>
	void OnMusicStatusChanged (bool isSoundEnabled)
	{
		if (isSoundEnabled) {
			StartBGMusic ();
		} else {
			StopBGMusic ();
		}
	}	
}

