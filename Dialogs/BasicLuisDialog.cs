using System;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : 
        base(new LuisService(new LuisModelAttribute(ConfigurationManager.AppSettings["LuisAppId"], 
                             ConfigurationManager.AppSettings["LuisAPIKey"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Please specify the query :).");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hello")]
        public async Task HelloIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Hello <b>Dominik</b>. Nice to hear you again. What do you want to do?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AccountBalance")]
        public async Task AccountBalanceIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Which account do you mean?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AllAcountsBalance")]
        public async Task AllAcountsBalanceIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Current account is 104000 EUR.");
            sb.AppendLine("Salary account is 453000 EUR.");
            sb.AppendLine("Total balance is 557000 EUR.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Payments")]
        public async Task PaymentsIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("150000 EUR for UPS its an Invoice 45/2017 and 3400 EUR for T mobile its a Telephone bill september 2017");
            sb.AppendLine("Do you want to accept these payments?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("AcceptAll")]
        public async Task AcceptAllIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("All transaction has been accepted.");
            sb.AppendLine("I want to remind you that your card expires next month. Do you want to renew it or would you like a new Visa Business Gold with 50000 EUR limit.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Visa")]
        public async Task VisaIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ok, by the way, please note that tomorrow you need to pay taxes. Do you want do it now?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Goodbye")]
        public async Task GoodbyeIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Goodbye Dominik.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }
    }
}