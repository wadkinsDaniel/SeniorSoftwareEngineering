using UnityEngine;

public class QuestManager : MonoBehaviour {

	public static QuestManager current;

	public Quest currentlyTrackedQuest;

	private bool testBool;

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
		
		testBool = currentlyTrackedQuest.isQuestDone();

		Debug.Log(testBool);
	}

	public void setCurrentlyTrackedQuest(Quest newQuest){
		currentlyTrackedQuest = newQuest;
	}
}