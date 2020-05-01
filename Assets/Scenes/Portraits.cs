using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Portraits : MonoBehaviour
{
    public Sprite[] PortraitArray;
    int charSelect = 0;
    public Image PortraitImage;
    public TextMeshProUGUI RaceText;
    public AudioSource AudioPlayer;
    public AudioClip[] HeroVoiceFemale;
    public AudioClip[] HeroVoiceMale;
    public AudioClip Error;
    public TMP_InputField name_field;
    int voiceID = 0;
    public int sex;

    public TextMeshProUGUI MightText;
    public TextMeshProUGUI IntelligenceText;
    public TextMeshProUGUI WillpowerText;
    public TextMeshProUGUI EnduranceText;
    public TextMeshProUGUI AccuracyText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI LuckText;

    public TextMeshProUGUI BonusNum;

    public TMP_Dropdown Class_dropdown;

    public TextMeshProUGUI Skill1Text;
    public TextMeshProUGUI Skill2Text;
    public TMP_Dropdown SkillDropdown1;
    public TMP_Dropdown SkillDropdown2;
    private int temp_skill_name1_id;
    private int temp_skill_name2_id;
    private bool skills_complite = false;

    public int[][][] StatTable = new int[4][][]{

        new int[7][]{new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{ 9, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{9, 25, 1, 1}},

        new int[7][]{new int[4]{ 7, 15, 2, 1}, new int[4]{14, 30, 1, 2}, new int[4]{11, 25, 1, 1}, new int[4]{ 7, 15, 2, 1}, new int[4]{14, 30, 1, 2}, new int[4]{11, 25, 1, 1}, new int[4]{9, 20, 1, 1}},

        new int[7][]{new int[4]{14, 30, 1, 2}, new int[4]{ 7, 15, 2, 1}, new int[4]{ 7, 15, 2, 1}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{14, 30, 1, 2}, new int[4]{9, 20, 1, 1}},

        new int[7][]{new int[4]{14, 30, 1, 2}, new int[4]{11, 25, 1, 1}, new int[4]{11, 25, 1, 1}, new int[4]{14, 30, 1, 2}, new int[4]{ 7, 15, 2, 1}, new int[4]{ 7, 15, 2, 1}, new int[4]{9, 20, 1, 1}}

    };

    public static int[][] SkillAvailabilityPerClass = new int[][]{new int[]{0, 2, 0, 1, 1, 1, 1, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},

        new int[]{0, 1, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 2, 1, 0},

        new int[]{1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 2, 2, 1, 1, 0, 0, 0},

        new int[]{0, 1, 1, 1, 0, 0, 2, 0, 1, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},

        new int[]{0, 1, 0, 1, 1, 2, 0, 0, 0, 1, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1},

        new int[]{0, 1, 1, 2, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0},

        new int[]{0, 0, 0, 0, 0, 0, 2, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 2, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1},

        new int[]{0, 0, 2, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 2, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1},

        new int[]{2, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0}};


    string RandomizeName(bool isMale)

    {

        if (isMale)

            return Texts.NPCNames[Random.Range(0, 30)];

        else

            return Texts.NPCNames[Random.Range(30, 60)];

    }
    public string GetSkillNameById(int skill_id)
    {
        string i = "";
        switch (skill_id)
        {
            case 0:
                i = "Staff";
                break;
            case 1:
                i = "Sword";
                break;
            case 2:
                i = "Dagger";
                break;
            case 3:
                i = "Axe";                
                break;
            case 4:
                i="Spear";
                break;
            case 5:
                i="Bow";
                break;
            case 6:
                i="Mace";
                break;
            case 7: 
                i="Blaster";
                break;
            case 8:
                i="Shield";
                break;
            case 9:
                i="Leather";
                break;
            case 10:
                i="Chain";
                break;
            case 11:
                i="Plate";
                break;
            case 12:
                i="Fire";
                break;
            case 13:
                i="Air";
                break;
            case 14:
                i="Water";
                break;
            case 15:
                i="Earth";
                break;
            case 16:
                i="Spirit";
                break;
            case 17:
                i="Mind";
                break;
            case 18:
                i="Body";
                break;
            case 19:
                i="Light";
                break;
            case 20:
                i="Dark";
                break;
            case 21:
                i="ItemId";
                break;
            case 22:
                i="Merchant";
                break;
            case 23:
                i="Repair";
                break;
            case 24:
                i="Bodybuilding";
                break;
            case 25:
                i="Meditation";
                break;
            case 26:
                i="Perception";
                break;
            case 27:
                i="Diplomacy";
                break;
            case 28:
                i="Thievery";
                break;
            case 29:
                i="DisarmTrap";
                break;
            case 30:
                i="Dodge";
                break;
            case 31:
                i="Unarmed";
                break;
            case 32:
                i="MonsterId";
                break;
            case 33:
                i="Armsmaster";
                break;
            case 34:
                i="Stealing";
                break;
            case 35:
                i="Alchemy";
                break;
            case 36:
                i="Learning";
                break;
            default:
                Debug.Log("Skill not found!");
                break;
        }
        return i;
    }

    public int GetSkillIdByName(string skill_name)
    {
        int i = 0;
        switch (skill_name)
        {
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


    public void ClearBtn() {
        SetInitialStats();
        SetInitialSkills();
        BonusNum.color = Color.red;
        BonusNum.text = 13 + "";
    }

    /*Initial*/
    public void SetInitialHero() {
        name_field.text = RandomizeName(isMale(charSelect));
    }
    public void SetInitialStats()
    {

        int v1 = GetRace(charSelect);

        MightText.text = StatTable[v1][0][0]+"";
        GetStatColor(0);

        IntelligenceText.text = StatTable[v1][1][0]+"";
        GetStatColor(1);

        WillpowerText.text = StatTable[v1][2][0]+"";
        GetStatColor(2);

        EnduranceText.text = StatTable[v1][3][0]+"";
        GetStatColor(3);

        AccuracyText.text = StatTable[v1][4][0]+"";
        GetStatColor(4);

        SpeedText.text = StatTable[v1][5][0]+"";
        GetStatColor(5);

        LuckText.text = StatTable[v1][6][0]+"";
        GetStatColor(6);

        BonusNum.color = Color.red;
        BonusNum.text = 13 + "";
    }
    public void SetInitialSkills() 
    {
        GetSkillIdxByOrder();
        /*Skill1Text.text = "Leather";         // leather
        Skill2Text.text = "Armsmaster";        // armsmaster
        SkillDropdown1.value = 5;
        SkillDropdown2.value = 1;*/
        //addToDropdown();

        //Players[0].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_BOW] = 1;         // bow

        // Players[0].ActiveSkills[(int)PlayerStats.PLAYER_SKILL_TYPE.PLAYER_SKILL_SWORD] = 1;         // sword
    }
    public void GetSkillIdxByOrder() 
    {
        int num_no_select_skill = 0;
        int num_select_skill = 0;
        SkillDropdown1.options.Clear();
        SkillDropdown2.options.Clear();
        skills_complite = false;
        temp_skill_name1_id = 0;
        temp_skill_name2_id = 0;

        for (int i = 0; i < 37; i++)
        {

            if (SkillAvailabilityPerClass[Class_dropdown.value][i] == 2)
            {
                if (num_no_select_skill == 0)
                {
                    Skill1Text.text = GetSkillNameById(i);
                    num_no_select_skill++;
                }
                else
                    Skill2Text.text = GetSkillNameById(i);

            }
            else if (SkillAvailabilityPerClass[Class_dropdown.value][i] == 1)
            {
                addToDropdownsSkills(GetSkillNameById(i), num_select_skill);
                if (num_select_skill == 0)
                {
                    SkillDropdown1.value = i;
                    num_select_skill++;
                    temp_skill_name1_id = i;
                    SkillDropdown1.RefreshShownValue();
                }
                else if (num_select_skill == 1)
                {
                    SkillDropdown2.value = i;
                    num_select_skill++;
                    temp_skill_name2_id = i;
                    SkillDropdown2.RefreshShownValue();
                }
            }
        }
        skills_complite = true;
    }
    public void addToDropdownsSkills(string Skill_name, int flag)
    {
        if (flag == 0)
        {            
            SkillDropdown1.options.Add(new TMP_Dropdown.OptionData() { text = Skill_name });
        }
        else if (flag == 1)
        {
            SkillDropdown2.options.Add(new TMP_Dropdown.OptionData() { text = Skill_name });
        }
        else
        {
            SkillDropdown1.options.Add(new TMP_Dropdown.OptionData() { text = Skill_name });
            SkillDropdown2.options.Add(new TMP_Dropdown.OptionData() { text = Skill_name });
        }
    }

    public void ChangeSkill1() 
    {
        //string text1 = GetSkillNameById(SkillDropdown1.captionText);
        //string text2 = GetSkillNameById(SkillDropdown2.value);

        if (skills_complite == true)
        {
            Debug.Log(SkillDropdown1.options[SkillDropdown1.value].text + "");
            Debug.Log(SkillDropdown2.options[SkillDropdown2.value].text + "");
            if (SkillDropdown1.options[SkillDropdown1.value].text == SkillDropdown2.options[SkillDropdown2.value].text)
            {
                SkillDropdown1.value = GetSkillIdByName(GetSkillNameById(temp_skill_name1_id));
                AudioPlayer.PlayOneShot(Error);
            }
            else
            {
                temp_skill_name1_id = GetSkillIdByName(SkillDropdown1.options[SkillDropdown1.value].text);
            }
            SkillDropdown1.RefreshShownValue();
        }
    }
    public void ChangeSkill2()
    {
        //string text1 = GetSkillNameById(SkillDropdown1.value);
        //string text2 = GetSkillNameById(SkillDropdown2.value);

        if (skills_complite == true)
        {
            Debug.Log(SkillDropdown1.options[SkillDropdown1.value].text + "");
            Debug.Log(SkillDropdown2.options[SkillDropdown2.value].text + "");
            if (SkillDropdown1.options[SkillDropdown1.value].text == SkillDropdown2.options[SkillDropdown2.value].text)
            {
                SkillDropdown2.value = GetSkillIdByName(GetSkillNameById(temp_skill_name2_id));
                AudioPlayer.PlayOneShot(Error);
            }
            else
            {
                temp_skill_name2_id = GetSkillIdByName(SkillDropdown2.options[SkillDropdown2.value].text);
            }
            SkillDropdown2.RefreshShownValue();
        }
    }

    /*Might Stat*/
    public void MightStatPlus() 
    {
        int race = GetRace(charSelect);
        int i = int.Parse(MightText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][0][2];
        if (num > 0 && i <= StatTable[race][0][1] && test >= 0)
        {
            i += StatTable[race][0][3];
            num -= StatTable[race][0][2];
            if (num <= 0)
            {
                BonusNum.text = 0 + "";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            MightText.text = i + "";
            GetStatColor(0);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }
    public void MightStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(MightText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][0][0])
        {
            i -= StatTable[race][0][3];
            num += StatTable[race][0][2];
            BonusNum.text = num + "";
            MightText.text = i + "";
            GetStatColor(0);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }

    /* Intelligence Stat*/
    public void IntelligenceStatPlus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(IntelligenceText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][1][2];
        if (num > 0 && i <= StatTable[race][1][1] && test >=0)
        {
            i += StatTable[race][1][3];
            num -= StatTable[race][1][2];
            if (num <= 0)
            {
                BonusNum.text = 0 + "";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            IntelligenceText.text = i + "";
            GetStatColor(1);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }
    public void IntellegenceStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(IntelligenceText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][1][0])
        {
            i -= StatTable[race][1][3];
            num += StatTable[race][1][2];
            BonusNum.text = num + "";
           IntelligenceText.text = i + "";
            GetStatColor(1);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }
    /*Personality Stat*/
    public void PersonalityStatPlus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(WillpowerText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][2][2];
        if (num > 0 && i <= StatTable[race][2][1] && test >= 0)
        {
            i += StatTable[race][2][3];
            num -= StatTable[race][2][2];
            if (num <= 0)
            {
                BonusNum.text = 0 + "";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            WillpowerText.text = i + "";
            GetStatColor(2);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }
    public void PersonalityStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(WillpowerText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][2][0])
        {
            i -= StatTable[race][2][3];
            num += StatTable[race][2][2];
            BonusNum.text = num + "";
            WillpowerText.text = i + "";
            GetStatColor(2);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }

    /*Endurance Stat*/
    public void EnduranceStatPlus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(EnduranceText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][3][2];
        if (num > 0 && i <= StatTable[race][3][1] & test >= 0)
        {
            i += StatTable[race][3][3];
            num -= StatTable[race][3][2];
            if (num <= 0)
            {
                BonusNum.text = 0 + "";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            EnduranceText.text = i + "";
            GetStatColor(3);
        }
        else
            AudioPlayer.PlayOneShot(Error);
        
    }
    public void EnduranceStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(EnduranceText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][3][0])
        {
            i -= StatTable[race][3][3];
            num += StatTable[race][3][2];
            BonusNum.text = num + "";
            EnduranceText.text = i + "";
            GetStatColor(3);
        }
        else
        {
            AudioPlayer.PlayOneShot(Error);
        }
    }
    
    /* Accuracy Stat*/
    public void AccuracyStatPlus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(AccuracyText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][4][2];
        if (num > 0 && i <= StatTable[race][4][1] && test >= 0)
        {
            i += StatTable[race][4][3];
            num -= StatTable[race][4][2];
            if (num <= 0)
            {
                BonusNum.text = 0 + "";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            AccuracyText.text = i + "";
            GetStatColor(4);
        }
        else
        {
            //Debug.Log("Beep");
            AudioPlayer.PlayOneShot(Error);
        }
    }
    public void AccuracyStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(AccuracyText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][4][0])
        {
            i -= StatTable[race][4][3];
            num += StatTable[race][4][2];
            BonusNum.text = num + "";
            AccuracyText.text = i + "";
            GetStatColor(4);
        }
        else
        {
            AudioPlayer.PlayOneShot(Error);
        }
    }

    /* Speed stat*/
    public void SpeedStatPlus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(SpeedText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][5][2];
        if (num > 0 && i <= StatTable[race][5][1] && test >= 0)
        {
            i += StatTable[race][5][3];
            num -= StatTable[race][5][2];
            if (num <= 0)
            {
                BonusNum.text = 0 + "";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            SpeedText.text = i + "";
            GetStatColor(5);
        }
        else
        {
            //Debug.Log("Beep");
            AudioPlayer.PlayOneShot(Error);
        }
    }
    public void SpeedStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(SpeedText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][5][0])
        {
            i -= StatTable[race][5][3];
            num += StatTable[race][5][2];
            BonusNum.text = num + "";
            SpeedText.text = i + "";
            GetStatColor(5);
        }
        else
        {
            //Debug.Log("Beep");
            AudioPlayer.PlayOneShot(Error);
        }
    }

    /*Luck stat*/
    public void LuckStatPlus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(LuckText.text);
        int num = int.Parse(BonusNum.text);
        int test = num - StatTable[race][6][2];
        if (num > 0 && i <= StatTable[race][6][1] && test >= 0)
        {
            i+= StatTable[race][6][3];
            num-= StatTable[race][6][2];
            if (num <= 0)
            {
                BonusNum.text = 0+"";
                BonusNum.color = Color.white;
            }
            BonusNum.text = num + "";
            LuckText.text = i + "";
            GetStatColor(6);
        }
        else
        {
            //Debug.Log("Beep");
            AudioPlayer.PlayOneShot(Error);
        }
    }
    public void LuckStatMinus()
    {
        int race = GetRace(charSelect);
        int i = int.Parse(LuckText.text);
        int num = int.Parse(BonusNum.text);
        if (i > StatTable[race][6][0])
        {
            i-= StatTable[race][6][3];
            num+= StatTable[race][6][2];
            BonusNum.text = num + "";
            LuckText.text = i + "";
            GetStatColor(6);
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }

    void GetStatColor(int uStat)
    {
        //uStat - Стат который проверяем
        int attribute_value = 0; // edx@1

        int base_attribute_value = 0;



        base_attribute_value = StatTable[GetRace(charSelect)][uStat][0];

        switch (uStat)

        {

            case 0: attribute_value = int.Parse(MightText.text);
                if (attribute_value == base_attribute_value)
                    MightText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    MightText.color = Color.green;
                else
                    MightText.color = Color.red;
                break;

            case 1: attribute_value = int.Parse(IntelligenceText.text);
                if (attribute_value == base_attribute_value)
                    IntelligenceText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    IntelligenceText.color = Color.green;
                else
                    IntelligenceText.color = Color.red;
                break;

            case 2: attribute_value = int.Parse(WillpowerText.text);
                if (attribute_value == base_attribute_value)
                    WillpowerText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    WillpowerText.color = Color.green;
                else
                    WillpowerText.color = Color.red;
                break;

            case 3: attribute_value = int.Parse(EnduranceText.text);
                if (attribute_value == base_attribute_value)
                    EnduranceText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    EnduranceText.color = Color.green;
                else
                    EnduranceText.color = Color.red;
                break;

            case 4: attribute_value = int.Parse(AccuracyText.text);
                if (attribute_value == base_attribute_value)
                    AccuracyText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    AccuracyText.color = Color.green;
                else
                    AccuracyText.color = Color.red;
                break;

            case 5: attribute_value = int.Parse(SpeedText.text);
                if (attribute_value == base_attribute_value)
                    SpeedText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    SpeedText.color = Color.green;
                else
                    SpeedText.color = Color.red;
                break;

            case 6: attribute_value = int.Parse(LuckText.text);
                if (attribute_value == base_attribute_value)
                    LuckText.color = Color.white;
                else if (attribute_value > base_attribute_value)
                    LuckText.color = Color.green;
                else
                    LuckText.color = Color.red;
                break;

            default: Debug.Log("Unexpected attribute"); break;

        };
    }

    /*Portraits select*/
    public void PrevPortraits()
    {
        if (charSelect > 0)
        {
            charSelect--;
            PortraitImage.sprite = PortraitArray[charSelect];
            SelectRace(charSelect);
            SetInitialStats();
            BonusNum.text = 13 + "";
            BonusNum.color = Color.red;
            SetInitialHero();
            if (isMale(charSelect))
                AudioPlayer.PlayOneShot(HeroVoiceMale[charSelect]);
            else
                AudioPlayer.PlayOneShot(HeroVoiceFemale[charSelect]);
            //voiceID = charSelect;
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }
    public void NextPortraits() {
        if (charSelect < PortraitArray.Length-1)
        {
            charSelect++;
            PortraitImage.sprite = PortraitArray[charSelect];
            SelectRace(charSelect);
            SetInitialStats();
            BonusNum.color = Color.red;
            BonusNum.text = 13 + "";
            SetInitialHero();
            if (isMale(charSelect))
                AudioPlayer.PlayOneShot(HeroVoiceMale[charSelect]);
            else
                AudioPlayer.PlayOneShot(HeroVoiceFemale[charSelect]);
            //voiceID = charSelect;
        }
        else
            AudioPlayer.PlayOneShot(Error);
    }

    /*Voice select*/
    public void ChangeVoicePlus() {
        if (voiceID < 12)
            voiceID++;
        else
            voiceID=0;
        if (voiceID != 0)
        {
            if (isMale(charSelect))
                AudioPlayer.PlayOneShot(HeroVoiceMale[voiceID * 2 - 1]);
            else
                AudioPlayer.PlayOneShot(HeroVoiceFemale[voiceID * 2 - 1]);
        }
        else {
            if (isMale(charSelect))
                AudioPlayer.PlayOneShot(HeroVoiceMale[0]);
            else
                AudioPlayer.PlayOneShot(HeroVoiceFemale[0]);
        }
    }
    public void ChangeVoiceMinus()
    {
        if (voiceID > 1)
            voiceID--;
        else
            voiceID = 12;
        if (voiceID != 0)
        {
            if (isMale(charSelect))
                AudioPlayer.PlayOneShot(HeroVoiceMale[voiceID * 2 - 2]);
            else
                AudioPlayer.PlayOneShot(HeroVoiceFemale[voiceID * 2 - 1]);
        }
        else {
            if (isMale(charSelect))
                AudioPlayer.PlayOneShot(HeroVoiceMale[23]);
            else
                AudioPlayer.PlayOneShot(HeroVoiceFemale[23]);
        }
    }

    /*Sex and race select*/
    bool isMale(int id) {
        //bool isMale = false;
        switch (id) {
            case 0:
            case 1:
            case 2:
            case 3:
            case 8:
            case 9:
            case 12:
            case 13:
            case 16:
            case 17:
                sex = 0;
                return true;
                break;
            default:
                sex = 1;
                return false;
        }
    }
    void SelectRace(int charID) {
        switch (charID) { 
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                RaceText.text = "Human";
                break;
            case 8:
            case 9:
            case 10:
            case 11:
                RaceText.text = "Elf";
                break;
            case 12:
            case 13:
            case 14:
            case 15:
                RaceText.text = "Dwarf";
                break;
            case 16:
            case 17:
            case 18:
            case 19:
                RaceText.text = "Goblin";
                break;
        }
    }
    public int GetRace(int cur_face_id)
    {

        if (cur_face_id <= 7)
            return 0;
        else if (cur_face_id <= 11)
            return 1;
        else if (cur_face_id <= 15)
            return 3;
        else if (cur_face_id <= 19)
            return 2;
        else
            return 0;
    }
}
