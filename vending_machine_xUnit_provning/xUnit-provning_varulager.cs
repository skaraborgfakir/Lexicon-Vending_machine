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
	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Japp" )]
	[InlineData( "Te" )]
	public void VadFinnsILager1( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    string[] allaProdukter = varulager.AllaProdukter();
	    // Assert
	    Assert.Contains( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Ångbåt" )]
	public void VadFinnsILagerAvProduktTypen( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    string[] allaProdukter = varulager.AllaProdukter(Produkttyper.lego);
	    // Assert
	    Assert.Contains( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Starship Executor" )]
	[InlineData( "Dajm" )]
	[InlineData( "Lönnsirap" )]
	public void VadFinnsInteILager( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    string[] allaProdukter = varulager.AllaProdukter();
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Ångbåt" )]
	public void VadFinnsInteILagerAvProduktTypen( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    string[] allaProdukter = varulager.AllaProdukter(Produkttyper.dricka);
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}

    }
}
