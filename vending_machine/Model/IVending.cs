using System;

namespace Varuautomat.Modell {
    interface IVending {
	void ShowAll();
	void InsertMoney(string valör);
	void Purchase();
	void EndTransaction();
    }
}
