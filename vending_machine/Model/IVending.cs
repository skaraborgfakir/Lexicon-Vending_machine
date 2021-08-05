using System;
using System.Collections.Generic;

namespace Varuautomat.Modell {
    interface IVending {
	string[] ShowAll();                      // alla produkter
	void InsertMoney(string namn);           // mata in sedel eller mynt
	Produkt Purchase(string namn);           // returnerar en kort instruktion, exv "Skål"
	Dictionary<string,int> EndTransaction(); // vilka sedlar och mynt och hur många som man får i växel
    }
}
