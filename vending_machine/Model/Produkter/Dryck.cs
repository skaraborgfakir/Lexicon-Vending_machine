using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Dryck : Produkt, IAvseddAttÄtas {
	public Dryck( string namn, int önskatPris) {
	    Namn = namn;
	    Pris = önskatPris;
	}
	public string NäringsInformation() {
	    return  "innehåll: H2O. Socker. Citronsyra. Smaksättare.";
	}
	public override string Examine() {
	    return "svalkande, innehåll H2O. Ska drickas";
	}
	public override string Use() {
	    return "Svalkande dryck. Skål";
	}
    }
}
