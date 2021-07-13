using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

/// <summary> modulen ersätter Varuautomatkontrollanten
/// kontrollera att man kan mata in pengar (InsertMoney) i Varuautomaten
/// och att de summeras korrekt
/// </summary>
namespace Varuautomat.Betalningsmedel_xUnit_provning {
    /// <summary> Testa att Varuautomaten rätt summerar pengarna
    /// </summary>
    public class Summering_Kontanter
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
