﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour {

	public static QuestManager current;

	public Text[] questTextDisplay;

	private Quest currentlyTrackedQuest;
	private int loopIterator;

	private void OnEnable(){

		if(current != null) {
			Destroy(gameObject);
		}else{
			current = this;
		}

		DialogueInteraction.spokeWithNpc += recieveNotification;
	}
	private void OnDisable(){
		DialogueInteraction.spokeWithNpc += recieveNotification;
	}

	private void recieveNotification(int questObjectID){
		currentlyTrackedQuest.updateRequirements(questObjectID);
		StartCoroutine(updateQuestUI());
	}

	private IEnumerator updateQuestUI(){

		loopIterator = 0;
		
		foreach(KeyValuePair<int, bool> kvp in currentlyTrackedQuest.getRequirements()){

			questTextDisplay[loopIterator].text = "Speak with " + kvp.Key.ToString() + 
							": " + kvp.Value;

			loopIterator++;
		}

		yield return new WaitForSeconds(1.0f);
	}

	public void setCurrentlyTrackedQuest(Quest newQuest){
		currentlyTrackedQuest = newQuest;		
		StartCoroutine(updateQuestUI());
	}
}