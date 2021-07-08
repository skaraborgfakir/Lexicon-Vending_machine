using System;

namespace Varuautomat {
    interface IVending {
	public void ShowAll();
	public void InsertMoney();
	public void Purchase();
	public void EndTransaction();
    }
}
