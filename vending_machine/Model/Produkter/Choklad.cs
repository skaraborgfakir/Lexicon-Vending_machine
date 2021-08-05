using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Choklad : Produkt, IAvseddAttÄtas {
	public Choklad( string namn, int önskatPris) {
	    Namn = namn;
	    Pris = önskatPris;
	}
	public string NäringsInformation() {
	    return "Innehåller kakaosmör";
	}
	public override string Examine() {
	    return "sött, kan ha en skarp bitter chokladsmak " + "pris " + pris;
	}
	public override string Use() {
	    return "Den är stärkande och glädjande. Ät upp den och bli gladare !";
	}
    }
}
