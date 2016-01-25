// unit test code
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass] //attribute required for any class that contains unit test methods to run in Test Explorer.
    public class BankAccountTests
    {

        // CASE 1: Does the debit method subtract correctly?
        [TestMethod] //required for methods to run in Test Explorer
        public void Debit_WithValidAmount_UpdatesBalance() //can't have parameters and must return void
        {
            double beginningBalance = 10.00;
            double debitAmount = 4.00;
            double expected = 6.00;
            BankAccount account = new BankAccount("Brendon Blanchurd", beginningBalance);
            
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }





        // CASE 2: Shouldn't be able to debit a negative number.
        // Expect some general ArgumentOutOfRange exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))] //use the ExpectedExceptionAttribute attribute to assert that right exception has been thrown
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 10.00;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Ivon Swed", beginningBalance);
            
            account.Debit(debitAmount);

            // assert is handled by ExpectedException
        }





        // CASE 2: Shouldn't be able to debit more than you have in your account.
        // Expect a specific ArgumentOutOfRange Exception message (more specific than last one) from Debit() method
        [TestMethod]
        // don't need to say [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 10.00;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Allar Bogleaeava", beginningBalance);
            
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");

            // assert is handled by ExpectedException
        }

    }
}