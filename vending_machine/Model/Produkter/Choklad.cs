using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Choklad : Produkt, IAvseddAttÄtas {
	// public override int Pris {
	//     get { return base.pris; }
	//     set { base.pris = value; }
	// }

	public Choklad( string namn, int önskatPris) {
	    base.Namn = namn;
	    base.Pris = önskatPris;
	}

	// public string Namn() { get { return base.pris;}}
	// }

	public string NäringsInformation() {
	    return "sött, kan ha en skarp bitter chokladsmak";
	}
    }
}
