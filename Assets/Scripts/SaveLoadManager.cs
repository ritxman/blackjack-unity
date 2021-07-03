using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoadManager : MonoBehaviour {

	public string nickname = "";
	public int chips = 1000;
	public int numberOfGame = 0;
	public int totalWin = 0;
	public int totalLoss = 0;
	public int totalBlackJack = 0;
	
	//history transaksi shop
	public List<string> namaItem = new List<string>();
	public List<string> jumlahItem = new List<string>();
	public List<string> totalPrice = new List<string>();
	public List<string> dateBuy = new List<string>();
	public int counterBuyItem = 0;
	
	//game status
	public List<string> idGame = new List<string>();
	public List<string> startingChip = new List<string>();
	
	//deck 1
	public List<string> card1Deck1 = new List<string>();
	public List<string> card2Deck1 = new List<string>();
	public List<string> card3Deck1 = new List<string>();
	public List<string> card4Deck1 = new List<string>();
	public List<string> card5Deck1 = new List<string>();
	
	//deck 2
	public List<string> card1Deck2 = new List<string>();
	public List<string> card2Deck2 = new List<string>();
	public List<string> card3Deck2 = new List<string>();
	public List<string> card4Deck2 = new List<string>();
	public List<string> card5Deck2 = new List<string>();
	
	//deck 3
	public List<string> card1Deck3 = new List<string>();
	public List<string> card2Deck3 = new List<string>();
	public List<string> card3Deck3 = new List<string>();
	public List<string> card4Deck3 = new List<string>();
	public List<string> card5Deck3 = new List<string>();
	
	//deck dealer
	public List<string> card1DeckDealer = new List<string>();
	public List<string> card2DeckDealer = new List<string>();
	public List<string> card3DeckDealer = new List<string>();
	public List<string> card4DeckDealer = new List<string>();
	public List<string> card5DeckDealer = new List<string>();
	
	public List<string> cardValue1 = new List<string>();
	public List<string> cardValue2 = new List<string>();
	public List<string> cardValue3 = new List<string>();
	public List<string> cardValueDealer = new List<string>();
	
	public List<string> betValue1 = new List<string>();
	public List<string> betValue2 = new List<string>();
	public List<string> betValue3 = new List<string>();
	
	public List<string> status1 = new List<string>();
	public List<string> status2 = new List<string>();
	public List<string> status3 = new List<string>();
	public List<string> endChip = new List<string>();
	public List<string> changeTotal = new List<string>();
	
	
	public void clearData(){
		PlayerPrefs.DeleteAll();
	}
	public void saveData(){
		//try{
		PlayerPrefs.SetString("nickname",nickname);
		PlayerPrefs.SetInt("chips",chips);
		PlayerPrefs.SetInt("numberOfGame",numberOfGame);
		PlayerPrefs.SetInt("totalWin",totalWin);
		PlayerPrefs.SetInt("totalLoss",totalLoss);
		PlayerPrefs.SetInt("totalBlackJack",totalBlackJack);
		for(int i=0; i<counterBuyItem; i++){
			PlayerPrefs.SetString("namaItem"+i,(string)namaItem[i]);
			PlayerPrefs.SetString("jumlahItem"+i,(string)jumlahItem[i]);
			PlayerPrefs.SetString("totalPrice"+i,(string)totalPrice[i]);
			PlayerPrefs.SetString("dateBuy"+i,(string)dateBuy[i]);
		}
		PlayerPrefs.SetInt("counterBuyItem",counterBuyItem);
		for(int i=0; i<numberOfGame; i++){
			PlayerPrefs.SetString("idGame"+i,(string)idGame[i]);
			PlayerPrefs.SetString("startingChip"+i,(string)startingChip[i]);
			PlayerPrefs.SetString("card1Deck1"+i,(string)card1Deck1[i]);
			PlayerPrefs.SetString("card2Deck1"+i,(string)card2Deck1[i]);
			PlayerPrefs.SetString("card3Deck1"+i,(string)card3Deck1[i]);
			PlayerPrefs.SetString("card4Deck1"+i,(string)card4Deck1[i]);
			PlayerPrefs.SetString("card5Deck1"+i,(string)card5Deck1[i]);
			
			PlayerPrefs.SetString("card1Deck2"+i,(string)card1Deck2[i]);
			PlayerPrefs.SetString("card2Deck2"+i,(string)card2Deck2[i]);
			PlayerPrefs.SetString("card3Deck2"+i,(string)card3Deck2[i]);
			PlayerPrefs.SetString("card4Deck2"+i,(string)card4Deck2[i]);
			PlayerPrefs.SetString("card5Deck2"+i,(string)card5Deck2[i]);
			
			PlayerPrefs.SetString("card1Deck3"+i,(string)card1Deck3[i]);
			PlayerPrefs.SetString("card2Deck3"+i,(string)card2Deck3[i]);
			PlayerPrefs.SetString("card3Deck3"+i,(string)card3Deck3[i]);
			PlayerPrefs.SetString("card4Deck3"+i,(string)card4Deck3[i]);
			PlayerPrefs.SetString("card5Deck3"+i,(string)card5Deck3[i]);
			
			PlayerPrefs.SetString("card1DeckDealer"+i,(string)card1DeckDealer[i]);
			PlayerPrefs.SetString("card2DeckDealer"+i,(string)card2DeckDealer[i]);
			PlayerPrefs.SetString("card3DeckDealer"+i,(string)card3DeckDealer[i]);
			PlayerPrefs.SetString("card4DeckDealer"+i,(string)card4DeckDealer[i]);
			PlayerPrefs.SetString("card5DeckDealer"+i,(string)card5DeckDealer[i]);
	
			PlayerPrefs.SetString("cardValue1"+i,(string)cardValue1[i]);
			PlayerPrefs.SetString("cardValue2"+i,(string)cardValue2[i]);
			PlayerPrefs.SetString("cardValue3"+i,(string)cardValue3[i]);
			PlayerPrefs.SetString("cardValueDealer"+i,(string)cardValueDealer[i]);
			
			PlayerPrefs.SetString("betValue1"+i,(string)betValue1[i]);
			PlayerPrefs.SetString("betValue2"+i,(string)betValue2[i]);
			PlayerPrefs.SetString("betValue3"+i,(string)betValue3[i]);
			
			PlayerPrefs.SetString("status1"+i,(string)status1[i]);
			PlayerPrefs.SetString("status2"+i,(string)status2[i]);
			PlayerPrefs.SetString("status3"+i,(string)status3[i]);
			PlayerPrefs.SetString("endChip"+i,(string)endChip[i]);
			PlayerPrefs.SetString("changeTotal"+i,(string)changeTotal[i]);
		}
		//}catch{
			
		//}
		PlayerPrefs.Save();
	}
	public void loadData(){
		//validasi apakah sudah ada playerprefs yang bernama nickname
		if(!PlayerPrefs.HasKey("nickname")){
			saveData();
		}else{
			nickname = PlayerPrefs.GetString("nickname");
			chips = PlayerPrefs.GetInt("chips");
			numberOfGame = PlayerPrefs.GetInt("numberOfGame");
			totalWin = PlayerPrefs.GetInt("totalWin");
			totalLoss = PlayerPrefs.GetInt("totalLoss");
			totalBlackJack = PlayerPrefs.GetInt("totalBlackJack");
			counterBuyItem = PlayerPrefs.GetInt("counterBuyItem");
			namaItem.Clear();
			jumlahItem.Clear();
			totalPrice.Clear();
			dateBuy.Clear();
			for(int i=0; i<counterBuyItem; i++){
				namaItem.Add(""+PlayerPrefs.GetString("namaItem"+i));
				jumlahItem.Add(""+PlayerPrefs.GetString("jumlahItem"+i));
				totalPrice.Add(""+PlayerPrefs.GetString("totalPrice"+i));
				dateBuy.Add(""+PlayerPrefs.GetString("dateBuy"+i));
			}
			idGame.Clear();
			startingChip.Clear();
			card1Deck1.Clear();
			card2Deck1.Clear();
			card3Deck1.Clear();
			card4Deck1.Clear();
			card5Deck1.Clear();
			
			card1Deck2.Clear();
			card2Deck2.Clear();
			card3Deck2.Clear();
			card4Deck2.Clear();
			card5Deck2.Clear();
			
			card1Deck3.Clear();
			card2Deck3.Clear();
			card3Deck3.Clear();
			card4Deck3.Clear();
			card5Deck3.Clear();
			
			card1DeckDealer.Clear();
			card2DeckDealer.Clear();
			card3DeckDealer.Clear();
			card4DeckDealer.Clear();
			card5DeckDealer.Clear();
			
			cardValue1.Clear();
			cardValue2.Clear();
			cardValue3.Clear();
			cardValueDealer.Clear();
			
			betValue1.Clear();
			betValue2.Clear();
			betValue3.Clear();
			status1.Clear();
			status2.Clear();
			status3.Clear();
			endChip.Clear();
			changeTotal.Clear();
			for(int i=0; i<numberOfGame; i++){
				idGame.Add(""+PlayerPrefs.GetString("idGame"+i));
				startingChip.Add(""+PlayerPrefs.GetString("startingChip"+i));
				card1Deck1.Add(""+PlayerPrefs.GetString("card1Deck1"+i));
				card2Deck1.Add(""+PlayerPrefs.GetString("card2Deck1"+i));
				card3Deck1.Add(""+PlayerPrefs.GetString("card3Deck1"+i));
				card4Deck1.Add(""+PlayerPrefs.GetString("card4Deck1"+i));
				card5Deck1.Add(""+PlayerPrefs.GetString("card5Deck1"+i));
				
				card1Deck2.Add(""+PlayerPrefs.GetString("card1Deck2"+i));
				card2Deck2.Add(""+PlayerPrefs.GetString("card2Deck2"+i));
				card3Deck2.Add(""+PlayerPrefs.GetString("card3Deck2"+i));
				card4Deck2.Add(""+PlayerPrefs.GetString("card4Deck2"+i));
				card5Deck2.Add(""+PlayerPrefs.GetString("card5Deck2"+i));
				
				card1DeckDealer.Add(""+PlayerPrefs.GetString("card1DeckDealer"+i));
				card2DeckDealer.Add(""+PlayerPrefs.GetString("card2DeckDealer"+i));
				card3DeckDealer.Add(""+PlayerPrefs.GetString("card3DeckDealer"+i));
				card4DeckDealer.Add(""+PlayerPrefs.GetString("card4DeckDealer"+i));
				card5DeckDealer.Add(""+PlayerPrefs.GetString("card5DeckDealer"+i));
				
				card1Deck3.Add(""+PlayerPrefs.GetString("card1Deck3"+i));
				card2Deck3.Add(""+PlayerPrefs.GetString("card2Deck3"+i));
				card3Deck3.Add(""+PlayerPrefs.GetString("card3Deck3"+i));
				card4Deck3.Add(""+PlayerPrefs.GetString("card4Deck3"+i));
				card5Deck3.Add(""+PlayerPrefs.GetString("card5Deck3"+i));
				
				cardValue1.Add(""+PlayerPrefs.GetString("cardValue1"+i));
				cardValue2.Add(""+PlayerPrefs.GetString("cardValue2"+i));
				cardValue3.Add(""+PlayerPrefs.GetString("cardValue3"+i));
				cardValueDealer.Add(""+PlayerPrefs.GetString("cardValueDealer"+i));
				
				betValue1.Add(""+PlayerPrefs.GetString("betValue1"+i));
				betValue2.Add(""+PlayerPrefs.GetString("betValue2"+i));
				betValue3.Add(""+PlayerPrefs.GetString("betValue3"+i));
				
				status1.Add(""+PlayerPrefs.GetString("status1"+i));
				status2.Add(""+PlayerPrefs.GetString("status2"+i));
				status3.Add(""+PlayerPrefs.GetString("status3"+i));
				endChip.Add(""+PlayerPrefs.GetString("endChip"+i));
				changeTotal.Add(""+PlayerPrefs.GetString("changeTotal"+i));
			}
		}
	}
	// Use this for initialization
	void Start () {
		for(int i=0; i<counterBuyItem; i++){
			namaItem.Add("");
			jumlahItem.Add("");
			totalPrice.Add("");
			dateBuy.Add("");
		}
		for(int i=0; i<numberOfGame; i++){
			idGame.Add("");
			startingChip.Add("");
			card1Deck1.Add("");
			card2Deck1.Add("");
			card3Deck1.Add("");
			card4Deck1.Add("");
			card5Deck1.Add("");
			
			card1Deck2.Add("");
			card2Deck2.Add("");
			card3Deck2.Add("");
			card4Deck2.Add("");
			card5Deck2.Add("");
			
			card1Deck3.Add("");
			card2Deck3.Add("");
			card3Deck3.Add("");
			card4Deck3.Add("");
			card5Deck3.Add("");
			
			cardValue1.Add("");
			cardValue2.Add("");
			cardValue3.Add("");
			cardValueDealer.Add("");
			
			betValue1.Add("");
			betValue2.Add("");
			betValue3.Add("");
			
			status1.Add("");
			status2.Add("");
			status3.Add("");
			endChip.Add("");
			changeTotal.Add("");
		}
		//clearData();
	}
}
