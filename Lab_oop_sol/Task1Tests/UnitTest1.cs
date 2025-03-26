using Task1;

namespace Task1Tests
{
    [TestClass]
    public class UnitTest1
    {
        //корректность вывода строк
        [TestMethod]
        public void to_string1()
        {
            var a = 19;
            var b = 6;
            var result = "19/6";
            Assert.IsTrue(new Rational(a, b).ToString() == result);
        }

        [TestMethod]
        public void to_string2()
        {
            var a = -19;
            var b = 6;
            var result = "-19/6";
            Assert.IsTrue(new Rational(a, b).ToString() == result);
        }

        [TestMethod]
        public void to_string3()
        {
            var a = 19;
            var b = -6;
            var result = "-19/6";
            Assert.IsTrue(new Rational(a, b).ToString() == result);
        }

        //конструируем
        [TestMethod]
        public void construct()
        {
            var a = 19;
            var b = 6;
            var result = new Rational(a, b);
            Assert.IsTrue(result.ToString() == "19/6");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void construct2()
        {
            var a = 19;
            var b = 0;
            var result = new Rational(a, b);
        }

        [TestMethod]
        public void sum()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue((rat1 + rat2).ToString() == "29/21");
        }

        [TestMethod]
        public void razn()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue((rat1 - rat2).ToString() == "1/21");
        }

        [TestMethod]
        public void proizv()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue((rat1 * rat2).ToString() == "10/21");
        }

        [TestMethod] //обычное деление
        public void del1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue((rat1 / rat2).ToString() == "15/14");
        }

        [TestMethod]//деление на 0
        [ExpectedException(typeof(ArgumentException))]
        public void del2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(0, 3);
            var res = rat1 / rat2;
        }

        [TestMethod]
        public void equal1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue(!(rat1.ToString() == rat2.ToString()));
        }

        [TestMethod]
        public void equal2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 7);
            Assert.IsTrue(rat1.ToString() == rat2.ToString());
        }

        [TestMethod]
        public void not_equal1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue(rat1.ToString() != rat2.ToString());
        }

        [TestMethod]
        public void not_equal2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 7);
            Assert.IsTrue(!(rat1.ToString() != rat2.ToString()));
        }

        [TestMethod]
        public void bol_eq1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue(rat1 >= rat2);
        }

        [TestMethod]
        public void bol_eq2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 3);
            Assert.IsTrue(!(rat1 >= rat2));
        }

        [TestMethod]
        public void bol_eq3()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 7);
            Assert.IsTrue(rat1 >= rat2);
        }

        [TestMethod]
        public void men_eq1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue(!(rat1 <= rat2));
        }

        [TestMethod]
        public void men_eq2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 3);
            Assert.IsTrue(rat1 <= rat2);
        }

        [TestMethod]
        public void men_eq3()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 7);
            Assert.IsTrue(rat1 <= rat2);
        }

        [TestMethod]
        public void bol1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue(rat1 > rat2);
        }

        [TestMethod]
        public void bol2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 3);
            Assert.IsTrue(!(rat1 > rat2));
        }

        [TestMethod]
        public void men1()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(2, 3);
            Assert.IsTrue(rat1 > rat2);
        }

        [TestMethod]
        public void men2()
        {
            var rat1 = new Rational(5, 7);
            var rat2 = new Rational(5, 3);
            Assert.IsTrue(!(rat1 > rat2));
        }

    }
}