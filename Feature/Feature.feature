Feature: SearchProduct
	Bu test N11 sitesi ürün arama senaryosu içerir.


Scenario: N11 Ürün Arama

	* "#searchData" arama alanına tıklanır.
	* "#searchData" arama alanına "Telefon" yazılır.
	* "2" saniye süreyle beklenir.
	* ".searchBtn" arama butonuna tıklanır.
	* "2" saniye süreyle beklenir.
	* ".logo" ana sayfaya geri gider.
	
