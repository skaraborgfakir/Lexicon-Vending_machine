using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Mellanmål : Produkt, IAvseddAttÄtas {
	public Mellanmål( string namn, int önskatPris) {
	    Namn = namn;
	    Pris = önskatPris;
	}
	public string NäringsInformation() {
	    return "Innehåller fibrer och kolhydrater";
	}
	public override string Examine() {
	    return "Innehåller fibrer och kolhydrater";
	}
	public override string Use() {
	    return "Den är närande och stärkande. Ät upp den !";
	}
    }
}
