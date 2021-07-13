using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Dryck : Produkt, IAvseddAttÄtas {
	// public override int Pris {
	//     get { return base.pris; }
	//     set { base.pris = value; }
	// }

	public Dryck( string namn, int önskatPris) {
	    base.Namn = namn;
	    base.Pris = önskatPris;
	}

	// public string Namn() { get { return base.pris;}}
	// }

	public string NäringsInformation() {
	    return "svalkande, innehåll H2O";
	}
    }
}
