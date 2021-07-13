using System;

namespace Varuautomat.Modell {
    interface IVending {
	string[] ShowAll();
	void InsertMoney(string valör);
	void Purchase();
	void EndTransaction();
    }
}
