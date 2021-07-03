using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public int phase;
	public GameObject [] deck1 = new GameObject[6];
	public GameObject [] deck2 = new GameObject[6];
	public GameObject [] deck3 = new GameObject[6];
	public GameObject [] deckDealer = new GameObject[6];
	public GameObject pointer;
	public GameObject backgroundSpot1;
	public GameObject backgroundSpot2;
	public GameObject backgroundSpot3;
	public GameObject backgroundSpotDealer;
	public GameObject buttonDouble;
	public GameObject afterResult;
	private bool [] cardTakenSuits = new bool[5];
	private bool [] cardTakenValue = new bool[14];
	public GameObject phase1GameObject;
	public GameObject phase2GameObject;
	public GameObject deck3TurnText;
	public GameObject deck2TurnText;
	public GameObject deck1TurnText;
	public InputField inputField1;
	public InputField inputField2;
	public InputField inputField3;
	public Text textNotif;
	private int counterDeck1;
	private int counterDeck2;
	private int counterDeck3;
	private int counterDeckDealer;
	private int scoreDeck1;
	private int scoreDeck2;
	private int scoreDeck3;
	private int scoreDeckDealer;
	private bool flagAceDeck1;
	private bool flagAceDeck2;
	private bool flagAceDeck3;
	private bool flagAceDeckDealer;
	private bool hangDeck1;
	private Color colorWin;
	private Color colorLose;
	public GameObject confirmExit;
	public GameObject textLostBet;
	public Text textCounter1;
	public Text textCounter2;
	public Text textCounter3;
	public Text textCounterDealer;
	public Text textBet1;
	public Text textBet2;
	public Text textBet3;
	public Text textStatusDeck1;
	public Text textStatusDeck2;
	public Text textStatusDeck3;
	public Text textStatusDeckDealer;
	public Text textResultDeck1;
	public Text textResultDeck2;
	public Text textResultDeck3;
	public Text textResultDeckDealer;
	public Text textTotalChips;
	public Text textNickName;
	public Text textChipsChange;
	
	public int indexGameStatus;
	public SaveLoadManager slm;
	private int bet1;
	private int bet2;
	private int bet3;
	private int keputusanDealer;
	//untuk mengatur turn
	private int deckGiliran;
	//validasi input bet
	private bool inputValid;
	//random kartu berdasarkan value (A,2,3,4,5,6,7,8,9,10,J,Q,K) dan suits (spades, hearts, clubs, diamond)
	private int value;
	private int suits;
	private int valueKhusus1;
	private int suitsKhusus1;
	private string valueString;
	private string suitsString;
	
	//untuk keperluan validasi
	private bool isDoubleDeck3;
	private bool isDoubleDeck2;
	private bool isDoubleDeck1;
	private bool isBlackJack1;
	private bool isBlackJack2;
	private bool isBlackJack3;
	private bool isBlackJackDealer;
	private bool isStopDealer;
	private int totalWinSpot3;
	private int totalWinSpot2;
	private int totalWinSpot1;
	
	//scene enter name
	public InputField inputNickName;
	public Text notifText;
	private string nickNameInput;
	private bool space;
	public GameObject panelEnterName;
	
	//scene mainMenu
	public GameObject shopPanel;
	public GameObject menuPanel;
	public GameObject statisticPanel;
	//shop
	private int qty1;
	private int qty2;
	private int qty3;
	private int totalItemBuy;
	public Text textQty1;
	public Text textQty2;
	public Text textQty3;
	public GameObject buttonBuy1;
	public GameObject buttonBuy2;
	public GameObject buttonBuy3;
	public Slider sliderQty1;
	public Slider sliderQty2;
	public Slider sliderQty3;
	public GameObject confirmBuy;
	public Text totalPriceText;
	public Text buyItemText;
	public GameObject successBuy;
	public string itemName;
	public int jumlahQty;
	public int totalHarga;
	
	//statistic
	public GameObject gameStatus;
	public GameObject shopHistory;
	public GameObject mainMenuStatistic;
	
	//shop history
	public Text [] textNamaItem = new Text[6];
	public Text [] textQty = new Text[6];
	public Text [] textTotalPrice = new Text[6];
	public Text [] textDate = new Text[6];
	private int halaman;
	
	//game status
	public Text textJumlahGamePlayed;
	public Text textJumlahWin;
	public Text textJumlahLose;
	public Text textJumlahBlackJack;
	
	public GameObject textLoadingData;
	//history game
	public Text setGameText;
	public Text startingChipText;
	public Text bet1Text;
	public Text bet2Text;
	public Text bet3Text;
	public Text value1Text;
	public Text value2Text;
	public Text value3Text;
	public Text valueDealerText;
	public Text status1Text;
	public Text status2Text;
	public Text status3Text;
	public Text chipChangeText;
	public Text chipBalanceText;
	public Image card1Deck1;
	public Image card2Deck1;
	public Image card3Deck1;
	public Image card4Deck1;
	public Image card5Deck1;
	
	public Image card1Deck2;
	public Image card2Deck2;
	public Image card3Deck2;
	public Image card4Deck2;
	public Image card5Deck2;
	
	public Image card1Deck3;
	public Image card2Deck3;
	public Image card3Deck3;
	public Image card4Deck3;
	public Image card5Deck3;
	
	public Image card1DeckDealer;
	public Image card2DeckDealer;
	public Image card3DeckDealer;
	public Image card4DeckDealer;
	public Image card5DeckDealer;
	
	private GameObject tempCard;
	private Color colorPlus;
	
	// Use this for initialization
	void Start () {
		Camera.main.aspect = 1980f / 1080f;
		inputValid = true;
		//warna merah
		colorLose.r = 255;
		colorLose.g = 0;
		colorLose.b = 0;
		colorLose.a = 1;
		
		//warna hitam
		colorWin.r = 0;
		colorWin.g = 0;
		colorWin.b = 0;
		colorWin.a = 1;
		
		//warna hijau
		colorPlus.r = 0;
		colorPlus.g = 255;
		colorPlus.b = 0;
		colorPlus.a = 1;
		//slm.clearData();
		
		if(Application.loadedLevelName == "EnterName"){
			textLoadingData.SetActive(false);
			notifText.text = "";
			slm.loadData();
			if(slm.nickname != ""){
				textLoadingData.SetActive(true);
				panelEnterName.SetActive(false);
				Invoke("nextSceneMainMenu",2f);
			}
		}else if(Application.loadedLevelName == "mainMenu"){
			slm.loadData();
		}else if(Application.loadedLevelName == "BlackJack"){
			slm.loadData();
			phase1();
		}
		
		
	}
	public void resetData(){
		slm.clearData();
		Application.LoadLevel("EnterName");
	}
	//untuk membeli chip
	public void checkButtonBuy(){
		if(qty1 == 0){
			buttonBuy1.SetActive(false);
		}else{
			buttonBuy1.SetActive(true);
		}
		if(qty2 == 0){
			buttonBuy2.SetActive(false);
		}else{
			buttonBuy2.SetActive(true);
		}
		if(qty3 == 0){
			buttonBuy3.SetActive(false);
		}else{
			buttonBuy3.SetActive(true);
		}
	}
	//slider input qty
	public void changeQty1(){
		qty1 = (int)sliderQty1.value;
		checkButtonBuy();
		textQty1.text = ""+qty1;
	}
	public void changeQty2(){
		qty2 = (int)sliderQty2.value;
		checkButtonBuy();
		textQty2.text = ""+qty2;
	}
	public void changeQty3(){
		qty3 = (int)sliderQty3.value;
		checkButtonBuy();
		textQty3.text = ""+qty3;
	}
	
	//bermain game
	public void PlayGame(){
		Application.LoadLevel("BlackJack");
	}
	public void shop(){
		textQty1.text = ""+qty1;
		textQty2.text = ""+qty2;
		textQty3.text = ""+qty3;
		checkButtonBuy();
		menuPanel.SetActive(false);
		shopPanel.SetActive(true);
	}
	//membeli item 1
	public void buyItem1(){
		totalItemBuy = 0;
		confirmBuy.SetActive(true);
		itemName = "1000 chip";
		jumlahQty = (int)sliderQty1.value;
		totalHarga = ((int)sliderQty1.value * 1);
		buyItemText.text = "Buy "+(1000 * jumlahQty)+" chip?";
		totalPriceText.text = "Total Price: "+totalHarga+"$";
		totalItemBuy = 1000 * jumlahQty;
	}
	
	//membeli item 2
	public void buyItem2(){
		totalItemBuy = 0;
		confirmBuy.SetActive(true);
		itemName = "5000 chip";
		jumlahQty = (int)sliderQty2.value;
		totalHarga = ((int)sliderQty2.value * 4);
		buyItemText.text = "Buy "+(5000 * jumlahQty)+" chip?";
		totalPriceText.text = "Total Price: "+totalHarga+"$";
		totalItemBuy = 5000 * jumlahQty;
	}
	
	//membeli item 3
	public void buyItem3(){
		totalItemBuy = 0;
		confirmBuy.SetActive(true);
		itemName = "10000 chip";
		jumlahQty = (int)sliderQty3.value;
		totalHarga = ((int)sliderQty3.value * 7);
		buyItemText.text = "Buy "+(10000 * jumlahQty)+" chip?";
		totalPriceText.text = "Total Price: "+totalHarga+"$";
		totalItemBuy = 10000 * jumlahQty;
	}
	public void cancelBuy(){
		confirmBuy.SetActive(false);
		successBuy.SetActive(false);
	}
	public void yesBuy(){
		confirmBuy.SetActive(false);
		slm.namaItem.Add(""+itemName);
		slm.jumlahItem.Add(""+jumlahQty);
		slm.totalPrice.Add(""+totalHarga);
		slm.dateBuy.Add(""+System.DateTime.Now);
		slm.counterBuyItem++;
		slm.chips = slm.chips + totalItemBuy;
		slm.saveData();
		successBuy.SetActive(true);
	}
	public void showShopHistory(){
		slm.loadData();
		halaman = 0;
		mainMenuStatistic.SetActive(false);
		shopHistory.SetActive(true);
		addTextShopHistory(halaman);
	}
	//menambah log shop history
	public void addTextShopHistory(int indexAwal){
		for(int i=0; i<4; i++){
			if(indexAwal + i < slm.counterBuyItem){
				textNamaItem[i].text = ""+slm.namaItem[indexAwal+i];
				textQty[i].text = ""+slm.jumlahItem[indexAwal+i];
				textTotalPrice[i].text = ""+slm.totalPrice[indexAwal+i];
				textDate[i].text = ""+slm.dateBuy[indexAwal+i];
			}else{
				textNamaItem[i].text = "";
				textQty[i].text = "";
				textTotalPrice[i].text = "";
				textDate[i].text = "";
			}
		}
	}
	//kehalaman kiri
	public void leftShopHistory(){
		if(halaman-4 >= 0){
			halaman = halaman - 4;
			addTextShopHistory(halaman);
		}
	}
	//kehalaman kanan
	public void rightShopHistory(){
		if(halaman+4 < slm.counterBuyItem){
			halaman = halaman + 4;
			addTextShopHistory(halaman);
		}
	}
	public void leftIndex(){
		if(indexGameStatus+1 < slm.numberOfGame){
			indexGameStatus++;
			showGameStatusIndex(indexGameStatus);
		}
	}
	public void rightIndex(){
		if(indexGameStatus-1 >= 0){
			indexGameStatus--;
			showGameStatusIndex(indexGameStatus);
		}
	}
	public void showGameStatusIndex(int index){
		setGameText.text = "Game: "+slm.idGame[index];
		startingChipText.text = "Starting chip: "+slm.startingChip[index];
		bet1Text.text = "Bet: "+slm.betValue1[index];
		bet2Text.text = "Bet: "+slm.betValue2[index];
		bet3Text.text = "Bet: "+slm.betValue3[index];
		value1Text.text = ""+slm.cardValue1[index];
		value2Text.text = ""+slm.cardValue2[index];
		value3Text.text = ""+slm.cardValue3[index];
		valueDealerText.text = ""+slm.cardValueDealer[index];
		status1Text.text = ""+slm.status1[index];
		status2Text.text = ""+slm.status2[index];
		status3Text.text = ""+slm.status3[index];
		if(slm.changeTotal[index][0] == '+'){
			if(slm.changeTotal[index][1] == '0'){
				chipChangeText.GetComponent<Text>().color = colorWin;
			}else{
				chipChangeText.GetComponent<Text>().color = colorPlus;
			}
		}else{
			chipChangeText.GetComponent<Text>().color = colorLose;
		}
		chipChangeText.text = "Chip Change:\n"+slm.changeTotal[index];
		chipBalanceText.text = "Chip Balance:\n"+slm.endChip[index];
		
		if(slm.card1Deck1[index] != ""){
			card1Deck1.gameObject.SetActive(true);
			card1Deck1.sprite = GameObject.Find(""+slm.card1Deck1[index]).GetComponent<Image>().sprite;
		}else card1Deck1.gameObject.SetActive(false);
		if(slm.card2Deck1[index] != ""){
			card2Deck1.gameObject.SetActive(true);
			card2Deck1.sprite = GameObject.Find(""+slm.card2Deck1[index]).GetComponent<Image>().sprite;
		}else card2Deck1.gameObject.SetActive(false);
		if(slm.card3Deck1[index] != ""){
			card3Deck1.gameObject.SetActive(true);
			card3Deck1.sprite = GameObject.Find(""+slm.card3Deck1[index]).GetComponent<Image>().sprite;
		}else card3Deck1.gameObject.SetActive(false);
		if(slm.card4Deck1[index] != ""){
			card4Deck1.gameObject.SetActive(true);
			card4Deck1.sprite = GameObject.Find(""+slm.card4Deck1[index]).GetComponent<Image>().sprite;
		}else card4Deck1.gameObject.SetActive(false);
		if(slm.card5Deck1[index] != ""){
			card5Deck1.gameObject.SetActive(true);
			card5Deck1.sprite = GameObject.Find(""+slm.card5Deck1[index]).GetComponent<Image>().sprite;
		}else card5Deck1.gameObject.SetActive(false);
			
		if(slm.card1Deck2[index] != ""){
			card1Deck2.gameObject.SetActive(true);
			card1Deck2.sprite = GameObject.Find(""+slm.card1Deck2[index]).GetComponent<Image>().sprite;
		}else card1Deck2.gameObject.SetActive(false);
		if(slm.card2Deck2[index] != ""){
			card2Deck2.gameObject.SetActive(true);
			card2Deck2.sprite = GameObject.Find(""+slm.card2Deck2[index]).GetComponent<Image>().sprite;
		}else card2Deck2.gameObject.SetActive(false);
		if(slm.card3Deck2[index] != ""){
			card3Deck2.gameObject.SetActive(true);
			card3Deck2.sprite = GameObject.Find(""+slm.card3Deck2[index]).GetComponent<Image>().sprite;
		}else card3Deck2.gameObject.SetActive(false);
		if(slm.card4Deck2[index] != ""){
			card4Deck2.gameObject.SetActive(true);
			card4Deck2.sprite = GameObject.Find(""+slm.card4Deck2[index]).GetComponent<Image>().sprite;
		}else card4Deck2.gameObject.SetActive(false);
		if(slm.card5Deck2[index] != ""){
			card5Deck2.gameObject.SetActive(true);
			card5Deck2.sprite = GameObject.Find(""+slm.card5Deck2[index]).GetComponent<Image>().sprite;
		}else card5Deck2.gameObject.SetActive(false);
		
		if(slm.card1Deck3[index] != ""){
			card1Deck3.gameObject.SetActive(true);
			card1Deck3.sprite = GameObject.Find(""+slm.card1Deck3[index]).GetComponent<Image>().sprite;
		}else card1Deck3.gameObject.SetActive(false);
		if(slm.card2Deck3[index] != ""){
			card2Deck3.gameObject.SetActive(true);
			card2Deck3.sprite = GameObject.Find(""+slm.card2Deck3[index]).GetComponent<Image>().sprite;
		}else card2Deck3.gameObject.SetActive(false);
		if(slm.card3Deck3[index] != ""){
			card3Deck3.gameObject.SetActive(true);
			card3Deck3.sprite = GameObject.Find(""+slm.card3Deck3[index]).GetComponent<Image>().sprite;
		}else card3Deck3.gameObject.SetActive(false);
		if(slm.card4Deck3[index] != ""){
			card4Deck3.gameObject.SetActive(true);
			card4Deck3.sprite = GameObject.Find(""+slm.card4Deck3[index]).GetComponent<Image>().sprite;
		}else card4Deck3.gameObject.SetActive(false);
		if(slm.card5Deck3[index] != ""){
			card5Deck3.gameObject.SetActive(true);
			card5Deck3.sprite = GameObject.Find(""+slm.card5Deck3[index]).GetComponent<Image>().sprite;
		}else card5Deck3.gameObject.SetActive(false);
		
		if(slm.card1DeckDealer[index] != ""){
			card1DeckDealer.gameObject.SetActive(true);
			card1DeckDealer.sprite = GameObject.Find(""+slm.card1DeckDealer[index]).GetComponent<Image>().sprite;
		}else card1DeckDealer.gameObject.SetActive(false);
		if(slm.card2DeckDealer[index] != ""){
			card2DeckDealer.gameObject.SetActive(true);
			card2DeckDealer.sprite = GameObject.Find(""+slm.card2DeckDealer[index]).GetComponent<Image>().sprite;
		}else card2DeckDealer.gameObject.SetActive(false);
		if(slm.card3DeckDealer[index] != ""){
			card3DeckDealer.gameObject.SetActive(true);
			card3DeckDealer.sprite = GameObject.Find(""+slm.card3DeckDealer[index]).GetComponent<Image>().sprite;
		}else card3DeckDealer.gameObject.SetActive(false);
		if(slm.card4DeckDealer[index] != ""){
			card4DeckDealer.gameObject.SetActive(true);
			card4DeckDealer.sprite = GameObject.Find(""+slm.card4DeckDealer[index]).GetComponent<Image>().sprite;
		}else card4DeckDealer.gameObject.SetActive(false);
		if(slm.card5DeckDealer[index] != ""){
			card5DeckDealer.gameObject.SetActive(true);
			card5DeckDealer.sprite = GameObject.Find(""+slm.card5DeckDealer[index]).GetComponent<Image>().sprite;
		}else card5DeckDealer.gameObject.SetActive(false);
	}
	public void showGameStatus(){
		indexGameStatus = slm.numberOfGame-1;
		mainMenuStatistic.SetActive(false);
		gameStatus.SetActive(true);
		setGameText.text = "";
		startingChipText.text = "";
		bet1Text.text = "";
		bet2Text.text = "";
		bet3Text.text = "";
		value1Text.text = "";
		value2Text.text = "";
		value3Text.text = "";
		valueDealerText.text = "";
		status1Text.text = "";
		status2Text.text = "";
		status3Text.text = "";
		chipChangeText.text = "";
		chipBalanceText.text = "";
		card1Deck1.sprite = null;
		card2Deck1.sprite = null;
		card3Deck1.sprite = null;
		card4Deck1.sprite = null;
		card5Deck1.sprite = null;
		
		card1Deck2.sprite = null;
		card2Deck2.sprite = null;
		card3Deck2.sprite = null;
		card4Deck2.sprite = null;
		card5Deck2.sprite = null;
		
		card1Deck3.sprite = null;
		card2Deck3.sprite = null;
		card3Deck3.sprite = null;
		card4Deck3.sprite = null;
		card5Deck3.sprite = null;
		
		card1DeckDealer.sprite = null;
		card2DeckDealer.sprite = null;
		card3DeckDealer.sprite = null;
		card4DeckDealer.sprite = null;
		card5DeckDealer.sprite = null;
		if(indexGameStatus>=0)showGameStatusIndex(indexGameStatus);
	}
	public void statisticMenu(){
		menuPanel.SetActive(false);
		textJumlahGamePlayed.text = "Total Plays:\n"+slm.numberOfGame;
		textJumlahWin.text = "Win:\n"+slm.totalWin;
		textJumlahLose.text = "Lose:\n"+slm.totalLoss;
		textJumlahBlackJack.text = "BlackJack:\n"+slm.totalBlackJack;
		statisticPanel.SetActive(true);
		mainMenuStatistic.SetActive(true);
	}
	public void backToMenu(){
		statisticPanel.SetActive(false);
		shopPanel.SetActive(false);
		menuPanel.SetActive(true);
		shopHistory.SetActive(false);
		gameStatus.SetActive(false);
	}
	public void nextSceneMainMenu(){
		Application.LoadLevel("mainMenu");
	}
	public void okEnterName(){
		space = true;
		nickNameInput = ""+inputNickName.text;
		if(inputNickName.text == ""){
			notifText.text = "Please enter your name first";
		}else if(nickNameInput.Length > 20 || nickNameInput.Length < 5){
			notifText.text = "name length must between 5 - 20 characters";
		}else{
			for(int i=0; i<nickNameInput.Length; i++){
				if(nickNameInput[i] != ' '){
					space = false;
					break;
				}
			}
			if(space == true){
				notifText.text = "Please enter your name";
			}else{
				slm.nickname = ""+nickNameInput;
				slm.saveData();
				Application.LoadLevel("mainMenu");
			}
		}
	}
	//untuk menambah kartu
	public void addCard(int deck, int kartu){
		//pencegahan hang
		if(deck != 1){
			//melakukan random kartu, akan random ulang jika kartu yang dipilih nilainya sama dengan yang sudah dikeluarkan
			do{
				suits = Random.Range(1,5);
				value = Random.Range(1,14);
			}while(cardTakenSuits[suits] == true && cardTakenValue[value] == true);
		}else{
			do{
				suitsKhusus1 = Random.Range(1,5);
				valueKhusus1 = Random.Range(1,14);
			}while(cardTakenSuits[suitsKhusus1] == true && cardTakenValue[valueKhusus1] == true);
			suits = suitsKhusus1;
			value = valueKhusus1;
		}
		//set array yang diambil menjadi true, 
		//true berfungsi untuk menandakan bahwa kartu yang sudah diambil tidak dapat direspawn lagi
		cardTakenSuits[suits] = true;
		cardTakenValue[value] = true;
		if(suits == 1){
			suitsString = "Spades";
		}else if(suits == 2){
			suitsString = "Hearts";
		}else if(suits == 3){
			suitsString = "Clubs";
		}else if(suits == 4){
			suitsString = "Diamonds";
		}
		if(value == 1){
			valueString = "As";
		}else if(value == 11){
			valueString = "Jack";
		}else if(value == 12){
			valueString = "Queen";
		}else if(value == 13){
			valueString = "King";
		}else{
			valueString = ""+value;
		}
		//check score deck 1 / kiri
		if(deck == 1){
			deck1[counterDeck1].SetActive(true);
			counterDeck1++;
			if(counterDeck1 == 1){
				slm.card1Deck1.Add(valueString+""+suitsString);
			}
			if(counterDeck1 == 2){
				slm.card2Deck1.Add(valueString+""+suitsString);
			}
			if(counterDeck1 == 3){
				slm.card3Deck1.Add(valueString+""+suitsString);
			}
			if(counterDeck1 == 4){
				slm.card4Deck1.Add(valueString+""+suitsString);
			}
			if(counterDeck1 == 5){
				slm.card5Deck1.Add(valueString+""+suitsString);
			}
			if(value == 1){
				flagAceDeck1 = true;
				scoreDeck1 = scoreDeck1 + 1;
			}else if(value > 10){
				scoreDeck1 = scoreDeck1 + 10;
			}else{
				scoreDeck1 = scoreDeck1 + value;
			}
			if(flagAceDeck1 == true){
				if(scoreDeck1+10 < 22){
					textCounter1.text = scoreDeck1+" / "+(scoreDeck1+10);
				}else{
					textCounter1.text = scoreDeck1+"";
				}
			}else{
				textCounter1.text = scoreDeck1+"";
			}
			if(scoreDeck1 > 21){
				textStatusDeck1.text = "BUSTED";
				if(counterDeck1 == 3){
					slm.card4Deck1.Add("");
					slm.card5Deck1.Add("");
				}else if(counterDeck1 == 4){
					slm.card5Deck1.Add("");
				}
				try{
					phase3();
				}catch{}
			}else{
				if(counterDeck1 == 5){
					textStatusDeck1.text = "5 DRAGONS";
					try{
						phase3();
					}catch{}
				}
			}
			
		}
		//check score deck 2 / tengah
		else if(deck == 2){
			deck2[counterDeck2].SetActive(true);
			counterDeck2++;
			if(counterDeck2 == 1){
				slm.card1Deck2.Add(valueString+""+suitsString);
			}
			if(counterDeck2 == 2){
				slm.card2Deck2.Add(valueString+""+suitsString);
			}
			if(counterDeck2 == 3){
				slm.card3Deck2.Add(valueString+""+suitsString);
			}
			if(counterDeck2 == 4){
				slm.card4Deck2.Add(valueString+""+suitsString);
			}
			if(counterDeck2 == 5){
				slm.card5Deck2.Add(valueString+""+suitsString);
			}
			if(value == 1){
				flagAceDeck2 = true;
				scoreDeck2 = scoreDeck2 + 1;
			}else if(value > 10){
				scoreDeck2 = scoreDeck2 + 10;
			}else{
				scoreDeck2 = scoreDeck2 + value;
			}
			if(flagAceDeck2 == true){
				if(scoreDeck2+10 < 22){
					textCounter2.text = scoreDeck2+" / "+(scoreDeck2+10);
				}else{
					textCounter2.text = scoreDeck2+"";
				}
			}else{
				textCounter2.text = scoreDeck2+"";
			}
			if(scoreDeck2 > 21){
				textStatusDeck2.text = "BUSTED";
				if(counterDeck2 == 3){
					slm.card4Deck2.Add("");
					slm.card5Deck2.Add("");
				}else if(counterDeck2 == 4){
					slm.card5Deck2.Add("");
				}
				deck1Turn();
			}else{
				if(counterDeck2 == 5){
					textStatusDeck2.text = "5 DRAGONS";
					deck1Turn();
				}
			}
		}
		//check score deck 3 / kanan
		else if(deck == 3){
			deck3[counterDeck3].SetActive(true);
			counterDeck3++;
			if(counterDeck3 == 1){
				slm.card1Deck3.Add(valueString+""+suitsString);
			}
			if(counterDeck3 == 2){
				slm.card2Deck3.Add(valueString+""+suitsString);
			}
			if(counterDeck3 == 3){
				slm.card3Deck3.Add(valueString+""+suitsString);
			}
			if(counterDeck3 == 4){
				slm.card4Deck3.Add(valueString+""+suitsString);
			}
			if(counterDeck3 == 5){
				slm.card5Deck3.Add(valueString+""+suitsString);
			}
			if(value == 1){
				flagAceDeck3 = true;
				scoreDeck3 = scoreDeck3 + 1;
			}else if(value > 10){
				scoreDeck3 = scoreDeck3 + 10;
			}else{
				scoreDeck3 = scoreDeck3 + value;
			}
			if(flagAceDeck3 == true){
				if(scoreDeck3+10 < 22){
					textCounter3.text = scoreDeck3+" / "+(scoreDeck3+10);
				}else{
					textCounter3.text = scoreDeck3+"";
				}
			}else{
				textCounter3.text = scoreDeck3+"";
			}
			if(scoreDeck3 > 21){
				textStatusDeck3.text = "BUSTED";
				if(counterDeck3 == 3){
					slm.card4Deck3.Add("");
					slm.card5Deck3.Add("");
				}else if(counterDeck3 == 4){
					slm.card5Deck3.Add("");
				}
				deck2Turn();
			}else{
				if(counterDeck3 == 5){
					textStatusDeck3.text = "5 DRAGONS";
					deck2Turn();
				}
			}
		}
		//hitung nilai dealer
		else{
			deckDealer[counterDeckDealer].SetActive(true);
			counterDeckDealer++;
			if(counterDeckDealer == 1){
				slm.card1DeckDealer.Add(valueString+""+suitsString);
			}
			if(counterDeckDealer == 2){
				slm.card2DeckDealer.Add(valueString+""+suitsString);
			}
			if(counterDeckDealer == 3){
				slm.card3DeckDealer.Add(valueString+""+suitsString);
			}
			if(counterDeckDealer == 4){
				slm.card4DeckDealer.Add(valueString+""+suitsString);
			}
			if(counterDeckDealer == 5){
				slm.card5DeckDealer.Add(valueString+""+suitsString);
			}
			if(value == 1){
				flagAceDeckDealer = true;
				scoreDeckDealer = scoreDeckDealer + 1;
			}else if(value > 10){
				scoreDeckDealer = scoreDeckDealer + 10;
			}else{
				scoreDeckDealer = scoreDeckDealer + value;
			}
			if(flagAceDeckDealer == true){
				if(scoreDeckDealer+10 < 22){
					textCounterDealer.text = scoreDeckDealer+" / "+(scoreDeckDealer+10);
				}else{
					textCounterDealer.text = scoreDeckDealer+"";
				}
			}else{
				textCounterDealer.text = scoreDeckDealer+"";
			}
			if(scoreDeckDealer > 21){
				textStatusDeckDealer.text = "BUSTED";
				isStopDealer = true;
			}else{
				if(counterDeckDealer == 5){
					textStatusDeckDealer.text = "5 DRAGONS";
					isStopDealer = true;
				}
			}
		}
		
		//mengeluarkan gambar kartu sesuai dengan angka random
		if(deck != 4)
			GameObject.Find("Card"+kartu+"Deck"+deck).GetComponent<Image>().sprite = GameObject.Find(valueString+""+suitsString).GetComponent<Image>().sprite;
		else
			GameObject.Find("Card"+kartu+"Dealer").GetComponent<Image>().sprite = GameObject.Find(valueString+""+suitsString).GetComponent<Image>().sprite;
		
	}
	//untuk melakukan hit
	public void hitCard(){
		buttonDouble.SetActive(false);
		if(deckGiliran == 3){
			isBlackJack3 = false;
			addCard(deckGiliran,counterDeck3+1);
		}else if(deckGiliran == 2){
			isBlackJack2 = false;
			addCard(deckGiliran,counterDeck2+1);
		}else if(deckGiliran == 1){
			isBlackJack1 = false;
			addCard(deckGiliran,counterDeck1+1);
		}
	}
	//untuk melakukan stop
	public void stopCard(){
		if(deckGiliran == 3){
			if(isBlackJack3 == true){
				textStatusDeck3.text = "BLACKJACK";
			}
			if(counterDeck3 == 2){
				slm.card3Deck3.Add("");
				slm.card4Deck3.Add("");
				slm.card5Deck3.Add("");
			}else if(counterDeck3== 3){
				slm.card4Deck3.Add("");
				slm.card5Deck3.Add("");
			}else if(counterDeck3 == 4){
				slm.card5Deck3.Add("");
			}
			deck2Turn();
		}else if(deckGiliran == 2){
			if(isBlackJack2 == true){
				textStatusDeck2.text = "BLACKJACK";
			}
			if(counterDeck2 == 2){
				slm.card3Deck2.Add("");
				slm.card4Deck2.Add("");
				slm.card5Deck2.Add("");
			}else if(counterDeck2 == 3){
				slm.card4Deck2.Add("");
				slm.card5Deck2.Add("");
			}else if(counterDeck2 == 4){
				slm.card5Deck2.Add("");
			}
			deck1Turn();
		}else if(deckGiliran == 1){
			if(isBlackJack1 == true){
				textStatusDeck1.text = "BLACKJACK";
			}
			if(counterDeck1 == 2){
				slm.card3Deck1.Add("");
				slm.card4Deck1.Add("");
				slm.card5Deck1.Add("");
			}else if(counterDeck1== 3){
				slm.card4Deck1.Add("");
				slm.card5Deck1.Add("");
			}else if(counterDeck1 == 4){
				slm.card5Deck1.Add("");
			}
			try{
				phase3();
			}catch{}
		}
	}
	//untuk melakukan double
	public void doubleCard(){
		if(deckGiliran == 3){
			slm.chips = slm.chips - bet3;
			textTotalChips.text = "Total Chip: "+slm.chips;
			slm.card4Deck3.Add("");
			slm.card5Deck3.Add("");
			slm.saveData();
			textChipsChange.text = "-"+bet3;
			
			bet3 = bet3 * 2;
			textBet3.text = ""+bet3;
			isDoubleDeck3 = true;
			addBlankCard(deckGiliran,counterDeck3+1);
			deck2Turn();
		}else if(deckGiliran == 2){
			slm.chips = slm.chips - bet2;
			textTotalChips.text = "Total Chip: "+slm.chips;
			slm.card4Deck2.Add("");
			slm.card5Deck2.Add("");
			slm.saveData();
			textChipsChange.text = "-"+bet2;
			
			bet2 = bet2 * 2;
			textBet2.text = ""+bet2;
			isDoubleDeck2 = true;
			addBlankCard(deckGiliran,counterDeck2+1);
			deck1Turn();
		}else if(deckGiliran == 1){
			slm.chips = slm.chips - bet1;
			textTotalChips.text = "Total Chip: "+slm.chips;
			slm.card4Deck1.Add("");
			slm.card5Deck1.Add("");
			slm.saveData();
			textChipsChange.text = "-"+bet1;
			
			bet1 = bet1 * 2;
			textBet1.text = ""+bet1;
			isDoubleDeck1 = true;
			addBlankCard(deckGiliran,counterDeck1+1);
			Invoke("phase3",1f);
		}
	}
	//menambah kartu tampak belakang
	public void addBlankCard(int deck, int kartu){
		if(deck == 1){
			deck1[counterDeck1].SetActive(true);
		}else if(deck == 2){
			deck2[counterDeck2].SetActive(true);
		}else if(deck == 3){
			deck3[counterDeck3].SetActive(true);
		}else{
			deckDealer[counterDeckDealer].SetActive(true);
		}
		if(deck != 4)
			GameObject.Find("Card"+kartu+"Deck"+deck).GetComponent<Image>().sprite = GameObject.Find("BelakangKartu").GetComponent<Image>().sprite;
		else
			GameObject.Find("Card"+kartu+"Dealer").GetComponent<Image>().sprite = GameObject.Find("BelakangKartu").GetComponent<Image>().sprite;
	}
	public void deck3Turn(){
		if(bet3 != 0){
			buttonDouble.SetActive(true);
			deckGiliran = 3;
			pointer.SetActive(true);
			pointer.transform.localPosition = new Vector3(262,-49,0);
			unActiveTurnText();
			deck3TurnText.SetActive(true);
			if(scoreDeck3 == 21 || (scoreDeck3+10) == 21){
				isBlackJack3 = true;
			}
		}else{
			slm.card1Deck3.Add("");
			slm.card2Deck3.Add("");
			slm.card3Deck3.Add("");
			slm.card4Deck3.Add("");
			slm.card5Deck3.Add("");
			deck2Turn();
		}
	}
	public void deck2Turn(){
		backgroundSpot3.SetActive(true);
		if(bet2 != 0){
			buttonDouble.SetActive(true);
			deckGiliran = 2;
			pointer.SetActive(true);
			pointer.transform.localPosition = new Vector3(-4,-49,0);
			unActiveTurnText();
			deck2TurnText.SetActive(true);
			if(scoreDeck2 == 21 || (scoreDeck2+10) == 21){
				isBlackJack2 = true;
			}
		}else{
			slm.card1Deck2.Add("");
			slm.card2Deck2.Add("");
			slm.card3Deck2.Add("");
			slm.card4Deck2.Add("");
			slm.card5Deck2.Add("");
			deck1Turn();
		}
	}
	public void deck1Turn(){
		backgroundSpot2.SetActive(true);
		if(bet1 != 0){
			buttonDouble.SetActive(true);
			deckGiliran = 1;
			pointer.SetActive(true);
			pointer.transform.localPosition = new Vector3(-259,-49,0);
			unActiveTurnText();
			deck1TurnText.SetActive(true);
			if(scoreDeck1 == 21 || (scoreDeck1+10) == 21){
				isBlackJack1 = true;
			}
		}else{
			slm.card1Deck1.Add("");
			slm.card2Deck1.Add("");
			slm.card3Deck1.Add("");
			slm.card4Deck1.Add("");
			slm.card5Deck1.Add("");
			try{
				phase3();
			}catch{}
		}
	}
	//untuk menonaktifkan seluruh turn text
	public void unActiveTurnText(){
		deck1TurnText.SetActive(false);
		deck2TurnText.SetActive(false);
		deck3TurnText.SetActive(false);
	}
	//untuk phase 1
	public void phase1(){
		//reset nilai - nilai variabel
		counterDeck1 = 0;
		counterDeck2 = 0;
		counterDeck3 = 0;
		counterDeckDealer = 0;
		textTotalChips.text = "Total Chip: "+slm.chips;
		textNickName.text = ""+slm.nickname;
		textStatusDeck1.text = "";
		textStatusDeck2.text = "";
		textStatusDeck3.text = "";
		textStatusDeckDealer.text = "";
		textChipsChange.text = "";
		scoreDeck1 = 0;
		scoreDeck2 = 0;
		scoreDeck3 = 0;
		deckGiliran = 0;
		totalWinSpot3 = 0;
		totalWinSpot2 = 0;
		totalWinSpot1 = 0;
		backgroundSpot1.SetActive(false);
		backgroundSpot2.SetActive(false);
		backgroundSpot3.SetActive(false);
		backgroundSpotDealer.SetActive(false);
		isBlackJack1 = false;
		isBlackJack2 = false;
		isBlackJack3 = false;
		isBlackJackDealer = false;
		isDoubleDeck1 = false;
		isDoubleDeck2 = false;
		isDoubleDeck3 = false;
		flagAceDeck1 = false;
		flagAceDeck2 = false;
		flagAceDeck3 = false;
		flagAceDeckDealer = false;
		isStopDealer = false;
		unActiveTurnText();
		textBet1.text = "";
		textBet2.text = "";
		textBet3.text = "";
		scoreDeckDealer = 0;
		textCounter1.text = "";
		textCounter2.text = "";
		textCounter3.text = "";
		textResultDeck1.text = "";
		textResultDeck2.text = "";
		textResultDeck3.text = "";
		textResultDeckDealer.text = "";
		textCounterDealer.text = "";
		textNotif.text = "";
		hangDeck1 = false;
		phase1GameObject.SetActive(true);
		phase2GameObject.SetActive(false);
		inputField1.gameObject.SetActive(true);
		inputField2.gameObject.SetActive(true);
		inputField3.gameObject.SetActive(true);
		afterResult.SetActive(false);
		for(int i=0; i<=4; i++){
			cardTakenSuits[i] = false;
		}
		for(int i=0; i<=13; i++){
			cardTakenValue[i] = false;
		}
		for(int i=0; i<5; i++){
			deck1[i].SetActive(false);
			deck2[i].SetActive(false);
			deck3[i].SetActive(false);
			deckDealer[i].SetActive(false);
		}
		
	}
	//untuk phase 2
	public void phase2(){
		inputValid = true;
		textNotif.text = "";
		if(inputField1.text == "" || inputField2.text == "" || inputField3.text == ""){
			textNotif.text = "Please input all bet (0-500)";
		}else{
			try{
				bet1 = int.Parse(inputField1.text);
				bet2 = int.Parse(inputField2.text);
				bet3 = int.Parse(inputField3.text);
			}catch(System.FormatException e){
				textNotif.text = "Invalid input format";
				inputValid = false;
			}
			if(inputValid == true){
				if(bet1 < 0 || bet1 > 500 || bet2 < 0 || bet2 > 500 || bet3 < 0 || bet3 > 500){
					textNotif.text = "Bet must be in range 0 - 500";
				}else if(bet1 + bet2 + bet3 > slm.chips){
					textNotif.text = "Not enough chip to bet";
				}else if(bet1 == 0 && bet2 == 0 && bet3 == 0){
					textNotif.text = "Must have at least 1 available spot";
				}else{
					phase = 2;
					slm.chips = slm.chips - (bet1+bet2+bet3);
					textTotalChips.text = "Total Chip: "+slm.chips;
					slm.saveData();
					slm.startingChip.Add(""+(slm.chips + (bet1 + bet2 + bet3)));
					textChipsChange.text = "-"+(bet1+bet2+bet3);
					phase1GameObject.SetActive(false);
					inputField1.gameObject.SetActive(false);
					inputField2.gameObject.SetActive(false);
					inputField3.gameObject.SetActive(false);
					textBet1.text = ""+bet1;
					textBet2.text = ""+bet2;
					textBet3.text = ""+bet3;
					if(bet1 != 0){
						addCard(1,1);
						addCard(1,2);
					}
					if(bet2 != 0){
						addCard(2,1);
						addCard(2,2);
					}
					if(bet3 != 0){
						addCard(3,1);
						addCard(3,2);
					}
					addCard(4,1);
					addBlankCard(4,2);
					phase2GameObject.SetActive(true);
					deck3Turn();
				}
			}
		}
	}
	//untuk phase 3 / dealer turn
	public void phase3(){
		if(hangDeck1 == false){ //jika tidak ditambahkan ini, maka akan terjadi hang.
			hangDeck1 = true;
			if(isDoubleDeck3){
				addCard(3,counterDeck3+1);
			}
			if(isDoubleDeck2){
				addCard(2,counterDeck2+1);
			}
			if(isDoubleDeck1){
				addCard(1,counterDeck1+1);
			}
			//giliran dealer
			deckGiliran = 4;
			backgroundSpot1.SetActive(true);
			pointer.SetActive(false);
			phase = 3;
			unActiveTurnText();
			phase2GameObject.SetActive(false);
			addCard(4,counterDeckDealer+1); //membalik kartu yang ditutup
			
			//check apakah dealer mendapatkan blackjack
			if((scoreDeckDealer + 10) == 21 && flagAceDeckDealer == true){
				scoreDeckDealer = scoreDeckDealer + 10;
				isBlackJackDealer = true;
				textStatusDeckDealer.text = "BLACKJACK";
				slm.card3DeckDealer.Add("");
				slm.card4DeckDealer.Add("");
				slm.card5DeckDealer.Add("");
			}else{
				//simple dealer AI
				for(;;){
					if(isStopDealer == true){
						if(counterDeckDealer == 2){
							slm.card3DeckDealer.Add("");
							slm.card4DeckDealer.Add("");
							slm.card5DeckDealer.Add("");
						}else if(counterDeckDealer == 3){
							slm.card4DeckDealer.Add("");
							slm.card5DeckDealer.Add("");
						}else if(counterDeckDealer == 4){
							slm.card5DeckDealer.Add("");
						}
						break;
					}
					if(scoreDeckDealer <= 11){
						addCard(4,counterDeckDealer+1);
					}else if(scoreDeckDealer > 11 && scoreDeckDealer < 20){
						keputusanDealer = Random.Range(1,3);
						if(keputusanDealer == 1){
							addCard(4,counterDeckDealer+1);
						}else{
							isStopDealer = true;
						}
					}else{
						isStopDealer = true;
					}
				}
			}
			backgroundSpotDealer.SetActive(true);
			result();
		}
	}
	
	//untuk menghitung result
	public void result(){
		//deck 3
		counterDeck1 = 0;
		counterDeck2 = 0;
		counterDeck2 = 0;
		totalWinSpot1 = 0;
		totalWinSpot2 = 0;
		totalWinSpot3 = 0;
		if(flagAceDeck3 && (scoreDeck3 + 10 < 22)){
			scoreDeck3 = scoreDeck3 + 10;
		}
		if(bet3 != 0){
			if(scoreDeck3 > 21){ //busted
				textResultDeck3.GetComponent<Text>().color = colorLose;
				textResultDeck3.text = "LOSE\n-"+bet3;
				slm.status3.Add("BUSTED");
				slm.totalLoss++;
			}else{
				if(isBlackJack3){ // mendapat blackjack
					totalWinSpot3 = totalWinSpot3 + bet3;
					slm.totalBlackJack++;
				}
				if(counterDeck3 == 5){ //mendapat 5 dragons
					totalWinSpot3 = totalWinSpot3 + bet3;
				}
				if(scoreDeck3 > scoreDeckDealer){
					totalWinSpot3 = totalWinSpot3 + (bet3*2);
					textResultDeck3.GetComponent<Text>().color = colorWin;
					textResultDeck3.text = "WIN\n+"+totalWinSpot3;
					slm.status3.Add("WIN");
					slm.totalWin++;
				}else if(scoreDeck3 == scoreDeckDealer){
					totalWinSpot3 = totalWinSpot3 + bet3;
					textResultDeck3.GetComponent<Text>().color = colorWin;
					if(totalWinSpot3 == bet3){ //tidak mendapat blackjack ataupun 5 dragons
						if(isBlackJackDealer || counterDeckDealer == 5){
							totalWinSpot3 = totalWinSpot3 - bet3;
							textResultDeck3.text = "LOSE\n-"+bet3;
							slm.status3.Add("LOSE");
							slm.totalLoss++;
						}else{
							textResultDeck3.text = "DRAW";
							slm.status3.Add("DRAW");
						}
					}else{
						if(isBlackJack3 && !isBlackJackDealer){
							totalWinSpot3 = totalWinSpot3 + (bet3*2);
							textResultDeck3.text = "WIN\n+"+totalWinSpot3;
							slm.status3.Add("WIN");
							slm.totalWin++;
						}else if(isBlackJack3 && isBlackJackDealer){
							textResultDeck3.text = "DRAW";
							slm.status3.Add("DRAW");
						}else{
							//5 dragons
							if(counterDeck3 == 5 && counterDeckDealer != 5){
								totalWinSpot3 = totalWinSpot3 + (bet3 * 2);
								textResultDeck3.text = "WIN\n+"+totalWinSpot3;
								slm.status3.Add("WIN");
								slm.totalWin++;
							}else if(counterDeck3 == 5 && counterDeckDealer == 5){
								textResultDeck3.text = "DRAW";
								slm.status3.Add("DRAW");
							}else{
								textResultDeck3.text = "DRAW";
								slm.status3.Add("DRAW");
							}
						}
					}
				}else{
					if(scoreDeckDealer < 22){
						if(counterDeck3 != 5 || isBlackJackDealer){
							textResultDeck3.GetComponent<Text>().color = colorLose;
							textResultDeck3.text = "LOSE\n-"+bet3;
							slm.status3.Add("LOSE");
							slm.totalLoss++;
						}else{
							totalWinSpot3 = totalWinSpot3 + (bet3 * 2);
							textResultDeck3.GetComponent<Text>().color = colorWin;
							textResultDeck3.text = "WIN\n+"+totalWinSpot3;
							slm.status3.Add("WIN");
							slm.totalWin++;
						}
					}else{ //kalau dealernya busted
						textResultDeck3.GetComponent<Text>().color = colorWin;
						totalWinSpot3 = totalWinSpot3 + (bet3*2);
						textResultDeck3.text = "WIN\n+"+totalWinSpot3;
						slm.status3.Add("WIN");
						slm.totalWin++;
					}
				}
			}
		}else{
			slm.status3.Add("");
		}
		//deck 2
		
		if(flagAceDeck2 && (scoreDeck2 + 10 < 22)){
			scoreDeck2 = scoreDeck2 + 10;
		}
		if(bet2 != 0){
			if(scoreDeck2 > 21){ //busted
				textResultDeck2.GetComponent<Text>().color = colorLose;
				textResultDeck2.text = "LOSE\n-"+bet2;
				slm.status2.Add("BUSTED");
				slm.totalLoss++;
			}else{
				if(isBlackJack2){ // mendapat blackjack
					totalWinSpot2 = totalWinSpot2 + bet2;
					slm.totalBlackJack++;
				}
				if(counterDeck3 == 5){ //mendapat 5 dragons
					totalWinSpot2 = totalWinSpot2 + bet2;
				}
				if(scoreDeck2 > scoreDeckDealer){
					totalWinSpot2 = totalWinSpot2 + (bet2*2);
					textResultDeck2.GetComponent<Text>().color = colorWin;
					textResultDeck2.text = "WIN\n+"+totalWinSpot2;
					slm.status2.Add("WIN");
					slm.totalWin++;
				}else if(scoreDeck2 == scoreDeckDealer){
					totalWinSpot2 = totalWinSpot2 + bet2;
					textResultDeck2.GetComponent<Text>().color = colorWin;
					if(totalWinSpot2 == bet2){ //tidak mendapat blackjack ataupun 5 dragons
						if(isBlackJackDealer || counterDeckDealer == 5){
							totalWinSpot2 = totalWinSpot2 - bet2;
							textResultDeck2.text = "LOSE\n-"+bet2;
							slm.status2.Add("LOSE");
							slm.totalLoss++;
						}else{
							textResultDeck2.text = "DRAW";
							slm.status2.Add("DRAW");
						}
					}else{
						if(isBlackJack2 && !isBlackJackDealer){
							totalWinSpot2 = totalWinSpot2 + (bet2 * 2);
							textResultDeck2.text = "WIN\n+"+totalWinSpot2;
							slm.status2.Add("WIN");
							slm.totalWin++;
						}else if(isBlackJack2 && isBlackJackDealer){
							textResultDeck2.text = "DRAW\n"+totalWinSpot2;
							slm.status2.Add("DRAW");
						}else{
							//5 dragons
							if(counterDeck2 == 5 && counterDeckDealer != 5){
								totalWinSpot2 = totalWinSpot2 + (bet2 * 2);
								textResultDeck2.text = "WIN\n+"+totalWinSpot2;
								slm.status2.Add("WIN");
								slm.totalWin++;
							}else if(counterDeck2 == 5 && counterDeckDealer == 5){
								textResultDeck2.text = "DRAW\n"+totalWinSpot2;
								slm.status2.Add("DRAW");
							}else{
								textResultDeck2.text = "DRAW";
								slm.status2.Add("DRAW");
							}
						}
					}
				}else{
					if(scoreDeckDealer < 22){
						if(counterDeck2 != 5 || isBlackJackDealer){
							textResultDeck2.GetComponent<Text>().color = colorLose;
							textResultDeck2.text = "LOSE\n-"+bet2;
							slm.status2.Add("LOSE");
							slm.totalLoss++;
						}else{
							totalWinSpot2 = totalWinSpot2 + (bet2 * 2);
							textResultDeck2.GetComponent<Text>().color = colorWin;
							textResultDeck2.text = "WIN\n+"+totalWinSpot2;
							slm.status2.Add("WIN");
							slm.totalWin++;
						}
					}else{ //kalau dealernya busted
						textResultDeck2.GetComponent<Text>().color = colorWin;
						totalWinSpot2 = totalWinSpot2 + (bet2 * 2);
						textResultDeck2.text = "WIN\n+"+totalWinSpot2;
						slm.status2.Add("WIN");
						slm.totalWin++;
					}
				}
			}
		}else{
			slm.status2.Add("");
		}
		//deck 1
		
		
		if(flagAceDeck1 && (scoreDeck1 + 10 < 22)){
			scoreDeck1 = scoreDeck1 + 10;
		}
		if(bet1!=0){
			if(scoreDeck1 > 21){ //busted
				textResultDeck1.GetComponent<Text>().color = colorLose;
				textResultDeck1.text = "LOSE\n-"+bet1;
				slm.status1.Add("BUSTED");
				slm.totalLoss++;
			}else{
				if(isBlackJack1){ // mendapat blackjack
					totalWinSpot1 = totalWinSpot1 + bet1;
					slm.totalBlackJack++;
				}
				if(counterDeck1 == 5){ //mendapat 5 dragons
					totalWinSpot1 = totalWinSpot1 + bet1;
				}
				if(scoreDeck1 > scoreDeckDealer){
					totalWinSpot1 = totalWinSpot1 + (bet1*2);
					textResultDeck1.GetComponent<Text>().color = colorWin;
					textResultDeck1.text = "WIN\n+"+totalWinSpot1;
					slm.status1.Add("WIN");
					slm.totalWin++;
				}else if(scoreDeck1 == scoreDeckDealer){
					totalWinSpot1 = totalWinSpot1 + bet1;
					textResultDeck1.GetComponent<Text>().color = colorWin;
					if(totalWinSpot1 == bet1){ //tidak mendapat blackjack ataupun 5 dragons
						if(isBlackJackDealer || counterDeckDealer == 5){
							totalWinSpot1 = totalWinSpot1 - bet1;
							textResultDeck1.text = "LOSE\n-"+bet1;
							slm.status1.Add("LOSE");
							slm.totalLoss++;
						}else{
							textResultDeck1.text = "DRAW";
							slm.status1.Add("DRAW");
						}
					}else{
						if(isBlackJack1 && !isBlackJackDealer){
							totalWinSpot1 = totalWinSpot1 + bet1;
							textResultDeck1.text = "WIN\n+"+totalWinSpot1;
							slm.status1.Add("WIN");
							slm.totalWin++;
						}else if(isBlackJack1 && isBlackJackDealer){
							slm.status1.Add("DRAW");
							textResultDeck1.text = "DRAW";
						}else{
							//5 dragons
							if(counterDeck1 == 5 && counterDeckDealer != 5){
								totalWinSpot1 = totalWinSpot1 + bet1;
								textResultDeck1.text = "WIN\n+"+totalWinSpot1;
								slm.status1.Add("WIN");
								slm.totalWin++;
							}else if(counterDeck1 == 5 && counterDeckDealer == 5){
								textResultDeck1.text = "DRAW\n";
								slm.status1.Add("DRAW");
							}else{
								textResultDeck1.text = "DRAW";
								slm.status1.Add("DRAW");
							}
						}
					}
				}else{
					if(scoreDeckDealer < 22){
						if(counterDeck1 != 5 || isBlackJackDealer){
							textResultDeck1.GetComponent<Text>().color = colorLose;
							textResultDeck1.text = "LOSE\n-"+bet1;
							slm.status1.Add("LOSE");
							slm.totalLoss++;
						}else{
							totalWinSpot1 = totalWinSpot1 + (bet1 * 2);
							textResultDeck1.GetComponent<Text>().color = colorWin;
							textResultDeck1.text = "WIN\n+"+totalWinSpot1;
							slm.status1.Add("WIN");
							slm.totalWin++;
						}
					}else{ //kalau dealernya busted
						textResultDeck1.GetComponent<Text>().color = colorWin;
						totalWinSpot1 = totalWinSpot1 + (bet1 * 2);
						textResultDeck1.text = "WIN\n+"+totalWinSpot1;
						slm.status1.Add("WIN");
						slm.totalWin++;
					}
				}
			}
		}else{
			slm.status1.Add("");
		}
		//set text pada UI
		textChipsChange.text = "+"+(totalWinSpot1 + totalWinSpot2 + totalWinSpot3);
		slm.chips = slm.chips + (totalWinSpot1 + totalWinSpot2 + totalWinSpot3);
		textTotalChips.text = "Total Chip: "+slm.chips;
		
		//menyimpan data
		slm.numberOfGame++;
		slm.idGame.Add(""+slm.numberOfGame);
		slm.cardValue1.Add(""+scoreDeck1);
		slm.cardValue2.Add(""+scoreDeck2);
		slm.cardValue3.Add(""+scoreDeck3);
		slm.cardValueDealer.Add(""+scoreDeckDealer);
		slm.betValue1.Add(""+bet1);
		slm.betValue2.Add(""+bet2);
		slm.betValue3.Add(""+bet3);
		slm.endChip.Add(""+slm.chips);
		if(slm.chips < int.Parse(slm.startingChip[slm.numberOfGame-1])){ //jika terjadi pengurangan
			slm.changeTotal.Add(""+(slm.chips - int.Parse(slm.startingChip[slm.numberOfGame-1])));
		}else{ //jika terjadi penambahan
			slm.changeTotal.Add("+"+(slm.chips - int.Parse(slm.startingChip[slm.numberOfGame-1])));
		}
		slm.saveData();
		afterResult.SetActive(true);
	}
	public void sameBet(){
		phase1();
		phase2();
	}
	public void newBet(){
		phase1();
		inputField1.text = "";
		inputField2.text = "";
		inputField3.text = "";
	}
	//ketika tombol back to main menu diklik
	public void exitToMainMenu(){
		confirmExit.SetActive(true);
		if(phase == 2){
			textLostBet.SetActive(true);
		}else{
			textLostBet.SetActive(false);
		}
	}
	
	//konfirmasi untuk kembali ke main menu
	public void yesExitToMainMenu(){
		slm.saveData();
		Application.LoadLevel("mainMenu");
	}
	public void noExitToMainMenu(){
		confirmExit.SetActive(false);
	}
}
