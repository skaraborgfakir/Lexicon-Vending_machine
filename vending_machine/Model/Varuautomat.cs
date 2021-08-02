//
// Modell för Varuautomat
//
// affärslogik
//

using System;

namespace Varuautomat.Modell {
    public class Varuautomat : IVending {
	private int kundSaldo = 0;
	private AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	private Varulager varulager = new Varulager();

	public int KundSaldo { get { return kundSaldo; }}

	public Varuautomat() {
	}

	public string[] ShowAll() {
	    return varulager.AllaProdukter();
	}

	// public string[] AllaProdukter(Produkttyper produkttyp) {
	//     return varulager.AllaProdukter(produkttyp);
	// }

	/// <summary>
	/// mata in sedlar eller mynt i fasta valörer, och kreditera kundsaldo
	/// </summary>
	public void InsertMoney(string namn) {
	    try {
		if ( accepteradeBetalningsmedel.accepterasMyntet( namn)) {
		    kundSaldo = kundSaldo + accepteradeBetalningsmedel.Värde(namn);
		}
		else if ( accepteradeBetalningsmedel.accepterasSedeln( namn)) {
		    kundSaldo = kundSaldo + accepteradeBetalningsmedel.Värde(namn);
		} else {
		    throw new ArgumentException( "ej accepterad valör");  // ej accepterad - spotta ut
		}
	    }
	    catch (ArgumentException)  // fel - accepterasSedeln eller accepterasMyntet ljög
	    {
		throw new ArgumentException( "ej accepterad valör");
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
