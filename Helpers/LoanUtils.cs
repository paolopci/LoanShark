using MortgageCalculator.Models;

namespace MortgageCalculator.Helpers
{
    public static class LoanUtils
    {
        /// <summary>
        /// Calculates a payment for a simple interest loan
        /// </summary>
        /// <param name="amount">Loan Amount</param>
        /// <param name="rate">Annualized Rate as a double</param>
        /// <param name="term">Term in Years</param>
        /// <returns>A monthly payment as a double</returns>
        public static double CalcPayment(double amount, double rate, double term)
        {
            var monthlyRate = CalculateMonthlyRate(rate);
            var months = term * 12;
            var payment = (amount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -months));
            return payment;
        }

        public static Loan GetPayments(Loan loan)
        {
            loan.Payments.Clear();
            // Calculate the monthly payment
            loan.Payment = CalcPayment(loan.PurchaseAmount, loan.Rate, loan.Term);

            // variables to hold the total interest and balance
            double balance = loan.PurchaseAmount;
            double totalInterest = 0;
            double monthlyPrincipal = 0;
            double monthlyInterest = 0;
            double monthlyRate = CalculateMonthlyRate(loan.Rate);
            int loanMonths = loan.Term * 12;


            for (int month = 1; month <= loanMonths; month++)
            {
                monthlyInterest = CalculateMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;

                LoanPayment loanPayment = new LoanPayment();

                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.MonthlyPrincipal = monthlyPrincipal;
                loanPayment.MonthlyInterest = monthlyInterest;
                loanPayment.TotalInterest = totalInterest;
                loanPayment.Balance = balance < 0 ? 0 : balance;

                // Add the payment to the list
                loan.Payments.Add(loanPayment);
            }
            loan.TotalInterest=totalInterest;
            loan.TotalCost = loan.PurchaseAmount + totalInterest;

            return loan;
        }

        private static double CalculateMonthlyRate(double rate)
        {
            return rate / 1200;
        }

        private static double CalculateMonthlyInterest(double balance, double monthlyRate)
        {
            return balance * monthlyRate;
        }
    }
}
