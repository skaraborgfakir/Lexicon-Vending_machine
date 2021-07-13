using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Mellanmål : Produkt, IAvseddAttÄtas {
	// public override int Pris {
	//     get { return base.pris; }
	//     set { base.pris = value; }
	// }

	public Mellanmål( string namn, int önskatPris) {
	    base.Namn = namn;
	    base.Pris = önskatPris;
	}

	public string NäringsInformation() {
	    return "närande";
	}
    }
}
