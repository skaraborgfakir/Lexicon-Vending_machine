namespace Varuautomat.Modell {
    class Lego : Leksak {
	// public string Namn() { get { return base.pris;}}

	public Lego( string namn, int önskatPris):base( namn, önskatPris) {
	}
	public new string Examine() {
	    return "Mamma kan jag få en lite sak ?";
	}
	public new string Use() {
	    return "Gå och lek. Lek Gott";
	}
	public new string Åldersrekommendation() {
	    return "lämpar sig för barn mellan 1-99 år. Lek Gott";
	}
    }
}
