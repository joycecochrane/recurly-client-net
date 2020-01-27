using System;
using FluentAssertions;
// using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Recurly.Test
{
  public class PurchaseTest : BaseTest
  {
    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void InvoicePurchase()
    {
      var account = CreateNewAccountWithBillingInfo();
      var currency = "USD";
      var plan = new Plan(GetMockPlanCode(), GetMockPlanName()) { Description = "Plan for Purchase Test" };
      plan.UnitAmountInCents.Add("USD", 580);
      plan.Create();

      var purchase = new Purchase(account.AccountCode, currency);

      purchase.Account.BillingInfo = account.BillingInfo;

      var sub = new Subscription(plan.PlanCode);
      purchase.Subscriptions.Add(sub);

      try
      {
        var collection = Purchase.Invoice(purchase);
        Assert.NotNull(collection.ChargeInvoice);
        Assert.Equal(collection.ChargeInvoice.Transactions[0].Account.AccountCode, account.AccountCode);
        Assert.Equal(collection.ChargeInvoice.Address.Company, "Acme Software");
      }
      catch (ValidationException exception) {
        System.Console.WriteLine("Exception: " + exception);
      }
    }

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void CancelPurchase()
    {
      var collection = CreateNewCollection();
      
      try
      {
        var transactionUuid = collection.ChargeInvoice.Transactions[0].Uuid;
        var cancelledCollection = Purchase.Cancel(transactionUuid);
        cancelledCollection.ChargeInvoice.State.Should().Be(Invoice.InvoiceState.Failed);
      }
      catch (ValidationException exception)
      {
        System.Console.WriteLine("Exception: " + exception);
      }
    }

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void CapturePurchase()
    {
      var collection = CreateNewCollection();
      
      try
      {
        var transactionUuid = collection.ChargeInvoice.Transactions[0].Uuid;
        var capturedCollection = Purchase.Capture(transactionUuid);
        capturedCollection.ChargeInvoice.State.Should().Be(Invoice.InvoiceState.Paid);
      }
      catch (ValidationException exception)
      {
        System.Console.WriteLine("Exception: " + exception);
      }
    }
  }
}