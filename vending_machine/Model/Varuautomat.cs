//
// Modell för Varuautomat
//
// affärslogik
//

using System;
using Varuautomat.Modell.Produkter;
using Varuautomat.Modell.Varulager;

namespace Varuautomat.Modell {
    public class Varuautomat : IVending {
	private int kundSaldo = 0;

	public int KundSaldo { get { return kundSaldo; }}

	public Varuautomat() {
	}

	public void ShowAll() {
	    throw new NotImplementedException();
	}

	/// <summary>
	/// mata in sedlar eller mynt i fasta valörer, och kreditera kundsaldo
	/// </summary>
	public void InsertMoney(string valör) {
	    if ( accepterasMyntet( valör)) {
	    }
	    else if ( accepterasSedeln( valör)) {
	    } else {
		throw new FelaktigValör();
	    }
	}

	public void Purchase() {
	    // debitera kundsaldo
	    throw new NotImplementedException();
	}

	public void EndTransaction() {
	    // debitera kundsaldo
	    throw new NotImplementedException();
	}
    }
}
