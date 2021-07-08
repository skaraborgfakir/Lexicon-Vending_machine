using System;
with  Varuautomat.Produkter;

namespace Varuautomat {
    class Varuautomat : IVending {
	int kundSaldo = 0;
	Produkt[] varulager;

	Varuautomat() {
	}
	public ShowAll() {
	}

	/// <summary>
	/// mata in sedlar eller mynt i fasta valörer
	/// </summary>
	public void InsertMoney() {
	    // kreditera kundsaldo
	}

	public void Purchase() {
	    // debitera kundsaldo
	}

	public void EndTransaction() {
	    // debitera kundsaldo
	}
    }
}
