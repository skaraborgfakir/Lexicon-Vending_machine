using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

namespace Varuautomat.xUnit_provning {
    public class VaruautomatVarulagerprovning
    {
	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Japp" )]
	[InlineData( "Ångbåt" )]
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
	[InlineData( "Superdestroyer Executor" )]
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

    /// <summary> Testa att Varuautomaten accepterar eller ej accepterar valörer/valutor
    /// </summary>
    public class VaruautomatKontrolleraBetalningsmedel {
	/// <summary> Testa att Varuautomaten inte accepterar icke-accepterade valörer/valutor
	/// rabiat AAA
	/// </summary>
	[Theory]
	[InlineData( "KungHaakon" )]
	[InlineData( "danskKrona" )]
	[InlineData( "1Zdollar" )]
	[InlineData( "KopieradIngmar " )]
	public void BlandadeFelValörerAAA(string valör) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    Action act = () => varuautomat.InsertMoney( valör);
	    //Assert
	    ArgumentException e = Assert.Throws<ArgumentException>(act);
	}

	/// <summary> Testa att Varuautomaten inte accepterar icke-accepterade valörer/valutor
	/// följer inte bokstavligt AAA
	/// </summary>
	[Theory]
	[InlineData( "KungHaakon" )]
	[InlineData( "danskKrona" )]
	[InlineData( "1Zdollar" )]
	[InlineData( "KopieradIngmar " )]
	public void BlandadeFelValörerInteAAA(string valör) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act & Assert
	    Assert.Throws<ArgumentException>(() => varuautomat.InsertMoney( valör));
	}

	/// <summary> Testa att Varuautomaten accepterar räät valörer/valutor
	/// och att deras valörer är rätt
	/// </summary>
	[Theory]
	[InlineData( 200, "Ingmar")]
	[InlineData( 20,  "Astrid")]
	[InlineData( 1,   "kungen")]
	[InlineData( 5,   "5-krona")]
	public void ValörEnstakaMyntSedlar( int  valör, string namn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    varuautomat.InsertMoney( namn);
	    //Assert
	    Assert.Equal( valör, varuautomat.KundSaldo);
	}
    }

    /// <summary> Mata in flera mynt och sedlar efter varandra och
    /// testa att Varuautomaten rätt summerar pengarna
    /// </summary>
    public class VaruautomatKundsaldo
    {
	[Theory]
	[ClassData(typeof(BlandadeValörerData))]
	public void BlandadeValörer(int förväntad_summa, string[] blandadeValörer) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    foreach ( string valör in blandadeValörer)
		varuautomat.InsertMoney( valör);
	    //Assert
	    Assert.Equal( förväntad_summa, varuautomat.KundSaldo);
	}
	public class BlandadeValörerData : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { 280, new string[] { "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
		yield return new object[] { 480, new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }

    /// <summary> Testa att Varuautomaten rätt summerar pengarna
    /// och returnerar rätt summa efter transaktionsslut
    /// </summary>
    // public class VaruautomatTransaktionsslut {
    //	/// <summary> Testa att Varuautomaten vid avbrytet köp returnerar växel på rätt sätt
    //	/// </summary>
    //	[Theory]
    //	[ClassData(typeof(BlandadeValörerData))]
    //	public void BlandadeValörerAvbrytetKöp(int förväntat_belopp, string[] blandadeValörer) {
    //	    // Arrange
    //	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
    //	    // Act
    //	    foreach ( string valör in blandadeValörer)
    //		varuautomat.InsertMoney( valör);
    //	    varuautomat.EndTransaction();
    //	    //Assert
    //	    Assert.Throws<NotImplementedException>(() => varuautomat.EndTransaction());
    //	    //  Assert.Equal( förväntat_belopp, varuautomat.KundSaldo);
    //	}
    //	public class BlandadeValörerData : IEnumerable<object[]> {
    //	    public IEnumerator<object[]> GetEnumerator() {
    //		yield return new object[] { 0, new string[] { "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
    //		yield return new object[] { 0, new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
    //	    }
    //	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    //	}
    // }
}
