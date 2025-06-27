using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SzigoHelperConsole;

namespace UnitTest
{
    [TestClass]
    public class EgyszeruProgTetelekUT
    {
        //ELNEVEZÉSEK DIREKT NEM LETTEK NORMÁLISAK (NEM EGY MUNKAHELYI PROJECT, AHOL MINDENNEK JÓNAK KELL LENNIE

        /* PL: Eldöntés tételnél
         * * a pLogikaiTulajdonság olyan, mintha azt mondanám, hogy keressük meg az első páros elemet, ami while-ban így nézne ki:
         * * while (i < bemenetiTomb.Length && !bemenetiTomb[i] % 2 == 0)
         * 
         * jelen esetben ezt lambdával adjuk meg, tehát, meghívásnál: EgyszeruProgTetelek.EldontesTetel(array, x => x % 2 == 0);
         * ahol az x egy integer lesz
         * ha bővebben érteni akarod, akkor nézz utána egy hivatalos doksiban --> vagy ChatGPT    
         */

        [TestMethod]
        public void SorozatSzamitasTetel_1()
        {
            // Arrange
            const int expectedValue = 28;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.SorozatSzamitasTetel(array);

            // Assert
            result.Should().Be(expectedValue);
        }

        [TestMethod]
        public void EldontesTetel_1()
        {
            // Arrange
            const bool expectedValue = true;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.EldontesTetel(array, x => x % 2 == 0);

            // Assert
            result.Should().Be(expectedValue);
        }

        [TestMethod]
        public void EldontesTetel_2()
        {
            // Arrange
            const bool expectedValue = false;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.EldontesTetel(array, x => x % 10 == 0);

            // Assert
            result.Should().Be(expectedValue);
        }

        [TestMethod]
        public void KivalasztasTetel_1()
        {
            // Arrange
            const int expectedValue = 1;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.KivalasztasTetel(array, x => x % 2 == 0);

            // Assert
            result.Should().Be(expectedValue);
        }

        [TestMethod]
        public void LinearisKeresesTetel_1()
        {
            // Arrange
            const int expectedValue = 1;
            const bool expectedLogicalValue = true;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.LinearisKeresesTetel(array, x => x % 2 == 0);

            // Assert
            result.Should().Be((expectedLogicalValue, expectedValue));
        }

        [TestMethod]
        public void LinearisKeresesTetel_2()
        {
            // Arrange
            int? expectedValue = null;
            const bool expectedLogicalValue = false;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.LinearisKeresesTetel(array, x => x % 10 == 0);

            // Assert
            result.Should().Be((expectedLogicalValue, expectedValue));
        }

        [TestMethod]
        public void MegszamlalasTetel_1()
        {
            // Arrange
            int expectedValue = 3;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.MegszamlalasTetel(array, x => x % 2 == 0);

            // Assert
            result.Should().Be(expectedValue);
        }

        [TestMethod]
        public void MegszamlalasTetel_2()
        {
            // Arrange
            int expectedValue = 0;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.MegszamlalasTetel(array, x => x % 10 == 0);

            // Assert
            result.Should().Be(expectedValue);
        }

        [TestMethod]
        public void MaximumKivalasztas_1()
        {
            // Arrange
            int expectedValue = 6;
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            var result = EgyszeruProgTetelek.MaximumKivalasztas(array);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}
