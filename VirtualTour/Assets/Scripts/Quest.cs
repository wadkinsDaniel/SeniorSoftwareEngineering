﻿using System.Collections.Generic;

public class Quest{

	private Dictionary<int, bool> requirements;
	private bool isCompleted;

	public Quest(){
		requirements = new Dictionary<int, bool>();		
		setUpQuestDefault();
		isCompleted = false;
	}

	public void updateRequirements(int questObjectID){

		if (requirements.ContainsKey(questObjectID)){
			requirements[questObjectID] = true;
		}
	}

	private void setUpQuestDefault(){

		requirements.Add(200, false);
		requirements.Add(201, false);
	}

	public bool isQuestDone(){

		int questCompleted = 0;

		foreach(KeyValuePair<int, bool> kvp in requirements){
			
			if(kvp.Value == true){
				questCompleted++;

			}else if (kvp.Value == false){
				break;
			}
		}

		if(questCompleted == requirements.Count){
			isCompleted = true;
		}

		return isCompleted;
	}

	public Dictionary<int,bool> getRequirements(){
		return requirements;
	}
}