using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

namespace Varuautomat.xUnit_provning {
    public class VaruautomatVarulagerprovning
    {
	[Theory]
	[InlineData( "Te" )]
	[InlineData( "Kaffe" )]
	[InlineData( "Coca Cola" )]
	public void VadFinnsILager( string produktnamn) {
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
	public void VadFinnsInteILager( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.ShowAll();
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}
    }

    /// <summary> Testa att Varuautomaten rätt summerar pengarna
    /// </summary>
    public class VaruautomatKundsaldo
    {
	[Theory]
	[ClassData(typeof(BlandadeValörerData))]
	public void BlandadeValörer(int förväntat_belopp, string[] blandadeValörer) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    foreach ( string valör in blandadeValörer)
		varuautomat.InsertMoney( valör);
	    //Assert
	    Assert.Equal( förväntat_belopp, varuautomat.KundSaldo);
	}
	public class BlandadeValörerData : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { 280, new string[] { "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
		yield return new object[] { 480, new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }
}
