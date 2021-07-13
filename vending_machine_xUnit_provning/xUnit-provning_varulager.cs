using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

/// <summary> modulen ersätter Varuautomatkontrollanten
/// kontrollera att några saker finns i varulager
/// </summary>
namespace Varuautomat.xUnit_provning {
    public class Varulagerprov {
	// [Fact]
	// public void VadFinnsILager1() {
	//     // Arrange
	//     Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	//     // Act
	//     string[] allaProdukter = varuautomat.ShowAll();
	//     foreach (string prod in allaProdukter)
	//	Console.WriteLine( "produkt: " + prod);
	//     // Assert
	//     // Assert.Contains( produktnamn, allaProdukter);
	// }

	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Japp" )]
	[InlineData( "Te" )]
	public void VadFinnsILager1( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.ShowAll();
	    // Assert
	    Assert.Contains( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Starship Executor" )]
	[InlineData( "Dajm" )]
	[InlineData( "Lönnsirap" )]
	public void VadFinnsInteILager1( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.ShowAll();
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}

	// [Theory]
	// [InlineData( Produkttyper.dricka )]
	// public void VadFinnsILager3( Produkttyper produkttyp) {
	//     // Arrange
	//     Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	//     // Act
	//     string[] allaProdukter = varuautomat.AllaProdukter(produkttyp);
	//     foreach (string prod in allaProdukter)
	//	Console.WriteLine( "produkt (dricka): " + prod);
	//     // Assert
	//     // Assert.Contains( produktnamn, allaProdukter);
	// }

	[Theory]
	[InlineData( "Te" )]
	[InlineData( "Kaffe" )]
	[InlineData( "Coca Cola" )]
	public void VadFinnsILager2( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.AllaProdukter(Produkttyper.dricka);
	    // foreach (string prod in allaProdukter)
	    //	Console.WriteLine( "produkt (dricka): " + prod);
	    // Assert
	    Assert.Contains( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Te" )]
	[InlineData( "Kaffe" )]
	[InlineData( "Coca Cola" )]
	public void VadFinnsInteILager2( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.AllaProdukter(Produkttyper.lego);
	    // foreach (string prod in allaProdukter)
	    //	Console.WriteLine( "produkt (lego): " + prod);
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}
    }
}
