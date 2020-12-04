using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoDeDivisores.Test
{
	[TestClass]
	public class GeracaoDeDivisoresUtilTest
	{
		[TestMethod]
		public void AoProcessarADecomposicaoDoMaiorValorInteiroPermitidoTodosOsDivisoresDevemSerGeradosCorretamente()
		{
			//Arrange
			//Act
			int[] resultadoProcessado = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numero: 1998000000, apenasDivisoresPrimos: false).ToArray();

			string textoResultadoProcessado = String.Join(",", resultadoProcessado);

			//Assert
			string resultadoEsperado = @"1,2,3,4,5,6,8,9,10,12,15,16,18,20,24,25,27,30,32,36,37,40,45,48,50,54,
			60,64,72,74,75,80,90,96,100,108,111,120,125,128,135,144,148,150,160,180,185,192,200,216,222,225,240,
			250,270,288,296,300,320,333,360,370,375,384,400,432,444,450,480,500,540,555,576,592,600,625,640,666,
			675,720,740,750,800,864,888,900,925,960,999,1000,1080,1110,1125,1152,1184,1200,1250,1332,1350,1440,
			1480,1500,1600,1665,1728,1776,1800,1850,1875,1920,1998,2000,2160,2220,2250,2368,2400,2500,2664,2700,
			2775,2880,2960,3000,3125,3200,3330,3375,3456,3552,3600,3700,3750,3996,4000,4320,4440,4500,4625,4736,
			4800,4995,5000,5328,5400,5550,5625,5760,5920,6000,6250,6660,6750,7104,7200,7400,7500,7992,8000,8325,
			8640,8880,9000,9250,9375,9600,9990,10000,10656,10800,11100,11250,11840,12000,12500,13320,13500,13875,
			14208,14400,14800,15000,15625,15984,16000,16650,16875,17280,17760,18000,18500,18750,19980,20000,21312,
			21600,22200,22500,23125,23680,24000,24975,25000,26640,27000,27750,28125,28800,29600,30000,31250,31968,
			33300,33750,35520,36000,37000,37500,39960,40000,41625,42624,43200,44400,45000,46250,46875,48000,49950,
			50000,53280,54000,55500,56250,59200,60000,62500,63936,66600,67500,69375,71040,72000,74000,75000,79920,
			80000,83250,84375,86400,88800,90000,92500,93750,99900,100000,106560,108000,111000,112500,115625,118400,
			120000,124875,125000,127872,133200,135000,138750,140625,144000,148000,150000,159840,166500,168750,177600,
			180000,185000,187500,199800,200000,208125,213120,216000,222000,225000,231250,240000,249750,250000,266400,
]			270000,277500,281250,296000,300000,319680,333000,337500,346875,355200,360000,370000,375000,399600,400000,
			416250,421875,432000,444000,450000,462500,499500,500000,532800,540000,555000,562500,578125,592000,600000,
			624375,639360,666000,675000,693750,720000,740000,750000,799200,832500,843750,888000,900000,925000,999000,
			1000000,1040625,1065600,1080000,1110000,1125000,1156250,1200000,1248750,1332000,1350000,1387500,1480000,
			1500000,1598400,1665000,1687500,1734375,1776000,1800000,1850000,1998000,2000000,2081250,2160000,2220000,
			2250000,2312500,2497500,2664000,2700000,2775000,2960000,3000000,3121875,3196800,3330000,3375000,3468750,
			3600000,3700000,3996000,4162500,4440000,4500000,4625000,4995000,5203125,5328000,5400000,5550000,6000000,
			6243750,6660000,6750000,6937500,7400000,7992000,8325000,8880000,9000000,9250000,9990000,10406250,10800000,
			11100000,12487500,13320000,13500000,13875000,14800000,15609375,15984000,16650000,18000000,18500000,19980000,
			20812500,22200000,24975000,26640000,27000000,27750000,31218750,33300000,37000000,39960000,41625000,44400000,
			49950000,54000000,55500000,62437500,66600000,74000000,79920000,83250000,99900000,111000000,124875000,133200000,
			166500000,199800000,222000000,249750000,333000000,399600000,499500000,666000000,999000000,1998000000";

			Assert.AreEqual(textoResultadoProcessado, Util.ObterTextoTratado(resultadoEsperado));
		}

		[TestMethod]
		public void AoProcessarADecomposicaoDoMaiorValorInteiroPermitidoTodosOsDivisoresPrimosDevemSerGeradosCorretamente()
		{
			//Arrange
			//Act
			int[] resultadoProcessado = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numero: (1998000000), apenasDivisoresPrimos: true).ToArray();

			string textoResultadoProcessado = String.Join(",", resultadoProcessado);

			//Assert
			string resultadoEsperado = @"2,3,5,37";

			Assert.AreEqual(textoResultadoProcessado, resultadoEsperado);
		}

		[TestMethod]
		public void AoProcessarADecomposicaoDeUmNumeroNaturalAQuantidadeTotalDeDivisoresDeveCorresponderAFormula()
		{
			//Arrange
			//Act
			int[] resultadoProcessado = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numero: 53640, apenasDivisoresPrimos: false).ToArray();

			int quantidadeDeDivisoresProcessada = resultadoProcessado.Length;

			//Assert
			/*
				53640 | 2
				26820 | 2
				13410 | 2
				 6705 | 3
				 2235 | 3
				  745 | 5
				  149 | 149
				    1 |

				Fórmula: 
					1-Obter expoentes dos fatores primos: 
						1.1) 2^3; 3^2; 5^1; 149^1
						1.2) 3; 2; 1; 1

					2-Somar uma unidade a cada expoente:
						2.1) 4; 3; 2; 2

					3-Multiplicar os valores obtidos:
						3.1) 4 x 3 x 2 x 2 = 48 
			*/

			int totalDeDivisoresEsperado = 48;

			Assert.AreEqual(quantidadeDeDivisoresProcessada, totalDeDivisoresEsperado);
		}

		[TestMethod]
		public void AoProcessarADecomposicaoDeUmNumeroPrimoApenasOsDoisDivisoresCorrespondentesDevemSerObtidos()
		{
			//Arrange
			//Act
			int[] resultadoProcessado = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numero: 2147483647, apenasDivisoresPrimos: false).ToArray();

			string textoResultadoProcessado = String.Join(",", resultadoProcessado);

			//Assert
			string resultadoEsperado = @"1,2147483647";

			Assert.AreEqual(textoResultadoProcessado, resultadoEsperado);
		}
	}
}
