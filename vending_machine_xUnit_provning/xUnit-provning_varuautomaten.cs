using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

/// <summary> modulen ersätter Varuautomatkontrollanten
/// kontrollera att några saker finns i varulager
/// samma produkter som i xUnit-provning_varulager.cs
/// </summary>
namespace Varuautomat.xUnit_provning {
    ///
    ///
    public class VaruautomatVarulagerprovning
    {
	[Theory]
	[InlineData( "Superdestroyer Executor" )]
	[InlineData( "Starship Executor" )]
	[InlineData( "Dajm" )]
	[InlineData( "Lönnsirap" )]
	public void VadFinnsInteILager(string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.ShowAll();
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}

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
    }

    /// <summary> Testa vilka valörer/valutor som Varuautomaten accepterar (eller inte)
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
	public void BlandadeValörer(string[] blandadeValörer, int förväntad_summa) {
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
		yield return new object[] { new string[] { "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"},           280};
		yield return new object[] { new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}, 480};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }

    /// <summary> Testa att saldo i varuautomaten är rätt efter att köpet var helt avbrutet och efter några genomförda
    /// men utan att någon kvarvarande växel ska återlämnas (ingen EndTransaction)
    /// </summary>
    public class VaruautomatTransaktioner {
	/// <summary> Testa att Varuautomaten vid genomfört köp uppdaterar totalförsäljning
	/// De olika testfunktionerna hämtar sina indata från samma behållare
	/// </summary>
	[Theory]
	[ClassData(typeof(EttKöp))]
	public void BlandadKompott1(string[] blandadeValörer, string[] saker, int förväntatSaldo, int förväntadFörsäljning) {
	    _ = förväntatSaldo;

	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    foreach ( string valör in blandadeValörer) varuautomat.InsertMoney( valör);

	    // Act
	    foreach (string sak in saker) { Produkt produkt = varuautomat.Purchase(sak); }

	    //Assert
	    Assert.Equal( förväntadFörsäljning, varuautomat.TotalFörsäljning);
	}

	/// <summary> Testa att Varuautomaten vid genomfört köp uppdaterar kundsaldot
	/// De olika testfunktionerna hämtar sina indata från samma behållare
	/// </summary>
	[Theory]
	[ClassData(typeof(EttKöp))]
	public void BlandadKompott2(string[] blandadeValörer, string[] saker, int förväntatSaldo, int förväntadFörsäljning) {
	    _ = förväntadFörsäljning;

	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    foreach ( string valör in blandadeValörer) varuautomat.InsertMoney( valör);

	    // Act
	    foreach (string sak in saker) { Produkt produkt = varuautomat.Purchase(sak); }

	    //Assert
	    Assert.Equal( förväntatSaldo, varuautomat.KundSaldo);
	}

	/// <summary> Testa att Varuautomaten efter genomförda köp har rätt kvarstående kundsaldo
	/// och att försäljningssumman stämmer
	/// </summary>
	public class EttKöp : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid", "Astrid"}, new string[]{ "Ångbåt"},        0, 500};
		yield return new object[] { new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"},           new string[]{ "Polisstation"}, 80, 400};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }

    /// <summary> Testa att varuautomaten lämnar tillbaka rätt växel efter avbrutet köp eller inte
    /// </summary>
    public class VaruautomatHelaTransaktioner {
	/// <summary> Testa att Varuautomaten vid genomfört köp uppdaterar totalförsäljning
	/// De olika testfunktionerna hämtar sina indata från samma behållare
	/// </summary>
	[Theory]
	[ClassData(typeof(EttKöp))]
	public void GenomförtKöp(string[] blandadeValörer, string[] saker, int förväntatSaldo, int förväntadFörsäljning, int förväntadVäxelSumma) {
	    _ = förväntatSaldo;
	    _ = förväntadFörsäljning;

	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    foreach (string valör in blandadeValörer) varuautomat.InsertMoney( valör);
	    Console.WriteLine( "efter inmatning av pengar " + varuautomat.KundSaldo);
	    foreach (string sak in saker) { Produkt produkt = varuautomat.Purchase(sak); }
	    Console.WriteLine( "efter köp " + varuautomat.KundSaldo);

	    // Act
	    Dictionary <string, int> växel = varuautomat.EndTransaction();

	    Dictionary <string, int>.KeyCollection växelPeng = växel.Keys;
	    int växelSumma = 0;
	    foreach (string pengnamn in växelPeng) {
		Console.WriteLine( "Växelpengens namn: " + pengnamn + " antal som växel: "+ växel[pengnamn] + " delsumma: " +  växel[pengnamn] * accepteradeBetalningsmedel.Värde(pengnamn) );
		växelSumma = växelSumma + växel[pengnamn] * accepteradeBetalningsmedel.Värde(pengnamn);
	    }

	    //Assert
	    Assert.Equal( 0, varuautomat.KundSaldo);
	    Assert.Equal( växelSumma, förväntadVäxelSumma);
	}

	public class EttKöp : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { new string[] { "Astrid", "Astrid"},                                                   new string[]{ "Coca Cola", "Te" }, 40,  20,  20};
		yield return new object[] { new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid", "Astrid"}, new string[]{ },                    0,   0, 500};
		yield return new object[] { new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid", "Astrid"}, new string[]{ "Ångbåt"},            0, 500,   0};
		yield return new object[] { new string[] { "Ingmar", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"},           new string[]{ "Polisstation"},     80, 400,  80};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }
}
