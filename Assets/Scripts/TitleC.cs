using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class TitleC : MonoBehaviour {
	
	public Texture2D tip;
	public string goToScene = "emerald_01";
	public string spawnPointName = "PlayerSpawnPointC"; 
	public GameObject characterDatabase;
	public Transform modelPosition;
	public Vector2 characterUiSize = new Vector2(400 , 460); //Show Detail GUI of your Character from CharacterData.
	
	private int page = 0;
	//private int presave = 0;
	
	private int saveSlot = 0;
	private string charName = "Richea";
	private int charSelect = 0;
	private int maxChar = 1;
	private CharacterDataC charData;
	private GameObject showingModel;

	public bool startBtnFlag = false;
	public bool loadBtnFlag = false;
	public bool creditBtnFlag = false;

	public GameObject TitleWin;
	public GameObject LoadingWin;
	public GameObject CreateWin;

	public GameObject LoadWin;
	public GameObject CreditWin;

	public TextMeshProUGUI LoadBtnSlot1;
	public TextMeshProUGUI LoadBtnSlot2;
	public TextMeshProUGUI LoadBtnSlot3;

	public GameObject HeroName;

	[SerializeField]
		public TMP_InputField name_field;

	public TextMeshProUGUI MightText;
	public TextMeshProUGUI IntelligenceText;
	public TextMeshProUGUI WillpowerText;
	public TextMeshProUGUI EnduranceText;
	public TextMeshProUGUI AccuracyText;
	public TextMeshProUGUI SpeedText;
	public TextMeshProUGUI LuckText;

	public Portraits PortraitsData;

	public TMP_Dropdown dropdown;

	public TextMeshProUGUI BonusNum;

	public AudioSource AudioPlayer;
	public AudioClip Error;
	public AudioClip Begin;

	void  Start (){
		//Screen.lockCursor = false;
        Cursor.lockState = CursorLockMode.None;
		charData = characterDatabase.GetComponent<CharacterDataC>();
		maxChar = charData.player.Length;
		if(!modelPosition){
			modelPosition = this.transform;
		}
		startBtnFlag = false;
		loadBtnFlag = false;
		creditBtnFlag = false;
		saveSlot = -1;
	}
	public void StartBtn() {
		startBtnFlag = true;
		page = 2;
		TitleWin.SetActive(false);
		CreateWin.SetActive(true);
	}
	public void LoadBtn()
	{
		loadBtnFlag = true;
		TitleWin.SetActive(false);
		LoadWin.SetActive(true);
	}

	public void CreditBtn()
	{
		creditBtnFlag = true;
		TitleWin.SetActive(false);
		CreditWin.SetActive(true);
}
	public void QuitBtn()
	{
		Application.Quit();
	}
	public void ReturnBtn()
	{
		startBtnFlag = false;
		page = 0;
		TitleWin.SetActive(true);
		CreateWin.SetActive(false);
		LoadWin.SetActive(false);
		CreditWin.SetActive(false);
	}
	public void LoadGameBtn()
	{
		if (saveSlot >= 0)
			LoadData();
		else
			Debug.Log("Beep");
	}
	void  OnGUI (){
		if(page == 0){
			//Menu
			if (/*GUI.Button ( new Rect(Screen.width - 420,160,140,50), "Start Game") ||*/ startBtnFlag) {
				//page = 2;
			}
			if (/*GUI.Button ( new Rect(Screen.width - 420,280,140,50), "Load Game") ||*/ loadBtnFlag) {
				//Check for previous Save Data
				page = 3;
			}
			if (/*GUI.Button ( new Rect(Screen.width - 420,400,140,50), "How to Play") ||*/ creditBtnFlag) {
				page = 1;
			}
		}
		
		if(page == 1){//окно credits
			//Help
			/*GUI.Box ( new Rect(Screen.width /2 -250,115,400,400), tip);
			
			if (GUI.Button ( new Rect(Screen.width - 280, Screen.height -150,250 ,90), "Back")) {
				page = 0;
			}*/
		}
		
		if(page == 2){//Окно создания персонажа - модель персонажа
			//saveSlot = 0;
			page = 5;
			SwitchModel();
			//Create Character and Select Save Slot
			/*GUI.Box ( new Rect(Screen.width / 2 - 250,170,500,400), "Select your slot");
			if (GUI.Button ( new Rect(Screen.width / 2 + 185,175,30,30), "X")) {
				page = 0;
			}
			//---------------Slot 1 [ID 0]------------------
			if(PlayerPrefs.GetInt("PreviousSave0") > 0){
				if (GUI.Button ( new Rect(Screen.width / 2 - 200,205,200,100), PlayerPrefs.GetString("Name0") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel0").ToString())) {
					//When Slot 1 already used
					saveSlot = 0;
					page = 4;
				}
			}else{
				if (GUI.Button ( new Rect(Screen.width / 2 - 200,205,200,100), "- Empty Slot -")) {
					//Empty Slot 1
					saveSlot = 0;
					page = 5;
					SwitchModel();
				}
			}
			//---------------Slot 2 [ID 1]------------------
			if(PlayerPrefs.GetInt("PreviousSave1") > 0){
				if (GUI.Button ( new Rect(Screen.width / 2 - 200,315,200,100), PlayerPrefs.GetString("Name1") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel1").ToString())) {
					//When Slot 2 already used
					saveSlot = 1;
					page = 4;
				}
			}else{
				if (GUI.Button ( new Rect(Screen.width / 2 - 200,315,200,100), "- Empty Slot -")) {
					//Empty Slot 2
					saveSlot = 1;
					page = 5;
					SwitchModel();
				}
			}
			//---------------Slot 3 [ID 2]------------------
			if(PlayerPrefs.GetInt("PreviousSave2") > 0){
				if (GUI.Button ( new Rect(Screen.width / 2 - 200,425,200,100), PlayerPrefs.GetString("Name2") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel2").ToString())) {
					//When Slot 3 already used
					saveSlot = 2;
					page = 4;
				}
			}else{
				if (GUI.Button ( new Rect(Screen.width / 2 - 200,425,200,100), "- Empty Slot -")) {
					//Empty Slot 3
					saveSlot = 2;
					page = 5;
					SwitchModel();
				}
			}*/
		}
		
		if(page == 3){//окно загрузки сохранения
			//Load Save Slot
			//GUI.Box ( new Rect(Screen.width / 2 - 250,170,500,400), "Menu");
			/*if (GUI.Button ( new Rect(Screen.width / 2 + 185,175,30,30), "X")) {
				page = 0;
			}*/
			//---------------Slot 1 [ID 0]------------------
			if(PlayerPrefs.GetInt("PreviousSave0") > 0){
				LoadBtnSlot1.text = PlayerPrefs.GetString("Name0");
				/*if (GUI.Button ( new Rect(Screen.width / 2 - 200,205,400,100), PlayerPrefs.GetString("Name0") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel0").ToString())) {
					//When Slot 1 already used
					saveSlot = 0;
					//LoadData ();
				}*/
			}
			else{
				LoadBtnSlot1.text = "- Empty Slot -";
				/*if (GUI.Button ( new Rect(Screen.width / 2 - 200,205,400,100), "- Empty Slot -")) {
					//Empty Slot 1
				}*/
			}
			//---------------Slot 2 [ID 1]------------------
			if(PlayerPrefs.GetInt("PreviousSave1") > 0){
				LoadBtnSlot2.text = PlayerPrefs.GetString("Name1");
				/*if (GUI.Button ( new Rect(Screen.width / 2 - 200,315,400,100), PlayerPrefs.GetString("Name1") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel1").ToString())) {
					//When Slot 2 already used
					saveSlot = 1;
					LoadData ();
				}*/
			}
			else{
				LoadBtnSlot2.text = "- Empty Slot -";
				/*if (GUI.Button ( new Rect(Screen.width / 2 - 200,315,400,100), "- Empty Slot -")) {
					//Empty Slot 2
				}*/
			}
			//---------------Slot 3 [ID 2]------------------
			if(PlayerPrefs.GetInt("PreviousSave2") > 0){
				LoadBtnSlot3.text = PlayerPrefs.GetString("Name2");
				/*if (GUI.Button ( new Rect(Screen.width / 2 - 200,425,400,100), PlayerPrefs.GetString("Name2") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel2").ToString())) {
					//When Slot 3 already used
					saveSlot = 2;
					LoadData ();
				}*/
			}
			else{
				LoadBtnSlot3.text = "- Empty Slot -";
				/*if (GUI.Button ( new Rect(Screen.width / 2 - 200,425,400,100), "- Empty Slot -")) {
					//Empty Slot 3
				}*/
			}
			
		}
		
		if(page == 4){
			//Overwrite Confirm
			GUI.Box ( new Rect(Screen.width /2 - 150,200,300,180), "Are you sure to overwrite this slot?");
			if (GUI.Button ( new Rect(Screen.width / 2 - 110,260,100,40), "Yes")) {
				page = 5;
				SwitchModel();
			}
			if (GUI.Button ( new Rect(Screen.width / 2 +20,260,100,40), "No")) {
				page = 0;
			}
		}
		
		if(page == 5){
			//Character Select and Name Your Character
			/*GUI.Box ( new Rect(80,100,300,360), "Enter Your Name");
			
			GUI.Label ( new Rect(100, 200, 300, 40), charData.player[charSelect].description.textLine1);
			GUI.Label ( new Rect(100, 230, 300, 40), charData.player[charSelect].description.textLine2);
			GUI.Label ( new Rect(100, 260, 300, 40), charData.player[charSelect].description.textLine3);
			GUI.Label ( new Rect(100, 290, 300, 40), charData.player[charSelect].description.textLine4);*/

			//charName = GUI.TextField ( new Rect(15, 167, 212, 26), charName, 25);

			/*if (GUI.Button ( new Rect(180,400,100,40), "Done")) {
				NewGame();
			}
			if (GUI.Button(new Rect(Screen.width / 2 + 185, 175, 30, 30), "X"))
			{
				page = 0;
				TitleWin.SetActive(true);
			}*/
			//Previous Character
			if (GUI.Button ( new Rect(Screen.width /2 - 110, Screen.height - 150, 50,50), "<")) {
				/*if(charSelect > 0){
					charSelect--;
					SwitchModel();
				}*/
			}
			//Next Character
			if (GUI.Button ( new Rect(Screen.width /2 + 190, Screen.height - 150, 50,50), ">")) {
				/*if(charSelect < maxChar -1){
					charSelect++;
					SwitchModel();
				}*/
			}
			//Show Detail GUI of your Character from CharacterData.
			if(charData.player[charSelect].guiDescription)
				GUI.DrawTexture( new Rect(Screen.width - characterUiSize.x - 5 ,40,characterUiSize.x,characterUiSize.y), charData.player[charSelect].guiDescription);
		}
		
	}

	public void PrevHero() {
		if (charSelect > 0)
		{
			charSelect--;
			SwitchModel();
		}
	}
	public void NextHero() {
		if (charSelect < maxChar - 1)
		{
			charSelect++;
			SwitchModel();
		}
	}
	public void  NewGame (){
		int num = int.Parse(BonusNum.text);
		if (num == 0) {
			AudioPlayer.PlayOneShot(Begin);
			saveSlot = 0;
			PlayerPrefs.SetInt("SaveSlot", saveSlot);
			//PlayerPrefs.SetString("Name" +saveSlot.ToString(), charName);
			//PlayerPrefs.SetInt("PlayerID" +saveSlot.ToString() , charSelect);
			PlayerPrefs.SetInt("Loadgame", 0);
			GameObject pl = Instantiate(charData.player[charSelect].playerPrefab, transform.position, transform.rotation) as GameObject;
			pl.GetComponent<StatusC>().spawnPointName = spawnPointName;
			pl.GetComponent<StatusC>().characterId = charSelect;
			pl.GetComponent<StatusC>().characterName = name_field.text;

			pl.GetComponent<StatusC>().CurrentFace = charSelect;
			pl.GetComponent<StatusC>().VoiceID = charSelect;

			pl.GetComponent<StatusC>().Might = int.Parse(MightText.text);
			pl.GetComponent<StatusC>().Intelligence = int.Parse(IntelligenceText.text);
			pl.GetComponent<StatusC>().Willpower = int.Parse(WillpowerText.text);
			pl.GetComponent<StatusC>().Endurance = int.Parse(EnduranceText.text);
			pl.GetComponent<StatusC>().Accuracy = int.Parse(AccuracyText.text);
			pl.GetComponent<StatusC>().Speed = int.Parse(SpeedText.text);
			pl.GetComponent<StatusC>().Luck = int.Parse(LuckText.text);

			pl.GetComponent<StatusC>().ClassType = (StatusC.PlayerClassType)dropdown.value;
			pl.GetComponent<StatusC>().Sex = (StatusC.PlayerSex)PortraitsData.sex;
			pl.GetComponent<StatusC>().Gold = 200;
			pl.GetComponent<StatusC>().FoodRations = 7;
			pl.GetComponent<StatusC>().ActiveSkills[PortraitsData.SkillDropdown1.value] = 1;
			pl.GetComponent<StatusC>().ActiveSkills[PortraitsData.SkillDropdown2.value] = 1;
			int skill_num = GetSkillIdByName(PortraitsData.Skill1Text.text);
			pl.GetComponent<StatusC>().ActiveSkills[skill_num] = 1;
			skill_num = GetSkillIdByName(PortraitsData.Skill2Text.text);
			pl.GetComponent<StatusC>().ActiveSkills[skill_num] = 1;

			//Application.LoadLevel(goToScene);
			LoadingWin.SetActive(true);
		}
		else
			AudioPlayer.PlayOneShot(Error);

	}
	public int GetSkillIdByName(string skill_name) {
		int i = 0;
		switch (skill_name) {
			case "Staff":
				i = 0;
				break;
			case "Sword":
				i = 1;
				break;
			case "Dagger":
				i = 2;
				break;
			case "Axe":
				i = 3;
				break;
			case "Spear":
				i = 4;
				break;
			case "Bow":
				i = 5;
				break;
			case "Mace":
				i = 6;
				break;
			case "Blaster":
				i = 7;
				break;
			case "Shield":
				i = 8;
				break;
			case "Leather":
				i = 9;
				break;
			case "Chain":
				i = 10;
				break;
			case "Plate":
				i = 11;
				break;
			case "Fire":
				i = 12;
				break;
			case "Air":
				i = 13;
				break;
			case "Water":
				i = 14;
				break;
			case "Earth":
				i = 15;
				break;
			case "Spirit":
				i = 16;
				break;
			case "Mind":
				i = 17;
				break;
			case "Body":
				i = 18;
				break;
			case "Light":
				i = 19;
				break;
			case "Dark":
				i = 20;
				break;
			case "ItemId":
				i = 21;
				break;
			case "Merchant":
				i = 22;
				break;
			case "Repair":
				i = 23;
				break;
			case "Bodybuilding":
				i = 24;
				break;
			case "Meditation":
				i = 25;
				break;
			case "Perception":
				i = 26;
				break;
			case "Diplomacy":
				i = 27;
				break;
			case "Thievery":
				i = 28;
				break;
			case "DisarmTrap":
				i = 29;
				break;
			case "Dodge":
				i = 30;
				break;				
			case "Unarmed":
				i = 31;
				break;
			case "MonsterId":
				i = 32;
				break;
			case "Armsmaster":
				i = 33;
				break;
			case "Stealing":
				i = 34;
				break;
			case "Alchemy":
				i = 35;
				break;
			case "Learning":
				i = 36;
				break;
			default:
				Debug.Log("Skill not found!");
				break;
		}
		return i;
	}
	void  LoadData (){
		PlayerPrefs.SetInt("SaveSlot", saveSlot);
		//if(presave == 10){
		PlayerPrefs.SetInt("Loadgame", 10);
		int playerId = PlayerPrefs.GetInt("PlayerID" +saveSlot.ToString());
		GameObject pl = Instantiate(charData.player[playerId].playerPrefab , transform.position , transform.rotation) as GameObject;
		pl.GetComponent<StatusC>().spawnPointName = spawnPointName;
		Application.LoadLevel(goToScene);
		//}
	}
	
	void  SwitchModel (){
		if(showingModel){
			Destroy(showingModel);
		}
		//Spawn Showing Model from Character Database
		if(charData.player[charSelect].characterSelectModel){
			showingModel = Instantiate(charData.player[charSelect].characterSelectModel , modelPosition.position , modelPosition.rotation) as GameObject;
		}
	}
	
}